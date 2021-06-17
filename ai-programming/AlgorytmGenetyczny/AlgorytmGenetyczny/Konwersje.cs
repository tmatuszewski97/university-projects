using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgorytmGenetyczny.Sprawdzenia;

namespace AlgorytmGenetyczny
{
    class Konwersje
    {
        public static double StringNaDouble(string napis)
        {
            string wartoscString = napis.Trim();
            wartoscString = CzyPrzecinek() ? wartoscString.Replace(".", ",") : wartoscString.Replace(",", ".");
            double wynik = Convert.ToDouble(wartoscString);
            return wynik;
        }

        public static int StringNaInt(string napis)
        {
            string wartoscString = napis.Trim();
            int wynik = Convert.ToInt32(wartoscString);
            return wynik;
        }
    }
}
