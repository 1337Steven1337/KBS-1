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
using System.Windows.Forms;
using TheHunt.Model;

namespace TheHunt
{
    public partial class Player : Form
    {
        private World world = null;
        public event EventHandler<EventArgs> Timer;
        public Timer timer;
        public Timer spriteTimer;
        public int count;
        public Boolean beweegNaarBoven = false;
        public Boolean beweegNaarLinks = false;
        public Boolean beweegNaarBeneden = false;
        public Boolean beweegNaarRechts = false;
        Rectangle nextPlayerMove;
        
        public Keys lastPressedKey;


        public Player()
        {
            InitializeComponent();
            timer = new Timer();
            spriteTimer = new Timer();
            timer.Interval = 1;
            spriteTimer.Interval = 100;
            spriteTimer.Tick += new EventHandler(beweegSprites);
            timer.Tick += new EventHandler(timer_Tick);

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
                FieldObject obj = this.world.FieldObjects[i];
                obj.draw(g);
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
            timer.Start();
            
        }

        private bool checkIntersect(Keys k)
        {

            int playerX = this.world.Player.position.x;
            int playerY = this.world.Player.position.y;
            


            foreach (var item in this.world.FieldObjects)
            {
                Rectangle randomObj = new Rectangle(item.x, item.y, item.width * 32, item.height * 32);
                
                switch (k)
                {
                    
                    case Keys.Up:
                        this.nextPlayerMove = new Rectangle(playerX, playerY - this.world.Player.speed.y, 32, 32);
                        break;
                    case Keys.Down:
                        this.nextPlayerMove = new Rectangle(playerX, playerY + this.world.Player.speed.y, 32, 32);
                        break;
                    case Keys.Left:
                        this.nextPlayerMove = new Rectangle(playerX - this.world.Player.speed.x, playerY, 32, 32);
                        break;
                    case Keys.Right:
                        this.nextPlayerMove = new Rectangle(playerX + this.world.Player.speed.x, playerY, 32, 32);
                        break;
                }

                if (nextPlayerMove.IntersectsWith(randomObj))
                {
                    return true;
                }
        }
            return false;
        }

        public void Map_OnKeyDown(object sender, KeyEventArgs k)
        {
            this.lastPressedKey = k.KeyCode;
            spriteTimer.Start();
            
            
            switch (k.KeyCode)
            {
                case Keys.Up:
                    this.beweegNaarBoven = true;
                    break;

                case Keys.Left:
                    this.beweegNaarLinks = true;
                    break;

                case Keys.Down:
                    this.beweegNaarBeneden = true;
                    break;

                case Keys.Right:
                    this.beweegNaarRechts = true;
                    break;
            }
            
        }

        public void Map_OnKeyUp(object sender, KeyEventArgs k)
        {
            
            switch (lastPressedKey)
                {
                    case Keys.Up:
                        Player1.bitmap = Properties.Resources.brockSprite4;
                        break;

                    case Keys.Left:
                        Player1.bitmap = Properties.Resources.brockSprite10;
                    break;

                    case Keys.Down:
                        Player1.bitmap = Properties.Resources.brockSprite1;
                    break;

                    case Keys.Right:
                        Player1.bitmap = Properties.Resources.brockSprite7;
                    break;
            }
         

            switch (k.KeyCode)
            {
                case Keys.Up:
                    this.beweegNaarBoven = false;
                    break;

                case Keys.Left:
                    this.beweegNaarLinks = false;
                    break;

                case Keys.Down:
                    this.beweegNaarBeneden = false;
                    break;

                case Keys.Right:
                    this.beweegNaarRechts = false;
                    break;
            }
        }


        void beweegSprites(object sender, EventArgs e)
        {
            
            switch (this.lastPressedKey)
            {
                case Keys.Left:
                    switch (count)
                    {
                        case 0:
                            Player1.bitmap = Properties.Resources.brockSprite10;
                            count = 1;
                            break;
                        case 1:
                            Player1.bitmap = Properties.Resources.brockSprite11;
                            count = 2;
                            break;
                        case 2:
                            Player1.bitmap = Properties.Resources.brockSprite12;
                            count = 0;
                            break;
                    }
                    break;
                case Keys.Down:
                    switch (count)
                    {
                        case 0:
                            Player1.bitmap = Properties.Resources.brockSprite1;
                            count = 1;
                            break;
                        case 1:
                            Player1.bitmap = Properties.Resources.brockSprite2;
                            count = 2;
                            break;
                        case 2:
                            Player1.bitmap = Properties.Resources.brockSprite3;
                            count = 0;
                            break;
                    }
                    break;
                case Keys.Right:
                    switch (count)
                    {
                        case 0:
                            Player1.bitmap = Properties.Resources.brockSprite7;
                            count = 1;
                            break;
                        case 1:
                            Player1.bitmap = Properties.Resources.brockSprite8;
                            count = 2;
                            break;
                        case 2:
                            Player1.bitmap = Properties.Resources.brockSprite9;
                            count = 0;
                            break;
                    }
                    break;
                case Keys.Up:
                    switch (count)
                    {
                        case 0:
                            Player1.bitmap = Properties.Resources.brockSprite4;
                            count = 1;
                            break;
                        case 1:
                            Player1.bitmap = Properties.Resources.brockSprite5;
                            count = 2;
                            break;
                        case 2:
                            Player1.bitmap = Properties.Resources.brockSprite6;
                            count = 0;
                            break;
                    }
                    break;
                case Keys.None:
                    spriteTimer.Stop();

                    break;
            }
            
        }

        public bool IsAnyKeyDown()
        {
            var values = Enum.GetValues(typeof(System.Windows.Input.Key));

            foreach (var v in values)
            {
                if (((System.Windows.Input.Key)v) != System.Windows.Input.Key.None )
                {
                    if (System.Windows.Input.Keyboard.IsKeyDown((System.Windows.Input.Key)v))
                    {
                        return true;
                    }
                }

            }
            return false;
        }


        void timer_Tick(object sender, EventArgs e)
        {
            if (!IsAnyKeyDown())
            {
                lastPressedKey = Keys.None;
            }
            if (this.beweegNaarBoven)
            {
                if (!checkIntersect(Keys.Up))
                {
                world.Player.position.y -= world.Player.speed.y;
                }

            }

            if (this.beweegNaarLinks)
            {
                if (!checkIntersect(Keys.Left))
                {
                world.Player.position.x -= world.Player.speed.x;
            }
            }

            if (this.beweegNaarBeneden)
            {
                if (!checkIntersect(Keys.Down))
                {
                world.Player.position.y += world.Player.speed.y;
            }
            }

            if (this.beweegNaarRechts)
            {
                if (!checkIntersect(Keys.Right))
                {
                world.Player.position.x += world.Player.speed.x;
            }
            }
            
            this.Invalidate();
        }

        private void buttonQuitMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void buttonResume_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {

        }

        private void buttonQuitDesktop_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            Close();
        }
    }
}
