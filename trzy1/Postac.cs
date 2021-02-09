using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trzy1
{
    class Postac
    {
        public Wek2d poz=new Wek2d();
        public UInt16 typ;
        public Zbiornik plecak;
        public String nazwa;
        public Postac()
        {
            poz.x = 0;
            poz.y = 0;
            typ = 0;
            
        }
        public void Rysuj()
        {

        }

        public override string ToString()
        {
            return ("postac "+nazwa+" +["+poz.ToString()+"]\r\nplecak:\r\n"+plecak.ToString());
        }

        public void Wypisz()
        {
            System.Diagnostics.Debug.WriteLine("postac "+nazwa);
            plecak.Wypisz();
        }
        public void Podnies(Wek2d gdzie)
        {
            
            for(Rzecz co=Swiat.przedmioty.znajdz(gdzie); co!=null; co = Swiat.przedmioty.znajdz(gdzie))
                {
                plecak.Dodaj(co);
                Swiat.przedmioty.Usun(co);

            }
        }

    }
}
