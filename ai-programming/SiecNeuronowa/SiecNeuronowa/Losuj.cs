using static SiecNeuronowa.Globalne;

namespace SiecNeuronowa
{
    public static class Losuj
    {
        public static double LosowyDouble(double min, double max)
        {
            return losowa.NextDouble() * (max - min) + min;
        }

        public static int LosowyInt(int min, int max)
        {
            return losowa.Next(min, max);
        }
    }
}
