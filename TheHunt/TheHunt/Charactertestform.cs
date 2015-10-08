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
    public enum Direction {
        up,
        left,
        right,
        down
    }

    public partial class Charactertestform : Form
    {
        System.Timers.Timer timer2 = new System.Timers.Timer(100);


        public event EventHandler<EventArgs> Timered;

        private Direction richting;
        private GameEngine g = new GameEngine();
        private Move m = new Move();
        private Character c1 = new Character(30, 30, 20, 20);

        
        public Charactertestform()
        {

            InitializeComponent();
            Paint += new PaintEventHandler(c1.drawcharacter);
            
        }


        private void Charactertestform_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            Debug.WriteLine("test");

            if(e.KeyCode == Keys.Up)
            {
                richting = Direction.up;
            }
            else if(e.KeyCode==Keys.Down){
                richting = Direction.down;
            }else if(e.KeyCode == Keys.Left)
            {
                richting = Direction.left;
            }else if (e.KeyCode == Keys.Right)
            {
                richting = Direction.right;
            }
            m.Moven(richting, c1);
            this.Refresh(); 
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }





        public void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)

        {
            timer2.Enabled = true;
            //m.up(c1);
            richting = Direction.up;
            this.Refresh();
        }

        public void pictureBox2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            timer2.Enabled = true;
            m.left(c1);
            richting = Direction.left;
            this.Refresh();
        }

        public void pictureBox3_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            timer2.Enabled = true;
            m.down(c1);
            richting = Direction.down;
            this.Refresh();
        }

        public void pictureBox4_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(sender== pictureBox1)
            {
                richting = Direction.up;
            }else if(sender == pictureBox2)
            {
                richting = Direction.left;
            }
            else if(sender == pictureBox3)
            {
                richting = Direction.down;
            }else if(sender == pictureBox4)
            {
                richting = Direction.right;
            }
            timer2.Enabled = true;
            this.Timer(1, e);
        }

        private void Timer(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            if (timer2.Enabled == true) {
                Thread.Sleep(50);
                g.move.Moven(richting,c1);
                //Debug.WriteLine("test");
            this.Refresh(); 
                
                if(e.Button == MouseButtons.Left)
                {

                    timer2.Enabled = true;

                }else
                {
                    timer2.Enabled = false;
                }



                Timer(this, e);
            }


        }

        protected virtual void OnTimered()
        {
            if(Timered != null)
            {
                Timered(this, EventArgs.Empty);
            }
        }

        private void pictureBox4_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            timer2.Enabled = false;
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
