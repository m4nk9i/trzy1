using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trzy1
{
    class Sciezka
    {
        public List<Wek2d> ktoredy;
        public Sciezka()
        {
            ktoredy = new List<Wek2d>();
        }
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
