using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmGenetyczny
{
    public static class FunkcjePrzystosowania
    {
        public static double zadanie1(List<double>wartosciZdekodowane)
        {
            double x1 = wartosciZdekodowane[0];
            double x2 = wartosciZdekodowane[1];

            return (Math.Sin(x1 * 0.05) + Math.Sin(x2 * 0.05) + 0.4 * Math.Sin(x1 * 0.15) * Math.Sin(x2 * 0.15));
        }
    }
}
