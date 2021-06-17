using System;
using System.Windows.Forms;
using static SiecNeuronowa.Konwersje;

namespace SiecNeuronowa
{
    public partial class FormTworzSiecZLiczb : Form
    {
        public FormTworzSiecZLiczb()
        {
            InitializeComponent();
        }

        private void CofnijDoEkranPowitalny_Click(object sender, EventArgs e)
        {
            Hide();
            EkranPowitalny form = new EkranPowitalny();
            form.ShowDialog();
        }

        private void ZatwierdzWagi_Click(object sender, EventArgs e)
        {
            PoleMinWaga.Enabled = false;
            PoleMaxWaga.Enabled = false;
            ZatwierdzWagi.Enabled = false;
            EtykietaWprowadzLiczby.Visible = true;
            PoleWprowadzLiczby.Visible = true;
            ZatwierdzLiczby.Visible = true;
        }

        private Siec siecXor;
        private void ZatwierdzLiczby_Click(object sender, EventArgs e)
        {
            siecXor = new Siec(StringNaListeInt(PoleWprowadzLiczby.Text), StringNaDouble(PoleMinWaga.Text), StringNaDouble(PoleMaxWaga.Text));
            Hide();
            FormObliczenia form = new FormObliczenia(siecXor);
            form.ShowDialog();

        }
    }
}
