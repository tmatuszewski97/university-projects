using System;
using System.Collections.Generic;
using static SiecNeuronowa.Losuj;

namespace SiecNeuronowa
{
    public class Neuron
    {
        public double wartosc;
        public double korekta;
        public List<double> wagi;

        public Neuron(double wartosc, int iloscWag, double minWaga, double maxWaga)
        {
            this.wartosc = wartosc;
            this.wagi = InicjujWagiDlaNeuronu(iloscWag, minWaga, maxWaga);
        }

        public List<double> InicjujWagiDlaNeuronu(int iloscWagNaNeuron, double minWaga, double maxWaga) //funkcja tworzaca liste losowych wag dla neuronu
        {
            List<double> wynik = new List<double>();
            for (int i = 0; i < iloscWagNaNeuron; i++)
            {
                wynik.Add(LosowyDouble(minWaga, maxWaga)/*, wagaParametr */);
            }

            return wynik;
        }

        public void WyliczSume(List<Neuron> poprzedniaWarstwaNeurony)
        {
            this.wartosc = 1 * wagi[0];
            int j = 0;
            for (int i = 1; i < wagi.Count; i++)
            {
                this.wartosc += poprzedniaWarstwaNeurony[j].wartosc * wagi[i];
                j++;
            }
        }

        public void FunkcjaAktywujaca(double beta)
        {
            this.wartosc = (1 / (1 + Math.Exp(-(beta) * wartosc)));
        }

        public string wagiNeuronuNapis() //funkcja wykorzystywana przy zapisywaniu 
        {
            string wynik = "";
            foreach (double waga in wagi)
            {
                wynik += waga + " ";
            }

            return wynik + "\n";
        }

        public override string ToString() //funkcja nadpisana w celach ladniejszego wyswietlania w konsoli
        {
            string tmp = wagiNeuronuNapis();
            return "\nNeuron o wartosci: " + wartosc + "\nWagi dla neuronu: " + this.wagiNeuronuNapis() + "Korekta: " + this.korekta + "\n";
        }
    }
}
