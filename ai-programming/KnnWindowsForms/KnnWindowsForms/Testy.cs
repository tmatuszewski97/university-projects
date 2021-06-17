using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnWindowsForms
{
    public static class Testy
    {
        public static bool CzyPrzecinek()
        {
            string test = "1,5";
            double wynikTestu;
            return double.TryParse(test, out wynikTestu);
        }

        public static bool CzyDouble (string zmienna)
        {
            double wynik;
            return double.TryParse(zmienna, out wynik);
        }

        public static bool CzyInt(string zmienna)
        {
            int wynik;
            return int.TryParse(zmienna, out wynik);
        }
    }
}
