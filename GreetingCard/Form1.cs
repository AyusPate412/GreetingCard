using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

//24 April, 2024
//Greeting Card
//Ayush Patel
namespace GreetingCard
{
    public partial class Greetings : Form
    {
        Pen pinkPen = new Pen(Color.Pink, 1);
        Pen blackPen = new Pen(Color.Black, 1);

        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush pinkBrush = new SolidBrush(Color.LightPink);

        Font drawFont = new Font("Arial", 42, FontStyle.Bold);

        public Greetings()
        {
            InitializeComponent();
        }

        private void Greetings_Shown(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            //Set background Color
            g.Clear(Color.LightBlue);

            //Writes Happy Diwali
            g.DrawString("Happy", drawFont, blueBrush, 315, 100);
            g.DrawString("Diwali", drawFont, blueBrush, 315, 200);

            //Draw Wire
            g.DrawLine(blackPen, 0, 25, 1000, 25);

           //Draw Lights   
            for (int i = 0; i < 27; i++)
            {
                g.DrawEllipse(pinkPen, 10 + i * 30, 25, 10, 20);
                g.FillEllipse(pinkBrush, 10 + i * 30, 25, 10, 20);
            }

            //Ballons
            for (int i = 0; i < 3; i++)
            {
                g.DrawEllipse(pinkPen, 15 + i * 50, 300, 30, 50);
                g.FillEllipse(pinkBrush, 15 + i * 50, 300, 30, 50);
                g.DrawLine(blackPen, 30 + i * 50, 350, 80, 400);
            }

            for (int i = 0; i < 3; i++)
            {
                g.DrawEllipse(pinkPen, 200 + i * 50, 300, 30, 50);
                g.FillEllipse(pinkBrush, 200 + i * 50, 300, 30, 50);
                g.DrawLine(blackPen, 200 + i * 50, 350, 280, 400);
            }
        }

        private void Greetings_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            Random rand = new Random();
            int flash = 0;

            while (flash < 2) {
                for (int i = 0; i < 27; i++)
                {
                    Color randomColor = Color.FromArgb(rand.Next(255), rand.Next(256), rand.Next(256));
                    g.FillEllipse(new SolidBrush(randomColor), 10 + i * 30, 25, 10, 20);
                }

                flash++;    
                Thread.Sleep(1000);
            }
            //ballon's y value
            int y = 300;

            //while loop to move the ballon up
            while (y > 0)
            {
                g.Clear(Color.LightBlue);
                for (int i = 0; i < 3; i++)
                {
                    g.DrawEllipse(pinkPen, 15 + i * 50, y, 30, 50);
                    g.FillEllipse(pinkBrush, 15 + i * 50, y, 30, 50);
                    g.DrawLine(blackPen, 30 + i * 50, y+50, 80, y+120);
                }
                Thread.Sleep(10);
                y--;

                for (int i = 0; i < 3; i++)
                {
                    g.DrawEllipse(pinkPen, 15 + i * 50, y, 30, 50);
                    g.FillEllipse(pinkBrush, 15 + i * 50, y, 30, 50);
                    g.DrawLine(blackPen, 30 + i * 50, y + 50, 80, y + 120);
                }
                Thread.Sleep(10);
                y--;

            }
        }
    }
}
        