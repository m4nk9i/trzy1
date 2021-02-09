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

    
    class Rzecz
    {
        public Wek2d poz=new Wek2d();
        public Typ_rzeczy typ;
        public Rzecz()
        {
            poz.x = 0;
            poz.y = 0;
            typ = Typ_rzeczy.NIEZNANE;

        }
        public void Wypisz()
        {
                System.Diagnostics.Debug.WriteLine("rzecz "+typ+" "+poz.ToString());
        }
        public override string ToString()
        {
            return ("rzecz "+typ+" "+poz.ToString());
        }
    }
    class Roslina : Rzecz
    {
        public Single wiek;
        public UInt16 gatunek;
        //public Swiat swiat;
     
        public Roslina()
        {
            typ = Typ_rzeczy.ROSLINA;
            wiek = 0;
            gatunek = 0;

        }

        public override string ToString()
        {
            return (base.ToString() + " wiek " + wiek + " gatunek " + Swiat.gatunkiRoslin[gatunek].nazwa);
        }
    }
}