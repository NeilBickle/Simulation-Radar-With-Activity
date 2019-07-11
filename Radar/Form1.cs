using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;


namespace Radar
{
    public partial class Form1 : Form
    {
        
        Timer Time = new Timer();

        int WIDTH = 300, HEIGHT = 300, HAND = 150, CirWIDTH = 25, CirHEIGHT = 25;

        int k;
        int jg, kj;
        int hb, iu;
        int b, c;

        int yf, hg, dan = 20;

        Bitmap bmpImg;
        Pen D;
        Graphics h;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

          
            
            

            bmpImg = new Bitmap(WIDTH + 1, HEIGHT + 1);

            this.BackColor = Color.Black;

            jg = WIDTH / 2;
            kj = HEIGHT / 2;
            hb = CirWIDTH / 2;
            iu = CirHEIGHT / 2;

            k = 0;

            Time.Interval = 5;
            Time.Tick += new EventHandler(this.Time_Tick);
            Time.Start();

        }

        private void Time_Tick(object sender, EventArgs e)
        {
            D = new Pen(Color.Green, 1f);

            h = Graphics.FromImage(bmpImg);

            int tu = (k - dan) % 360;

            if (k >= 0 && k <= 180)
            {
                b = jg + (int)(HAND * Math.Sin(Math.PI * k / 180));
                c = kj - (int)(HAND * Math.Cos(Math.PI * k / 180));
            }
            else
            {
                b = jg - (int)(HAND * -Math.Sin(Math.PI * k / 180));
                c = kj - (int)(HAND * Math.Cos(Math.PI * k / 180));
            }
            if (tu >= 0 && tu <= 180)
            {
                yf = jg + (int)(HAND * Math.Sin(Math.PI * tu / 180));
                hg = kj - (int)(HAND * Math.Cos(Math.PI * tu / 180));
            }
            else
            {
                yf = jg - (int)(HAND * -Math.Sin(Math.PI * tu / 180));
                hg = kj - (int)(HAND * Math.Cos(Math.PI * tu / 180));
            }

            h.DrawEllipse(D, 0, 0, WIDTH, HEIGHT);
            h.DrawEllipse(D, 80, 80, WIDTH - 160, HEIGHT - 160);

            h.DrawEllipse(D, 60, 60, CirWIDTH, CirHEIGHT);
            h.DrawEllipse(D, 60, 60, CirWIDTH - 0, CirHEIGHT - 0);

            h.DrawLine(D, new Point(jg, 0), new Point(jg, HEIGHT));
            h.DrawLine(D, new Point(0, kj), new Point(WIDTH, kj));

            h.DrawLine(new Pen(Color.Black, 1f), new Point(jg, kj), new Point(yf, hg));
            h.DrawLine(D, new Point(jg, kj), new Point(b, c));

            pictureBox1.Image = bmpImg;

            D.Dispose();
            h.Dispose();

            k++;
            if (k == 360)
            {
                k = 0;
            }

            if (k == 35 || k == 240)
            {
                SoundPlayer pley = new SoundPlayer();
                pley.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\sonar_ping.wav";
                pley.Play();
            }
        }
    }
}
