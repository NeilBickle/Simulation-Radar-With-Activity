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
    public partial class FrmMain : Form
    {
         //Global Variables
        //New Timer Object
        Timer Time = new Timer();

            //Width, Height And Hand Measurements
        int WIDTH = 300, HEIGHT = 300, HAND = 150, CirWIDTH = 25, CirHEIGHT = 25;

        //Standard Ints
        int k;
        int jg, kj;
        int hb, iu;
        int b, c;

        int yf, hg, dan = 20;
      
        //Bitmap
        Bitmap bmpImg;
        //Pen
        Pen D;
        //Graphics
        Graphics h;
        Graphics E;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

          
            
            
            // New Bitmap Object
            bmpImg = new Bitmap(WIDTH + 1, HEIGHT + 1);

            //Changing The Background Colour
            this.BackColor = Color.Black;

            //Widths And Heights
            jg = WIDTH / 2;
            kj = HEIGHT / 2;
            hb = CirWIDTH / 2;
            iu = CirHEIGHT / 2;

            //Turn
            k = 0;

            //Time Method Starter
            Time.Interval = 5;
            Time.Tick += new EventHandler(this.Time_Tick);
            Time.Start();

        }

        private void Time_Tick(object sender, EventArgs e)
        {
            // Starting Each Of The Pen, Graphics And Solid Brush
            //Pen
            D = new Pen(Color.Green, 1f);
            //Graphics
            h = Graphics.FromImage(bmpImg);
            E = Graphics.FromImage(bmpImg);
            //SolidBrush
            SolidBrush FullBrush = new SolidBrush(Color.LightGreen);
            
            int tu = (k - dan) % 360;
            //IfAndElseStatements
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
            //Draw The Radar
            h.DrawEllipse(D, 0, 0, WIDTH, HEIGHT);
            h.DrawEllipse(D, 80, 80, WIDTH - 160, HEIGHT - 160);

            //Enter The Ellipse For The Dummy Entry On The Radar
            E.DrawEllipse(D, 60, 60, CirWIDTH, CirHEIGHT);
            E.DrawEllipse(D, 60, 60, CirWIDTH - 0, CirHEIGHT - 0);

            E.FillEllipse(FullBrush, 60, 60, CirWIDTH, CirHEIGHT);
            E.FillEllipse(FullBrush, 60, 60, CirWIDTH - 0, CirHEIGHT - 0);

            //DrawLines For The Radar
            h.DrawLine(D, new Point(jg, 0), new Point(jg, HEIGHT));
            h.DrawLine(D, new Point(0, kj), new Point(WIDTH, kj));

            h.DrawLine(new Pen(Color.Black, 1f), new Point(jg, kj), new Point(yf, hg));
            h.DrawLine(D, new Point(jg, kj), new Point(b, c));

            //Enter BMPImg In To Picture Box
            pictureBox1.Image = bmpImg;

            //Dispose Objects
            D.Dispose();
            h.Dispose();
            E.Dispose();

            //TurnManagement
            k++;
            if (k == 360)
            {
                k = 0;
            }

            //The Sound Effect Was Found Here Credit To Zedge: https://www.zedge.net/ringtone/e2892d25-1a2b-3868-af40-1f643576b330
            if (k == 60 || k == 251)
            {
                //Sound Effect
                SoundPlayer pley = new SoundPlayer();
                pley.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\sonar_ping.wav";
                pley.Play();
            }
        }
    }
}
