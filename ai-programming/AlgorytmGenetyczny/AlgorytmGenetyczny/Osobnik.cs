using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgorytmGenetyczny.Losuj;
using static AlgorytmGenetyczny.Kopiuj;

namespace AlgorytmGenetyczny
{
    public class Osobnik
    {
        public List<List<int>>chromosomy = new List<List<int>>();
        public List<double>wartosciZdekodowane = new List<double>();
        public double wartoscFunkcjiPrzystosowania;


        public Osobnik(int ileChromNaParametr, int ileParametrow)
        {
            for (int i = 0; i < ileParametrow; i++)
            {
                List<int> listaChromNaPar = new List<int>();
                for (int j = 0; j < ileChromNaParametr; j++)
                {
                    listaChromNaPar.Add(LosowyInt(0, 2));
                }

                chromosomy.Add(listaChromNaPar);
            }

        }

        public Osobnik(Osobnik innyOsobnik)
        {
            chromosomy = KopiujListeChromosomow(innyOsobnik.chromosomy);
            wartosciZdekodowane = KopiujListeDouble(innyOsobnik.wartosciZdekodowane);
            wartoscFunkcjiPrzystosowania = innyOsobnik.wartoscFunkcjiPrzystosowania;
        }

        public void MutujJednopunktowo(int ileChromNaParametr)
        {
            int losujPar = LosowyInt(0, chromosomy.Count);
            int losujChrom = LosowyInt(0, ileChromNaParametr);

            if (chromosomy[losujPar][losujChrom] == 0)
                chromosomy[losujPar][losujChrom] = 1;
            else
                chromosomy[losujPar][losujChrom] = 0;
        }

        public override string ToString()
        {
            string wynik = "Osobnik o chromosomach: ";
            foreach (List<int> chrNaPar in chromosomy)
            {
                for(int i=0; i<chrNaPar.Count; i++)
                {
                    wynik += chrNaPar[i];
                }
            }

            wynik += "\r\nWartosci po zdekodowaniu: \r\n";
            foreach (double wartosc in wartosciZdekodowane)
            {
                wynik += wartosc + "\r\n";
            }

            wynik += "Wartosc funkcji przystosowania: \r\n";
            wynik += wartoscFunkcjiPrzystosowania + "\r\n";

            wynik += "\r\n";

            return wynik;
        }
    }
}
