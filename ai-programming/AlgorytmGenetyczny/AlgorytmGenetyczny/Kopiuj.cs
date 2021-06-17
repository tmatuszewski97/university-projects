using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmGenetyczny
{
    public static class Kopiuj
    {
        public static List<Osobnik> KopiujListeOsobnikow(List<Osobnik> lista)
        {
            List<Osobnik>nowaLista = new List<Osobnik>(lista.Count);
            foreach (Osobnik os in lista)
            {
                nowaLista.Add(new Osobnik(os));
            }

            return nowaLista;
        }

        public static List<List<int>> KopiujListeChromosomow(List<List<int>> lista)
        {
            List<List<int>> listaChromosomow = new List<List<int>>(lista.Count);
            foreach (List<int> podlista in lista)
            {
                List<int>nowaPodlista = new List<int>(podlista.Count);
                foreach (int liczba in podlista)
                {
                    nowaPodlista.Add(liczba);
                }
                listaChromosomow.Add(nowaPodlista);
            }

            return listaChromosomow;
        }

        public static List<double> KopiujListeDouble(List<double> lista)
        {
            List<double>listaWynikowa = new List<double>(lista.Count);
            foreach (double liczba in lista)
            {
                listaWynikowa.Add(liczba);
            }

            return listaWynikowa;
        }
    }
}
