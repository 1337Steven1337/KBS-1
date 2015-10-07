using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHunt.Controller;
using System.Windows.Forms;

namespace TheHunt
{
    public partial class Charactertestform : Form
    {
        private Move m = new Move();
        private Character c1 = new Character(30, 30, 20, 20);
        public Charactertestform()
        {

            InitializeComponent();

            Paint += new PaintEventHandler(c1.drawcharacter);
            
        }

        private void Charactertestform_KeyDown(object sender, KeyEventArgs e)
        {
            m.Moven(e, c1);
            this.Refresh(); 
        }
    }

    class Character
    {
        public int xPoint { get; set; }
        public int yPoint { get; set; }
        public int xSpeed { get; set; }
        public int ySpeed { get; set; }

        public Character() { }

        //public Character(int xPoint, int yPoint)
        //{
        //    this.xPoint = xPoint;
        //    this.yPoint = yPoint;
        //}
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
