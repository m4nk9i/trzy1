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

    /// <summary>
    /// kontener na obiekty, (np. plecak) implementowany przez liste obiektow.
    /// </summary>
    class Zbiornik
    {
        public List<Rzecz> zawartosc;
 //       public StrRoslina[] gatroslin;

            /// <summary>
            /// domyslny kontruktor
            /// </summary>
        public Zbiornik()
        {
            zawartosc = new List<Rzecz>();
        }
        /// <summary>
        /// dodaje rzecz do listy zbiornika
        /// </summary>
        /// <param name="co">jakie konkretnie obiekt dodajemy</param>
        public void Dodaj(Rzecz co)

        {
            zawartosc.Add(co);
        }
        /// <summary>
        /// usuwa rzecz ze zbiornika
        /// </summary>
        /// <param name="co">jaki konkretnie obiekt usuwa ze zbiornika, nie niszczy go.</param>
        public void Usun(Rzecz co)
        {
            zawartosc.Remove(co);
        }

        /// <summary>
        /// wypisuje na debug zawartosc zbiornika
        /// todo - do wywalenia.
        /// </summary>
        public void Wypisz()
        {
            foreach(Rzecz rz in zawartosc)
            {
                System.Diagnostics.Debug.WriteLine(rz.ToString());
      //          rz.Wypisz();

            }
        }
        /// <summary>
        /// wypisuje do stringa zawartosc zbirnika, oddziela znakami nowej linii
        /// </summary>
        /// <returns>string z zawartoscia zbiornika</returns>
        public override string ToString()
        {
            string t_str = "";
            foreach(Rzecz rz in zawartosc)
            {
                t_str += rz.ToString()+"\r\n";
            }
            return t_str;
        }

        /// <summary>
        /// znajduje zzecz w zbiorniku, wg polozenia
        /// </summary>
        /// <param name="gdzie">polozenia na mapie</param>
        /// <returns>wskaznik znalezionego obiektu, null jesli nie znalazlo</returns>
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


    /// <summary>
    /// lista postaci
    /// </summary>
    class Zaloga
    {
        public List<Postac> czlonkowie;
        /// <summary>
        /// domyslny konstruktor
        /// </summary>
        public Zaloga()
        {
            czlonkowie = new List<Postac>();
        }
        /// <summary>
        /// dodaje postac do listy
        /// </summary>
        /// <param name="kto">kogo ma dopisac</param>
        public void Dodaj(Postac kto)
        {
            czlonkowie.Add(kto);
        }


        /// <summary>
        /// wypisuje czlonkow na debug
        /// todo - usunac, zastapione przez ToString()
        /// </summary>
        public void Wypisz()
        {
            foreach (Postac po in czlonkowie)
            {
                //System.Diagnostics.Debug.WriteLine(po.ToString());
                po.Wypisz();

            }
        }
        /// <summary>
        /// zapisuje do stringa czlonkow listy
        /// </summary>
        /// <returns>string z czlonkami zalogi</returns>

        public override string ToString()
        {
            string t_str="";
            foreach (Postac po in czlonkowie)
            {
                t_str += po.ToString()+"\r\n";
            }
            return t_str;
        }

        /// <summary>
        /// przelicza wszystkich czlonkow zalogi - tj, wykonuje na nich rozne machinacje.
        /// </summary>
        public void Wykonaj()
        {
            foreach(Postac po in czlonkowie)
            {
                po.Wykonaj();
            }
        }

        public Postac Znajdz(Wek2d gdzie)
        {
            Postac t_po = null;
            foreach (Postac po in czlonkowie)
            {
                if ((gdzie.x == po.poz.x) && (gdzie.y == po.poz.y)) t_po = po;
            }
            return t_po;
        }

    }
}
