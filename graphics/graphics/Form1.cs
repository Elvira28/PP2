using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphics
{
    public class Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            Pen pen = new Pen(Color.Tomato, 7);
            Rectangle rectangle = new Rectangle(50, 100, 200, 200);
            graph.DrawArc(pen, rectangle, -180, -180);                       // arc

            Rectangle[] recs = new Rectangle[10];
            int x = 20, y = 20, h = 60, w = 45;
            for (int i = 0; i < 10; i++)
            {
                recs[i] = new Rectangle(x, y, h, w);
                h += 10;
                w += 10;
                x += 10;
                y += 10;
            }
            graph.DrawRectangles(pen, recs);                        //Array of rectangles
            HatchBrush hb = new HatchBrush(HatchStyle.Cross, Color.FloralWhite, Color.FromArgb(255, 255, 0, 0));
            graph.FillEllipse(hb, rectangle);

            graph.FillRectangle(hb, 0, 0, this.Width, this.Height);    // fill all the form

            // draw path - draws something from array of points
        }
    }
}
