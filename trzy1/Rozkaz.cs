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
    /// <summary>
    /// bazowa klasa rozkazu.
    /// </summary>

    class Rozkaz
    {
        public Typ_rozkazu rodzaj = Typ_rozkazu.NIEZNANY;
    }
    /// <summary>
    /// RoIdzdo dziecdziczy po rozkaz. rozkaz przesuniecai postaci miedzy punktami
    /// </summary>
    class RoIdzdo:Rozkaz
    {
        Wek2d cel;
        public Sciezka scie;
        /// <summary>
        /// domyslny konstruktor
        /// </summary>
        public RoIdzdo()
        {
            rodzaj = Typ_rozkazu.IDZDO;
        }
        /// <summary>
        /// konstruktor z wyznaczeniem punktu docelowego
        /// </summary>
        /// <param name="pcel">punkt docelowy</param>
        public RoIdzdo(Wek2d pcel)
        {
            rodzaj = Typ_rozkazu.IDZDO;
            cel = pcel;

        }
    }
    /// <summary>
    /// RoZnajdzdroge dziedziczy z Rozkaz. Rozkaz odszukania drogi 
    /// </summary>
    class RoZnajdzdroge : Rozkaz
    {
        public Wek2d cel;
        /// <summary>
        /// domyslny kontruktor
        /// </summary>
        public RoZnajdzdroge()
            {
            rodzaj = Typ_rozkazu.ZNAJDZDROGE;
            }
        /// <summary>
        /// konstriktor ze wskazaniem celu.
        /// </summary>
        /// <param name="pcel">cel drogi</param>
        public RoZnajdzdroge(Wek2d pcel)
        {
            rodzaj = Typ_rozkazu.ZNAJDZDROGE;
            cel = pcel;
        }
    }

    /// <summary>
    /// RoStroj dziedziczy po rozkaz
    /// </summary>
    class RoStoj:Rozkaz
    {
        /// <summary>
        /// domyslny konstruktor
        /// </summary>
        public RoStoj()
        {
            rodzaj = Typ_rozkazu.STOJ;
        }

    }

    /// <summary>
    /// RoKop dziedzyczy po rozkaz. kopie w zadanym miejscu
    /// </summary>
    class RoKop:Rozkaz
    {
        public Wek2d cel;
        /// <summary>
        /// domyslny konstruktor
        /// </summary>
        public RoKop()
        {
            rodzaj = Typ_rozkazu.KOP;
        }
        /// <summary>
        /// konsktruktor ze wskazaniem kopania w okreslonym miejscu
        /// </summary>
        /// <param name="pcel">okreslone wspolrzedne kopania</param>
        public RoKop(Wek2d pcel)
        {
            rodzaj = Typ_rozkazu.KOP;
            cel = pcel;
        }
        /// <summary>
        /// wypsuje do stringa wpolrzedne kopania.
        /// </summary>
        /// <returns>string wpolrzednych kopania</returns>
        public override string ToString()
        {
            string tstr = "rozkaz kop "+cel.ToString() ;
            return
                tstr;
        }
    }
    /// <summary>
    /// rozkaz podniesienia dziedziczy z rozkaz
    /// </summary>
    class RoPodnies:Rozkaz
    {
        /// <summary>
        /// konstruktor domyslny
        /// </summary>
        public RoPodnies()
        {
            rodzaj = Typ_rozkazu.PODNIES;
        }
    }
}
