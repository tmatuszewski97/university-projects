using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static KnnWindowsForms.Testy;

namespace KnnWindowsForms
{
    public static class OknoZParametrem
    {
        public static double WyswietlOkno(string text, string caption)
        {
            Form okno = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 400};
            TextBox textBox = new TextBox() { Left = 150, Top = 40, Width = 100, TextAlign = HorizontalAlignment.Center};
            Button confirmation = new Button() { Text = "Zatwierdź", Left = 150, Width = 100, Top = 60, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { okno.Close(); };
            okno.Controls.Add(textBox);
            okno.Controls.Add(confirmation);
            okno.Controls.Add(textLabel);
            okno.AcceptButton = confirmation;

            if (okno.ShowDialog() == DialogResult.OK)
            {
                var tmp = textBox.Text;
                tmp = CzyPrzecinek() ? tmp.Replace(".", ",") : tmp.Replace(",", ".");
                if (CzyDouble(tmp))
                {
                    //BladAtrybuty.Visible = false;
                    return (Convert.ToDouble(tmp));
                }
            }

            return 0;
        }
    }
}
