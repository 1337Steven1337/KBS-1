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
        private List<Npc> npcList = new List<Npc>();
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
            this.loadNpcs();
            this.Location = new System.Drawing.Point(form.Location.X + (int)(form.Size.Width), form.Location.Y);
            this.Size = new Size((int)(form.Size.Width * 0.25),form.Size.Height);

            for (int i = 0; i < fieldObjects.Count; i++)
            {
                Obstacle item = fieldObjects[i];
                PictureBox wallBox = new PictureBox();
                PictureBox player1Box = new PictureBox();
                PictureBox HBouncerBox = new PictureBox();
                PictureBox VBouncerBox = new PictureBox();

                wallBox.Click += Item_Click;
                wallBox.Tag = "FieldObject-" + i;
                wallBox.Image = item.getImage();


                player1Box.Click += Item_Click;
                player1Box.Tag = "Player-" + i;
                player1Box.Image = Properties.Resources.brockSprite1;
                player1Box.SizeMode = PictureBoxSizeMode.StretchImage;
                player1Box.Size = new Size(50,60);

                HBouncerBox.Click += Item_Click;
                HBouncerBox.Tag = "HBouncer-" + i;
                HBouncerBox.Image = Properties.Resources.H_bouncer;

                VBouncerBox.Click += Item_Click;
                VBouncerBox.Tag = "VBouncer-" + i;
                VBouncerBox.Image = Properties.Resources.V_bouncer;



                flowLayout.Controls.Add(wallBox);
                flowLayout.Controls.Add(player1Box);
                flowLayout.Controls.Add(HBouncerBox);
                flowLayout.Controls.Add(VBouncerBox);

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
            if (this.mode == "HBouncer")
            {
                npcList[int.Parse(parts[1])].type = Npc.Type.H_Bouncer;
                this.active = npcList[int.Parse(parts[1])];
            }
            if (this.mode == "VBouncer")
            {
                npcList[int.Parse(parts[1])].type = Npc.Type.V_Bouncer;
                this.active = npcList[int.Parse(parts[1])];
            }
        }

        private void loadObjects()
        {
            Obstacle wall = new Obstacle();
            wall.x = wall.y = 1;
            this.fieldObjects.Add(wall);
        }

        private void loadNpcs()
        {
            Npc npc = new Npc();
            this.npcList.Add(npc);
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
