using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics2
{
    public partial class Form1 : Form
    {
        bool MouseClicked = false;
        public int x, y, r = 0;
        Color[] colors = new Color[] { Color.Red, Color.Gray, Color.Gold, Color.Green, Color.Blue };

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!MouseClicked)
            {
                x = e.Location.X;
                y = e.Location.Y;
                MouseClicked = true;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                MouseClicked = false;
            }
        }
        Random random = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            r += 10;
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int index = random.Next(0, colors.Length - 1);
            Pen pen = new Pen(colors[index], 4);
            e.Graphics.FillEllipse(pen.Brush, x - r, y - r, 2 * r, 2 * r);
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
