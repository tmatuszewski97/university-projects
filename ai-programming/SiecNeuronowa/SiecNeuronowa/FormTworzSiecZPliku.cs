using System;
using System.IO;
using System.Windows.Forms;

namespace SiecNeuronowa
{
    public partial class FormTworzSiecZPliku : Form
    {
        public FormTworzSiecZPliku()
        {
            InitializeComponent();
        }

        private void CofnijDoEkranPowitalny_Click(object sender, EventArgs e)
        {
            Hide();
            EkranPowitalny form = new EkranPowitalny();
            form.ShowDialog();
        }

        private Siec siecXor;
        private void PrzyciskSzukajPliku_Click(object sender, EventArgs e)
        {
            if (WyborPliku.ShowDialog() != DialogResult.OK)
                return;
            var plik = new FileInfo(WyborPliku.FileName);
            if (plik.Extension != ".txt")
            {
                MessageBox.Show("Plik z danymi musi mieć rozszerzenie .txt !");
                return;
            }

            siecXor = Siec.UtworzSiecZPliku(WyborPliku.FileName);
            Hide();
            FormObliczenia form = new FormObliczenia(siecXor);
            form.ShowDialog();
        }
    }
}
