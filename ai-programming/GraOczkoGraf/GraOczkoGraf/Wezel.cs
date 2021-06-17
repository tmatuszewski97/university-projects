using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraOczkoGraf
{
    public class Wezel
    {
        static int _licznik = 0;
        public int wartosc;
        public string kto;
        public int id;
        public int wynik;

        public Wezel (int wartosc, string kto)
        {
            this.wartosc = wartosc;
            this.kto = kto;
            _licznik++;
            id = _licznik;
            wynik = 666;
        }

        public override string ToString()
        {
            return kto.ToString() + " " + wartosc.ToString();
        }
    }
}
