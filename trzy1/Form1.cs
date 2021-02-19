using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trzy1
{




    public partial class Form1 : Form
    {
        Graphics graf,tgraf;
        public List<ObrazOwoca> obrazkiowocow;
        public List<Image> obrazkimapy,obrazkiludzia;
        Bitmap bm;
        Wek2d myszku;


        public void ruszGlownego(int px,int py)
        {
            Wek2d pozglownego = Swiat.postaci.czlonkowie[0].poz;
            if (Swiat.mapaswiata.kafeleks[(int)(pozglownego.x)+px,(int)pozglownego.y+py].typ==Typ_kafla.TRAWA)
            {
                pozglownego.x += px;
                pozglownego.y += py;
                Swiat.postaci.czlonkowie[0].Podnies(pozglownego);
            }
            rysuj();
        }

        public void ustawObrazkiOwocow()    //potem to bedzie czytane z pliku.
        {
            ObrazOwoca tobr = new ObrazOwoca();
            obrazkiowocow = new List<ObrazOwoca>();
            tobr.obraz[0] = Properties.Resources.owoc1_1;
            tobr.obraz[1] = Properties.Resources.owoc1_2;
            tobr.obraz[2] = Properties.Resources.owoc1_3;
            tobr.obraz[3] = Properties.Resources.owoc1_4;
            obrazkiowocow.Add(tobr);

            obrazkiowocow = new List<ObrazOwoca>();
            tobr.obraz[0] = Properties.Resources.owoc1_1;
            tobr.obraz[1] = Properties.Resources.owoc1_2;
            tobr.obraz[2] = Properties.Resources.owoc1_3;
            tobr.obraz[3] = Properties.Resources.owoc1_4;
            obrazkiowocow.Add(tobr);

            obrazkiowocow = new List<ObrazOwoca>();
            tobr.obraz[0] = Properties.Resources.owoc1_1;
            tobr.obraz[1] = Properties.Resources.owoc1_2;
            tobr.obraz[2] = Properties.Resources.owoc1_3;
            tobr.obraz[3] = Properties.Resources.owoc1_4;
            obrazkiowocow.Add(tobr);

            obrazkiowocow = new List<ObrazOwoca>();
            tobr.obraz[0] = Properties.Resources.owoc1_1;
            tobr.obraz[1] = Properties.Resources.owoc1_2;
            tobr.obraz[2] = Properties.Resources.owoc1_3;
            tobr.obraz[3] = Properties.Resources.owoc1_4;
            obrazkiowocow.Add(tobr);


        }
        public void ustawObrazkiMapy()
        {
            Image im;
            obrazkimapy = new List<Image>();

            im = Properties.Resources.trawa;
            obrazkimapy.Add(im);
            im = Properties.Resources.ziemia;
            obrazkimapy.Add(im);
            im = Properties.Resources.mur;
            obrazkimapy.Add(im);
        }

        public void ustawObrazkiLudzia()
        {
            Image im;
            obrazkiludzia = new List<Image>();

            im = Properties.Resources.postac1;
            obrazkiludzia.Add(im);
        }

        public Form1()
        {
            
            InitializeComponent();
            ustawObrazkiOwocow();
            ustawObrazkiMapy();
            ustawObrazkiLudzia();
            graf = panel1.CreateGraphics();
            Program.ziemia.InitRzeczy();
            Program.ziemia.InitPostaci();
            Program.ziemia.InitMapy();
            bm = new Bitmap(panel1.Width, panel1.Height);
            
            tgraf = Graphics.FromImage(bm);
            myszku = new Wek2d();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.ziemia.WypiszPostaci();
            textBox1.Text += Program.ziemia.GetPostaciStr();
            textBox1.Text += Program.ziemia.GetPrzedmiotyStr();

        }

        private void rysujPrzedmioty()
        {
            foreach (Rzecz rz in Swiat.przedmioty.zawartosc)
            {
                if (rz.typ == Typ_rzeczy.ROSLINA)
                {
                    tgraf.DrawImage(obrazkiowocow[((Roslina)(rz)).gatunek].obraz[0], (rz.poz.x) * 32, (rz.poz.y) * 32);
                }
            }
        }

        private void rysujMape()
        {
            for(int i=0;i<16;i++)
                for (int j=0;j<16;j++)
                {
                    switch (Swiat.mapaswiata.kafeleks[i,j].typ)
                    {
                        case Typ_kafla.SCIANA:
                            
                                tgraf.DrawImage(obrazkimapy[2],i*32,j*32);
                                break;
                       case Typ_kafla.ZIEMIA:
                                tgraf.DrawImage(obrazkimapy[1],i * 32,j * 32);
                                break;
                        case Typ_kafla.TRAWA:
                           tgraf.DrawImage(obrazkimapy[0], i * 32, j * 32);
                            break;

                    }

                }
        }

        private void rysujPostacie()
        {
            foreach(Postac po in Swiat.postaci.czlonkowie)
            {
                tgraf.DrawImage(obrazkiludzia[0], po.poz.x * 32, po.poz.y * 32);
            }
        }

        private void rysujSciezke(Sciezka sc)
        {
            if (sc.ktoredy.Count > 0)
            {
                Wek2d pun = new Wek2d(sc.ktoredy[0].x, sc.ktoredy[0].y);
                foreach (Wek2d ka in sc.ktoredy)
                {
                    tgraf.DrawLine(Pens.Red, pun.x * 32 + 16, pun.y * 32 + 16, ka.x * 32 + 16, ka.y * 32 + 16);
                    pun.y = ka.y;
                    pun.x = ka.x;

                }
            }
        }


        private void rysujSciezki()
        {
            if (Swiat.postaci.czlonkowie[0].rozkazy.Count > 0)
            {
                if (Swiat.postaci.czlonkowie[0].rozkazy[0].rodzaj == Typ_rozkazu.IDZDO)
                {
                    rysujSciezke(((RoIdzdo)(Swiat.postaci.czlonkowie[0].rozkazy[0])).scie);
                }
            }
        }
        private void RysujUI()
        {
            tgraf.DrawRectangle(Pens.Yellow, myszku.x * 32, myszku.y * 32, 32, 32);
        }

        private void rysuj()
        {
           // graf.Clear(Color.White);
            rysujMape();
            rysujPrzedmioty();
            rysujPostacie();
            rysujSciezki();
            RysujUI();

            graf.DrawImage(bm, new Point(0, 0));

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            rysuj();


        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ruszGlownego(0, -1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ruszGlownego(0, 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ruszGlownego(1, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //Wek2d mpos = new Wek2d(e.X / 32.0f, e.Y / 32.0f);
            //Sciezka sc = new Sciezka();
            
            RoIdzdo ro1 = new RoIdzdo(myszku);
            //Swiat.postaci.czlonkowie[0].sciezka = Swiat.ZnajdzSciezke(Swiat.postaci.czlonkowie[0].poz, myszku);
            ro1.scie = Swiat.ZnajdzSciezke(Swiat.postaci.czlonkowie[0].poz, myszku);
            RoStoj ro3 = new RoStoj();

            switch (Swiat.mapaswiata.kafeleks[(int)myszku.x, (int)myszku.y].typ)
            {
                case Typ_kafla.TRAWA:
                    RoPodnies ro2 = new RoPodnies();

                    Swiat.postaci.czlonkowie[0].rozkazy.Clear();
                    Swiat.postaci.czlonkowie[0].rozkazy.Add(ro1);
                    Swiat.postaci.czlonkowie[0].rozkazy.Add(ro2);
                    //Swiat.postaci.czlonkowie[0].rozkazy.Add(ro3);
                    break;
                case Typ_kafla.ZIEMIA:
                    //Wek2d pk = new Wek2d();
                    RoKop ro4 = new RoKop(new Wek2d(myszku));
                    RoZnajdzdroge ro5 = new RoZnajdzdroge(new Wek2d(myszku));
                    //ro5.scie=Swiat.ZnajdzSciezke()
                    Swiat.postaci.czlonkowie[0].rozkazy.Clear();
                    Swiat.postaci.czlonkowie[0].rozkazy.Add(ro1);
                    Swiat.postaci.czlonkowie[0].rozkazy.Add(ro4);
                    Swiat.postaci.czlonkowie[0].rozkazy.Add(ro5);
                   // Swiat.postaci.czlonkowie[0].rozkazy.Add(ro3);
                    break;

                case Typ_kafla.SCIANA:
                    Swiat.postaci.czlonkowie[0].rozkazy.Clear();
                    Swiat.postaci.czlonkowie[0].rozkazy.Add(ro1);
                    //Swiat.postaci.czlonkowie[0].rozkazy.Add(ro3);
                    break;


            }
            rysuj();
            textBox1.Text += Swiat.postaci.czlonkowie[0].ListaRozkazow();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Swiat.Wykonaj();
            rysuj();
        }

        private void button6_Click(object sender, EventArgs e)
        {
         //   textBox1.Text += Swiat.postaci.czlonkowie[0].sciezka.ToString();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          //  rysuj();
           // e.Graphics.CopyFromScreen(new Point(10, 10), new Point(20, 20), new Size(70, 70));

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            myszku.x = e.X / 32;
            myszku.y = e.Y / 32;
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text+=Swiat.postaci.czlonkowie[0].ListaRozkazow();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ruszGlownego(-1, 0);
        }
    }


    public class ObrazOwoca
    {
        public Image[] obraz;
        public ObrazOwoca()
        {
            obraz = new Image[4];
        }

    }
}
