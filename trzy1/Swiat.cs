using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trzy1
{
    class Swiat
    {

        public static Zaloga postaci;
        public static Zbiornik przedmioty;
        public static StrRoslina[] gatunkiRoslin;
        public static Mapa mapaswiata;

        static Swiat()
        {
            postaci = new Zaloga();
            przedmioty = new Zbiornik();
         //   przedmioty.gatroslin = gatunkiRoslin;
        }

        static void Tabela_roslin()
        {

            gatunkiRoslin = new StrRoslina[4];

            gatunkiRoslin[0].nazwa = "proto-truskawka";
            gatunkiRoslin[0].energia = 10;
            gatunkiRoslin[0].czas_wzrostu = 3;

            gatunkiRoslin[1].nazwa = "jablko";
            gatunkiRoslin[1].energia = 10;
            gatunkiRoslin[1].czas_wzrostu = 3;

            gatunkiRoslin[2].nazwa = "swliwka";
            gatunkiRoslin[2].energia = 10;
            gatunkiRoslin[2].czas_wzrostu = 3;

            gatunkiRoslin[3].nazwa = "banan";
            gatunkiRoslin[3].energia = 10;
            gatunkiRoslin[3].czas_wzrostu = 3;

        }

        public void InitRzeczy()
        {
            Tabela_roslin();
            InitRoslin();
        }

        public void InitRoslin()
        {
            
            for (int i=0;i<10;i++)
            {
                Roslina roslina = new Roslina();
                roslina.poz.x = i+2;
                roslina.poz.y = 2;
                roslina.wiek = 1;
                roslina.gatunek = 0;
               // roslina.gatroslin = gatunkiRoslin;

                przedmioty.Dodaj(roslina);
            }

        }

        public void InitPostaci()
        {
            Postac glowny = new Postac();
            Zbiornik plecak_glownego = new Zbiornik();
            Roslina roslina = new Roslina();
            Rzecz bron = new Rzecz();
            roslina.gatunek = 0;
            plecak_glownego.Dodaj(roslina);
            roslina = new Roslina();
            roslina.gatunek = 1;
            plecak_glownego.Dodaj(roslina);
            glowny.nazwa = "glowny";
            glowny.plecak = plecak_glownego;
            glowny.poz.x = 4;
            glowny.poz.y = 5;
            postaci.Dodaj(glowny);

        }

        public void WypiszPostaci()
        {
            //postaci.Wypisz();
            System.Diagnostics.Debug.WriteLine(postaci.ToString());
            System.Diagnostics.Debug.WriteLine(przedmioty.ToString());
        }

        public string GetPostaciStr()
        {
            return (postaci.ToString());
        }

        public string GetPrzedmiotyStr()
        {
            return (przedmioty.ToString());
        }

        public void InitMapy()
        {
            mapaswiata = new Mapa();
            mapaswiata.kafeleks = new Kafelek[16,16];

            for (int i = 0; i < 16; i++)
            
                for (int j = 0; j < 16; j++)
                {
                    Kafelek kaf = new Kafelek();
                    kaf.typ = Typ_kafla.TRAWA;
                    if ((i>7)&&(j>7)) kaf.typ = Typ_kafla.ZIEMIA;
                    if ((i==0)||(i==15)||(j==0)||(j==15)) kaf.typ = Typ_kafla.SCIANA;
                    mapaswiata.kafeleks[i, j] = kaf;
                }

            
        }

    }
}
