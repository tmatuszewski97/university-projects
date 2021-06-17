using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KnnWindowsForms.WczytywanieDanych;
using static KnnWindowsForms.OkreslLiczbeAtrybutow;
using static KnnWindowsForms.Testy;
using static KnnWindowsForms.OkreslMaxK;
using static KnnWindowsForms.KnnKlasyfikator;
using static KnnWindowsForms.Normalizacja;
using static KnnWindowsForms.JedenKontraReszta;
using static KnnWindowsForms.OknoZParametrem;

namespace KnnWindowsForms
{
    /* Zdefiniowanie nowego typu danych */
    public delegate double Metryka(Probka probka1, Probka probka2, double parametr);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Probka> listaProbek = new List<Probka>();
        private int maksLiczbaAtrybutow;

        private void PrzyciskPlik_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var plik = new FileInfo(ofd.FileName);

            if (plik.Extension != ".txt")
            {
                MessageBox.Show("Plik z danymi musi mieć rozszerzenie: .txt");
                return;
            }

            listaProbek = WczytajDane(ofd.FileName);
            maksLiczbaAtrybutow = LiczbaAtrybutow(listaProbek);
            LiczbaMaksAtrybutow.Text = "Liczba atrybutów w próbkach: " + maksLiczbaAtrybutow;

            /* Pokazujemy ukryte elementy po tym jak odpowiedni plik został załączony*/
            LiczbaMaksAtrybutow.Visible = true;
            NapisAtrybuty.Visible = true;
            PoleAtrybuty.Visible = true;
            NapisListaAtrybutow.Visible = true;
            SpisAtrybutow.Visible = true;
            SpisAtrybutow.Enabled = false;

        }

        private List<double> listaAtrybutowProbkiTestowej = new List<double>();
        private Probka probkaTestowa = new Probka(new double[] { });

        private void PoleAtrybuty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var tmp = PoleAtrybuty.Text;
                tmp = CzyPrzecinek() ? tmp.Replace(".", ",") : tmp.Replace(",", ".");
                if (CzyDouble(tmp))
                {
                    BladAtrybuty.Visible = false;
                    SpisAtrybutow.Text += tmp + "\r\n";
                    listaAtrybutowProbkiTestowej.Add(Convert.ToDouble(tmp));
                }

                else if (!CzyDouble(tmp))
                {
                    PoleAtrybuty.Text = "";
                    /* Wyświetlamy błąd */
                    BladAtrybuty.Visible = true;
                }

                PoleAtrybuty.Text = "";

                if (listaAtrybutowProbkiTestowej.Count == maksLiczbaAtrybutow)
                {
                    PoleAtrybuty.Enabled = false;
                    /* Ukrywamy niepotrzebne elementy */
                    NapisAtrybuty.Visible = false;
                    PoleAtrybuty.Visible = false;
                    BladAtrybuty.Visible = false;
                    /* Wyświetlamy potrzebne pola */
                    NapisK.Text = "Podaj k (ilu sąsiadów brać pod uwagę) i zatwierdź enterem. Gdzie k: 0 < k < " + (MaxK(listaProbek) + 1);
                    NapisK.Visible = true;
                    PoleK.Visible = true;
                    PoleK.Focus();
                    probkaTestowa.atrybuty = listaAtrybutowProbkiTestowej.ToArray();
                }
                e.SuppressKeyPress = true;
            }
        }

        private int k;
        private void PoleK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var tmp = PoleK.Text;

                if (CzyInt(tmp))
                {
                    int liczba = int.Parse(tmp);
                    if (liczba > 0 && liczba <= MaxK(listaProbek))
                    {
                        k = liczba;
                        /* Ukrywamy niepotrzebne elementy */
                        BladK.Visible = false;
                        NapisK.Visible = false;
                        PoleK.Visible = false;

                        /* Wyświetlamy potrzebne pola */
                        PoleWyboruMetryki.Items.Add(new KeyValuePair<string, Metryka>("Euklidesowa", Metryki.Euklidesowa));
                        PoleWyboruMetryki.Items.Add(new KeyValuePair<string, Metryka>("Manhatan", Metryki.Manhatan));
                        PoleWyboruMetryki.Items.Add(new KeyValuePair<string, Metryka>("Czebyszewa", Metryki.Czebyszewa));
                        PoleWyboruMetryki.Items.Add(new KeyValuePair<string, Metryka>("Minkowskiego", Metryki.Minkowskiego));
                        PoleWyboruMetryki.Items.Add(new KeyValuePair<string, Metryka>("Z logarytmem", Metryki.ZLogarytmem));

                        PoleWyboruMetryki.Visible = true;
                        NapisMetryka.Visible = true;
                        PrzyciskKlasyfikuj.Visible = true;
                        CheckBoxNormalizacja.Visible = true;
                        PrzyciskDokladnosciKlasyfikacji.Visible = true;
                        PoleDokladnoscKlasyfikacji.Visible = true;
                        /* Określamy, czy pole podlega edycji */
                        PoleDokladnoscKlasyfikacji.ReadOnly = true;
                        /* Ustawiamy focus na pole */
                        PoleWyboruMetryki.Focus();

                        /* Ustawienie wartości początkowej (domyślnej) pola */
                        PoleWyboruMetryki.SelectedIndex = 0;
                    }

                    else
                    {
                        PoleK.Text = "";
                        /* Wyświetlamy błąd */
                        BladK.Visible = true;
                    }
                }

                else
                {
                    PoleK.Text = "";
                    /* Wyświetlamy błąd */
                    BladK.Visible = true;
                }
                e.SuppressKeyPress = true;
            }
        }

        private void Klasyfikuj_Click(object sender, EventArgs e)
        {
            /* Pobieramy metrykę z ComboBoxa */
            Metryka metryka;
            var wybrany = PoleWyboruMetryki.SelectedItem as KeyValuePair<string, Metryka>?;

            double parametr = 0;
            if (wybrany.Value.Key == "Minkowskiego")
            {
                parametr = WyswietlOkno("Wprowadź poniżej parametr potrzebny do metryki Minkowskiego (p > 0)", "Okno wprowadzania parametru");
            }

            var metoda = wybrany.Value.Value;
            metryka = metoda;

            probkaTestowa.klasa = zwrocKlase(listaProbek, probkaTestowa, k, metryka, parametr);
            /* Wyświetlamy potrzebne pole */
            PoleWynik.Visible = true;
            NapisWynik.Visible = true;
            /* Określamy, czy pole podlega edycji */
            PoleWynik.ReadOnly = true;
            PoleWynik.Text = probkaTestowa.ToString().Replace("\n", "\r\n");
        }

        private void PrzyciskResetuj_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void CheckBoxNormalizacja_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxNormalizacja.Checked)
            {
                Normalizuj(probkaTestowa, listaProbek);
                CheckBoxNormalizacja.Enabled = false;
                PrzyciskKlasyfikuj.Focus();
            }
        }

        private void PrzyciskDokladnosciKlasyfikacji_Click(object sender, EventArgs e)
        {
            /* Pobieramy metrykę z ComboBoxa */
            Metryka metryka;
            var wybrany = PoleWyboruMetryki.SelectedItem as KeyValuePair<string, Metryka>?;
            double parametr = 0;
            if (wybrany.Value.Key == "Minkowskiego")
            {
                parametr = WyswietlOkno("Wprowadź poniżej parametr potrzebny do metryki Minkowskiego (p > 0)", "Okno wprowadzania parametru");
            }
            var metoda = wybrany.Value.Value;
            metryka = metoda;

            double dokladnoscKlasyfikacji = DokladnoscKlasyfikacji(listaProbek, k, metryka, parametr);
            double procentowaDokladnoscKlasyfikacji = dokladnoscKlasyfikacji * 100;
            PoleDokladnoscKlasyfikacji.Text = procentowaDokladnoscKlasyfikacji + "%";
        }
    }
}
