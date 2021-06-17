using System;
using System.Windows.Forms;

namespace SiecNeuronowa
{
    public partial class EkranPowitalny : Form
    {
        public EkranPowitalny()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            FormTworzSiecZLiczb form = new FormTworzSiecZLiczb();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            FormTworzSiecZPliku form = new FormTworzSiecZPliku();
            form.ShowDialog();
        }
    }
}
