using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorytmGenetyczny
{
    public partial class EkranPowitalny : Form
    {
        public EkranPowitalny()
        {
            InitializeComponent();
        }

        private void PrzyciskZadanie1_Click(object sender, EventArgs e)
        {
            Hide();
            FormZadanie1 form = new FormZadanie1();
            form.ShowDialog();
        }
    }
}
