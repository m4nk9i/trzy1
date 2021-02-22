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
    /// <summary>
    /// najmniejszy kawalek mapy
    /// </summary>
    class Kafelek
    {
        public Typ_kafla typ;
    }

    /// <summary>
    /// mapa z akfelkow
    /// </summary>
    class Mapa
    {
        public Kafelek[,] kafeleks;
        /// <summary>
        /// domyslny konstruktor
        /// </summary>
        public Mapa()
        {

        }

    }
}
