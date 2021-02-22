using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trzy1
{
    /// <summary>
    /// prosta klasa ze wspolrzednymi 2D 
    /// </summary>
    class Wek2d
    {
        public float x, y;
        /// <summary>
        /// konstruktor domslny
        /// </summary>
        public Wek2d()
        {
            x = 0;
            y = 0;
        }
        /// <summary>
        /// konstruktor z ustawieniem polozenia
        /// </summary>
        /// <param name="gx">wspolrzedna x jako float</param>
        /// <param name="gy">wspolrzedna y jako float</param>
        public Wek2d(float gx,float gy)
        {
            x = gx;
            y = gy;
        }
        /// <summary>
        /// konstruktor z ustawieniem polozenia
        /// </summary>
        /// <param name="gx">wspolrzedna x jako int</param>
        /// <param name="gy">wspolrzedna y jako int</param>
        public Wek2d(int gx,int gy)
        {
            x = gx;
            y = gy;
        }
        /// <summary>
        /// konstruktor z ustawieniem polozenia
        /// </summary>
        /// <param name="frr">istniejaca zmienna z ktorej kopijemy wspolrzedne</param>
        public Wek2d (Wek2d frr)
        {
            x = frr.x;
            y = frr.y;
        }
        /// <summary>
        /// wyspiuje polozenie do stringa
        /// </summary>
        /// <returns>string ze wspolrzednymi</returns>
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

        public Rzecz Znajdz (Wek2d gdzie)
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

        public void Wykonaj()
        {
            foreach(Postac po in czlonkowie)
            {
                po.Wykonaj();
            }
        }

    }
}
