using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraOczkoGraf
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Wezel poczatek = new Wezel(0, "prot");
            Graf oczko = new Graf();

            oczko.RysujGraf(poczatek);
            //oczko.WypiszWierzcholki();
            //oczko.WypiszKrawedzie();
            //oczko.WygenerujKod();

            int wynik = oczko.MinMax(poczatek);
            oczko.WygenerujKod();

            System.Diagnostics.Process.Start("cmd", "/C start http://www.webgraphviz.com/");
            Console.WriteLine("Wynik programu został skopiowany do schowka.\nSkorzystaj z CTRL+V i wklej wynik na otwartej stronie (czyszcząc uprzednio pole wprowadzania danych), a następnie kliknij \"Generate Graph!\"");
            Console.ReadKey();
        }
    }
}
