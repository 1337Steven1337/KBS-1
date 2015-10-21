using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheHunt.Model;

namespace TheHunt.Designer
{
    public partial class Items : Form
    {
        private List<Obstacle> fieldObjects = new List<Obstacle>();
        private Model.Player player = new Model.Player();
        private string mode = "";
        private object active = null;
        private Form form;
        
        public Items(Form Designform)
        {
            InitializeComponent();
            this.form = Designform;
        }
    
        private void Items_Load(object sender, EventArgs e)
        {

            this.loadObjects();
            this.Location = new System.Drawing.Point(form.Location.X + (int)(form.Size.Width), form.Location.Y);
            this.Size = new Size((int)(form.Size.Width * 0.25),form.Size.Height);

            for (int i = 0; i < fieldObjects.Count; i++)
            {
                Obstacle item = fieldObjects[i];
                PictureBox box = new PictureBox();
                PictureBox box2 = new PictureBox();


                box2.Click += Item_Click;
                box2.Tag = "Player-" + i;
                box2.Image = Properties.Resources.brockSprite1;
                box2.SizeMode = PictureBoxSizeMode.StretchImage;
                box2.Size = new Size(40,60);
                box.Click += Item_Click;
                box.Tag = "FieldObject-" + i;
                box.Image = item.getImage();
                flowLayout.Controls.Add(box);
                flowLayout.Controls.Add(box2);
            }           
        }

        private void Item_Click(object sender, EventArgs e)
        {
            PictureBox s = (PictureBox)sender;
            string[] parts = s.Tag.ToString().Split('-');
            this.mode = parts[0];

            if (this.mode == "FieldObject")
            {
                this.active = fieldObjects[int.Parse(parts[1])];
            }

            if (this.mode == "Player")
            {
                this.active = player;
            }
        }

        private void loadObjects()
        {
            Obstacle wall = new Obstacle();
            wall.x = wall.y = 1;
            this.fieldObjects.Add(wall);
        }

        internal bool isSelected()
        {
            return this.active != null;
        }

        internal string getMode()
        {
            return mode;
        }

        internal T getActive<T>()
        {
            return (T)active;
        }
    }
}
