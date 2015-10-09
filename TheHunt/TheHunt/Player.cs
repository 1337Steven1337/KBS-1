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
using System.Windows.Input;
using TheHunt.Model;


namespace TheHunt
{
    public partial class Player : Form
    {
        private World world = null;
        public static Boolean isMuted = false;
        private int leftKey, rightKey, downKey, upKey = 0;
        public static Size startRes = new Size();
        

        public Player()
        {
            InitializeComponent();
            startRes.Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.8);
            startRes.Height = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.8);
            this.ClientSize = new Size(startRes.Width, startRes.Height);

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

        //public  void Map_KeyDown(object sender, System.Windows.Forms.KeyEventArgs k)
        //{
        //    if (k.KeyCode == Keys.Down || k.KeyCode == Keys.S || k.KeyCode == Keys.Up || k.KeyCode == Keys.W || k.KeyCode == Keys.Left || k.KeyCode == Keys.A || k.KeyCode == Keys.Right || k.KeyCode == Keys.D)
        //    {

        //        if ((k.KeyCode == Keys.Down || k.KeyCode == Keys.S) && FieldObject.downCollision == false)
        //        {   
        //            if (downKey == 0)
        //            {
        //                Player1.bitmap = Properties.Resources.brockSprite1;
        //                downKey = 1;
        //            }
        //            else if(downKey == 1) {
        //                Player1.bitmap = Properties.Resources.brockSprite2;
        //                downKey = 2;
        //            }
        //            else if(downKey == 2)
        //            {
        //                Player1.bitmap = Properties.Resources.brockSprite3;
        //                downKey = 1;
        //            }
        //            this.world.Player.position.y += this.world.Player.speed.y;
        //        }
        //        else if ((k.KeyCode == Keys.Up || k.KeyCode == Keys.W) && FieldObject.upCollision == false)
        //        {
        //            if (upKey == 0)
        //            {
        //                Player1.bitmap = Properties.Resources.brockSprite4;
        //                upKey = 1;
        //            }
        //            else if (upKey == 1)
        //            {
        //                Player1.bitmap = Properties.Resources.brockSprite5;
        //                upKey = 2;
        //            }
        //            else if (upKey == 2)
        //            {
        //                Player1.bitmap = Properties.Resources.brockSprite6;
        //                upKey = 1;
        //            }
        //            this.world.Player.position.y -= this.world.Player.speed.y;
                    
        //            downKey = 0;
        //            rightKey = 0;
        //            leftKey = 0;
        //        }
        //        else if ((k.KeyCode == Keys.Right || k.KeyCode == Keys.D) && FieldObject.rightCollision == false)
        //        {
        //            if (rightKey == 0)
        //            {
        //                Player1.bitmap = Properties.Resources.brockSprite7;
        //                rightKey = 1;
        //            }
        //            else if (rightKey == 1)
        //            {
        //                Player1.bitmap = Properties.Resources.brockSprite8;
        //                rightKey = 2;
        //            }
        //            else if (rightKey == 2)
        //            {
        //                Player1.bitmap = Properties.Resources.brockSprite9;
        //                rightKey = 1;
        //            }

        //            this.world.Player.position.x += this.world.Player.speed.x;
                    
        //            downKey = 0;
        //            upKey = 0;
        //            leftKey = 0;
        //        }
        //        else if ((k.KeyCode == Keys.Left || k.KeyCode == Keys.A) && FieldObject.rightCollision == false)
        //        {
        //            if (leftKey == 0)
        //            {
        //                Player1.bitmap = Properties.Resources.brockSprite10;
        //                leftKey = 1;
        //            }
        //            else if (leftKey == 1)
        //            {
        //                Player1.bitmap = Properties.Resources.brockSprite11;
        //                leftKey = 2;
        //            }
        //            else if (leftKey == 2)
        //            {
        //                Player1.bitmap = Properties.Resources.brockSprite12;
        //                leftKey = 1;
        //            }
        //            this.world.Player.position.x -= this.world.Player.speed.x;

        //            downKey = 0;
        //            upKey = 0;
        //            rightKey = 0;
        //        }                

        //        foreach (var item in this.world.FieldObjects)
        //        {
        //            if (item.collision(this.world.Player.position.x +2, this.world.Player.position.y +2, 32, 32))
        //            {
        //                world.Player.speed.x = 0;
        //                world.Player.speed.y = 0;
        //            }

        //        this.Invalidate();
        //        }
        //  }
        //}
    }
}
