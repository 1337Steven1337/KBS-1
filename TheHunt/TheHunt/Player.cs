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
        private Controller.Move beweeg;
        public Timer timer;
        public Timer spriteTimer;
        public int count;
        public Boolean beweegNaarBoven = false;
        public Boolean beweegNaarLinks = false;
        public Boolean beweegNaarBeneden = false;
        public Boolean beweegNaarRechts = false;
        
        public Keys lastPressedKey;


        public Player()
        {
            InitializeComponent();
            beweeg = new Controller.Move();
            timer = new Timer();
            spriteTimer = new Timer();
            timer.Interval = 10;
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
            timer.Start();
            
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
                        Player1.bitmap = Properties.Resources.brockSprite11;
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
                            Player1.bitmap = Properties.Resources.brockSprite111;
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
                            Player1.bitmap = Properties.Resources.brockSprite11;
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
                world.Player.position.y -= world.Player.speed.y;

            }

            if (this.beweegNaarLinks)
            {
                world.Player.position.x -= world.Player.speed.x;
            }

            if (this.beweegNaarBeneden)
            {
                world.Player.position.y += world.Player.speed.y;
            }

            if (this.beweegNaarRechts)
            {
                world.Player.position.x += world.Player.speed.x;
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
