using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHunt
{
    public partial class Map : Form
    {
        public Map()
        {
            InitializeComponent();
            Paint += new PaintEventHandler(DrawRect);
            
        }

        public void DrawRect(object sender, PaintEventArgs e)
        {

            var screen = Screen.PrimaryScreen.Bounds;
            var width = screen.Width / 100;
            var height = screen.Height / 100;


            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.Red);
            Rectangle rect = new Rectangle(10, 10, height, width);
            g.FillRectangle(brush, rect);
            //lol23
        }

    }
}
