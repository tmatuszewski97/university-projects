using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnnWindowsForms
{
    public static class KnnKlasyfikator
    {

        public static Dictionary<double, List<double>> WyliczOdleglosci(List<Probka> listaProbek, Probka probkaTestowa, Metryka metryka, double parametr)
        {
            Dictionary<double, List<double>> wynik = new Dictionary<double, List<double>>();

            foreach (Probka probka in listaProbek)
            {
                double odleglosc = metryka(probka, probkaTestowa, parametr);
                if (!wynik.ContainsKey(probka.klasa))
                {
                    wynik[probka.klasa] = new List<double>() { odleglosc };
                }

                else
                {
                    wynik[probka.klasa].Add(odleglosc);
                }
            }

            return wynik;
        }


        public static void PosortujWartosciSlownika(Dictionary<double, List<double>> slownik)
        {
            foreach (KeyValuePair<double, List<double>> para in slownik)
            {
                para.Value.Sort();
            }
        }

        public static Dictionary<double, double> KOdleglosci(Dictionary<double, List<double>> odleglosci, int k)
        {
            Dictionary<double, double> wynik = new Dictionary<double, double>();
            foreach (KeyValuePair<double, List<double>> para in odleglosci)
            {
                for (int i = 0; i < k; i++)
                {

                    if (wynik.ContainsKey(para.Key))
                        wynik[para.Key] += para.Value[i];

                    else
                        wynik[para.Key] = para.Value[i];
                }
            }

            return wynik;
        }

        public static string WyswietlSlownik(Dictionary<double, double> slownik)
        {
            string wynik = "";
            foreach (KeyValuePair<double, double> para in slownik)
            {
                wynik+=("Klasa: " + para.Key + " | Wartosc: " + para.Value + "\n");
            }

            return wynik;
        }

        public static bool CzyPowtorka(Dictionary<double, double> slownik, double wartosc)
        {
            bool czyPowtorka = false;
            int licznik = 0;
            foreach (KeyValuePair<double, double> para in slownik)
            {
                if (para.Value == wartosc)
                {
                    licznik++;
                }

            }

            if (licznik >= 2)
                czyPowtorka = true;

            return czyPowtorka;
        }

        public static double ZnajdzMin(Dictionary<double, double> slownik)
        {
            double min = double.MaxValue;
            double minIndeks = double.NaN;

            foreach (KeyValuePair<double, double> para in slownik)
            {
                if (para.Value < min)
                {
                    min = para.Value;
                    minIndeks = para.Key;

                }

            }

            if (double.IsNaN(minIndeks))
            {
                MessageBox.Show("Określenie minimalnej sumy odległości nie było możliwe");

            }

            else if (CzyPowtorka(slownik, min))
            {
                MessageBox.Show("Określenie minimalnej sumy odległości nie było możliwe - więcej niż jedna klasa ma taką sama sumę odległości...");
                minIndeks = double.NaN;
            }

            return minIndeks;
        }

        public static double zwrocKlase(List<Probka> listaProbek, Probka probkaTestowa, int k, Metryka metryka, double parametr)
        {
            Dictionary<double, List<double>> odleglosci = WyliczOdleglosci(listaProbek, probkaTestowa, metryka, parametr);
            PosortujWartosciSlownika(odleglosci);
            Dictionary<double, double> kOdleglosci = KOdleglosci(odleglosci, k);
            string odleglosciDoKlas = WyswietlSlownik(kOdleglosci);
            //MessageBox.Show(odleglosciDoKlas, "Suma " + k + " najkrótszych odległości do poszczególnych klas");
            double min = ZnajdzMin(kOdleglosci);
            return min;
        }
    }
}
