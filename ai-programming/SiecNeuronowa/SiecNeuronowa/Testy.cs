namespace SiecNeuronowa
{
    public static class Testy
    {
        public static bool CzyPrzecinek()
        {
            string test = "1,5";
            double wynikTestu;
            return double.TryParse(test, out wynikTestu);
        }
    }
}
