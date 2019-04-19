using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics3
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics g;
        bool MouseClicked = false;
        public int x, y, r = 0;
        Color[] color = new Color[] { Color.Red, Color.Firebrick, Color.Gold, Color.Purple, Color.WhiteSmoke };
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            r += 5;
            int index = random.Next(0, color.Length - 1);
            Pen pen = new Pen(color[index], 3);
            g.DrawEllipse(pen, x - r, y - r, 2 * r, 2 * r);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if ( !MouseClicked )
            {
                x = e.Location.X;
                y = e.Location.Y;
                timer1.Start();
                MouseClicked = true;
            }
            else
            {
                timer1.Stop();
                MouseClicked = false;
            }
        }
    }
}
