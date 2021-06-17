using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnWindowsForms
{
    public class Metryki
    {
        public static double Euklidesowa(Probka probka1, Probka probka2, double p)
        {
            double wynik = 0;

            for (int i = 0; i < probka1.atrybuty.Length; i++)
            {
                wynik += Math.Pow((probka1.atrybuty[i] - probka2.atrybuty[i]), 2);
            }

            return Math.Sqrt(wynik);
        }

        public static double Manhatan(Probka probka1, Probka probka2, double p)
        {
            double wynik = 0;
            for (int i = 0; i < probka1.atrybuty.Length; i++)
            {
                wynik += Math.Abs(probka1.atrybuty[i] - probka2.atrybuty[i]);
            }

            return wynik;
        }

        public static double Czebyszewa(Probka probka1, Probka probka2, double p)
        {
            double wynik = 0;
            for (int i = 0; i < probka1.atrybuty.Length; i++)
            {
                if (Math.Abs(probka1.atrybuty[i] - probka2.atrybuty[i]) > wynik)
                    wynik = Math.Abs(probka1.atrybuty[i] - probka2.atrybuty[i]);
            }

            return wynik;
        }

        public static double Minkowskiego(Probka probka1, Probka probka2, double p)
        {
            double wynik = 0;
            for (int i = 0; i < probka1.atrybuty.Length; i++)
            {
                wynik += Math.Pow((Math.Abs(probka1.atrybuty[i] - probka2.atrybuty[i])), p);
            }

            return Math.Pow(wynik, (1 / p));
        }

        public static double ZLogarytmem(Probka probka1, Probka probka2, double p)
        {
            double wynik = 0;
            for (int i = 0; i < probka1.atrybuty.Length; i++)
            {
                wynik += Math.Abs(Math.Log(Math.Abs(probka1.atrybuty[i])) - Math.Log(Math.Abs(probka2.atrybuty[i])));
            }

            return wynik;
        }

    }
}
