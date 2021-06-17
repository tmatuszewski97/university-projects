using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraOczkoGraf
{
    public class Graf
    {
        public List<Wezel> wierzcholki = new List<Wezel>();
        public List<Krawedz> krawedzie = new List<Krawedz>();

        static bool CzyPozaLista(Wezel wierzcholek, List<Wezel> wierzcholki)
        {
            foreach (Wezel el in wierzcholki)
            {
                if (wierzcholek.id == el.id)
                    return false;
            }

            return true;
        }

        public void WypiszWierzcholki()
        {
            foreach (Wezel wezel in wierzcholki)
            {
                Console.WriteLine(wezel.ToString());
            }
        }

        public void WypiszKrawedzie()
        {
            foreach (Krawedz krawedz in krawedzie)
            {
                Console.WriteLine(krawedz.ToString());
            }
        }

        public void WygenerujKod()
        {
            string wynik = "digraph G {\n";
            foreach (Krawedz krawedz in krawedzie)
            {
                wynik += krawedz.KodKrawedzi() + "\n";
                //Console.WriteLine(krawedz.KodKrawedzi());
            }

            wynik += "}";
            Clipboard.SetText(wynik);
        }

        public void RysujGraf(Wezel rodzic)
        {
            if (CzyPozaLista(rodzic, wierzcholki))
            {
                wierzcholki.Add(rodzic);
            }

            if (rodzic.wartosc < 21)
            {
                for (int i = 0; i < 3; i++)
                {
                    Wezel dziecko = new Wezel(0, "");

                    if (rodzic.kto.Equals("prot"))
                    {
                        dziecko.kto = "ant";
                    }

                    if (rodzic.kto.Equals("ant"))
                    {
                        dziecko.kto = "prot";
                    }

                    int waga = 4 + i;
                    dziecko.wartosc = rodzic.wartosc + waga;


                    if (dziecko.wartosc == 21 || dziecko.wartosc > 21)
                    {
                        if (dziecko.wartosc == 21)
                        {
                            dziecko.wynik = 0;
                        }

                        else if (dziecko.wartosc > 21)
                        {
                            if (dziecko.kto.Equals("prot"))
                            {
                                dziecko.wynik = 1;
                            }

                            else
                            {
                                dziecko.wynik = -1;
                            }
                        }

                        dziecko.kto = "";
                    }

                    wierzcholki.Add(dziecko);
                    Krawedz krawedz = new Krawedz(rodzic, dziecko, waga);
                    krawedzie.Add(krawedz);

                    RysujGraf(dziecko);

                }
            }
        }

        List<Krawedz> KrawedzieWezla(Wezel wezel)
        {
            List<Krawedz> krawedzieWezla = new List<Krawedz>();
            foreach (Krawedz el in krawedzie)
            {
                if (el.skad == wezel)
                {
                    krawedzieWezla.Add(el);
                }
            }

            return krawedzieWezla;
        }

        List<Wezel> DzieciWezla(Wezel rodzic)
        {
            List<Wezel> dzieci = new List<Wezel>();
            List<Krawedz> krawedzieWezla = KrawedzieWezla(rodzic);

            foreach (Krawedz kr in krawedzieWezla)
            {
                dzieci.Add(kr.dokad);
            }

            return dzieci;
        }

        Wezel ZnajdzWezelPoprzezWynik(List<Wezel> wezly, int wynik)
        {
            foreach (Wezel el in wezly)
            {
                if (el.wynik == wynik)
                {
                    return el;
                }
            }

            return null;
        }

        Krawedz ZnajdzKrawedzPrzezWezly(Wezel skad, Wezel dokad)
        {
            foreach (Krawedz el in krawedzie)
            {
                if (el.skad == skad && el.dokad == dokad)
                {
                    return el;
                }
            }

            return null;
        }

        bool CzyMaDziecko(Wezel wezel)
        {
            foreach (Krawedz kr in krawedzie)
            {
                if (kr.skad == wezel)
                {
                    return true;
                }
            }

            return false;
        }

        public int MinMax(Wezel wezel)
        {
            if (!CzyMaDziecko(wezel))
            {
                return wezel.wynik;
            }

            if (wezel.kto.Equals("prot"))
            {
                int maks = -800;
                List<Wezel> dzieciWezla = DzieciWezla(wezel);
                foreach (Wezel dziecko in dzieciWezla)
                {
                    int tmp = MinMax(dziecko);
                    maks = Math.Max(maks, tmp);
                }

                Wezel zaznacz = ZnajdzWezelPoprzezWynik(dzieciWezla, maks);
                Krawedz kr = ZnajdzKrawedzPrzezWezly(wezel, zaznacz);
                kr.kolor = "red";
                wezel.wynik = maks;
            }

            else
            {
                int min = 800;
                List<Wezel> dzieciWezla = DzieciWezla(wezel);
                foreach (Wezel dziecko in dzieciWezla)
                {
                    int tmp = MinMax(dziecko);
                    min = Math.Min(min, tmp);
                }

                Wezel zaznacz = ZnajdzWezelPoprzezWynik(dzieciWezla, min);
                Krawedz kr = ZnajdzKrawedzPrzezWezly(wezel, zaznacz);
                kr.kolor = "red";
                wezel.wynik = min;
            }
            return wezel.wynik;
        }
    }
}
