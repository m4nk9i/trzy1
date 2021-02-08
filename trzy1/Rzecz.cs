using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trzy1
{
    enum Typ_rzeczy
    {
        NIEZNANE,
        BRON,
        ROSLINA
    }
    enum Typ_broni
    {
        NIEZNANE,
        NOZ,
        MIECZ,
        TARCZA
    }
    class Rzecz
    {
        Wek2d poz;
        public Typ_rzeczy typ;
        public Rzecz()
        {
            poz.x = 0;
            poz.y = 0;
            typ = Typ_rzeczy.NIEZNANE;

        }
      
    }
    class Roslina:Rzecz
    {
        Single wiek;
        public Roslina()
        {
            typ = Typ_rzeczy.ROSLINA;
            wiek = 0;

        }
    }
}