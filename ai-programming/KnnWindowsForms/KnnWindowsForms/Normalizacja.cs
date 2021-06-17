using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnWindowsForms
{
    public static class Normalizacja
    {
        static List<double> MaxArgumenty(Probka probkaTestowa, List<Probka> listaProbek)
        {
            List<double> maxArgumenty = new List<double>();

            foreach (double argument in probkaTestowa.atrybuty)
                maxArgumenty.Add(argument);

            foreach (Probka probka in listaProbek)
            {
                for (int i = 0; i < probka.atrybuty.Length; i++)
                {
                    if (probka.atrybuty[i] > maxArgumenty[i])
                        maxArgumenty[i] = probka.atrybuty[i];
                }
            }

            return maxArgumenty;
        }

        static List<double> MinArgumenty(Probka probkaTestowa, List<Probka> listaProbek)
        {
            List<double> minArgumenty = new List<double>();

            foreach (double argument in probkaTestowa.atrybuty)
                minArgumenty.Add(argument);

            foreach (Probka probka in listaProbek)
            {
                for (int i = 0; i < probka.atrybuty.Length; i++)
                {
                    if (probka.atrybuty[i] < minArgumenty[i])
                        minArgumenty[i] = probka.atrybuty[i];
                }
            }

            return minArgumenty;
        }

        static void NormalizujProbke(Probka probka, List<Probka> listaProbek, List<double>minArgumenty, List<double>maxArgumenty)
        {
            for (int i = 0; i < probka.atrybuty.Length; i++)
            {
                probka.atrybuty[i] = ((probka.atrybuty[i] - minArgumenty[i]) / (maxArgumenty[i] - minArgumenty[i]));
            }
        }

        /* Normalizacja jest dokonywana z uwzględnieniem nowej próbki, jeśli maxArgument lub minArgument w kolumnie pochodzi od niej, to jest to respektowane */
        public static void Normalizuj(Probka probkaTestowa, List<Probka> listaProbek)
        {
            List<double> maxArgumenty = MaxArgumenty(probkaTestowa, listaProbek);
            List<double> minArgumenty = MinArgumenty(probkaTestowa, listaProbek);

            foreach (Probka probka in listaProbek)
            {
                NormalizujProbke(probka, listaProbek, minArgumenty, maxArgumenty);
            }

            NormalizujProbke(probkaTestowa, listaProbek, minArgumenty, maxArgumenty);
        }
    }
}
