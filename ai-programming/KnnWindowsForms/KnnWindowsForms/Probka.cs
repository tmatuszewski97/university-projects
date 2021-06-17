using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnWindowsForms
{
    public class Probka
    {
        public double[] atrybuty;
        public double klasa;

        public Probka(double[] atrybuty)
        {
            this.atrybuty = atrybuty;
        }

        public string SpiszAtrybuty(double[] tab)
        {
            string wynik = "";
            for (int i = 0; i < tab.Length; i++)
            {
                wynik += tab[i] + "\n";
                //wynik += tab[i] + " ";
            }

            return wynik;
        }

        public override string ToString()
        {
            return "Atrybuty:\n" + SpiszAtrybuty(atrybuty) + "\nKlasa:\n" + klasa;
            //return "Atrybuty:" + SpiszAtrybuty(atrybuty) + "Klasa:" + klasa;
        }
    }

}
