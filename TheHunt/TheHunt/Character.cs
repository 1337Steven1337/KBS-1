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
    public partial class Character : Form
    {
        private int xPoint { get; set; }
        private int yPoint { get; set; }
        private int xSpeed { get; set; }
        private int ySpeed { get; set; }

        public Character()
        {
            InitializeComponent();
            Paint += new PaintEventHandler(drawcharacter);           
        }
        
        public Character(int xPoint, int yPoint, int xSpeed, int ySpeed)
        {
            this.xPoint = xPoint;
            this.yPoint = yPoint;
            this.xSpeed = xSpeed;
            this.ySpeed = ySpeed;
        }

        private void drawcharacter(object sender, PaintEventArgs e)
        {
            var width = this.Width/50;
            var height = this.Height/50;

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Red);
            // Create rectangle.
            Rectangle characterShape = new Rectangle(0, 0, width, height);
            // Fill rectangle to screen.
            e.Graphics.FillRectangle(blueBrush, characterShape);
        }
    }
}
