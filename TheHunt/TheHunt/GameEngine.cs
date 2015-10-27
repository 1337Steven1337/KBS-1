using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheHunt.Model;

namespace TheHunt
{
    public class GameEngine : Form
    {
        int width, height;
        Form1 gameView = new Form1();
        bool isRunning;
        System.Windows.Forms.KeyEventArgs k;
        private World world = null;
        public static bool MapIsRunning;
        private int leftKey, rightKey, downKey, upKey = 0;

        public GameEngine(int width, int height, Form1 gameView)
        {
            this.width = width;
            this.height = height;
            this.gameView = gameView;
        }

        public void Run()
        {
            if (isRunning) return;
            isRunning = true;
            gameView.Show();
            while (isRunning && !gameView.IsDisposed)
            {
                Update();
                Render();
                Application.DoEvents();
            }
        }

        public void Update()
        {
            if (MapIsRunning)
            {
                Map_KeyDown(this, k);
            }
        }

        public void Render()
        {

        }
        public void Map_KeyDown(object sender, System.Windows.Forms.KeyEventArgs k)
        {
            if (k.KeyCode == Keys.Down || k.KeyCode == Keys.S || k.KeyCode == Keys.Up || k.KeyCode == Keys.W || k.KeyCode == Keys.Left || k.KeyCode == Keys.A || k.KeyCode == Keys.Right || k.KeyCode == Keys.D)
            {

                if ((k.KeyCode == Keys.Down || k.KeyCode == Keys.S) && FieldObject.downCollision == false)
                {
                    if (downKey == 0)
                    {
                        Player1.bitmap = Properties.Resources.brockSprite1;
                        downKey = 1;
                    }
                    else if (downKey == 1)
                    {
                        Player1.bitmap = Properties.Resources.brockSprite2;
                        downKey = 2;
                    }
                    else if (downKey == 2)
                    {
                        Player1.bitmap = Properties.Resources.brockSprite3;
                        downKey = 1;
                    }
                    this.world.Player.position.y += this.world.Player.speed.y;
                }
                else if ((k.KeyCode == Keys.Up || k.KeyCode == Keys.W) && FieldObject.upCollision == false)
                {
                    if (upKey == 0)
                    {
                        Player1.bitmap = Properties.Resources.brockSprite4;
                        upKey = 1;
                    }
                    else if (upKey == 1)
                    {
                        Player1.bitmap = Properties.Resources.brockSprite5;
                        upKey = 2;
                    }
                    else if (upKey == 2)
                    {
                        Player1.bitmap = Properties.Resources.brockSprite6;
                        upKey = 1;
                    }
                    this.world.Player.position.y -= this.world.Player.speed.y;

                    downKey = 0;
                    rightKey = 0;
                    leftKey = 0;
                }
                else if ((k.KeyCode == Keys.Right || k.KeyCode == Keys.D) && FieldObject.rightCollision == false)
                {
                    if (rightKey == 0)
                    {
                        Player1.bitmap = Properties.Resources.brockSprite7;
                        rightKey = 1;
                    }
                    else if (rightKey == 1)
                    {
                        Player1.bitmap = Properties.Resources.brockSprite8;
                        rightKey = 2;
                    }
                    else if (rightKey == 2)
                    {
                        Player1.bitmap = Properties.Resources.brockSprite9;
                        rightKey = 1;
                    }

                    this.world.Player.position.x += this.world.Player.speed.x;

                    downKey = 0;
                    upKey = 0;
                    leftKey = 0;
                }
                else if ((k.KeyCode == Keys.Left || k.KeyCode == Keys.A) && FieldObject.rightCollision == false)
                {
                    if (leftKey == 0)
                    {
                        Player1.bitmap = Properties.Resources.brockSprite10;
                        leftKey = 1;
                    }
                    else if (leftKey == 1)
                    {
                        Player1.bitmap = Properties.Resources.brockSprite11;
                        leftKey = 2;
                    }
                    else if (leftKey == 2)
                    {
                        Player1.bitmap = Properties.Resources.brockSprite12;
                        leftKey = 1;
                    }
                    this.world.Player.position.x -= this.world.Player.speed.x;

                    downKey = 0;
                    upKey = 0;
                    rightKey = 0;
                }

                foreach (var item in this.world.FieldObjects)
                {
                    if (item.collision(this.world.Player.position.x + 2, this.world.Player.position.y + 2, 32, 32))
                    {
                        world.Player.speed.x = 0;
                        world.Player.speed.y = 0;
                    }

                    this.Invalidate();
                }
            }
        }
    }
}
