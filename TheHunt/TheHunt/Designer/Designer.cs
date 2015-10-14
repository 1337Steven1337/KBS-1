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

        public Designer(Form startform)
        {
            InitializeComponent();

            // Keep reference to the start form
            this.startForm = startform;
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
            this.Click += Designer_Click;

            this.items = new Items();
            this.items.Disposed += Items_Disposed;

            this.items.Show();
        }

        private void Designer_Click(object sender, EventArgs e)
        {
            if(this.items.active != null)
            {
                //FieldObject o = FieldObject.DeepCopy(this.items.active);
                this.world.FieldObjects.Add(o);
            }
        }

        private void Items_Disposed(object sender, EventArgs e)
        {
            this.startForm.Show();
            this.Close();
        }

        private void setFullScreenSize(object sender, PropertyChangedEventArgs e)
        {
            if (e == null || e.PropertyName == "full")
            {
                if (Properties.Screen.Default.full)
                {
                    this.Bounds = Screen.PrimaryScreen.Bounds;
                }
                else
                {
                    this.Size = this.startForm.Size;
                }

                // Calculate the grid size variables
                this.cellSizeX = (float)this.Size.Width / (float)cellLayout.X;
                this.cellSizeY = (float)this.Size.Height / (float)cellLayout.Y;

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

            this.paintGrid(graphics, pencil);
        }
    }
}
