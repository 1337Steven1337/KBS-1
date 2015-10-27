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
    public partial class Toolbox : Form
    {
        private Obstacle fieldObjects = new Obstacle();
        private Powerups powerUps = new Powerups();
        private Model.Player player = new Model.Player();
        private Npc npc = new Npc();
        private string mode = "";
        private object active = null;
        private Form form;
        private object selectedObject;

        public Toolbox(Form Designform)
        {
            InitializeComponent();
            this.form = Designform;
            this.AutoScroll = true;
            this.HorizontalScroll.Enabled = false;
            this.HorizontalScroll.Visible = false;
            this.VerticalScroll.Enabled = false;
            this.VerticalScroll.Visible = false;
        }

        private void Items_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(form.Location.X + (int)(form.Size.Width), form.Location.Y);
            this.Size = new Size((int)(form.Size.Width * 0.25), form.Size.Height);          

            PictureBox wallBox = new PictureBox();
            PictureBox PURunBox = new PictureBox();
            PictureBox PUScore = new PictureBox();

            PictureBox player1Box = new PictureBox();
            PictureBox HBouncerBox = new PictureBox();
            PictureBox VBouncerBox = new PictureBox();
            PictureBox enemyBox = new PictureBox();

            wallBox.Click += Item_Click;
            wallBox.Tag = "FieldObject";
            wallBox.Image = Properties.Resources.wall;

            PURunBox.Click += Item_Click;
            PURunBox.Tag = "PURun";
            PURunBox.Image = Properties.Resources.SpeedUp;

            PUScore.Click += Item_Click;
            PUScore.Tag = "PUScore";
            PUScore.Image = Properties.Resources.Scoreboost;




            player1Box.Click += Item_Click;
            player1Box.Tag = "Player";
            player1Box.Image = Properties.Resources.brockSprite1;
            player1Box.SizeMode = PictureBoxSizeMode.StretchImage;
            player1Box.Size = new Size(50, 60);

            HBouncerBox.Click += Item_Click;
            HBouncerBox.Tag = "HBouncer";
            HBouncerBox.Image = Properties.Resources.H_bouncer;

            VBouncerBox.Click += Item_Click;
            VBouncerBox.Tag = "VBouncer";
            VBouncerBox.Image = Properties.Resources.V_bouncer;

            enemyBox.Click += Item_Click;
            enemyBox.Tag = "Enemy";
            enemyBox.Image = Properties.Resources.Enemy;


            this.playerPanel.Controls.Add(player1Box);

            this.NPCPanel.Controls.Add(enemyBox);
            this.NPCPanel.Controls.Add(HBouncerBox);
            this.NPCPanel.Controls.Add(VBouncerBox);

            this.worldPanel.Controls.Add(wallBox);
            this.worldPanel.Controls.Add(PURunBox);
            this.worldPanel.Controls.Add(PUScore);

            initPropertyPanel();
            initPlayerPanel();
            initNPCPanel();
            initWorldPanel();
        }

        private void Item_Click(object sender, EventArgs e)
        {
            PictureBox s = (PictureBox)sender;
            this.mode = s.Tag.ToString();

            if (this.mode == "SelectTool")
            {
                this.active = null;
            }

            if (this.mode == "FieldObject")
            {
                fieldObjects.type = Obstacle.Type.wall;
                this.active = fieldObjects;
            }
            if (this.mode == "PURun")
            {
                powerUps.type = Powerups.Type.Speedboost;
                powerUps.setUsed(false);
                this.active = powerUps;
            }
            if (this.mode == "PUScore")
            {
                powerUps.type = Powerups.Type.Scoreboost;
                powerUps.setUsed(false);
                this.active = powerUps;
            }

            if (this.mode == "WorldGround")
            {
                fieldObjects.type = Obstacle.Type.worldground;
                this.active = fieldObjects;
            }

            if (this.mode == "Player")
            {
                this.active = player;
            }
            if (this.mode == "HBouncer")
            {
                npc.type = Npc.Type.H_Bouncer;
                this.active = npc;
            }
            if (this.mode == "VBouncer")
            {
                npc.type = Npc.Type.V_Bouncer;
                this.active = npc;
            }

            if (this.mode == "Enemy")
            {
                npc.type = Npc.Type.Enemy;
                this.active = npc;
            }

        }

        public void setValueAfterSelectClick(object Object)
        {
            this.selectedObject = Object;
            if (selectedObject.GetType() == typeof(Obstacle))
            {
                //Setting Property Values
                this.previewObjectBox.Image = ((Obstacle)selectedObject).getImage();
                this.previewObjectBox.SizeMode = PictureBoxSizeMode.CenterImage;
                this.previewObjectBox.BackColor = Color.DarkGray;
                this.ObjectName.Text = ((Obstacle)selectedObject).type.ToString();
                this.ObjectCoords.Text = "X: " + ((Obstacle)selectedObject).x + " Y: " + ((Obstacle)selectedObject).y;
                if (((Obstacle)selectedObject).type == (Obstacle.Type.wall))
                {
                    this.runSpeedLabel.Visible = false;
                    this.numericRunSpeed.Visible = false;
                    this.walkSpeedLabel.Visible = false;
                    this.numericWalkSpeed.Visible = false;
                }


                this.mode = "Geen";
                this.previewObjectBox.Click -= Item_Click;
                this.previewObjectBox.MouseHover += delegate (object se, EventArgs ea) { this.previewObjectBox.Image = Properties.Resources.selectBtn; this.previewObjectBox.Click += Item_Click; this.previewObjectBox.SizeMode = PictureBoxSizeMode.StretchImage; this.previewObjectBox.BackColor = SystemColors.Control; };
                this.previewObjectBox.MouseLeave += delegate (object se, EventArgs ea) { this.previewObjectBox.Image = ((Obstacle)selectedObject).getImage(); this.previewObjectBox.Click -= Item_Click; this.previewObjectBox.SizeMode = PictureBoxSizeMode.CenterImage; this.previewObjectBox.BackColor = Color.DarkGray; };
            }
            else
            if (selectedObject.GetType() == typeof(Npc))
            {
                MessageBox.Show("X:" + ((Npc)selectedObject).positions.current_position.x + " Y: " + ((Npc)selectedObject).positions.current_position.y);

                //Setting Property Values
                this.previewObjectBox.Image = ((Npc)selectedObject).getImage();
                this.previewObjectBox.SizeMode = PictureBoxSizeMode.CenterImage;
                this.previewObjectBox.BackColor = Color.DarkGray;
                this.ObjectName.Text = ((Npc)selectedObject).type.ToString();
                this.ObjectCoords.Text = "X: " + ((Npc)selectedObject).positions.current_position.x + " Y: " + ((Npc)selectedObject).positions.current_position.y;
                this.runSpeedLabel.Visible = false;
                this.walkSpeedLabel.Visible = true;
                this.numericWalkSpeed.Visible = true;
                this.numericRunSpeed.Visible = false;
                this.walkSpeedLabel.Text = "Speed :";
                this.numericWalkSpeed.Minimum = 0;
                this.numericWalkSpeed.Maximum = 15;
                this.numericWalkSpeed.Value = ((Npc)selectedObject).speed.x;


                this.numericWalkSpeed.Click += delegate (object se, EventArgs ea) { ((Npc)selectedObject).speed.x = int.Parse(this.numericWalkSpeed.Value.ToString()); ((Npc)selectedObject).speed.y = int.Parse(this.numericWalkSpeed.Value.ToString()); };

                this.mode = "Geen";
                this.previewObjectBox.Click -= Item_Click;
                this.previewObjectBox.MouseHover += delegate (object se, EventArgs ea) { this.previewObjectBox.Image = Properties.Resources.selectBtn; this.previewObjectBox.Click += Item_Click; this.previewObjectBox.SizeMode = PictureBoxSizeMode.StretchImage; this.previewObjectBox.BackColor = SystemColors.Control; };
                this.previewObjectBox.MouseLeave += delegate (object se, EventArgs ea) { this.previewObjectBox.Image = ((Npc)selectedObject).getImage(); this.previewObjectBox.Click -= Item_Click; this.previewObjectBox.SizeMode = PictureBoxSizeMode.CenterImage; this.previewObjectBox.BackColor = Color.DarkGray; };

            }
            else
            if (selectedObject.GetType() == typeof(Model.Player))
            {
                //Setting Property Values
                this.previewObjectBox.Image = ((Model.Player)selectedObject).getImage();
                this.previewObjectBox.SizeMode = PictureBoxSizeMode.CenterImage;
                this.previewObjectBox.BackColor = Color.DarkGray;
                this.ObjectName.Text = "Player";
                this.ObjectCoords.Text = "X: " + ((Model.Player)selectedObject).positions.current_position.x + " Y: " + ((Model.Player)selectedObject).positions.current_position.y;
                this.runSpeedLabel.Visible = true;
                this.walkSpeedLabel.Visible = true;
                this.numericWalkSpeed.Visible = true;
                this.numericRunSpeed.Visible = true;
                this.runSpeedLabel.Text = "Run speed :";
                this.numericWalkSpeed.Value = ((Model.Player)selectedObject).movement.walk.x;
                this.walkSpeedLabel.Text = "Walk speed :";
                this.numericRunSpeed.Value = ((Model.Player)selectedObject).movement.run.x;
                
                

                this.numericWalkSpeed.Maximum = 5;
                this.numericWalkSpeed.Minimum = 1;
                this.numericRunSpeed.Maximum = 10;
                this.numericRunSpeed.Minimum = 2;

                this.numericWalkSpeed.Click += delegate (object se, EventArgs ea) { ((Model.Player)selectedObject).movement.walk = new Model.Point(int.Parse(this.numericWalkSpeed.Value.ToString()), int.Parse(this.numericWalkSpeed.Value.ToString()));};
                this.numericRunSpeed.Click += delegate (object se, EventArgs ea) { ((Model.Player)selectedObject).movement.run = new Model.Point(int.Parse(this.numericRunSpeed.Value.ToString()), int.Parse(this.numericRunSpeed.Value.ToString()));};


                //ADD SETTER FUNCTION

                this.mode = "Geen";
                this.previewObjectBox.Click -= Item_Click;
                this.previewObjectBox.MouseHover += delegate (object se, EventArgs ea) { this.previewObjectBox.Image = Properties.Resources.selectBtn; this.previewObjectBox.Click += Item_Click; this.previewObjectBox.SizeMode = PictureBoxSizeMode.StretchImage; this.previewObjectBox.BackColor = SystemColors.Control; };
                this.previewObjectBox.MouseLeave += delegate (object se, EventArgs ea) { this.previewObjectBox.Image = ((Model.Player)selectedObject).getImage(); this.previewObjectBox.Click -= Item_Click; this.previewObjectBox.SizeMode = PictureBoxSizeMode.CenterImage; this.previewObjectBox.BackColor = Color.DarkGray; };

            }
        }

        public void initWorldPanel()
        {
            this.worldPanel.Size = new Size((int)(this.Width * 0.9), (int)(this.Height * 0.22));
            this.worldPanel.Location = new System.Drawing.Point((int)(this.Location.X + this.Size.Width * 0.05), this.Location.Y);
        }

        public void initNPCPanel()
        {
            this.NPCPanel.Size = new Size((int)(this.Width * 0.9), (int)(this.Height * 0.25));
            this.NPCPanel.Location = new System.Drawing.Point((int)(this.Location.X + this.Size.Width * 0.05), this.worldPanel.Location.Y + this.worldPanel.Height + (int)(this.Height * 0.15));

        }


        public void initPlayerPanel()
        {
            this.playerPanel.Size = new Size((int)(this.Width * 0.9), (int)(this.Height * 0.20));
            this.playerPanel.Location = new System.Drawing.Point((int)(this.Location.X + this.Size.Width * 0.05), this.worldPanel.Location.Y + this.worldPanel.Height + (int)(this.Height * 0.15));

        }

        public void initPropertyPanel()
        {
            this.propertiesPanel.Size = new Size((int)(this.Width * 0.9), (int)(this.Height * 0.25));
            this.propertiesPanel.Location = new System.Drawing.Point((int)(this.Location.X + this.Size.Width * 0.05), this.playerPanel.Location.Y + this.playerPanel.Height);


            this.previewObjectBox.Click += Item_Click;
            this.previewObjectBox.Tag = "SelectTool";
            this.previewObjectBox.Image = Properties.Resources.selectBtn;
            this.previewObjectBox.Size = new Size((int)(this.propertiesPanel.Width * 0.3),(int)(this.propertiesPanel.Height * 0.3));
            this.previewObjectBox.SizeMode = PictureBoxSizeMode.StretchImage;
            
            
            this.propertiesPanel.Controls.Add(this.previewObjectBox);
            this.propertiesPanel.Controls.Add(this.ObjectName);
            this.propertiesPanel.Controls.Add(this.PropertiesLabel);
            this.propertiesPanel.Controls.Add(this.ObjectCoords);
            this.propertiesPanel.Controls.Add(this.runSpeedLabel);
            this.propertiesPanel.Controls.Add(this.walkSpeedLabel);
            this.propertiesPanel.Controls.Add(this.numericWalkSpeed);
            this.propertiesPanel.Controls.Add(this.numericRunSpeed);

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
