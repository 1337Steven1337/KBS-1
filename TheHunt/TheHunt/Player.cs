using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using TheHunt.Model;

namespace TheHunt
{
    public partial class Player : Form
    {
        private World world = null;
        private int screenWith, screenHeight;
        public Player()
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);

                this.screenWith = this.Width;
                this.screenHeight = this.Height;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);            
            Graphics g = e.Graphics;
            for (int i = 0; i < this.world.FieldObjects.Count; i++)
            {
                FieldObject wall = this.world.FieldObjects[i];
                wall.draw(g);
            }

            this.world.Player.draw(g);
        }

        private void Map_Load(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + "/../../World/World1.json"))
            {
                this.world = JsonConvert.DeserializeObject<World>(reader.ReadToEnd());
                this.Invalidate();
            }
        }

        private void Map_KeyDown(object sender, KeyEventArgs k)
        {
            if (k.KeyCode == Keys.Down || k.KeyCode == Keys.Up || k.KeyCode == Keys.Left || k.KeyCode == Keys.Right)
            {  
                int SpeedX = this.world.Player.speed.x;
                int SpeedY = this.world.Player.speed.y;
                int newX = this.world.Player.position.x;
                int newY = this.world.Player.position.y;         

                    switch (k.KeyCode)
                    {
                        case Keys.Down:
                        foreach (var item in this.world.FieldObjects)
                        {
                            Rectangle randomObj = new Rectangle(item.x, item.y, item.width * 32, item.height * 32);
                            Rectangle playerObj = new Rectangle(newX, newY + SpeedY, 32, 32);

                            if (!playerObj.IntersectsWith(randomObj))
                            {
                                this.world.Player.position.y += SpeedY;
                            }
                            else
                            {
                               newX = item.y -32;
                            }
                        }
                        break;

                        case Keys.Up:
                        foreach (var item in this.world.FieldObjects)
                        {
                            Rectangle randomObj = new Rectangle(item.x, item.y, item.width * 32, item.height * 32);
                            Rectangle playerObj = new Rectangle(newX, newY - SpeedY, 32, 32);
                            if (!playerObj.IntersectsWith(randomObj))
                            {
                                this.world.Player.position.y -= SpeedY;
                            }
                            else
                            {
                                this.world.Player.position.y = item.y +32;
                            }
                        }
                        break;
                        case Keys.Right:
                        foreach (var item in this.world.FieldObjects)
                        {
                            Rectangle randomObj = new Rectangle(item.x, item.y, item.width * 32, item.height * 32);
                            Rectangle playerObj = new Rectangle(newX + SpeedX, newY, 32, 32);
                            if (!playerObj.IntersectsWith(randomObj))
                            {
                                this.world.Player.position.x += SpeedX;
                            }
                            else
                            {
                                this.world.Player.position.x = item.x - 32;
                            }


                        }
                        break;
                        case Keys.Left:
                        foreach (var item in this.world.FieldObjects)
                        {
                            Rectangle randomObj = new Rectangle(item.x, item.y, item.width * 32, item.height * 32);
                            Rectangle playerObj = new Rectangle(newX - SpeedX, newY, 32, 32);

                            if (!playerObj.IntersectsWith(randomObj))
                            {
                                this.world.Player.position.x -= SpeedX;
                            }
                            else
                            {
                                this.world.Player.position.x = item.x + 32;
                            }
                        }
                            break;
                        default:
                            break;
                    
                }
                this.Invalidate();
            }
        }
    }
}
