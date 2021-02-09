using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trzy1
{
    public enum Typ_kafla
    {
        NIEZNANE,
        SCIANA,
        ZIEMIA,
        TRAWA

    }

    class Kafelek
    {
        public Typ_kafla typ;
    }
    class Mapa
    {
        public Kafelek[,] kafeleks;
        public Mapa()
        {

        }

    }
}
