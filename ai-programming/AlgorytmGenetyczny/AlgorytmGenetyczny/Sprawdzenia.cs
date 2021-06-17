using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorytmGenetyczny
{
    public static class Sprawdzenia
    {
        public static void CzyWlaczycPrzycisk(Button przycisk, bool[] aktualna, bool[] oczekiwana)
        {
            /* Metoda ponizej sprawdza czy obie tablice posiadaja takie same wartosci w srodku */
            if (aktualna.SequenceEqual(oczekiwana))
                przycisk.Enabled = true;
            else
                przycisk.Enabled = false;
        }

        public static bool CzyPrzecinek()
        {
            string test = "1,5";
            double wynikTestu;
            return double.TryParse(test, out wynikTestu);
        }

        public static bool CzyDouble(string zmienna)
        {
            string wartoscString = zmienna.Trim();
            wartoscString = CzyPrzecinek() ? wartoscString.Replace(".", ",") : wartoscString.Replace(",", ".");
            double wynik;
            return double.TryParse(wartoscString, out wynik);
        }

        public static bool CzyInt(string zmienna)
        {
            string wartoscString = zmienna.Trim();
            int wynik;
            return int.TryParse(wartoscString, out wynik);
        }
    }
}
