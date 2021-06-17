using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static SiecNeuronowa.Testy;
using static SiecNeuronowa.Losuj;
using static SiecNeuronowa.Konwersje;

namespace SiecNeuronowa
{
    public class Siec
    {
        public int licznikEpok; //zmienna potrzebna tylko dla wyświetlania, ile epok zostało wykonanych przed nauczeniem
        public List<Warstwa> warstwy = new List<Warstwa>();
        List<double> bledySieci = new List<double>();

        public Siec(List<int> lista, double minWaga, double maxWaga)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (i == 0) //jesli jest to warstwa wejsciowa
                {
                    warstwy.Add(new Warstwa(lista[i], 1, 0, minWaga, maxWaga));
                    /*
                    foreach (Neuron neuron in warstwy[i].neuronyWarstwy)
                    {
                        Console.WriteLine("Podaj wartosc wejsciowa: "); //pytamy o wartosci poczatkowe
                        neuron.wartosc = StringNaDouble(Console.ReadLine());
                    }
                    */
                }

                else
                {
                    int liczbaWagNaWarstwe = lista[i] * (lista[i - 1] + 1); //ile krawedzi przypada na dana warstwe
                    int liczbaWagNaNeuron = liczbaWagNaWarstwe / lista[i]; //ile krawedzi przypada na dany neutron
                    warstwy.Add(new Warstwa(lista[i], 1, liczbaWagNaNeuron, minWaga, maxWaga)); //tworzymy warstwy z losowymi wagami
                }
            }
        }

        public void WczytajWagi(string sciezka) //funkcja wczytujaca wagi do sieci z pliku o okreslonej sciezce
        {
            var wiersze = System.IO.File.ReadAllLines(sciezka); //odczytujemy wszystkie linie w pliku

            int i = 1; //licznik warstw
            int j = 0; //licznik neuronow
            foreach (string wiersz in wiersze)
            {
                if (wiersz != "")
                {
                    var dane = wiersz.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int k = 0; //licznik wag w neuronie
                    foreach (var dana in dane)
                    {
                        var tmp = dana.Trim();
                        tmp = CzyPrzecinek() ? tmp.Replace(".", ",") : tmp.Replace(",", ".");
                        double liczba = double.Parse(tmp);
                        warstwy[i].neuronyWarstwy[j].wagi[k] = liczba;
                        k++;
                    }

                    if (j + 1 < warstwy[i].neuronyWarstwy.Count)
                    {
                        j++;
                    }
                }

                else
                {
                    if (i + 1 < warstwy.Count)
                    {
                        i++; //jesli w pliku napotkamy pusty wiersz, to inkrementujemy licznik warstw
                        j = 0; //po przeskoczeniu do nowej warstwy, licznik neuronow trzeba zresetowac
                    }
                }
            }
        }

        private static List<int> StrukturaSieci(string sciezka) //funkcja tworzaca liste przechowujaca strukture sieci, np. {2 2 1}. Struktura jest tworzona na podstawie pliku.
        {
            var wiersze = System.IO.File.ReadAllLines(sciezka); //odczytujemy wszystkie linie w pliku
            int licznikWarstw = 2; //licznik warstw w pliku, kazda linia pusta zwieksza ilosc warstw (zakladamy 2, gdyz warstwa poczatkowa (nie wchodzi w sklad pliku) + pierwsza warstwa)
            foreach (string wiersz in wiersze)
            {
                if (wiersz == "") //jesli pusty wiersz
                {
                    licznikWarstw++; //inkrementujemy licznik warstw
                }
            }
            int[] strukturaSieci = new int[licznikWarstw]; //tworzymy tablice o rozmiarze wyliczonej ilosci warstw
            int i = 1; //licznik warstwy
            int j = 1; //licznik neuronow na warstwie
            bool czyPierwszyWiersz = true;
            int licznikPierwszegoWiersza = 0;
            foreach (string wiersz in wiersze)
            {
                if (wiersz != "")
                {
                    if (czyPierwszyWiersz) //zliczamy ilosc liczb w pierwszym wierszu, aby na ich podstawie okreslic warstwe wejsciowa w sieci, gdyz w pliku nie ma o niej informacji.
                                           //Jest ona zalezna od pierwszej warstwy. Wykona sie to tylko dla pierwszego wiersza w pliku
                    {
                        var dane = wiersz.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var dana in dane)
                        {
                            licznikPierwszegoWiersza++;
                        }

                        czyPierwszyWiersz = false;
                    }

                    strukturaSieci[i] = j; //zapisujemy ile neuronow jest na danej warstwie
                    j++; //jesli jest wiecej neuronow to w nastepnym kroku ilosc neuronow na warstwie zostanie zwiekszona
                }

                else
                {
                    if (i == 1) //jesli dalej mamy do czynienia z pierwsza warstwa, ale juz na pewno okreslona to okreslamy ilosc neutronow na warstwie wejsciowej jako licznikPierwszegoWiersza-1 (bo parametr uczenia)
                    {
                        strukturaSieci[0] = licznikPierwszegoWiersza - 1;
                    }
                    i++; //jesli wiersz jest pusty, to przechodzimy do kolejnej warstwy
                    j = 1; //i resetujemy tam licznik neutronow na warstwie
                }
            }

            return strukturaSieci.ToList(); //na koniec zmieniamy tablice na liste

        }

        public static Siec UtworzSiecZPliku(string sciezka) //funkcja tworzaca siec neuronowa z zadanego pliku
        {
            List<int> strukturaSieci = StrukturaSieci(sciezka); //najpierw odczytujemy z pliku ilosc warstw i neuronow na
                                                                //warstwach i zapisujemy to do listy, np. {2 2 1}
            Siec nowaSiec = new Siec(strukturaSieci, -1, 1); //z zadanej listy tworzymy siec o odpowiedniej strukturze, na razie z losowymi wagami
            nowaSiec.WczytajWagi(sciezka); //wagi losowe sa zamieniane z tymi z pliku
            return nowaSiec;
        }

        public void ZapiszWagi(string sciezka) //funkcja zapisujaca wagi z sieci do pliku o okreslonej sciezce
        {
            using (System.IO.StreamWriter plik =
                new System.IO.StreamWriter(sciezka))
            {
                for (int i = 1; i < warstwy.Count; i++)
                {
                    string napis = warstwy[i].WagiWarstwy();
                    plik.WriteLine(napis);
                }
            }
        }

        public void NadpiszWejscia(List<int> wejscia)
        {
            int i = 0;
            foreach (Neuron neuron in warstwy[0].neuronyWarstwy)
            {
                neuron.wartosc = wejscia[i];
                i++;
            }
        }

        public void WyliczWartosci(double beta) //funkcja dokonujaca obliczen w sieci
        {
            for (int i = 1; i < warstwy.Count; i++)
            {
                foreach (Neuron neuronWarstwy in warstwy[i].neuronyWarstwy)
                {
                    neuronWarstwy.WyliczSume(warstwy[i - 1].neuronyWarstwy);
                    neuronWarstwy.FunkcjaAktywujaca(beta);
                }
            }
        }

        private int IleWejsc()
        {
            int wynik = 0;
            foreach (Neuron neuron in warstwy[0].neuronyWarstwy)
            {
                wynik++;
            }

            return wynik;
        }

        private Dictionary<List<int>, List<double>> WylosujKolejnoscProbek(Dictionary<List<int>, List<double>> probkiTestowe)
        {
            Dictionary<List<int>, List<double>> kopiaProbekTestowych = new Dictionary<List<int>, List<double>>(probkiTestowe);
            Dictionary<List<int>, List<double>> wynik = new Dictionary<List<int>, List<double>>();

            while (wynik.Count < probkiTestowe.Count)
            {
                int indeks = LosowyInt(0, kopiaProbekTestowych.Count);
                KeyValuePair<List<int>, List<double>> probka = kopiaProbekTestowych.ElementAt(indeks);
                wynik.Add(probka.Key, probka.Value);
                kopiaProbekTestowych.Remove(probka.Key);
            }

            return wynik;
        }

        public Dictionary<List<int>, List<double>> WczytajProbkiUczace(string sciezka)
        {
            Dictionary<List<int>, List<double>> wynik = new Dictionary<List<int>, List<double>>();

            var wiersze = System.IO.File.ReadAllLines(sciezka); //odczytujemy wszystkie linie w pliku
            foreach (string wiersz in wiersze)
            {
                /* Klucz slownika stanowia wejscia */
                List<int> wejscia = new List<int>();
                /* Wartosci slownika stanowia wartosci oczekiwane */
                List<double> wartosciOczekiwane = new List<double>();

                var dane = wiersz.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int licznikWejsc = IleWejsc();

                for (int i = 0; i < licznikWejsc; i++)
                {
                    int liczba = StringNaInt(dane[i]);
                    wejscia.Add(liczba);
                }

                for (int i = licznikWejsc; i < dane.Length; i++)
                {
                    double liczba = StringNaDouble(dane[i]);
                    wartosciOczekiwane.Add(liczba);
                }

                /* Dodajemy probke ListaWejsc, ListaWartosciOczekiwanych do slownika */
                wynik.Add(wejscia, wartosciOczekiwane);
            }

            return wynik;
        }

        private void UczSiec(List<int> wejscia, List<double> wartosciOczekiwane, double krokUczenia, double beta, int nrWarstwy)
        {
            /* Jesli mamy do czynienia z ostatnia warstwa */
            if (nrWarstwy == warstwy.Count - 1)
            {
                /* Przepisujemy podane w argumencie wejscia, na wejscia sieci */
                NadpiszWejscia(wejscia);
                /* Wyliczamy wartosci neuronow w sieci */
                WyliczWartosci(beta);
            }

            /* Dopoki nie dojdziemy do pierwszej warstwy */
            if (nrWarstwy > 0)
            {
                /* Licznik wartosci oczekiwanych */
                int i = 0;
                /* Dla kazdego neurona w aktualnej warstwie wykonujemy ten blok */
                foreach (Neuron neuron in warstwy[nrWarstwy].neuronyWarstwy)
                {
                    /* Jesli mowa jest o ostatniej warstwie to korekta dla kazdego neurona poczatkowo wynosi tyle */
                    if (nrWarstwy == warstwy.Count - 1)
                    {
                        neuron.korekta = krokUczenia * (wartosciOczekiwane[i] - neuron.wartosc);
                        i++;
                    }

                    /* Nastepnie wyliczana jest juz konkretna korekta dla kazdego neurona w danej warstwie */
                    neuron.korekta = neuron.korekta * beta * neuron.wartosc * (1 - neuron.wartosc);

                    /* Do tej listy zapisujemy wszystkie nowe wagi dla neuronu */
                    List<double> noweWagiNeuronu = new List<double>();
                    for (int j = 0; j < neuron.wagi.Count; j++)
                    {
                        /* Wyliczamy nowe wagi */
                        /* Nizej - przypadek jesli chodzi o wage miedzy neuronem a wyjsciem ukrytym */
                        if (j == 0)
                            noweWagiNeuronu.Add(neuron.wagi[j] + neuron.korekta * 1);
                        /* Nizej - przypadek jesli chodzi o wage miedzy neuronami */
                        /* Tutaj wyliczamy tez zmiany na wyjsciach poprzedzajacej warstwy */
                        else
                        {
                            noweWagiNeuronu.Add(neuron.wagi[j] + neuron.korekta * warstwy[nrWarstwy - 1].neuronyWarstwy[j - 1].wartosc);
                            /* Dla wejsc nie trzeba juz korekty */
                            if (nrWarstwy > 1)
                                warstwy[nrWarstwy - 1].neuronyWarstwy[j - 1].korekta += neuron.korekta * neuron.wagi[j];
                        }
                    }

                    /* Nadpisujemy wagi */
                    for (int j = 0; j < neuron.wagi.Count; j++)
                    {
                        neuron.wagi[j] = noweWagiNeuronu[j];
                    }

                }

                /* Przechodzimy do warstwy wczesniejszej */
                nrWarstwy--;
                UczSiec(wejscia, wartosciOczekiwane, krokUczenia, beta, nrWarstwy);
            }

            /* Jesli doszlismy do warstwy nr 0 to koniec rekurencji */
        }

        private void UczPrzezEpoke(Dictionary<List<int>, List<double>> probkiTestowe, double krokUczenia, double beta)
        {
            foreach (KeyValuePair<List<int>, List<double>> probka in probkiTestowe)
            {
                UczSiec(probka.Key, probka.Value, krokUczenia, beta, warstwy.Count - 1);
            }
        }

        private bool SprawdzCzyBladPonizej(Dictionary<List<int>, List<double>>probkiTestowe, double beta, double maxBlad)
        {
            for (int k = 0; k < bledySieci.Count; k++)
            {
                bledySieci[k] = 0;
            }

            int i = 0;
            foreach (KeyValuePair<List<int>, List<double>>probka in probkiTestowe)
            {
                NadpiszWejscia(probka.Key);
                WyliczWartosci(beta);
                int j = 0;
                foreach (Neuron neuron in warstwy[warstwy.Count - 1].neuronyWarstwy)
                {
                    bledySieci[i] += Math.Abs(probka.Value[j] - neuron.wartosc);
                    j++;
                }

                i++;
            }

            foreach (double liczba in bledySieci)
            {
                if (liczba > maxBlad)
                    return false;
            }

            return true;
        }

        public void UczPrzezEpoki(int liczbaEpok, double krokUczenia, double beta, string linkDoProbek, double maxBlad)
        {
            Dictionary<List<int>, List<double>> probkiUczace = new Dictionary<List<int>, List<double>>(WczytajProbkiUczace(linkDoProbek));

            if (bledySieci.Count == 0)
            {
                for (int j = 0; j < probkiUczace.Count; j++)
                {
                    bledySieci.Add(0);
                }
            }

            for (int i = 0; i < liczbaEpok; i++)
            {
                licznikEpok = i+1;
                Dictionary<List<int>, List<double>> wylosowaneProbkiUczace = new Dictionary<List<int>, List<double>>(WylosujKolejnoscProbek(probkiUczace));
                UczPrzezEpoke(wylosowaneProbkiUczace, krokUczenia, beta);
                
                if (SprawdzCzyBladPonizej(wylosowaneProbkiUczace, beta, maxBlad))
                    break;
            }
        }

        private string WypiszWejscia()
        {
            string wynik = "Wejścia: \r\n";
            foreach (Neuron wej in warstwy[0].neuronyWarstwy)
            {
                wynik += "Wejscie o wartosci: " + wej.wartosc + "\r\n";
            }
            wynik += "\r\n";

            return wynik;
        }

        private string WypiszWyjscia()
        {
            string wynik = "Wyjścia: \r\n";
            foreach (Neuron wyj in warstwy[warstwy.Count-1].neuronyWarstwy)
            {
                wynik += "Wyjście o wartosci: " + wyj.wartosc + "\r\n";
            }
            wynik += "\r\n";

            return wynik;
        }

        private string WypiszNeuronyZWagami()
        {
            string wynik = "";
            for (int i = 1; i < warstwy.Count; i++)
            {
                wynik += "----------------------------------------------------------------------------\r\n";
                wynik += "Warstwa nr : "+ i + "\r\n\r\n";
                foreach (Neuron neuron in warstwy[i].neuronyWarstwy)
                {
                    if (i == warstwy.Count - 1)
                        wynik += "Wyjscie o wartosci: " + neuron.wartosc + "\r\n";
                    else
                        wynik += "Neuron o wartosci: " + neuron.wartosc + "\r\n";
                    
                    wynik += "Wagi: \r\n";
                    foreach (double liczba in neuron.wagi)
                    {
                        wynik += "Waga o wartosci: " + liczba + "\r\n";
                    }

                    wynik += "\r\n";
                }
            }

            return wynik;
        }

        public string WypiszWszystko()
        {
            string wynik = "";
            wynik += WypiszWejscia();
            wynik += WypiszNeuronyZWagami();
            return wynik;
        }

        public string WypiszWeWy()
        {
            string wynik = "Liczba wykonanych epok: " + licznikEpok + "\r\n\r\n";
            wynik += WypiszWejscia();
            wynik += WypiszWyjscia();
            return wynik;
        }
    }
}
