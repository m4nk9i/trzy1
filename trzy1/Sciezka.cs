using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trzy1
{
    /// <summary>
    /// droga wyznaczona miedzy dwoma miejscami
    /// </summary>
    class Sciezka
    {
        public List<Wek2d> ktoredy;
        /// <summary>
        /// domyslny konstruktor
        /// </summary>
        public Sciezka()
        {
            ktoredy = new List<Wek2d>();
        }
        /// <summary>
        /// wyspiuje do stringa polozenia kolejnych kafelkow drogi
        /// </summary>
        /// <returns>string z polozeniami</returns>
        public override string ToString()
        {
            string str = "";
            foreach(Wek2d kaf in ktoredy)
            {
                str += kaf.ToString() + "\r\n";
            }
            return str;
        }
        
    }

}
