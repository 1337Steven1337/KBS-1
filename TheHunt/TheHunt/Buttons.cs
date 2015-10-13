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
    public partial class Buttons : Form
    {
        //Player p = new Player();
        private Timer timer = new Timer();
        World world = new World();
        Direction GaNaar;
        public Buttons()
        {



        }


        public Control AddButton(Direction richting, int width, int height)
        {
            //checkt welke knop het is
            switch (richting)
            {
                case Direction.down:
                    GaNaar = Direction.down;
                    return downButton(width, height);

                case Direction.left:
                    GaNaar = Direction.left;
                    return leftButton(width, height);

                case Direction.up:
                    GaNaar = Direction.up;
                    return upButton(width, height);

                case Direction.right:
                    GaNaar = Direction.right;
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
            Down.MouseDown += Button_release;
            Down.MouseUp += Button_push;
            Down.Click += Down_Push;
            return Down;

        }

        private void Down_Push(object sender, EventArgs e)
        {
            world.Player.position.y += world.Player.speed.y;


        }

        private Control leftButton(int width, int heigt)
        {
            PictureBox Left = new PictureBox();
            Left.Size = new Size(75, 75);
            Left.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            Left.Location = new System.Drawing.Point(width - Left.Width * 3 - 20, heigt - Left.Height - 40);
            Left.ImageLocation = Directory.GetCurrentDirectory() + "/../../Resources/Pijl Links.png";
            Left.MouseDown += Button_release;
            Left.MouseUp += Button_push;
            return Left;
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
            Up.MouseDown += Button_release;
            Up.MouseUp += Button_push;
            return Up;
        }

        private Control rightButton(int width, int heigt)
        {
            PictureBox Right = new PictureBox();
            Right.Size = new Size(75, 75);
            Right.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            Right.Location = new System.Drawing.Point(width - Right.Width - 20, heigt - Right.Height - 40);
            Right.ImageLocation = Directory.GetCurrentDirectory() + "/../../Resources/Pijl rechts.png";
            Right.MouseDown += Button_release;
            Right.MouseUp += Button_push;
            return Right;
        }

        #endregion

        public void timer_Tick(object sender, EventArgs e)
        {
            if (timer.Enabled == true)
            {
                switch (GaNaar)
                {
                    case Direction.right:
                        world.Player.position.x += world.Player.speed.x;
                        break;
                    case Direction.left:
                        world.Player.position.x -= world.Player.speed.x;
                        break;
                    case Direction.down:
                        world.Player.position.y += world.Player.speed.y;
                        break;
                    case Direction.up:
                        world.Player.position.y -= world.Player.speed.y;
                        break;
                }
            }
        }


    }
}
