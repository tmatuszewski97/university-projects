using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraOczkoGraf
{
    public class Krawedz
    {
        public int waga;
        public Wezel skad;
        public Wezel dokad;
        public string kolor;

        public Krawedz(Wezel skad, Wezel dokad, int waga)
        {
            this.skad = skad;
            this.dokad = dokad;
            this.waga = waga;
            kolor = "black";
        }

        public override string ToString()
        {
            return "Krawedz: skad: " + skad.ToString() + ", dokad: " + dokad.ToString() + ", waga: " + waga.ToString() + ", kolor: " + kolor.ToString();
        }

        public string KodKrawedzi()
        {
            return "\"" + skad.kto + "\\n " + skad.wartosc + "\\n id=" + skad.id + "\\n wynik=" + skad.wynik + "\" -> \"" + dokad.kto + "\\n " + dokad.wartosc + "\\n id=" + dokad.id + "\\n wynik=" + dokad.wynik +
                   "\" [label = \"" + waga + "\" color = \"" + kolor + "\"];";
        }
    }
}
