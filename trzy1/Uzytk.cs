using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trzy1
{
    class Wek2d
    {
        public double x, y;
    }

    class Zbiornik
    {
        List<Rzecz> zawartosc;
        public void Dodaj(Rzecz co)
        {
            zawartosc.Add(co);
        }

        public void Wypisz()
        {
            
        }
    }

    class Zaloga
    {
        List<Postac> czlonkowie;

        public void Dodaj(Postac kto)
        {
            czlonkowie.Add(kto);
        }

    }
}
