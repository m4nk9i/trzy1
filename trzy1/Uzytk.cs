using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trzy1
{
    class Wek2d
    {
        public float x, y;
        public override string ToString()
        {
            return ("poz ("+x.ToString()+" "+y.ToString()+")");
        }
    }

    class Zbiornik
    {
        public List<Rzecz> zawartosc;
 //       public StrRoslina[] gatroslin;
        public Zbiornik()
        {
            zawartosc = new List<Rzecz>();
        }
        public void Dodaj(Rzecz co)
        {
            zawartosc.Add(co);
        }

        public void Usun(Rzecz co)
        {
            zawartosc.Remove(co);
        }

        public void Wypisz()
        {
            foreach(Rzecz rz in zawartosc)
            {
                System.Diagnostics.Debug.WriteLine(rz.ToString());
      //          rz.Wypisz();

            }
        }

        public override string ToString()
        {
            string t_str = "";
            foreach(Rzecz rz in zawartosc)
            {
                t_str += rz.ToString()+"\r\n";
            }
            return t_str;
        }

        public Rzecz znajdz (Wek2d gdzie)
        {
            Rzecz t_co = null;
            foreach (Rzecz r in zawartosc)
            {
                if ((gdzie.x == r.poz.x) && (gdzie.y == r.poz.y)) t_co = r;
            }
            return t_co;
        }
    }

    class Zaloga
    {
        public List<Postac> czlonkowie;

        public Zaloga()
        {
            czlonkowie = new List<Postac>();
        }

        public void Dodaj(Postac kto)
        {
            czlonkowie.Add(kto);
        }

        public void Wypisz()
        {
            foreach (Postac po in czlonkowie)
            {
                //System.Diagnostics.Debug.WriteLine(po.ToString());
                po.Wypisz();

            }
        }
        public override string ToString()
        {
            string t_str="";
            foreach (Postac po in czlonkowie)
            {
                t_str += po.ToString()+"\r\n";
            }
            return t_str;
        }


    }
}
