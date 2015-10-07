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
        private System.Timers.Timer refreshTimer = null;

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
            using (StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + "../World/World1.json"))
            {
                this.world = JsonConvert.DeserializeObject<World>(reader.ReadToEnd());
                this.Invalidate();
            }
        }

        private void Map_KeyDown(object sender, KeyEventArgs k)
        {
            if (k.KeyCode == Keys.Down || k.KeyCode == Keys.Up || k.KeyCode == Keys.Left || k.KeyCode == Keys.Right)
            {
                int newX = this.world.Player.position.x;
                int newY = this.world.Player.position.y;

                if (k.KeyCode == Keys.Down)
                {
                    newY += this.world.Player.speed.y;
                }
                else if (k.KeyCode == Keys.Up)
                {
                    newY -= this.world.Player.speed.y;
                }

                else if (k.KeyCode == Keys.Right)
                {
                    newX += this.world.Player.speed.x;
                }
                else if (k.KeyCode == Keys.Left)
                {
                    newX -= this.world.Player.speed.x;
                }

                

                this.Invalidate();
            }
        }
    }
}
