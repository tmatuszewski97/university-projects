using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AlgorytmGenetyczny.Konwersje;
using static AlgorytmGenetyczny.Sprawdzenia;

namespace AlgorytmGenetyczny
{
    public partial class FormZadanie1 : Form
    {
        private int nrZadania = 1;
        

        public FormZadanie1()
        {
            InitializeComponent();
        }

        private void PrzyciskEkranPowitalny_Click(object sender, EventArgs e)
        {
            Hide();
            EkranPowitalny form = new EkranPowitalny();
            form.ShowDialog();
        }

        private bool[] czyDostepnyPrzycisk = new bool[] {true, true, true, true, true, true, true};

        private void PoleParametry_TextChanged(object sender, EventArgs e)
        {
            if (PoleParametry.Text != "" && CzyInt(PoleParametry.Text))
                czyDostepnyPrzycisk[0] = true;
            else
                czyDostepnyPrzycisk[0] = false;
            CzyWlaczycPrzycisk(PrzyciskWywolajAlgorytm, czyDostepnyPrzycisk, new bool[] { true, true, true, true, true, true, true });
        }

        private void PoleMinZmiennosc_TextChanged(object sender, EventArgs e)
        {
            if (PoleMinZmiennosc.Text != "" && CzyDouble(PoleMinZmiennosc.Text))
                czyDostepnyPrzycisk[1] = true;
            else
                czyDostepnyPrzycisk[1] = false;
            CzyWlaczycPrzycisk(PrzyciskWywolajAlgorytm, czyDostepnyPrzycisk, new bool[] { true, true, true, true, true, true, true });
        }

        private void PoleMaxZmiennosc_TextChanged(object sender, EventArgs e)
        {
            if (PoleMaxZmiennosc.Text != "" && CzyDouble(PoleMaxZmiennosc.Text))
                czyDostepnyPrzycisk[2] = true;
            else
                czyDostepnyPrzycisk[2] = false;
            CzyWlaczycPrzycisk(PrzyciskWywolajAlgorytm, czyDostepnyPrzycisk, new bool[] { true, true, true, true, true, true, true });
        }

        private void PoleChromNaPar_TextChanged(object sender, EventArgs e)
        {
            if (PoleChromNaPar.Text != "" && CzyInt(PoleChromNaPar.Text))
                czyDostepnyPrzycisk[3] = true;
            else
                czyDostepnyPrzycisk[3] = false;
            CzyWlaczycPrzycisk(PrzyciskWywolajAlgorytm, czyDostepnyPrzycisk, new bool[] { true, true, true, true, true, true, true });
        }

        private void PoleIleOsobnikow_TextChanged(object sender, EventArgs e)
        {
            /* Sprawdzamy czy pole spełnia wymogi zadania */
            if (PoleIleOsobnikow.Text != "" && CzyInt(PoleIleOsobnikow.Text) && StringNaInt(PoleIleOsobnikow.Text)>=9 && StringNaInt(PoleIleOsobnikow.Text)%2==1 && StringNaInt(PoleIleOsobnikow.Text)/5 >= StringNaInt(PoleRozmiarTurnieju.Text))
                czyDostepnyPrzycisk[4] = true;
            else
                czyDostepnyPrzycisk[4] = false;
            CzyWlaczycPrzycisk(PrzyciskWywolajAlgorytm, czyDostepnyPrzycisk, new bool[] { true, true, true, true, true, true, true });
        }

        private void PoleRozmiarTurnieju_TextChanged(object sender, EventArgs e)
        {
            if (PoleRozmiarTurnieju.Text != "" && CzyInt(PoleRozmiarTurnieju.Text) && StringNaInt(PoleRozmiarTurnieju.Text) >= 1 && StringNaInt(PoleRozmiarTurnieju.Text)<=StringNaInt(PoleIleOsobnikow.Text)/5)
                czyDostepnyPrzycisk[5] = true;
            else
                czyDostepnyPrzycisk[5] = false;
            CzyWlaczycPrzycisk(PrzyciskWywolajAlgorytm, czyDostepnyPrzycisk, new bool[] { true, true, true, true, true, true, true });
        }

        private void PoleIleIteracji_TextChanged(object sender, EventArgs e)
        {
            if (PoleIleIteracji.Text != "" && CzyInt(PoleIleIteracji.Text) && StringNaInt(PoleIleIteracji.Text) >= 20)
                czyDostepnyPrzycisk[6] = true;
            else
                czyDostepnyPrzycisk[6] = false;
            CzyWlaczycPrzycisk(PrzyciskWywolajAlgorytm, czyDostepnyPrzycisk, new bool[] { true, true, true, true, true, true, true });
        }

        private void PrzyciskWywolajAlgorytm_Click(object sender, EventArgs e)
        {
            int ileParametrow = StringNaInt(PoleParametry.Text);
            double minZmiennosc = StringNaDouble(PoleMinZmiennosc.Text);
            double maxZmiennosc = StringNaDouble(PoleMaxZmiennosc.Text);
            int ileChromNaParametr = StringNaInt(PoleChromNaPar.Text);
            int ileOsobnikow = StringNaInt(PoleIleOsobnikow.Text);
            int rozmiarTurnieju = StringNaInt(PoleRozmiarTurnieju.Text);
            int ileIteracji = StringNaInt(PoleIleIteracji.Text);
            PoleWynikowe.Text = "";
            PoleListaOsobnikow.Text = "";
            PoleWynikowe.Text = "Wartości osobników po ostatniej iteracji:\r\n\r\n";
            PoleListaOsobnikow.Text = "Wyniki algorytmu w kolejnych iteracjach:\r\n\r\n";
            AlgorytmGenetyczny algorytm = new AlgorytmGenetyczny(ileParametrow, ileChromNaParametr, ileIteracji, ileOsobnikow, rozmiarTurnieju, minZmiennosc, maxZmiennosc, nrZadania, true, PoleWynikowe);
            PoleListaOsobnikow.Text += algorytm.WypiszOsobnikow();
        }
    }
}
