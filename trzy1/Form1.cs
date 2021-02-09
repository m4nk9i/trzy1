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
        Graphics graf;
        public List<ObrazOwoca> obrazkiowocow;
        public List<Image> obrazkimapy,obrazkiludzia;


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
                    graf.DrawImage(obrazkiowocow[((Roslina)(rz)).gatunek].obraz[0], (rz.poz.x) * 32, (rz.poz.y) * 32);
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
                            
                                graf.DrawImage(obrazkimapy[2],i*32,j*32);
                                break;
                       case Typ_kafla.ZIEMIA:
                                graf.DrawImage(obrazkimapy[1],i * 32,j * 32);
                                break;
                        case Typ_kafla.TRAWA:
                            graf.DrawImage(obrazkimapy[0], i * 32, j * 32);
                            break;

                    }

                }
        }

        private void rysujPostacie()
        {
            foreach(Postac po in Swiat.postaci.czlonkowie)
            {
                graf.DrawImage(obrazkiludzia[0], po.poz.x * 32, po.poz.y * 32);
            }
        }

        private void rysuj()
        {
            graf.Clear(Color.White);
            rysujMape();
            rysujPrzedmioty();
            rysujPostacie();

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
