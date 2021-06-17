using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgorytmGenetyczny.Globalne;

namespace AlgorytmGenetyczny
{
    public static class Losuj
    {
        public static int LosowyInt(int min, int max)
        {
            return losowa.Next(min, max);
        }
    }
}
