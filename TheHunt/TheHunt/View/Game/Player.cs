﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using TheHunt.Model;
using TheHunt.Service;
using TheHunt.View.Start;
using TheHunt.View.Options;

namespace TheHunt.View.Game
{
    public partial class Player : Form
    {
        // Variable to check if finished
        private bool finished = false;

        // Keep the world data
        private World world = null;

        // Level to be played
        private string levelString;

        // Variable to check player movement
        public static bool isPlayerMoving = false;

        // Creating empty bitmap for objects to be rendered in
        private Bitmap objectState;

        // Sound instance used for playing SFX
        Service.Sound geluidjes = Service.Sound.Instance;

        // Reference to the startScreen
        private startScreen startScreen = null;

        // Declare the main timer
        private Timer loop = null;

        // Declare the animation timer
        private Timer animate = null;

        // Declare the stopwatch to maintain delta time
        private Stopwatch delta = null;

        // Declare the stopwatch to count the amount of ms ticks (used for SSBomber)
        private Stopwatch MSticks = new Stopwatch();

        // Declare the gamepad
        private Gamepad gamepad = null;

        // Target FPS
        private int targetFps = 120;

        // Holds the pressed key
        private Keys pressedKey = Keys.None;

        // Holds the last pressed key
        private Keys lastPressedKey = Keys.None;

        // Converts internal lvl names to readable names for the highscore
        private Dictionary<string, string> lvlNames = new Dictionary<string, string>()
            {
                { "level1", "Level 1" },
                { "level2", "Level 2" },
                { "level3", "Level 3" },
                { "level4", "Level 4" },
                { "level5", "Level 5" },
                { "customlv1", "Custom level 1" },
                { "customlv2", "Custom level 2" },
                { "customlv3", "Custom level 3" },
                { "customlv4", "Custom level 4" },
                { "customlv5", "Custom level 5" }
            };

        // is Speedboost Active?
        public bool speedBoostActive = false;
        public Timer speedBoostTimer = new Timer();
        public int speedBoostLength = 0;

        // SSB timer / check
        public Timer SSBSpawnTimer = new Timer();
        public Timer SSBExplosion = new Timer();
        private int explosionState = 0;
        public bool isSSBSpawned = false;
        public static bool SSBPlayerCollision = false;
        private bool isExploding = false;
        private bool isSoundPlaying = false;
        private bool isSSBVisible = true;
        public List<Bitmap> SSBExplosionSpriteList = new List<Bitmap> { Properties.Resources.exp1, Properties.Resources.exp2, Properties.Resources.exp3, Properties.Resources.exp4, Properties.Resources.exp5, Properties.Resources.exp6, Properties.Resources.exp7
        , Properties.Resources.exp8, Properties.Resources.exp9, Properties.Resources.exp10, Properties.Resources.exp11, Properties.Resources.exp12, Properties.Resources.exp13, Properties.Resources.exp14};

        // Emp
        public bool emp = false;
        private List<Model.Point> npcSpeed = new List<Model.Point>();
        public Timer EMPTimer = new Timer();

        // Are we running?   
        private bool run = false;

        // Movement keys
        private List<Keys> movementKeys = new List<Keys>() { Keys.Up, Keys.Down, Keys.Left, Keys.Right };

        // Shift keys
        private List<Keys> shiftKeys = new List<Keys>() { Keys.Shift, Keys.LShiftKey, Keys.RShiftKey, Keys.ShiftKey };

        public Player(startScreen start, string level)
        {
            InitializeComponent();

            // Set the start form
            this.startScreen = start;

            // Set the level 
            this.levelString = level;

            // Set double buffer to prevent flickering
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        public void addScore(int bonus)
        {
            world.getScore().add(bonus);
        }

        // Prepare the game
        private void Game_Load(object sender, EventArgs e)
        {
            // Set initial location
            this.Location = this.startScreen.Location;

            // Set the initial size
            this.setFullScreenSize(this, null);

            // Check if the onscreen controls have to be displayed
            if (Properties.Settings.Default.onScreenControls)
            {
                // Add gamepad
                this.addGamePad();
            }

            // Subscribe to the events
            this.attachEvents();

            // Load the world
            this.load();

            // Set highscore name
            this.world.getScore().world = lvlNames[this.levelString];

            // Set the main timer
            this.loop = new Timer();
            this.loop.Interval = 1000 / targetFps;
            this.loop.Tick += updateWorld;

            // Set the animation timer
            this.animate = new Timer();
            this.animate.Interval = 100;
            this.animate.Tick += updateAnimations;


            // Set speedboost timer
            this.speedBoostTimer.Interval = 1000;
            this.speedBoostTimer.Tick += updateSpeedBoostLength;

            // Set SSB timer
            this.SSBSpawnTimer.Tick += SSBTimerStop;
            this.SSBExplosion.Interval = 100;
            this.SSBExplosion.Tick += playExplosion;

            // Set EMP timer
            this.EMPTimer.Tick += EMPReset;

            // Set the stopwatch
            this.delta = new Stopwatch();

            // Start the game timer/stopwatch
            startTimers(true);
        }


        private void updateSpeedBoostLength(object sender,EventArgs e)
        {
            if (this.speedBoostLength > 0)
            {
                this.speedBoostLength -= 1000;
            }
            else
            {
                this.speedBoostActive = false;
                this.run = false;
                this.speedBoostTimer.Stop();
            }
        }

        private void playExplosion(object sender, EventArgs e)
        {
            this.isExploding = true;
            this.world.player.isVisible = false;
            isSSBVisible = false;


            if (explosionState < this.SSBExplosionSpriteList.Count - 1)
            {
                this.explosionState++;
                if (explosionState == 6)
                {
                    this.world.player.isVisible = false;
                    Npc SSBer = new Npc();
                    foreach (Npc npcs in this.world.npcs)
                    {
                        if (npcs.type == Npc.Type.SuicideBomber)
                        {
                            SSBer = npcs;
                        }
                    }
                    this.world.npcs.Remove(SSBer);
                }
            }
            else
            {
                this.isExploding = false;
                this.world.getScore().score = 0;
                this.SSBExplosion.Stop();
            }
            this.Invalidate();
        }


        public void EMPReset(object sender, EventArgs e)
        {
            for (int i = 0; i < this.world.npcs.Count; i++)
            {
                this.world.npcs[i].speed = npcSpeed[i];
            }

            EMPTimer.Stop();
            emp = false;
        }

        public void SSBTimerStop(object sender , EventArgs e)
        {
            geluidjes.playIN();
            this.isSSBSpawned = true;
            this.SSBSpawnTimer.Stop();
        }


        // Normalizes the coordinates
        private void normalize()
        {
            double ratioX = this.Size.Width / 40.00;
            double ratioY = this.Size.Height / 20.00;

            this.world.player.sizeBreedte = this.Width / 40 - 5;
            this.world.player.sizeHoogte = this.Height / 20 - 5;
            
            this.world.player.positions.current_position = new Model.Point(
                (int)(this.world.player.positions.current_position.x * ratioX),
                (int)(this.world.player.positions.current_position.y * ratioY)
                );

            this.world.finish.x = (int)(this.world.finish.x * ratioX);
            this.world.finish.y = (int)(this.world.finish.y * ratioY);

            foreach (Obstacle obstacle in this.world.obstacles)
            {
                obstacle.x = (int)(obstacle.x * ratioX);
                obstacle.y = (int)(obstacle.y * ratioY);
            }

            foreach (Powerups powerup in this.world.powerups)
            {
                powerup.x = (int)(powerup.x * ratioX);
                powerup.y = (int)(powerup.y * ratioY);
            }

            foreach (Npc npc in this.world.npcs)
            {
                npc.positions.current_position = new Model.Point(
                    (int)(npc.positions.current_position.x * ratioX),
                    (int)(npc.positions.current_position.y * ratioY)
                    );
                npc.sizeBreedte = (int)(this.Size.Width/40.00) -5;
                npc.sizeHoogte = (int)(this.Size.Height/20.00) - 5;
            }
        }

        // Load the world
        private void load()
        {
            string data = (string)Properties.Levels.Default[levelString];

            // Assign the world variable
            this.world = JsonConvert.DeserializeObject<World>(data);


            // Check if level contains an SSBer, if so start spawn timer.
            foreach (Npc npcs in this.world.npcs)
            {
                if (npcs.type == Npc.Type.SuicideBomber)
                {
                    this.isSSBSpawned = false;
                    this.explosionState = 0;
                    Model.Player.lastPositionsList.Clear();
                    geluidjes.AADone = false;
                    geluidjes.EXDone = false;
                    SSBPlayerCollision = false;
                    isSSBVisible = true;
                    this.isSoundPlaying = false;
                    this.isExploding = false;
                    this.SSBExplosion.Stop();
                    this.SSBSpawnTimer.Interval = npcs.SSBspawnTimer;
                    this.SSBSpawnTimer.Start();
                }
            }

            // Normalize
            this.normalize();
        }

        // Add the gamepad
        private void addGamePad()
        {
            this.gamepad = new Gamepad(this);
            Control up = gamepad.AddButton(Gamepad.Direction.up, Width, Height);
            Control left = gamepad.AddButton(Gamepad.Direction.left, Width, Height);
            Control down = gamepad.AddButton(Gamepad.Direction.down, Width, Height);
            Control right = gamepad.AddButton(Gamepad.Direction.right, Width, Height);
            Controls.Add(up);
            Controls.Add(left);
            Controls.Add(down);
            Controls.Add(right);
        }

        public void Emp(int duration)
        {
            this.EMPTimer.Interval += duration;
            if (emp)
            {
                foreach (Npc npc in this.world.npcs)
                {
                    npcSpeed.Add(npc.speed);
                    npc.speed = new Model.Point(0,0);
                }
                EMPTimer.Start();
            }
            else
            {
                EMPTimer.Stop();
            }
        }

        private void attachEvents()
        {
            // Subscribe to the screen properties
            Properties.Screen.Default.PropertyChanged += setFullScreenSize;

            // Subscribe to the keydown event
            this.KeyDown += Game_KeyDown;

            // Subscribe to the keyup event
            this.KeyUp += Game_KeyUp;
        }

        // Function to update the world
        private void updateWorld(object sender, EventArgs e)
        {


            if (this.finished)
            {
                this.stopTimers(true);
                SSBSpawnTimer.Stop();
                Service.Highscore.Instance.add(this.world.getScore());

                if (levelString == "level5" || levelString.Substring(0, 6) == "custom")
                {
                    //is dit zo -> ga dan terug naar het hoofdmenu
                this.Close();
                this.startScreen.Show();
            }
            else
            {
                    //is dit niet zo voer dan de volgende functie uit
                    this.loadNextLevel();
                }
            }
            else
            {
                // Stop the timers
                this.loop.Stop();
                this.delta.Stop();

                if (SSBPlayerCollision && isSoundPlaying == false)
                {
                Model.Player.lastPositionsList.Clear();
                this.geluidjes.stopLoopInfidel(this,null);
                this.world.player.canMove = false;
                this.geluidjes.playAA();
                isSoundPlaying = true;
                }

                if (this.geluidjes.AADone)
                {
                    SSBExplosion.Start();
                }

                // Check if player is moving
                if (pressedKey == Keys.Up || pressedKey == Keys.Left || pressedKey == Keys.Down || pressedKey == Keys.Right)
                {
                    isPlayerMoving = true;
                }
                else
                {
                    isPlayerMoving = false;
                }

                // Calculate the delta time
                double delta = this.delta.ElapsedMilliseconds / (1000 / this.targetFps);

                // Move the player if he is able to
                if (this.world.player.canMove)
                {
                this.world.player.move(this.pressedKey, this.run, delta, this);
                }
                

                // Move the NPCs
                foreach (var npc in this.world.npcs)
                {
                    if (npc.type == Npc.Type.SuicideBomber)
                    {
                        if (isSSBSpawned == true)
                        {
                            npc.moveNPC(this.world);
                        }
                    }
                    else
                    {
                    npc.moveNPC(this.world);
                    npc.checkForPlayer(this.world, this);
                }

                }

                // Decay score
                this.world.getScore().subtract((int)Math.Round(1 * delta));

                // Redraw
                this.Invalidate();

                // Check if the player is "dead"
                if (this.world.getScore().score > 0)
                {
                    // Restart the timers
                    this.delta.Reset();
                    this.delta.Start();
                    this.loop.Start();
                }
                else
                {
                    this.toggleGameOver();
                }
            }
        }

        //kijk welk level volgende is
        private void loadNextLevel()
        {
            foreach (Npc npc in this.world.npcs)
            {
                npc.removeLabel();
            }

            Dictionary<string, string> levels = new Dictionary<string, string>()
            {
                { "level1", "level2" },
                { "level2", "level3" },
                { "level3", "level4" },
                { "level4", "level5" }
            };

            this.finished = false;
            this.objectState = null;
            this.levelString = levels[this.levelString];
            this.load();
            this.startTimers(true);
        }

        // Function to update the animations
        private void updateAnimations(object sender, EventArgs e)
        {
            // Animate the player
            if (this.world.player != null && this.world.player.canMove)
            {
            this.world.player.animate(this.pressedKey, this.lastPressedKey);
            }
            foreach (Npc npc in this.world.npcs)
            {
                if (npc.type == Npc.Type.SuicideBomber)
                {
                    if (isSSBSpawned)
                    {
                        if (!SSBPlayerCollision)
                        {
                            npc.animateSSB();
                        }                        
            }
                }
                else
                {
                    npc.animateBouncers();
                }
           
        }

        }

        // Handle the keydown event
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            this.extractKeyCode(e.KeyCode, true);
        }

        // Handle the keyup event
        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            this.extractKeyCode(e.KeyCode, false);
        }

        // Extract keycode from the event
        public void extractKeyCode(Keys keyCode, bool down)
        {
            if (movementKeys.Contains(keyCode)) // Check if the key is a movement key
            {
                this.lastPressedKey = this.pressedKey;
                if (down == true)
                {
                    this.pressedKey = keyCode;
                }
                else
                {
                    if (IsAnyKeyDown() != Keys.None)
                    {
                        this.pressedKey = IsAnyKeyDown();
                    }
                    else
                    {
                        this.pressedKey = Keys.None;
                    }
                }

            }
            else if(speedBoostActive && speedBoostLength > 0 && shiftKeys.Contains(keyCode)) // Check if the shiftkey is pressed
            {
                this.run = down;
                this.animate.Interval = (this.run) ? 50 : 100;
            }
            else if(keyCode == Keys.Escape && down == false) // Check if the scape key is pressed
            {
                this.toggleMenu();
            }
        }


        //Check if there is any key pressed, if so returns the pressed key
        private Keys IsAnyKeyDown()
        {
            var values = Enum.GetValues(typeof(System.Windows.Input.Key));

            foreach (var v in values)
            {
                if (((System.Windows.Input.Key)v) != System.Windows.Input.Key.None)
                {
                    if (System.Windows.Input.Keyboard.IsKeyDown((System.Windows.Input.Key)v))
                    {
                    System.Windows.Input.Key pressed = (System.Windows.Input.Key)Enum.Parse(typeof(System.Windows.Input.Key), ((System.Windows.Input.Key)v).ToString());
                    if (System.Windows.Input.Keyboard.IsKeyDown(pressed))
                    {
                            return (Keys)System.Windows.Input.KeyInterop.VirtualKeyFromKey(((System.Windows.Input.Key)v));
                        }
                    }
                }
            }
            return Keys.None;
        }

        // Check if something intersects with the world objects
        internal bool intersects(Model.Point point, Size size)
        {
            // Create a new rectangle representing the object
            Rectangle rectangle = new Rectangle(point.x, point.y, size.Width, size.Height);

            // Check if the item stays within the screen
            if (rectangle.Top < 0 || rectangle.Left < 0 || rectangle.Bottom > this.Size.Height || rectangle.Right > this.Size.Width)
            {
                return true;
            }
            
            // Check for collision with obstacles
            foreach (Obstacle obstacle in this.world.obstacles)
            {
                // Create a new rectangle representing the obstacle
                Rectangle rObstacle = new Rectangle(obstacle.x, obstacle.y, (int)obstacle.getPixelWidth(this.Size), (int)(obstacle.getPixelHeight(this.Size)));

                // Check if the obstacle intersects with the object
                if (rectangle.IntersectsWith(rObstacle))
                {
                    return true;
                }
            }

            // Check for collision with finish
            Rectangle rFinish = new Rectangle(world.finish.x, world.finish.y, (int)world.finish.getPixelWidth(this.Size), (int)(world.finish.getPixelHeight(this.Size)));
            if (rectangle.IntersectsWith(rFinish))
            {
                geluidjes.stopLoopInfidel(this, null);
                this.finished = true;
            }


            // Powerup check for collisions
            foreach (var powerup in this.world.powerups)
            { 
                Rectangle playerCoords = new Rectangle(this.world.player.positions.current_position.x, this.world.player.positions.current_position.y, (int)(this.world.player.sizeBreedte), (int)(this.world.player.sizeHoogte));
                if (playerCoords.IntersectsWith(new Rectangle(powerup.x, powerup.y, (int)(powerup.getPixelWidth(this.Size)), (int)(powerup.getPixelHeight(this.Size)))))
                {
                    powerup.UsePowerup(this);
                    this.world.powerups.Remove(powerup);
                    return true;
                }
            }


            return false;
        }

        // Function to handle the full screen option
        private void setFullScreenSize(object sender, PropertyChangedEventArgs e)
        {
            // Check if e == null (intial call) or the propertyname fullscreen is changed
            if (e == null || e.PropertyName == "full")
            {
                if (Properties.Screen.Default.full)
                {
                    this.Bounds = Screen.PrimaryScreen.Bounds;
                }
                else
                {
                    this.Size = new Size((int)(this.startScreen.Size.Width), this.startScreen.Size.Height);
                }

                // Set the menu location
                this.pnlMenu.Location = new System.Drawing.Point(this.Size.Width / 2 - this.pnlMenu.Width / 2, this.Size.Height / 2 - this.pnlMenu.Height / 2);

                // Set the gameover location
                this.pnlGameOver.Location = new System.Drawing.Point(this.Size.Width / 2 - this.pnlGameOver.Width / 2, this.Size.Height / 2 - this.pnlGameOver.Height / 2);

                // Redraw the form
                this.Invalidate();
            }
        }

        // Override the paint method to draw the game items
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (objectState == null)
            {
                this.objectState = new Bitmap(this.Size.Width, this.Size.Height);
                Graphics graphics = Graphics.FromImage(this.objectState);

                // Draw the obstacles
                foreach (Obstacle obstacle in this.world.obstacles)
                {
                    obstacle.draw(graphics, this.Size,"Game");
                }
            }
            else
            {
                // Get the graphic context
                Graphics g = e.Graphics;

                g.DrawImage(objectState,0,0);
                // Draw the NPCs
                foreach (Npc npc in this.world.npcs)
                {
                    if (npc.type == Npc.Type.SuicideBomber)
                    {
                        if (isSSBSpawned == true)
                        {
                            if (isSSBVisible == true)
                            {
                                npc.draw(g, this.Size, "Game");
                            }
                        
                }
                    }
                    else
                    {
                        npc.draw(g, this.Size, "Game");
                    }

                }

                // Draw the Powerups
                foreach (Powerups powerup in this.world.powerups)
                {
                    powerup.draw(g, this.Size,"Game",powerup.getUsed());
                }

                // Draw the player , if exists and is visible
                if (this.world.player != null && this.world.player.isVisible)
                {
                this.world.player.draw(g, this.Size, "Game");
                }

                // Draw the finish
                this.world.finish.draw(g, this.Size,"Game");

                // Draw score bar
                this.world.getScore().draw(g, this.Size);

                // Draw explosion
                if (isExploding)
                {
                    g.DrawImage(SSBExplosionSpriteList[this.explosionState],(this.world.player.positions.current_position.x - (int)(this.Size.Width/40.00)), (this.world.player.positions.current_position.y - (int)(this.Size.Height/20.00)),this.world.player.sizeBreedte*3,this.world.player.sizeHoogte*3);
                }
            }
        }

        // Starts the timers
        private void startTimers(bool iAnimate)
        {
            delta.Reset();
            delta.Start();
            loop.Start();
            MSticks.Start();
            if (iAnimate)
            {
                animate.Start();
            }
        }

        // Stops the timers
        private void stopTimers(bool iAnimate)
        {
            delta.Stop();
            delta.Reset();
            loop.Stop();
            MSticks.Reset();
            MSticks.Stop();

            if (iAnimate)
            {
                animate.Stop();
            }
        }

        private void toggleGameOver()
        {
            if(pnlGameOver.Visible)
            {

                // Reset the keys
                lastPressedKey = Keys.None;
                pressedKey = Keys.None;

                // Hide the menu
                pnlGameOver.Visible = false;

                //Start timers 
                startTimers(true);

                

            }
            else
            {

                // Pause the game
                stopTimers(true);

                // Show the menu
                pnlGameOver.Visible = true;
            }
        }

        // Toggle the menu
        private void toggleMenu()
        {
            if (!pnlGameOver.Visible)
            {
            if (pnlMenu.Visible)
            {
                    if (!isSSBSpawned && (int)(this.MSticks.ElapsedMilliseconds) < SSBSpawnTimer.Interval)
                    {
                        SSBSpawnTimer.Interval -= (int)(this.MSticks.ElapsedMilliseconds);
                        SSBSpawnTimer.Start();
                    }
                    else
                    {
                        geluidjes.LoopInfidel(this, null);
                    }
                    
                    
                    

                // Reset the keys
                lastPressedKey = Keys.None;
                pressedKey = Keys.None;

                // Hide the menu
                pnlMenu.Visible = false;

                // Start the game timers
                startTimers(true);
            }
            else
                {
                    if (!isSSBSpawned && (int)(this.MSticks.ElapsedMilliseconds) < SSBSpawnTimer.Interval)
                {
                    SSBSpawnTimer.Stop();;
                }
                geluidjes.pauseLoopInfidel(this, null);
                    

                    // Pause the game
                    stopTimers(true);

                // Show the menu
                pnlMenu.Visible = true;
            }
        }
        }

        // Handle the click event of the continue button
        private void pictureBoxContinue_Click(object sender, EventArgs e)
        {
            this.toggleMenu();
        }

        // Handle the click event of the options button
        private void pictureBoxOptions_Click(object sender, EventArgs e)
        {
            // Hide the menu
            pnlMenu.Visible = false;


            Dialog Options = new Dialog(true);
            Options.ShowDialog();

            if (Options.getClosed())
            {
                // Close the options dialog
                Options.Close();

                // Show the menu
                pnlMenu.Visible = true;
            }
        }

        // Handle the click event of the back to menu button
        private void pictureBoxExitToMenu_Click(object sender, EventArgs e)
        {
            geluidjes.stopLoopInfidel(this, null);
            if (isSSBSpawned == false)
            {
                SSBSpawnTimer.Stop();
            }
            this.stopTimers(true);
            this.Close();
            this.startScreen.Show();
        }

        // Handle the click event of the exit to desktop button
        private void pictureBoxExitToDesktop_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Close();
        }

        // Handle the click event of the restart button
        private void pictureBoxRestart_Click(object sender, EventArgs e)
        {
            foreach(Npc npc in this.world.npcs)
            {
                npc.removeLabel();
            }

            this.load();
            this.toggleGameOver();
        }

    }
}
