using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnWindowsForms
{
    public static class OkreslMaxK
    {
        /* Słownik, gdzie key - jaka klasa, value - ile jest w niej obiektów */
        public static Dictionary<double, int> ObliczLiczbenoscKlas(List<Probka> listaProbek)
        {
            Dictionary<double, int> wynik = new Dictionary<double, int>();

            foreach (Probka probka in listaProbek)
            {
                /* Jeśli klucza jeszcze nie ma w słowniku, to: */
                if (!wynik.ContainsKey(probka.klasa))
                {
                    wynik.Add(probka.klasa, 1);
                }

                /* Jeśli jest, to */
                else
                {
                    wynik[probka.klasa]++;
                }
            }

            return wynik;
        }

        public static int MaxK(List<Probka> listaProbek)
        {
            Dictionary<double, int> liczebnoscKlas = ObliczLiczbenoscKlas(listaProbek);
            int max = 999;
            foreach (KeyValuePair<double, int> para in liczebnoscKlas)
            {
                if (para.Value < max)
                    max = para.Value;
            }

            return max;
        }

    }
}