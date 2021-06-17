using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AlgorytmGenetyczny.FunkcjePrzystosowania;
using static AlgorytmGenetyczny.Losuj;
using static AlgorytmGenetyczny.Kopiuj;

namespace AlgorytmGenetyczny
{
    public class AlgorytmGenetyczny
    {
        private List<Osobnik> pulaOsobnikow = new List<Osobnik>();
        private int ileParametrow;
        private int ileChromNaParametr;
        private double minZmiennoscParametru;
        private double maxZmiennoscParametru;
        private double najlepszaWartosc;
        private double sredniaWartosc;

        public AlgorytmGenetyczny(int ileParametrow, int ileChromNaParametr, int ileIteracji, int ileOsobnikow, double rozmiarTurnieju, double minZmiennoscParametru, double maxZmiennoscParametru, int nrZadania, bool funkcjaPrzystosowaniaMaxCzyMin, TextBox PoleWynikowe)
        {
            this.ileParametrow = ileParametrow;
            this.ileChromNaParametr = ileChromNaParametr;
            this.minZmiennoscParametru = minZmiennoscParametru;
            this.maxZmiennoscParametru = maxZmiennoscParametru;

            for (int i = 0; i < ileOsobnikow; i++)
            {
                Osobnik osobnik = new Osobnik(this.ileChromNaParametr, this.ileParametrow);
                pulaOsobnikow.Add(osobnik);
                osobnik.wartosciZdekodowane = DekodujWszystkieChromosomy(osobnik.chromosomy);
                
                switch (nrZadania)
                {
                    case 1:
                        osobnik.wartoscFunkcjiPrzystosowania = zadanie1(osobnik.wartosciZdekodowane);
                        break;
                }
            }

            najlepszaWartosc = NajlepszaWartoscFunkcji(pulaOsobnikow, funkcjaPrzystosowaniaMaxCzyMin);
            sredniaWartosc = SredniaWartoscFunkcji(pulaOsobnikow);

            /* Blok wyboru osobnikow z turnieju */
            for (int j = 0; j < ileIteracji; j++)
            {
                if (j == 0)
                {
                    PoleWynikowe.Text += "Punkt startowy: \r\n";
                    PoleWynikowe.Text += "Najlepsza wartość funkcji przystosowania:\r\n" + najlepszaWartosc + "\r\n" +
                                         "Średnia wartość funkcji przystosowania:\r\n" + sredniaWartosc + "\r\n\r\n";
                }

                List<Osobnik> nowaPula = new List<Osobnik>();

                while (nowaPula.Count < pulaOsobnikow.Count-1)
                {
                    List<Osobnik> kopiaOsobnikow = KopiujListeOsobnikow(pulaOsobnikow);

                    List<Osobnik>listaTurniejowa = new List<Osobnik>();
                    for (int i = 0; i < rozmiarTurnieju; i++)
                    {
                        int losowyIndeks = LosowyInt(0, kopiaOsobnikow.Count);
                        listaTurniejowa.Add(kopiaOsobnikow[losowyIndeks]);
                        kopiaOsobnikow.RemoveAt(losowyIndeks);
                    }

                    Osobnik wybrany = WybierzNajlepszegoZListy(listaTurniejowa, funkcjaPrzystosowaniaMaxCzyMin);
                    nowaPula.Add(wybrany);
                }

                for (int i=0; i<nowaPula.Count; i++)
                {
                    nowaPula[i].MutujJednopunktowo(this.ileChromNaParametr);
                }

                Osobnik najlepszy = WybierzNajlepszegoZListy(pulaOsobnikow, funkcjaPrzystosowaniaMaxCzyMin);
                nowaPula.Add(najlepszy);

                foreach (Osobnik osobnik in nowaPula)
                {
                    osobnik.wartosciZdekodowane = DekodujWszystkieChromosomy(osobnik.chromosomy);
                    osobnik.wartoscFunkcjiPrzystosowania = zadanie1(osobnik.wartosciZdekodowane);
                }

                najlepszaWartosc = NajlepszaWartoscFunkcji(nowaPula, funkcjaPrzystosowaniaMaxCzyMin);
                sredniaWartosc = SredniaWartoscFunkcji(nowaPula);

                PoleWynikowe.Text += "Iteracja numer " + (j+1) + "\r\n";
                PoleWynikowe.Text += "Najlepsza wartość funkcji przystosowania:\r\n" + najlepszaWartosc + "\r\n" +
                                     "Średnia wartość funkcji przystosowania:\r\n" + sredniaWartosc + "\r\n\r\n";

                pulaOsobnikow = KopiujListeOsobnikow(nowaPula);
            }
        }

        private double DekodujChromosomyParametru(List<int> liczbaBinarna)
        {
            double zmiennosc = maxZmiennoscParametru - minZmiennoscParametru;
            double tmp = 0;
            for (int i = 0; i < ileChromNaParametr; i++)
            {
                tmp += liczbaBinarna[i] * Math.Pow(2, i);
            }

            double wynik = (minZmiennoscParametru + tmp / (Math.Pow(2, ileChromNaParametr) - 1) * zmiennosc);
            return wynik;
        }

        private List<double> DekodujWszystkieChromosomy(List<List<int>> chromosomy)
        {
            List<double>wartosci = new List<double>();
            foreach (List<int> chrNaPar in chromosomy)
            {
                wartosci.Add(DekodujChromosomyParametru(chrNaPar));
            }

            return wartosci;
        }

        /* Jesli wartoscMaxCzyMin = true - im większa wartość funkcji przystosowania, tym lepiej, jeśli false - im gorsza tym lepiej */
        private Osobnik WybierzNajlepszegoZListy(List<Osobnik> listaOsobnikow, bool wartoscMaxCzyMin)
        {
            Osobnik tmp = new Osobnik(listaOsobnikow[0]);

            for (int i=1; i< listaOsobnikow.Count; i++)
            {
                switch (wartoscMaxCzyMin)
                {
                    case false:
                        {
                            if (listaOsobnikow[i].wartoscFunkcjiPrzystosowania < tmp.wartoscFunkcjiPrzystosowania)
                            {
                                tmp = new Osobnik (listaOsobnikow[i]);
                            }
                            break;
                        }
                    case true:
                        {
                            if (listaOsobnikow[i].wartoscFunkcjiPrzystosowania > tmp.wartoscFunkcjiPrzystosowania)
                            {
                                tmp = new Osobnik (listaOsobnikow[i]);
                            }
                            break;
                        }
                }
            }

            return tmp;
        }

        private double NajlepszaWartoscFunkcji(List<Osobnik> listaOsobnikow, bool wartoscMaxCzyMin)
        {
            Osobnik tmp = WybierzNajlepszegoZListy(listaOsobnikow, wartoscMaxCzyMin);
            return (tmp.wartoscFunkcjiPrzystosowania);
        }

        private double SredniaWartoscFunkcji(List<Osobnik> listaOsobnikow)
        {
            double suma = 0;
            foreach (Osobnik osobnik in listaOsobnikow)
            {
                suma += osobnik.wartoscFunkcjiPrzystosowania;
            }

            return suma / listaOsobnikow.Count;
        }

        public string WypiszOsobnikow()
        {
            string wynik = "";
            foreach (Osobnik osobnik in pulaOsobnikow)
            {
                wynik += osobnik.ToString();
            }

            wynik += "\r\n";
            return wynik;
        }
    }
}
