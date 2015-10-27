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
using System.Timers;
using System.Diagnostics;
using System.Threading;
using System.Windows.Input;


namespace TheHunt
{
    //hier wordt de enumerator van direction aangemmaakt
    public enum Direction
    {
        up, 
        left,
        right,
        down
    }



    public partial class Charactertestform : Form
    {
        Direction down = Direction.down;
        Direction right = Direction.right;
        Direction up = Direction.up;
        Direction left = Direction.left;
        Buttons b = null; // new Buttons();
        System.Timers.Timer timer2 = new System.Timers.Timer(100);

        private Direction richting;
        private Object g = null;
        private Move m = new Move();
        private Character c1 = new Character(30, 30, 10, 10);

        public Charactertestform()
        {
            InitializeComponent();
            int width = Width;
            int heigt = Height;
            Controls.Add(b.AddButton(down, width, heigt));
            Controls.Add(b.AddButton(left, width, heigt));
            Controls.Add(b.AddButton(right, width, heigt));
            Controls.Add(b.AddButton(up, width, heigt));
            

            Paint += new PaintEventHandler(c1.drawcharacter);
            c1.xPoint += 100;
            Paint += new PaintEventHandler(c1.drawcharacter);
            // FormView a = new FormView(c1.xPoint, c1.yPoint, c1.xSpeed, c1.ySpeed);
        }


        private void Charactertestform_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            Debug.WriteLine("test");

            if (e.KeyCode == Keys.Up)
            {
                richting = Direction.up;
            }
            else if (e.KeyCode == Keys.Down)
            {
                richting = Direction.down;
            }
            else if (e.KeyCode == Keys.Left)
            {
                richting = Direction.left;
            }
            else if (e.KeyCode == Keys.Right)
            {
                richting = Direction.right;
            }
            //g.move.Moven(richting, c1);
            this.Refresh();
        }
        
        //public void pictureBox4_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    if (sender == pictureBox1)
        //    {
        //        richting = Direction.up;
        //    }
        //    else if (sender == pictureBox2)
        //    {
        //        richting = Direction.left;
        //    }
        //    else if (sender == pictureBox3)
        //    {
        //        richting = Direction.down;
        //    }
        //    else if (sender == pictureBox4)
        //    {
        //        richting = Direction.right;
        //    }
        //    timer1.Enabled = true;

        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
              //  g.move.Moven(richting, c1);
                this.Refresh();
            }
        }


        private void pictureBox4_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            timer1.Enabled = false;
        }
    }

    public class Character
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
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            // Create rectangle.
            Rectangle characterShape = new Rectangle(xPoint, yPoint, 20, 20);
            // Fill rectangle to screen.
            e.Graphics.FillRectangle(blueBrush, characterShape);
        }
    }
}