using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnWindowsForms
{
    public static class OkreslLiczbeAtrybutow
    {
        public static int LiczbaAtrybutow(List<Probka> listaProbek)
        {
            int wynik = 0;
            Probka probka = listaProbek[0];
            wynik = probka.atrybuty.Length;
            return wynik;
        }
    }
}
