using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheHunt.Model;

namespace TheHunt
{
    public partial class Map : Form
    {
        private List<FieldObject> objects = new List<FieldObject>();

        public Map()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Red);
            for (int i = 0; i < objects.Count; i++)
            {
                FieldObject wall = objects[i];
                Rectangle rect2 = new Rectangle(wall.x, wall.y, 100, 100);
                g.DrawRectangle(pen, rect2);
            }
        }

        private void Map_Load(object sender, EventArgs e)
        {

        }

        private void Map_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
