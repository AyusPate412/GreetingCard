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
using System.Media;

//24 April, 2024
//Greeting Card
//Ayush Patel
namespace GreetingCard
{
    public partial class Greetings : Form
    {
        // creates different color pens
        Pen whitePen = new Pen(Color.White, 1);

        // creates a Yellow brush
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

        // sets up the font, size and style
        Font drawFont = new Font("MV Boli", 42, FontStyle.Bold);
        Font drawFont2 = new Font("MV Boli", 20, FontStyle.Bold);

        //setup a new sound
        new SoundPlayer celebration = new SoundPlayer(Properties.Resources.dhol);
        new SoundPlayer fireworks = new SoundPlayer(Properties.Resources.fireworks);

        public Greetings()
        {
            InitializeComponent();
        }

        private void Greetings_Shown(object sender, EventArgs e)
        { 
            Graphics g = this.CreateGraphics();

            //Set background Color
            g.Clear(Color.Black);

            //Writes Happy Diwali
            g.DrawString("Happy", drawFont, yellowBrush, 315, 100);
            g.DrawString("Diwali", drawFont, yellowBrush, 315, 200);

            //Draw Wire
            g.DrawLine(whitePen, 0, 25, 1000, 25);

           //Draw Lights   
            for (int i = 0; i < 27; i++)
            {
                g.DrawEllipse(whitePen, 10 + i * 30, 25, 10, 20);
                g.FillEllipse(yellowBrush, 10 + i * 30, 25, 10, 20);
            }

            //Ballons
            for (int i = 0; i < 3; i++)
            {
                g.DrawEllipse(whitePen, 15 + i * 50, 300, 30, 50);
                g.FillEllipse(yellowBrush, 15 + i * 50, 300, 30, 50);
                g.DrawLine(whitePen, 30 + i * 50, 350, 80, 400);
            }

            //Creates another sets of ballons
            for (int i = 0; i < 3; i++)
            {
                g.DrawEllipse(whitePen, 200 + i * 50, 300, 30, 50);
                g.FillEllipse(yellowBrush, 200 + i * 50, 300, 30, 50);
                g.DrawLine(whitePen, 215 + i * 50, 350, 265, 400);
            }

            //creates another sets of ballons
            for (int i = 0; i < 3; i++)
            {
                g.DrawEllipse(whitePen, 600 + i * 50, 300, 30, 50);
                g.FillEllipse(yellowBrush, 600 + i * 50, 300, 30, 50);
                g.DrawLine(whitePen, 615 + i * 50, 350, 665, 400);
            }
        }

        private void Greetings_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            // creates random and creates a int flash
            Random rand = new Random();
            int flash = 0;
            int angle = 0;
            //flashes the lights different color 5 times
            while (flash < 5) {

                for (int i = 0; i < 27; i++)
                {
                    Color randomColor = Color.FromArgb(rand.Next(255), rand.Next(256), rand.Next(256));

                    g.DrawEllipse(whitePen, 10 + i * 30, 25, 10, 20);
                    g.FillEllipse(new SolidBrush(randomColor), 10 + i * 30, 25, 10, 20);
                    g.DrawLine(whitePen, 0, 25, 1000, 25);

                    //rotates happy diwali 
                    while (angle < 361)
                    {
                        g.Clear(Color.Black);
                        g.TranslateTransform(300, 150);
                        g.RotateTransform(0 + angle);
                        g.DrawString("Happy Diwali", drawFont, yellowBrush, -50, -50);
                        g.ResetTransform();

                        Thread.Sleep(200);
                        angle = angle + 45;
                    }
                }
                flash++;    
                Thread.Sleep(1000);
            }
            //ballon's y value
            int y = 300;

            //plays sounds 
            celebration.PlayLooping();
            fireworks.Play();

            //while loop to move the ballon up 
            while (y > - 250)
            {
                g.Clear(Color.Black);

                //moves the text and the ballons up
                for (int i = 0; i < 3; i++)
                {
                    g.DrawEllipse(whitePen, 15 + i * 50, y, 30, 50);
                    g.FillEllipse(yellowBrush, 15 + i * 50, y, 30, 50);
                    g.DrawLine(whitePen, 30 + i * 50, y + 50, 80, y + 120);

                    g.DrawEllipse(whitePen, 200 + i * 50, y, 30, 50);
                    g.FillEllipse(yellowBrush, 200 + i * 50, y, 30, 50);
                    g.DrawLine(whitePen, 215 + i * 50, y + 50, 265, y + 120);

                    g.DrawEllipse(whitePen, 600 + i * 50, y, 30, 50);
                    g.FillEllipse(yellowBrush, 600 + i * 50, y, 30, 50);
                    g.DrawLine(whitePen, 615 + i * 50, y + 50, 665, y + 120);

                    g.DrawString("Happy", drawFont, yellowBrush, 400, y);
                    g.DrawString("Diwali", drawFont, yellowBrush, 400, y + 100);

                    g.DrawString("From -", drawFont2, yellowBrush, 400, y + 200);
                    g.DrawString("Ayush Patel", drawFont2, yellowBrush, 400 + 100, y + 200);
                }
                Thread.Sleep(1);
                y = y - 4;
            }
            //stops the sound effect
            celebration.Stop();
            fireworks.Stop();
        }
    }
}
        