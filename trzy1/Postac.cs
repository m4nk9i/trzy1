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
    //    public Sciezka sciezka;
        public List<Rozkaz> rozkazy;
        public Postac()
        {
            poz.x = 0;
            poz.y = 0;
            typ = 0;
            //sciezka = new Sciezka();
            rozkazy = new List<Rozkaz>();
            
        }
        public void Rysuj()
        {

        }

        public void Wykonaj()
        {
            if (rozkazy.Count > 0)
            {
                switch (rozkazy[0].rodzaj)
                {
                    case Typ_rozkazu.IDZDO:
                        {
                            RoIdzdo roz1= (RoIdzdo)rozkazy[0];
                            //if (sciezka.ktoredy.Count > 0)
                            if (roz1.scie.ktoredy.Count > 0)
                                {
                                //Wek2d npoz = sciezka.ktoredy[0];
                                Wek2d npoz = roz1.scie.ktoredy[0];
                                if ((Swiat.mapaswiata.kafeleks[(int)npoz.x,(int)npoz.y].typ==Typ_kafla.SCIANA)
                                    || (Swiat.mapaswiata.kafeleks[(int)npoz.x, (int)npoz.y].typ == Typ_kafla.ZIEMIA))
                                {
                                    //sciezka.ktoredy.Clear();
                                    roz1.scie.ktoredy.Clear();
                                }
                                else
                                {
                                    poz = npoz;
                                    //sciezka.ktoredy.RemoveAt(0);
                                    roz1.scie.ktoredy.RemoveAt(0);
                                }
                            }
                            else
                            {
                                rozkazy.RemoveAt(0);
                            }
                        };
                        break;
                    case Typ_rozkazu.KOP:
                        {
                            
                            Wek2d kopp = ((RoKop)(rozkazy[0])).cel;
                            if (((poz.x-kopp.x)<=1) && ((kopp.x-poz.x)<=1) &&
                                ((poz.y - kopp.y) <= 1) && ((kopp.y - poz.y )<= 1))
                            {
                                Swiat.mapaswiata.kafeleks[(int)kopp.x, (int)kopp.y].typ = Typ_kafla.TRAWA;
                                rozkazy.RemoveAt(0);
                            }
                        };
                        break;
                    case Typ_rozkazu.STOJ:
                        { };
                        break;
                    case Typ_rozkazu.PODNIES:
                        {
                            Podnies(poz);
                        };
                        break;
                    case Typ_rozkazu.ZNAJDZDROGE:
                        {
                            RoIdzdo ro = new RoIdzdo();
                            ro.scie=Swiat.ZnajdzSciezke(poz, ((RoZnajdzdroge)(rozkazy[0])).cel);
                            rozkazy.RemoveAt(0);
                            rozkazy.Add(ro);
                        };
                        break;
                }
            }
        }

        public override string ToString()
        {
            return ("postac "+nazwa+" +["+poz.ToString()+"]\r\nplecak:\r\n"+plecak.ToString());
        }

        public string ListaRozkazow()
        {
            string tstr = "";
            foreach(Rozkaz ro in rozkazy)
            {
                tstr += ro.ToString() + "\r\n";
            }
            return tstr;
        }

        public void Wypisz()
        {
            System.Diagnostics.Debug.WriteLine("postac "+nazwa);
            plecak.Wypisz();
        }
        public void Podnies(Wek2d gdzie)
        {
            
            for(Rzecz co=Swiat.przedmioty.Znajdz(gdzie); co!=null; co = Swiat.przedmioty.Znajdz(gdzie))
                {
                plecak.Dodaj(co);
                Swiat.przedmioty.Usun(co);

            }
        }

    }
}
