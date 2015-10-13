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
    //in deze klasse wordt het character/ de speler  bewogen d.m.v het toetsenbord 
    public partial class Player : Form
    {
        private World world = null;
        public event EventHandler<EventArgs> Timer;
        public Timer timer;
        public Timer spriteTimer;
        public int count;
        public Form form1;
        public Boolean beweegNaarBoven = false;
        public Boolean beweegNaarLinks = false;
        public Boolean beweegNaarBeneden = false;
        public Boolean beweegNaarRechts = false;
        public Boolean isRunning = false;
        
        //dasd
        public int screenWidth, screenHeight;

        public Keys lastPressedKey;
        public Keys ingedrukteKey;

        public Player(Form form1)
        {
            InitializeComponent();
            this.Size = form1.Size;
            this.form1 = form1;
            this.pictureBoxOptionsButton.Location = new System.Drawing.Point(this.Size.Width - this.pictureBoxOptionsButton.Width, this.Height - this.pictureBoxOptionsButton.Height);
            this.panel1.Location = new System.Drawing.Point(this.Size.Width / 2 - this.panel1.Width / 2, this.Size.Height / 2 - this.panel1.Height / 2);
            this.panelOptions.Location = new System.Drawing.Point(this.Size.Width / 2 - this.panelOptions.Width / 2, this.Size.Height / 2 - this.panelOptions.Height / 2);
            if (Properties.Screen.Default.full)
            {
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }

            timer = new Timer();//timer voor de movement over het scherm
            spriteTimer = new Timer(); //timer voor de movement van het character/illustraties
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
                obj.draw(g, this.Size);
            }

            this.world.Player.draw(g, this.Size);
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

        //controle of het character er mag/kan lopen
        private bool checkIntersect(Keys k)
        {

            int playerX = this.world.Player.position.x;
            int playerY = this.world.Player.position.y;

            Model.Point newPosition = new Model.Point();

            switch (k)
            {
                case Keys.Up:
                    newPosition.x = this.world.Player.position.x;
                    newPosition.y = this.world.Player.position.y - this.world.Player.speed.y;
                    break;
                case Keys.Down:
                    newPosition.x = this.world.Player.position.x;
                    newPosition.y = this.world.Player.position.y + this.world.Player.speed.y;
                    break;
                case Keys.Left:
                    newPosition.x = this.world.Player.position.x - this.world.Player.speed.x;
                    newPosition.y = this.world.Player.position.y;
                    break;
                case Keys.Right:
                    newPosition.x = this.world.Player.position.x + this.world.Player.speed.x;
                    newPosition.y = this.world.Player.position.y;
                    break;
            }

            Rectangle newPlayerRectangle = new Rectangle(newPosition.x, newPosition.y, (int)this.world.Player.sizeBreedte, (int)this.world.Player.sizeHoogte);

            if (newPlayerRectangle.Top < 0 || newPlayerRectangle.Left < 0 || newPlayerRectangle.Bottom > this.Size.Height || newPlayerRectangle.Right > this.Size.Width)
            {
                return true;
            }

            foreach (var item in this.world.FieldObjects)
            {
                Rectangle randomObj = new Rectangle(item.x, item.y, (int)item.getPixelWidth(this.Size), (int)item.getPixelHeight(this.Size));

                if (newPlayerRectangle.IntersectsWith(randomObj))
                {
                    return true;
                }
            }

            return false;
        }
        // bij het indrukken van de toets wordt de timer gestart
        public void Map_OnKeyDown(object sender, KeyEventArgs k)
        {
            if (k.KeyCode != Keys.ShiftKey)
            {
                this.lastPressedKey = k.KeyCode;
            }
            

            spriteTimer.Start();

            if (k.KeyCode == Keys.ShiftKey)
            {
                isRunning = true;
            }

            if (k.KeyCode == Keys.Up)
            {
                this.beweegNaarBoven = true;
            }

            if (k.KeyCode == Keys.Left)
            {
                this.beweegNaarLinks = true;
            }

            if (k.KeyCode == Keys.Down)
            {
                this.beweegNaarBeneden = true;
            }

            if (k.KeyCode == Keys.Right)
            {
                this.beweegNaarRechts = true;
            }

            if (k.KeyCode == Keys.Escape)
            {
                toggleMenu();
            }


        }
        // bij het loslaten van de toets 
        public void Map_OnKeyUp(object sender, KeyEventArgs k)
        {
            if (k.KeyCode == Keys.ShiftKey)
            {
                isRunning = false;
            }


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

            //bij het loslaten wordt de beweging gestopt in bijbehorende rinchting
            switch (k.KeyCode)
            {
                //naar boven
                case Keys.Up:
                    this.beweegNaarBoven = false;
                    break;

                //naar links
                case Keys.Left:
                    this.beweegNaarLinks = false;
                    break;

                //naar beneden
                case Keys.Down:
                    this.beweegNaarBeneden = false;
                    break;

                //naar rechts
                case Keys.Right:
                    this.beweegNaarRechts = false;
                    break;
            }
        }

        //hier wordt de beweging van het character gegenereerd
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

                //indien er geen toets is ingedrukt stopt de movement
                case Keys.None:
                    spriteTimer.Stop();
                    break;
            }

        }
        //controle of er een toets is ingedrukt
        public bool IsAnyKeyDown()
        {
            var values = Enum.GetValues(typeof(System.Windows.Input.Key));

            foreach (var v in values)
            {
                if (((System.Windows.Input.Key)v) != System.Windows.Input.Key.None)
                {
                    if (System.Windows.Input.Keyboard.IsKeyDown((System.Windows.Input.Key)v))
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        //controle welke toets er is ingedrukt
        public void WelkeKeyIsDown()
        {
            var values = Enum.GetValues(typeof(System.Windows.Input.Key));

            foreach (var v in values)
            {
                if (((System.Windows.Input.Key)v) != System.Windows.Input.Key.None)
                {
                    System.Windows.Input.Key pressed = (System.Windows.Input.Key)Enum.Parse(typeof(System.Windows.Input.Key), ((System.Windows.Input.Key)v).ToString());
                    if (System.Windows.Input.Keyboard.IsKeyDown(pressed))
                    {
                      
                        this.lastPressedKey = (Keys)System.Windows.Input.KeyInterop.VirtualKeyFromKey(((System.Windows.Input.Key)v));

                    }
                }
            }
        }

        //beweeg zolang er een toets is ingedrukt
        void timer_Tick(object sender, EventArgs e)
        {
            if (!IsAnyKeyDown())
            {
                lastPressedKey = Keys.None;
            }
            else if (lastPressedKey == Keys.None)
            {
                WelkeKeyIsDown();
            }

            if (isRunning)
            {
                spriteTimer.Interval = 50;
                this.world.Player.speed = this.world.Player.movement.run;
            }
            else
            {
                spriteTimer.Interval = 100;
                this.world.Player.speed = this.world.Player.movement.walk;
            }

            switch (lastPressedKey)
            {
                case Keys.Up:
                    if (beweegNaarBoven)
                    {

                        if (!checkIntersect(Keys.Up))
                        {
                            world.Player.position.y -= world.Player.speed.y;
                        }
                    }

                    break;
                case Keys.Left:
                    if (beweegNaarLinks)
                    {
                        if (!checkIntersect(Keys.Left))
                        {
                            world.Player.position.x -= world.Player.speed.x;
                        }
                    }
                    break;
                case Keys.Down:
                    if (beweegNaarBeneden)
                    {
                        if (!checkIntersect(Keys.Down))
                        {
                            world.Player.position.y += world.Player.speed.y;
                        }
                    }
                    break;
                case Keys.Right:
                    if (beweegNaarRechts)
                    {
                        if (!checkIntersect(Keys.Right))
                        {
                            world.Player.position.x += world.Player.speed.x;
                        }
                    }
                    break;

                case Keys.None:
                    spriteTimer.Stop();
                    break;
            }


            this.Invalidate();
        }
        //hier keer je terug naar het hoofdmenu
        private void pictureBoxExitToMain_Click(object sender, EventArgs e)
        {
            this.Hide();
            form_startscreen form1 = new form_startscreen();
            form1.Show();
        }
        //hier keer je terug naar het spel
        private void pictureBoxContinue_Click(object sender, EventArgs e)
        {
            toggleMenu();
        }
        //hier sluit je het programma af
        private void pictureBoxExitToDesktop_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Close();
        }
    }
}
