using System;
using System.Collections.Generic;
using static SiecNeuronowa.Testy;

namespace SiecNeuronowa
{
    public static class Konwersje
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

        public static List<int> StringNaListeInt(string napis)
        {
            List<int> wynik = new List<int>();
            var dane = napis.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var dana in dane)
            {
                int liczba = Convert.ToInt32(dana.Trim());
                wynik.Add(liczba);
            }

            return wynik;
        }

        public static int DoubleNaInt(double liczba)
        {
            int wynik = Convert.ToInt32(liczba);
            return wynik;
        }
    }
}
