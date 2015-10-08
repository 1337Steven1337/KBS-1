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

        public Player()
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Red);
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
                if (k.KeyCode == Keys.Down)
                {
                    this.world.Player.position.y += this.world.Player.speed.y;
                }
                else if (k.KeyCode == Keys.Up)
                {
                    this.world.Player.position.y -= this.world.Player.speed.y;
                }

                else if (k.KeyCode == Keys.Right)
                {
                    this.world.Player.position.x += this.world.Player.speed.x;
                }
                else if (k.KeyCode == Keys.Left)
                {
                    this.world.Player.position.x -= this.world.Player.speed.x;
                }                

                foreach (var item in this.world.FieldObjects)
                {
                    if (item.collision(this.world.Player.position.x +2, this.world.Player.position.y +2, 32, 32))
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
