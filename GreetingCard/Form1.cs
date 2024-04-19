using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreetingCard
{
    public partial class Greetings : Form
    {
        public Greetings()
        {
            InitializeComponent();
        }

        private void Greetings_Shown(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            //Set background Color
            g.Clear(Color.LightBlue);

            Pen redPen = new Pen(Color.Red, 6);
            Pen bluePen = new Pen(Color.Blue, 6);
            Pen pinkPen = new Pen(Color.Pink, 1);
            Pen blackPen = new Pen(Color.Black, 1);

            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush redBrush = new SolidBrush(Color.MediumVioletRed);
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            SolidBrush pinkBrush = new SolidBrush(Color.LightPink);
            SolidBrush goldBrush = new SolidBrush(Color.Gold);

            Font drawFont = new Font("Arial", 42, FontStyle.Bold);


            //Writes Happy Diwali
            g.DrawString("Happy", drawFont, blueBrush, 315, 100);
            g.DrawString("Diwali", drawFont, blueBrush, 315, 200);

            //Draw Wire
            g.DrawLine(blackPen, 0, 25, 1000, 25);

           //Draw Lights   
            for (int i = 0; i < 27; i++)
            {
                g.DrawEllipse(pinkPen, 10 + i*30, 25, 10, 20);
                g.FillEllipse(pinkBrush, 10 + i * 30, 25, 10, 20);
            }

        }
    }
}
        

