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

            FieldObject w1 = new FieldObject(100, 100, FieldObject.Type.Wall);
            objects.Add(w1);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Red);
            for (int i = 0; i < objects.Count; i++)
            {
                FieldObject wall = objects[i];
                wall.draw(g);
            }
        }

        private void Map_Load(object sender, EventArgs e)
        {

        }
    }
}
