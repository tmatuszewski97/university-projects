using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KnnWindowsForms.KnnKlasyfikator;
using static KnnWindowsForms.OkreslMaxK;

namespace KnnWindowsForms
{
    public static class JedenKontraReszta
    {
        static double IloscProbek(List<Probka>listaProbek)
        {
            double wynik = 0;
            foreach (Probka probka in listaProbek)
            {
                wynik++;
            }
            return wynik;
        }

        public static double DokladnoscKlasyfikacji(List<Probka>listaProbek, int k, Metryka metryka, double parametr)
        {
            double licznik = 0;
            double iloscProbek = IloscProbek(listaProbek);
            double przypisanaKlasa;

            foreach (Probka probka in listaProbek)
            {
                List<Probka> kopiaListy = new List<Probka>(listaProbek);
                kopiaListy.Remove(probka);

                int maxK = MaxK(listaProbek);

                /* Jeśli maxK jest równe k przekazanemu do funkcji, to k ustawiamy na maksymalne po tym, jak usuwamy z listy próbkę testową */
                if (k == maxK)
                    k = MaxK(kopiaListy);

                przypisanaKlasa = zwrocKlase(kopiaListy, probka, k, metryka, parametr);
               
                if (przypisanaKlasa == probka.klasa)
                {
                    licznik++;
                }
            }

            return licznik / iloscProbek;
        }
    }


}
