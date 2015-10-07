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
        //variabelenn
        public int x = 0;
        public int y = 0;

        public Map()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //roep base onpaint aan!
            base.OnPaint(e);


            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Red);
            for (int x = 0; x < this.Width; x += 20)
            {
                Rectangle rect = new Rectangle(x, y, 20, 20);
                g.DrawRectangle(pen, rect);
                if (x > this.Width)
                {
                    x = 0;
                }
                for (int y = 0; y < this.Height; y += 20)
                {
                    Rectangle rect2 = new Rectangle(x, y, 20, 20);
                    g.DrawRectangle(pen, rect2);
                }
            }




        }

        
    }
}
