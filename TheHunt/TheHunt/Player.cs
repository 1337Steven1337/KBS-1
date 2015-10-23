﻿using Newtonsoft.Json;
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
        public Timer timer, spriteTimer;
        public int count;
        public int playerX;
        public int playerY;
        public Form form1;
        public Boolean beweegNaarBoven = false;
        public Boolean beweegNaarLinks = false;
        public Boolean beweegNaarBeneden = false;
        public Boolean beweegNaarRechts = false;
        public Boolean isRunning = false;
        public static Boolean isMoving = false;
        
        private Boolean changeLastPosition = false;
        private int lastPositionCounter = 0;
        //dasd
        public int screenWidth, screenHeight;
        private Buttons gamepad = null;
        public Keys lastPressedKey;
        public Keys ingedrukteKey;
        public Keys laatsteMovement;

        public Player(Form form1)
        {
            InitializeComponent();
            this.Size = form1.Size;
            this.form1 = form1;
            this.gamepad = new Buttons(this);
            Control up = gamepad.AddButton(Direction.up, Width, Height);
            Control left = gamepad.AddButton(Direction.left, Width, Height);
            Control down = gamepad.AddButton(Direction.down, Width, Height);
            Control right = gamepad.AddButton(Direction.right, Width, Height);
            Controls.Add(up);
            Controls.Add(left);
            Controls.Add(down);
            Controls.Add(right);
            this.pictureBoxOptionsButton.Location = new System.Drawing.Point(this.Size.Width - this.pictureBoxOptionsButton.Width, this.Height - this.pictureBoxOptionsButton.Height);
            this.panel1.Location = new System.Drawing.Point(this.Size.Width / 2 - this.panel1.Width / 2, this.Size.Height / 2 - this.panel1.Height / 2);
            if (Properties.Screen.Default.full)
            {
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }

            timer = new Timer();//timer voor de movement over het scherm
            spriteTimer = new Timer(); //timer voor de movement van het character/illustraties
            timer.Interval = 1000 / 60;
            spriteTimer.Interval = 100;
            spriteTimer.Tick += beweegSprites;
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

            //Teken Blokken
            for (int i = 0; i < this.world.obstacles.Count; i++)
            {
                Obstacle obj = this.world.obstacles[i];
                obj.draw(g, this.Size);
            }
            //Teken NPC's
            for (int i = 0; i < this.world.npcs.Count; i++)
            {
                Npc npc = this.world.npcs[i];
                npc.draw(g, this.Size,"Game");
            }
            this.world.player.draw(g, this.Size,"Game");
            this.world.boss.draw(g, this.Size);
        }

        private void Map_Load(object sender, EventArgs e)
        {

            using (StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + "/../../World/World1.json"))
            {
                this.world = JsonConvert.DeserializeObject<World>(reader.ReadToEnd());
            }
            // string world = Encoding.UTF8.GetString(Properties.Resources.World1);
            //this.world = JsonConvert.DeserializeObject<World>(world.Substring(1));

            this.Invalidate();

            timer.Start();
        }

        //controle of het character er mag/kan lopen
        private bool checkIntersect(Keys k)
        {
            int playerX = this.world.player.positions.current_position.x;
            int playerY = this.world.player.positions.current_position.y;

            playerX = this.world.player.positions.current_position.x;
            playerY = this.world.player.positions.current_position.y;

            Model.Point newPosition = new Model.Point();

            switch (k)
            {
                case Keys.Up:
                    newPosition.x = this.world.player.positions.current_position.x;
                    newPosition.y = this.world.player.positions.current_position.y - this.world.player.speed.y;
                    break;
                case Keys.Down:
                    newPosition.x = this.world.player.positions.current_position.x;
                    newPosition.y = this.world.player.positions.current_position.y + this.world.player.speed.y;
                    break;
                case Keys.Left:
                    newPosition.x = this.world.player.positions.current_position.x - this.world.player.speed.x;
                    newPosition.y = this.world.player.positions.current_position.y;
                    break;
                case Keys.Right:
                    newPosition.x = this.world.player.positions.current_position.x + this.world.player.speed.x;
                    newPosition.y = this.world.player.positions.current_position.y;
                    break;
            }

            Rectangle newPlayerRectangle = new Rectangle(newPosition.x, newPosition.y, (int)this.world.player.sizeBreedte, (int)this.world.player.sizeHoogte);

            if (newPlayerRectangle.Top < 0 || newPlayerRectangle.Left < 0 || newPlayerRectangle.Bottom > this.Size.Height || newPlayerRectangle.Right > this.Size.Width)
            {
                return true;
            }

            //check for collision with objects (walls)..
            foreach (var item in this.world.obstacles)
            {
                Rectangle randomObj = new Rectangle((int)(item.x * screenWidth / 40), (int)(item.y * screenHeight / 20), (int)item.getPixelWidth(this.Size), (int)item.getPixelHeight(this.Size));

                if (newPlayerRectangle.IntersectsWith(randomObj))
                {
                    return true;
                }
            }

            //check for collision with NPS's...
            //foreach (var item in this.world.npcs)
            //{
            //    Rectangle randomObj = new Rectangle(item.positions.current_position.x, item.positions.current_position.y, (int)item.getPixelWidth(this.Size), (int)item.getPixelHeight(this.Size));

            //    if (newPlayerRectangle.IntersectsWith(randomObj))
            //    {
            //        return true;
            //    }
            //}
            return false;
        }
        public void switchStatements(Keys keycode)
        {
            if (keycode != Keys.ShiftKey && keycode != Keys.LShiftKey && keycode != Keys.RShiftKey && keycode != Keys.Shift && keycode != Keys.F21 && keycode != Keys.F22 && keycode != Keys.F23 && keycode != Keys.F24)
            {
                this.lastPressedKey = keycode;
            }
            
            spriteTimer.Start();


            if (keycode == Keys.F21)
            {
                this.beweegNaarBoven = false;
                this.beweegNaarLinks = false;
                this.beweegNaarRechts = false;
                this.beweegNaarBeneden = false;
            }

            if (keycode == Keys.F22)
            {
                this.beweegNaarBoven = false;
                this.beweegNaarLinks = false;
                this.beweegNaarRechts = false;
                this.beweegNaarBeneden = false;
            }
            if (keycode == Keys.F23)
            {
                this.beweegNaarBoven = false;
                this.beweegNaarLinks = false;
                this.beweegNaarRechts = false;
                this.beweegNaarBeneden = false;
            }
            if (keycode == Keys.F24)
            {
                this.beweegNaarBoven = false;
                this.beweegNaarLinks = false;
                this.beweegNaarRechts = false;
                this.beweegNaarBeneden = false;
            }
            if (keycode == Keys.Up)
            {
                this.beweegNaarBoven = true;
                this.beweegNaarLinks = false;
                this.beweegNaarBeneden = false;
                this.beweegNaarRechts = false;
                this.laatsteMovement = Keys.Up;
            }
            if (keycode == Keys.Down)
            {
                this.beweegNaarBoven = false;
                this.beweegNaarLinks = false;
                this.beweegNaarBeneden = true;
                this.beweegNaarRechts = false;
                this.laatsteMovement = Keys.Down;
            }
            if (keycode == Keys.Left)
            {
                this.beweegNaarBoven = false;
                this.beweegNaarLinks = true;
                this.beweegNaarBeneden = false;
                this.beweegNaarRechts = false;
                this.laatsteMovement = Keys.Left;
            }
            if (keycode == Keys.Right)
            {
                this.beweegNaarBoven = false;
                this.beweegNaarLinks = false;
                this.beweegNaarBeneden = false;
                this.beweegNaarRechts = true;
                this.laatsteMovement = Keys.Right;
            }
            if (keycode == Keys.ShiftKey)
            {
                isRunning = true;
            }
            if (keycode == Keys.Escape)
            {
                toggleMenu();
            }
        }
        // bij het indrukken van de toets wordt de timer gestart
        public void Map_OnKeyDown(object sender, KeyEventArgs k)
        {
            this.switchStatements(k.KeyCode);



        }
        // bij het loslaten van de toets 
        public void Map_OnKeyUp(object sender, KeyEventArgs k)
        {
            if (k.KeyCode == Keys.ShiftKey || k.KeyCode == Keys.LShiftKey || k.KeyCode == Keys.RShiftKey || k.KeyCode == Keys.Shift)
            {
                isRunning = false;
            }

            if (IsAnyKeyDown())
            {
                WelkeKeyIsDown();
                if (ingedrukteKey == Keys.Up || ingedrukteKey == Keys.Left || ingedrukteKey == Keys.Down || ingedrukteKey == Keys.Right)
                {
                    this.lastPressedKey = this.ingedrukteKey;
                    if (this.lastPressedKey == Keys.Up)
                    {
                        beweegNaarBoven = true;
            }
                    if (this.lastPressedKey == Keys.Left)
                    {
                        beweegNaarLinks = true;
                    }
                    if (this.lastPressedKey == Keys.Down)
                    {
                        beweegNaarBeneden = true;
                    }
                    if (this.lastPressedKey == Keys.Right)
                    {
                        beweegNaarRechts = true;
                    }
                }
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
                    if (beweegNaarLinks)
                    {
                    switch (count)
                    {
                        case 0:
                                Model.Player.bitmap = Model.Player.PlayerSprites[10];
                            count = 1;
                            break;
                        case 1:
                                Model.Player.bitmap = Model.Player.PlayerSprites[11];
                            count = 2;
                            break;
                        case 2:
                                Model.Player.bitmap = Model.Player.PlayerSprites[12];
                            count = 0;
                            break;
                    }
                    }
                    break;
                case Keys.Down:
                    if (beweegNaarBeneden)
                    {
                    switch (count)
                    {
                        case 0:
                                Model.Player.bitmap = Model.Player.PlayerSprites[1];
                            count = 1;
                            break;
                        case 1:
                                Model.Player.bitmap = Model.Player.PlayerSprites[2];
                            count = 2;
                            break;
                        case 2:
                                Model.Player.bitmap = Model.Player.PlayerSprites[3];
                            count = 0;
                            break;
                    }
                    }
                    break;
                case Keys.Right:
                    if (beweegNaarRechts)
                    {
                    switch (count)
                    {
                        case 0:
                                Model.Player.bitmap = Model.Player.PlayerSprites[7];
                            count = 1;
                            break;
                        case 1:
                                Model.Player.bitmap = Model.Player.PlayerSprites[8];
                            count = 2;
                            break;
                        case 2:
                                Model.Player.bitmap = Model.Player.PlayerSprites[9];
                            count = 0;
                            break;
                    }
                    }
                    break;
                case Keys.Up:
                    if (beweegNaarBoven)
                    {
                    switch (count)
                    {
                        case 0:
                                Model.Player.bitmap = Model.Player.PlayerSprites[4];
                            count = 1;
                            break;
                        case 1:
                                Model.Player.bitmap = Model.Player.PlayerSprites[5];
                            count = 2;
                            break;
                        case 2:
                                Model.Player.bitmap = Model.Player.PlayerSprites[6];
                            count = 0;
                            break;
                    }
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


        public void resetSprites()
        {
            switch (this.laatsteMovement)
            {
                case Keys.Up:
                    Model.Player.bitmap = Model.Player.PlayerSprites[4];
                    break;

                case Keys.Left:
                    Model.Player.bitmap = Model.Player.PlayerSprites[10];
                    break;

                case Keys.Down:
                    Model.Player.bitmap = Model.Player.PlayerSprites[1];
                    break;

                case Keys.Right:
                    Model.Player.bitmap = Model.Player.PlayerSprites[7];
                    break;
            }
        }

        //controle welke toets er is ingedrukt en veranderd de lastPressedKey
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

                        this.ingedrukteKey = (Keys)System.Windows.Input.KeyInterop.VirtualKeyFromKey(((System.Windows.Input.Key)v));

                    }
                }
            }
        }

        //beweeg zolang er een toets is ingedrukt
        void timer_Tick(object sender, EventArgs e)
        {
            foreach (var npc in this.world.npcs)
            {
                npc.moveNPC(this.world);
            }

            if (!IsAnyKeyDown())
            {
                lastPressedKey = Keys.None;
                resetSprites();
            }

            if (beweegNaarBeneden == true || beweegNaarBoven == true || beweegNaarLinks == true || beweegNaarRechts == true)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }


            if (beweegNaarBeneden == false && beweegNaarBoven == false && beweegNaarLinks == false && beweegNaarRechts == false)
            {
                spriteTimer.Stop();
            }


            if (isRunning)
            {
                spriteTimer.Interval = 50;
                this.world.player.speed = this.world.player.movement.run;
            }
            else
            {
                spriteTimer.Interval = 100;
                this.world.player.speed = this.world.player.movement.walk;
            }

            if (this.beweegNaarBoven)
                    {
                        if (!checkIntersect(Keys.Up))
                        {
                            world.player.positions.current_position.y -= world.player.speed.y;
                        }

                else
                {
                    spriteTimer.Stop();
                }
                    }


            else if (this.beweegNaarLinks)
                    {
                        if (!checkIntersect(Keys.Left))
                        {
                            world.player.positions.current_position.x -= world.player.speed.x;
                        }

                else
                {
                    spriteTimer.Stop();
                }
                    }
            else if (this.beweegNaarBeneden)
                    {
                        if (!checkIntersect(Keys.Down))
                        {
                            world.player.positions.current_position.y += world.player.speed.y;
                        }

                else
                {
                    spriteTimer.Stop();
                }
                    }

            else if (this.beweegNaarRechts)
                    {
                        if (!checkIntersect(Keys.Right))
                        {
                            world.player.positions.current_position.x += world.player.speed.x;
                        }

                else
                {
                    spriteTimer.Stop();
                }
            }
            gamepad.isPressed = false;
            this.Invalidate();
        }



        //hier keer je terug naar het hoofdmenu
        private void pictureBoxExitToMain_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.Show();
            form1.Activate();
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



        private void pictureBoxOptionsButton_Click(object sender, EventArgs e)
        {
            toggleMenu();
        }

        private void pictureBoxOptions_Click(object sender, EventArgs e)
        {
            toggleOptions();
        }

        private void toggleMenu()
        {
            if (!menuEnabled)
            {
                panel1.Visible = true;
                menuEnabled = true;
                //Pauzeert de game
                spriteTimer.Tick -= beweegSprites;
                timer.Stop();
                spriteTimer.Stop();

            }
            else
            {
                lastPressedKey = Keys.None;
                laatsteMovement = Keys.None;
                panel1.Visible = false;
                menuEnabled = false;
                //De-pauzeert de game
                timer.Start();
                spriteTimer.Start();
                spriteTimer.Tick += beweegSprites;
            }
        }

        private void toggleOptions()
        {
            toggleMenu();
            //Aanmaken optionsdialog, hoofdprogramma wordt hierdoor helemaal stilgezet terwijl gewacht wordt op reactie
            OptionsDialog Options = new OptionsDialog(true);
            Options.ShowDialog();
            if (Options.getClosed())
            {
                Options.Close();
                Options = null;
                toggleMenu();
            }
        }
    }
}
