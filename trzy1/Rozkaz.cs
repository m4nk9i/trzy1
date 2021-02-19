using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trzy1
{

    public enum Typ_rozkazu
    {
        NIEZNANY,
        STOJ,
        IDZDO,
        KOP,
        PODNIES,
        ZNAJDZDROGE
    }
    class Rozkaz
    {
        public Typ_rozkazu rodzaj = Typ_rozkazu.NIEZNANY;
    }

    class RoIdzdo:Rozkaz
    {
        Wek2d cel;
        public Sciezka scie;
        public RoIdzdo()
        {
            rodzaj = Typ_rozkazu.IDZDO;
        }

        public RoIdzdo(Wek2d pcel)
        {
            rodzaj = Typ_rozkazu.IDZDO;
            cel = pcel;

        }
    }

    class RoZnajdzdroge : Rozkaz
    {
        public Wek2d cel;
        public RoZnajdzdroge()
            {
            rodzaj = Typ_rozkazu.ZNAJDZDROGE;
            }
        public RoZnajdzdroge(Wek2d pcel)
        {
            rodzaj = Typ_rozkazu.ZNAJDZDROGE;
            cel = pcel;
        }
    }

    class RoStoj:Rozkaz
    {
        public RoStoj()
        {
            rodzaj = Typ_rozkazu.STOJ;
        }

    }
    class RoKop:Rozkaz
    {
        public Wek2d cel;
        public RoKop()
        {
            rodzaj = Typ_rozkazu.KOP;
        }
        public RoKop(Wek2d pcel)
        {
            rodzaj = Typ_rozkazu.KOP;
            cel = pcel;
        }
        public override string ToString()
        {
            string tstr = "rozkaz kop "+cel.ToString() ;
            return
                tstr;
        }
    }
    class RoPodnies:Rozkaz
    {
        public RoPodnies()
        {
            rodzaj = Typ_rozkazu.PODNIES;
        }
    }
}
