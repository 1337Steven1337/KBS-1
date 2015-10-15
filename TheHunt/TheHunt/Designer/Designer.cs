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

        // Set an empty world
        private World world = new World();

        // Set world variables
        private string name = null;

        public Designer(Form startform)
        {
            InitializeComponent();

            // Keep reference to the start form
            this.startForm = startform;

            // Set double buffer to prevent flickering
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        private void Designer_Load(object sender, EventArgs e)
        {
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
                int x = (int)Math.Floor(e.X / cellSizeX);
                int y = (int)Math.Floor(e.Y / cellSizeY);

                if (this.items.getMode() == "FieldObject")
                {
                    FieldObject fieldObject = this.items.getActive<FieldObject>().clone();
                    fieldObject.x = (int)(x * cellSizeX);
                    fieldObject.y = (int)(y * cellSizeY);
                    this.world.FieldObjects.Add(fieldObject);
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
            if(this.name == null)
            {
                this.name = "test";
                // show dialog
                
            }
            
            string json = JsonConvert.SerializeObject(this.world);
            // Creates a resource writer.
            IResourceWriter writer = new ResourceWriter("myResources.resources");

            // Adds resources to the resource writer.
            writer.AddResource("String 1", "First String");

            writer.AddResource("String 2", "Second String");

            writer.AddResource("String 3", "Third String");

            // Writes the resources to the file or stream, and closes it.
            writer.Close();
            System.IO.File.WriteAllText(@"" +Directory.GetCurrentDirectory() + "/" + this.name + ".json", json);

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
            for (int i = 0; i < this.world.FieldObjects.Count; i++)
            {
                FieldObject obj = this.world.FieldObjects[i];
                obj.draw(graphics, this.Size);
            }
        }
    }
}
