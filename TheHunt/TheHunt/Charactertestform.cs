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
    public partial class Charactertestform : Form
    {
        public Charactertestform()
        {
            InitializeComponent();
            Character c1 = new Character();
            Character c2 = new Character(30,30);

            Paint += new PaintEventHandler(c1.drawcharacter);
            Paint += new PaintEventHandler(c2.drawcharacter);
        }
    }

    class Character
    {
        private int xPoint { get; set; }
        private int yPoint { get; set; }
        private int xSpeed { get; set; }
        private int ySpeed { get; set; }

        public Character(){}

        public Character(int xPoint, int yPoint)
        {
            this.xPoint = xPoint;
            this.yPoint = yPoint;
        }
        public Character(int xPoint, int yPoint, int xSpeed, int ySpeed)
        {
            this.xPoint = xPoint;
            this.yPoint = yPoint;
            this.xSpeed = xSpeed;
            this.ySpeed = ySpeed;
        }

        public void drawcharacter(object sender, PaintEventArgs e)
        {
            //var width = this.Width / 50;
            //var height = this.Height / 50;
            
            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Red);
            // Create rectangle.
            Rectangle characterShape = new Rectangle(xPoint, yPoint, 20, 20);
            // Fill rectangle to screen.
            e.Graphics.FillRectangle(blueBrush, characterShape);
        }
    }
}
