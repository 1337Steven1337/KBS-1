using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using TheHunt.Model;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHunt
{
    partial class Buttons : Form
    {
        //Player p = new Player();
        private Timer timer = new Timer();
        World world = new World();
        private Game player;
        public bool isPressed = false;
        Direction GaNaar;
        public Buttons(Game player)
        {
            this.player = player;
            timer.Interval = 1;
            timer.Tick += timer_Tick;

            timer.Start();
        }


        public Control AddButton(Direction richting, int width, int height)
        {
            timer.Enabled = false;
            //checkt welke knop het is
            switch (richting)
            {
                case Direction.down:
                    return downButton(width, height);

                case Direction.left:
                    return leftButton(width, height);

                case Direction.up:
                    return upButton(width, height);

                case Direction.right:
                    return rightButton(width, height);
            }
            return null;
        }

        #region Buttons definition
        private Control downButton(int width, int heigt)
        {
            PictureBox Down = new PictureBox();
            Down.Size = new Size(75, 75);
            Down.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            Down.Location = new System.Drawing.Point(width - Down.Width * 2 - 20, heigt - Down.Height - 40);
            Down.ImageLocation = Directory.GetCurrentDirectory() + "/../../Resources/pijl onder.png";
            Down.MouseDown += Button_push;
            Down.MouseDown += gotodown;
            Down.MouseUp += Button_release;
            Down.MouseUp += DisableDown;
            return Down;

        }


        private void DisableDown(object sender, MouseEventArgs e)
        {

            this.player.extractKeyCode(Keys.Down, false);
        }

        private void gotodown(object sender, MouseEventArgs e)
        {
            GaNaar = Direction.down;
        }

        private void Down_Push(object sender, EventArgs e)
        {
            world.player.positions.current_position.y += world.player.speed.y;


        }

        private Control leftButton(int width, int heigt)
        {
            PictureBox Left = new PictureBox();
            Left.Size = new Size(75, 75);
            Left.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            Left.Location = new System.Drawing.Point(width - Left.Width * 3 - 20, heigt - Left.Height - 40);
            Left.ImageLocation = Directory.GetCurrentDirectory() + "/../../Resources/Pijl Links.png";
            Left.MouseDown += Button_push;
            Left.MouseDown += gotoleft;
            Left.MouseUp += Button_release;
            Left.MouseUp += DisableLeft;
            return Left;
        }

        private void DisableLeft(object sender, MouseEventArgs e)
        {
            this.player.extractKeyCode(Keys.Left, false);
        }

        private void gotoleft(object sender, MouseEventArgs e)
        {
            GaNaar = Direction.left;
        }

        private void Button_release(object sender, MouseEventArgs e)
        {
            timer.Enabled = false;
           
        }
        private void Button_push(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }
        private Control upButton(int width, int heigt)
        {
            PictureBox Up = new PictureBox();
            Up.Size = new Size(75, 75);
            Up.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            Up.Location = new System.Drawing.Point(width - Up.Width * 2 - 20, heigt - Up.Height * 2 - 40);
            Up.ImageLocation = Directory.GetCurrentDirectory() + "/../../Resources/Pijl bovenk.png";
            Up.MouseDown += Button_push;
            Up.MouseDown += gotoup;
            Up.MouseUp += Button_release;
            Up.MouseUp += DisableUp;
            return Up;
        }

        private void DisableUp(object sender, MouseEventArgs e)
        {
            this.player.extractKeyCode(Keys.Up, false);
        }

        private void gotoup(object sender, MouseEventArgs e)
        {
            GaNaar = Direction.up;
        }

        private Control rightButton(int width, int heigt)
        {
            PictureBox Right = new PictureBox();
            Right.Size = new Size(75, 75);
            Right.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            Right.Location = new System.Drawing.Point(width - Right.Width - 20, heigt - Right.Height - 40);
            Right.ImageLocation = Directory.GetCurrentDirectory() + "/../../Resources/Pijl rechts.png";
            Right.MouseDown += Button_push;
            Right.MouseDown += gotoright;
            Right.MouseUp += Button_release;
            Right.MouseUp += DisableRight;
            return Right;
        }

        private void DisableRight(object sender, MouseEventArgs e)
        {
            this.player.extractKeyCode(Keys.Right, false);
        }

        private void gotoright(object sender, MouseEventArgs e)
        {
            GaNaar = Direction.right;
        }
        #endregion

        public void timer_Tick(object sender, EventArgs e)
        {
            if (timer.Enabled == true)
            {

                switch (GaNaar)
                {
                    
                    case Direction.right:
                        this.player.extractKeyCode(Keys.Right, true);
                    isPressed = true;
                        break;
                    case Direction.left:
                        this.player.extractKeyCode(Keys.Left, true);
                    isPressed = true;
                        break;
                    case Direction.down:
                        this.player.extractKeyCode(Keys.Down, true);
                    isPressed = true;
                        break;
                    case Direction.up:
                        this.player.extractKeyCode(Keys.Up, true);
                    isPressed = true;
                        break;
                }
            }
        }


    }
}
