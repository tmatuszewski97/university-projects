using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KnnWindowsForms.Testy;

namespace KnnWindowsForms
{
    public static class WczytywanieDanych
    {
        public static List<Probka> WczytajDane(string sciezka)
        {
            List<Probka> wynik = new List<Probka>();
            var wiersze = System.IO.File.ReadAllLines(sciezka);

            foreach (var wiersz in wiersze)
            {
                var dane = wiersz.Trim().Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                List<double> atrybuty = new List<double>();

                foreach (var dana in dane)
                {
                    var tmp = dana.Trim();
                    tmp = CzyPrzecinek() ? tmp.Replace(".", ",") : tmp.Replace(",", ".");
                    var liczba = double.Parse(tmp);
                    atrybuty.Add(liczba);
                }

                var ostatniaWartosc = atrybuty[atrybuty.Count - 1];
                atrybuty.RemoveAt(atrybuty.Count-1);

                double[] atrybutyTablica = atrybuty.ToArray();
                Probka probka = new Probka(atrybutyTablica);
                probka.klasa = ostatniaWartosc;
                wynik.Add(probka);
            }

            return wynik;
        }
    }
}
