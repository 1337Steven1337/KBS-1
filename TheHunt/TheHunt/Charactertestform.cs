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
           // InitializeComponent();
            Character c1 = new Character(30,30,20,20);
            Paint += new PaintEventHandler(c1.drawcharacter);
            c1.xPoint += 100;
            Paint += new PaintEventHandler(c1.drawcharacter);
            // FormView a = new FormView(c1.xPoint, c1.yPoint, c1.xSpeed, c1.ySpeed);
        }
    }

    class Character
    {
        public int xPoint { get; set; }
        public int yPoint { get; set; }
        public int xSpeed { get; set; }
        public int ySpeed { get; set; }

        
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
