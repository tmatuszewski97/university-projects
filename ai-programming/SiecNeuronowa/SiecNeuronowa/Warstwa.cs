using System.Collections.Generic;

namespace SiecNeuronowa
{
    public class Warstwa
    {
        private static int _licznik; //domyslnie startuje od 0
        public List<Neuron> neuronyWarstwy;
        public int idWarstwy;

        public Warstwa(int iloscNeuronow, double wartoscPoczatkowa, int iloscWagNaNeutron, double minWaga, double maxWaga) //funkcja tworzona warstwe o okreslonej liczbie neuronow, z okreslona dla nich wartoscia poczatkowa
            //oraz iloscia wag przypadajacych na neuron
        {
            neuronyWarstwy = InicjujNeuronyWarstwy(iloscNeuronow, wartoscPoczatkowa, iloscWagNaNeutron, minWaga, maxWaga);
            idWarstwy = _licznik;
            _licznik++;
        }

        public List<Neuron> InicjujNeuronyWarstwy(int iloscNeuronow, double wartoscPoczatkowa, int iloscWagNaNeutron, double minWaga, double maxWaga)
        {
            List<Neuron> wynik = new List<Neuron>();
            for (int i = 0; i < iloscNeuronow; i++)
            {
                wynik.Add(new Neuron(wartoscPoczatkowa, iloscWagNaNeutron, minWaga, maxWaga));
            }

            return wynik;
        }

        public string WagiWarstwy() //funkcja wykorzystywana przy zapisywaniu wag do pliku
        {
            string wynik = "";
            foreach (Neuron neuron in neuronyWarstwy)
            {
                wynik += neuron.wagiNeuronuNapis();
            }

            return wynik;
        }

        public override string ToString() //funkcja nadpisana w celach ladniejszego wyswietlania w konsoli
        {
            string wynik = "\n";
            wynik += "---------------------------------------------";
            wynik += "\nWarstwa nr: " + idWarstwy + "\n";
            foreach (Neuron neuron in neuronyWarstwy)
            {
                wynik += neuron;
            }
            wynik += "---------------------------------------------";
            return wynik;
        }
    }
}
