using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static SiecNeuronowa.Konwersje;

namespace SiecNeuronowa
{
    public partial class FormObliczenia : Form
    {
        private Siec mojaSiec;
        public FormObliczenia(Siec siec)
        {
            InitializeComponent();
            mojaSiec = siec;
            PoleDane.Text = mojaSiec.WypiszWszystko();
            PoleWeWy.Text = mojaSiec.WypiszWeWy();
        }

        private void WczytajWagi_Click(object sender, EventArgs e)
        {
            if (WyborPlikuWczytaj.ShowDialog() != DialogResult.OK)
                return;
            var plik = new FileInfo(WyborPlikuWczytaj.FileName);
            if (plik.Extension != ".txt")
            {
                MessageBox.Show("Plik z danymi musi mieć rozszerzenie .txt !");
                return;
            }

            mojaSiec.WczytajWagi(WyborPlikuWczytaj.FileName);
            PoleDane.Text = mojaSiec.WypiszWszystko();
            PoleWeWy.Text = mojaSiec.WypiszWeWy();
        }

        private void ZapiszWagi_Click(object sender, EventArgs e)
        {
            WyborPlikuZapisz.Filter = "Text File|*.txt";
            if (WyborPlikuZapisz.ShowDialog() != DialogResult.OK)
                return;
            string sciezka = WyborPlikuZapisz.FileName;
            mojaSiec.ZapiszWagi(sciezka);
        }

        private bool[] UczSiecEnabled = new bool[] {false, false, false, false, false};

        private void CzyWlaczycPrzycisk(Button przycisk, bool[] aktualna, bool[] oczekiwana)
        {
            /* Metoda ponizej sprawdza czy obie tablice posiadaja takie same wartosci w srodku */
            if (aktualna.SequenceEqual(oczekiwana))
                przycisk.Enabled = true;
            else
                przycisk.Enabled = false;
        }

        private void PoleBeta_TextChanged(object sender, EventArgs e)
        {
            if (PoleBeta.Text != "")
                UczSiecEnabled[0] = true;
            else
                UczSiecEnabled[0] = false;
            CzyWlaczycPrzycisk(PrzyciskUczSiec, UczSiecEnabled, new bool[] {true, true, true, true, true });
        }

        private void PoleKrokUczenia_TextChanged(object sender, EventArgs e)
        {
            if (PoleKrokUczenia.Text != "")
                UczSiecEnabled[1] = true;
            else
                UczSiecEnabled[1] = false;
            CzyWlaczycPrzycisk(PrzyciskUczSiec, UczSiecEnabled, new bool[] { true, true, true, true, true });
        }

        private void PoleLiczbaEpok_TextChanged(object sender, EventArgs e)
        {
            if (PoleLiczbaEpok.Text != "")
                UczSiecEnabled[2] = true;
            else
                UczSiecEnabled[2] = false;
            CzyWlaczycPrzycisk(PrzyciskUczSiec, UczSiecEnabled, new bool[] { true, true, true, true, true });
        }

        private void WczytajProbki_Click(object sender, EventArgs e)
        {
            if (WyborProbekWczytaj.ShowDialog() != DialogResult.OK)
                return;
            var plik = new FileInfo(WyborProbekWczytaj.FileName);
            if (plik.Extension != ".txt")
            {
                MessageBox.Show("Plik z danymi musi mieć rozszerzenie .txt !");
                UczSiecEnabled[3] = false;
                CzyWlaczycPrzycisk(PrzyciskUczSiec, UczSiecEnabled, new bool[] { true, true, true, true, true });
                return;
            }

            UczSiecEnabled[3] = true;
            CzyWlaczycPrzycisk(PrzyciskUczSiec, UczSiecEnabled, new bool[] {true, true, true, true, true });
        }

        private void PoleMaxBlad_TextChanged(object sender, EventArgs e)
        {
            if (PoleMaxBlad.Text != "")
                UczSiecEnabled[4] = true;
            else
                UczSiecEnabled[4] = false;
            CzyWlaczycPrzycisk(PrzyciskUczSiec, UczSiecEnabled, new bool[] { true, true, true, true, true });
        }

        private void PrzyciskUczSiec_Click(object sender, EventArgs e)
        {
            int liczbaEpok = StringNaInt(PoleLiczbaEpok.Text);
            double krokUczenia = StringNaDouble(PoleKrokUczenia.Text);
            double beta = StringNaDouble(PoleBeta.Text);
            string sciezkaProbekUczacych = WyborProbekWczytaj.FileName;
            double maxBlad = StringNaDouble(PoleMaxBlad.Text);

            mojaSiec.UczPrzezEpoki(liczbaEpok, krokUczenia, beta, sciezkaProbekUczacych, maxBlad);
            PoleDane.Text = mojaSiec.WypiszWszystko();
            PoleWeWy.Text = mojaSiec.WypiszWeWy();
        }

        private bool[] WyliczWynikEnabled = new bool[] {false, false};

        private void PoleWejscia_TextChanged(object sender, EventArgs e)
        {
            if (PoleWejscia.Text.Length > 2)
                WyliczWynikEnabled[0] = true;
            else
                WyliczWynikEnabled[0] = false;
            CzyWlaczycPrzycisk(PrzyciskWyliczWynik, WyliczWynikEnabled, new bool[] { true, true });
        }

        private void PoleBeta2_TextChanged(object sender, EventArgs e)
        {
            if (PoleBeta2.Text != "")
                WyliczWynikEnabled[1] = true;
            else
                WyliczWynikEnabled[1] = false;
            CzyWlaczycPrzycisk(PrzyciskWyliczWynik, WyliczWynikEnabled, new bool[] { true, true });
        }

        private void PrzyciskWyliczWynik_Click(object sender, EventArgs e)
        {
            List<int> wejscia = StringNaListeInt(PoleWejscia.Text);
            mojaSiec.NadpiszWejscia(wejscia);
            double beta = StringNaDouble(PoleBeta2.Text);
            mojaSiec.WyliczWartosci(beta);
            PoleDane.Text = mojaSiec.WypiszWszystko();
            PoleWeWy.Text = mojaSiec.WypiszWeWy();
        }

    }
}
