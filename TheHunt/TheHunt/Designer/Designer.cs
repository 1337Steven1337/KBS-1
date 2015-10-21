using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheHunt.Model;
using System.Resources;
using System.Configuration;

namespace TheHunt.Designer
{
    public partial class Designer : Form
    {
        private Form startForm;
        private Items items;

        // Set the cellLayout to width 40 & height 20
        private System.Drawing.Point cellLayout = new System.Drawing.Point(40, 20);

        // Set the default size of the cells
        private float cellSizeX = 32;
        private float cellSizeY = 32;

        // Count amount of players set in the designer (max 1)
        private int playerCount = 0;

        // Set an empty world
        private World world = null;

        // Set an pre-defined level
        private string levelString;

        // Set levelID (used for saving)
        private string levelID;

        // Set world variables
        private string name = null;

        public Designer(Form startform, string level, string levelID)
        {
            InitializeComponent();

            // Keep reference to the start form
            this.startForm = startform;

            // Set level to be edited
            this.levelString = level;

            // Set level ID (needed for saving)
            this.levelID = levelID;

            // Checks if there's a level to be edited or there has to be a new level to be created
            if (levelString == "")
            {
                this.world = new World();
            }
            else
            {
                //this.world = JsonConvert.DeserializeObject<World>(levelString);
                this.world = new World();
            }

            // Set double buffer to prevent flickering
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        private void Designer_Load(object sender, EventArgs e)
        {
            Properties.Levels.Default.customlv1 = "";
            Properties.Levels.Default.customlv2 = "";
            Properties.Levels.Default.customlv6 = "";
            Properties.Levels.Default.customlv10 = "";

            // Set initial location
            this.Location = this.startForm.Location;

            // Set the initial size
            this.setFullScreenSize(this, null);

            // Subscribe to the screen properties
            Properties.Screen.Default.PropertyChanged += setFullScreenSize;

            // Add onclick listener
            this.MouseClick += Designer_Click;

            // Create the form to hold the items
            this.items = new Items(this);
            this.items.Disposed += Items_Disposed;

            // Show the item form
            this.items.Show();
        }

        private void Designer_Click(object sender, MouseEventArgs e)
        {
            // Make sure something is selected
            if(this.items.isSelected())
            {
                // Calculate the X and Y of the new object
                int x = (int)Math.Floor(e.X / (this.Size.Width/40.00));
                int y = (int)Math.Floor(e.Y / (this.Size.Height/20.00));
                if (this.items.getMode() == "FieldObject")
                {
                    Obstacle fieldObject = this.items.getActive<Obstacle>().clone();
                    fieldObject.x = (int)(x);
                    fieldObject.y = (int)(y);
                    this.world.obstacles.Add(fieldObject);
                }
                if (this.items.getMode() == "Player" && this.playerCount == 0)
                {
                    this.world.player = this.items.getActive<Model.Player>().clone();
                    this.world.player.positions.current_position = new Model.Point((int)(x * this.Size.Width / 40.00),(int)(y * this.Size.Height / 20.00));
                    this.world.player.movement.walk = new Model.Point(2,2);
                    this.world.player.movement.run = new Model.Point(5,5);
                    this.world.player.speed = new Model.Point(3,3);
                    this.world.player.sizeBreedte = (int)cellSizeX;
                    this.world.player.sizeHoogte = (int)cellSizeY;
                    this.playerCount = 1;
                }
                else if (this.items.getMode() == "Player" && this.playerCount > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Er bestaat al een player in het veld, wil je deze overschrijven?", "Player toevoegen?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.world.player = this.items.getActive<Model.Player>().clone();
                        this.world.player.positions.current_position = new Model.Point((int)(x * this.Size.Width / 40.00), (int)(y * this.Size.Height / 20.00));
                        this.world.player.sizeBreedte = (int)cellSizeX;
                        this.world.player.sizeHoogte = (int)cellSizeY;
                    }
                }
                this.Invalidate();
            }
        }

        private void Items_Disposed(object sender, EventArgs e)
        {
            this.save();
            this.startForm.Show();
            this.Close();
        }

        private void save()
        {
            string json = JsonConvert.SerializeObject(this.world);
            switch (levelID)
            {
                case "level1":
                    Properties.Levels.Default.level1 = json;
                    break;
                case "level2":
                    Properties.Levels.Default.level2 = json;
                    break;
                case "level3":
                    Properties.Levels.Default.level3 = json;
                    break;
                case "level4":
                    Properties.Levels.Default.level4 = json;
                    break;
                case "level5":
                    Properties.Levels.Default.level5 = json;
                    break;
                case "customlv1":
                    Properties.Levels.Default.customlv1 = json;
                    break;
                case "customlv2":
                    Properties.Levels.Default.customlv2 = json;
                    break;
                case "customlv3":
                    Properties.Levels.Default.customlv3 = json;
                    break;
                case "customlv4":
                    Properties.Levels.Default.customlv4 = json;
                    break;
                case "customlv5":
                    Properties.Levels.Default.customlv5 = json;
                    break;
                case "customlv6":
                    Properties.Levels.Default.customlv6 = json;
                    break;
                case "customlv7":
                    Properties.Levels.Default.customlv8 = json;
                    break;
                case "customlv8":
                    Properties.Levels.Default.customlv8 = json;
                    break;
                case "customlv9":
                    Properties.Levels.Default.customlv9 = json;
                    break;
                case "customlv10":
                    Properties.Levels.Default.customlv10 = json;
                    break;
            }

            DialogResult dialogResult = MessageBox.Show("Wil je dit design opslaan?", "Opslaan", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Properties.Levels.Default.Save();
            }
            if (dialogResult == DialogResult.No)
            {
                Properties.Levels.Default.Reload();
            }
        
        



            this.Close();
            
        }

        // Function to handle the full screen option
        private void setFullScreenSize(object sender, PropertyChangedEventArgs e)
        {
            // Check if e == null (intial call) or the propertyname fullscreen is changed
            if (e == null || e.PropertyName == "full")
            {
                if (Properties.Screen.Default.full)
                {
                    this.Bounds = Screen.PrimaryScreen.Bounds;
                }
                else
                {
                    this.Size = new Size((int)(this.startForm.Size.Width * 0.8), this.startForm.Size.Height) ;
                }

                // Calculate the grid size variables
                this.cellSizeX = (float)this.Size.Width / (float)cellLayout.X;
                this.cellSizeY = (float)this.Size.Height / (float)cellLayout.Y;

                // Redraw the form
                this.Invalidate();
            }
        }

        private void paintGrid(Graphics graphics, Pen pencil)
        {
            // Draw the vertical lines
            for (int x = 1; x < cellLayout.X; x++)
            {
                graphics.DrawLine(pencil, x * cellSizeX, 0, x * cellSizeX, this.Size.Height);
            }

            // Draw the horizontal lines
            for (int y = 1; y < cellLayout.Y; y++)
            {
                graphics.DrawLine(pencil, 0, y * cellSizeY, this.Size.Width, y * cellSizeY);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Set the graphic context
            Graphics graphics = e.Graphics;
            Pen pencil = new Pen(Color.Black);

            // Paint the grid
            this.paintGrid(graphics, pencil);

            // Draw the field objects
            for (int i = 0; i < this.world.obstacles.Count; i++)
            {
                Obstacle obj = this.world.obstacles[i];
                obj.draw(graphics, this.Size);
            }


            //Draw the Player, if a player is set (max 1)
            if (playerCount > 0)
            {
                Model.Player player = this.world.player;
                player.draw(graphics, this.Size);
            }



        }
    }
}
