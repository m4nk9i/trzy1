using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trzy1
{
    /// <summary>
    /// klasa postaci, przedmiotow i tego wszstiego
    /// </summary>
    class Swiat
    {

        public static Zaloga postaci;
        public static Zbiornik przedmioty;
        public static StrRoslina[] gatunkiRoslin;
        public static Mapa mapaswiata;

        /// <summary>
        /// konstruktor domyslny
        /// </summary>
        static Swiat()
        {
            postaci = new Zaloga();
            przedmioty = new Zbiornik();
         //   przedmioty.gatroslin = gatunkiRoslin;
        }

        /// <summary>
        /// przeliczenie postaci, przedmiotow itp
        /// </summary>
        public static void Wykonaj()
        {
            postaci.Wykonaj();
        }

        /// <summary>
        /// inicjacja tabeli roslin, 
        /// todo - zrobic z pliku
        /// </summary>
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

        /// <summary>
        /// szuka ssciezki miedzuy punktami
        /// todo- kiepski algorytm poprawic na A* czy cos
        /// </summary>
        /// <param name="pocz">punkt startowy</param>
        /// <param name="koniec">pnkt koncowy</param>
        /// <returns>zwraca sciezke</returns>
        public static Sciezka ZnajdzSciezke(Wek2d pocz, Wek2d koniec)
        {
            Sciezka tsciezka = new Sciezka();
            if (pocz.x<koniec.x)
            {
                for (int i=(int)pocz.x;i<=koniec.x;i++)
                {
                    Wek2d kaf = new Wek2d(i,(int)pocz.y);
                    tsciezka.ktoredy.Add(kaf);

                }
            }
            if (pocz.x>koniec.x)
            {
                for (int i=(int)pocz.x;i>=koniec.x; i--)
                {
                    Wek2d kaf = new Wek2d(i, (int)pocz.y);
                    tsciezka.ktoredy.Add(kaf);
                }
            }

            if (pocz.y < koniec.y)
            {
                for (int i = (int)pocz.y; i <= koniec.y; i++)
                {
                    Wek2d kaf = new Wek2d((int)koniec.x, i);
                    tsciezka.ktoredy.Add(kaf);
                }
            }
            if (pocz.y > koniec.y)
            {
                for (int i = (int)pocz.y; i >= koniec.y; i--)
                {
                    Wek2d kaf = new Wek2d((int)koniec.x,i);
                    tsciezka.ktoredy.Add(kaf);
                }
            }

            return tsciezka;
        }

        /// <summary>
        /// ustawienie pierwotne rzeczy
        /// </summary>

        public void InitRzeczy()
        {
            Tabela_roslin();
            InitRoslin();
        }

        /// <summary>
        /// pierwotne ustawienie roslinek
        /// todo - zrobic z pliku
        /// </summary>

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

        /// <summary>
        /// ustawienie pierwotne postaci
        /// todo- zrobic z pliku
        /// </summary>
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
           // glowny.sciezka = ZnajdzSciezke(glowny.poz, new Wek2d(6, 7));
            postaci.Dodaj(glowny);


            //dodatkowy ludzik

            glowny = new Postac();
            plecak_glownego = new Zbiornik();
            glowny.plecak = plecak_glownego;
            glowny.poz.x = 1;
            glowny.poz.y = 1;
            postaci.Dodaj(glowny);

        }


        /// <summary>
        /// wypisuje postaci na debug
        /// todo- wywalic
        /// </summary>
        public void WypiszPostaci()
        {
            //postaci.Wypisz();
            System.Diagnostics.Debug.WriteLine(postaci.ToString());
            System.Diagnostics.Debug.WriteLine(przedmioty.ToString());
        }

        /// <summary>
        /// zwraca to stringu liste postaci
        /// </summary>
        /// <returns>string z lista postaci</returns>

        public string GetPostaciStr()
        {
            return (postaci.ToString());
        }

        /// <summary>
        /// zwraca to stringu liste przedmiotow
        /// </summary>
        /// <returns>string z lista przedmiotow</returns>
        public string GetPrzedmiotyStr()
        {
            return (przedmioty.ToString());
        }

        /// <summary>
        /// ustawienia pierwotne mapy
        /// todo- z pliku
        /// </summary>
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
