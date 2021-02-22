using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trzy1
{
    public enum Typ_rzeczy
    {
        NIEZNANE,
        BRON,
        ROSLINA
    }
    public enum Typ_broni
    {
        NIEZNANE,
        NOZ,
        MIECZ,
        TARCZA
    }
    


    public struct StrRoslina
    {
        public String nazwa;
        public UInt16 energia;
        public UInt16 czas_wzrostu;
    }

    /// <summary>
    /// rozne obiekty, baza dla warzyw broni itp.
    /// </summary>
    class Rzecz
    {

        public Wek2d poz=new Wek2d();
        public Typ_rzeczy typ;

        /// <summary>
        /// domyslny konstruktor
        /// </summary>
        public Rzecz()
        {
            poz.x = 0;
            poz.y = 0;
            typ = Typ_rzeczy.NIEZNANE;

        }
        /// <summary>
        /// wyspiuje na Debug parametru obiektu
        /// todo - usunac, zasstapianoe przez ToString()
        /// </summary>
        public void Wypisz()
        {
                System.Diagnostics.Debug.WriteLine("rzecz "+typ+" "+poz.ToString());
        }
        /// <summary>
        /// wypisuje do stringa wlasciwosci obiektu
        /// </summary>
        /// <returns>string z typem i polozeniem rzeczy</returns>

        public override string ToString()
        {
            return ("rzecz "+typ+" "+poz.ToString());
        }
    }
    /// <summary>
    /// rosclina dzeidziczy z rzecz
    /// </summary>
    class Roslina : Rzecz
    {
        public Single wiek;
        public UInt16 gatunek;
        //public Swiat swiat;
        /// <summary>
        /// domyslny konstruktor
        /// </summary>
     
        public Roslina()
        {
            typ = Typ_rzeczy.ROSLINA;
            wiek = 0;
            gatunek = 0;

        }
        /// <summary>
        /// zapisuje do string paramatry rosliny
        /// </summary>
        /// <returns>string z polozeniem, typem, gatunkiem itp.</returns>
        public override string ToString()
        {
            return (base.ToString() + " wiek " + wiek + " gatunek " + Swiat.gatunkiRoslin[gatunek].nazwa);
        }
    }
}