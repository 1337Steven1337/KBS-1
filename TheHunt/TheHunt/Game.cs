using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheHunt.Model;
using TheHunt.Controller.Highscore;

namespace TheHunt
{
    public partial class Game : Form
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

        // Reference to the startScreen
        private form_startscreen startScreen = null;

        // Declare the main timer
        private Timer loop = null;

        // Declare the animation timer
        private Timer animate = null;

        // Declare the stopwatch to maintain delta time
        private Stopwatch delta = null;

        // Declare the gamepad
        private Buttons gamepad = null;

        // Target FPS
        private int targetFps = 120;

        // Holds the pressed key
        private Keys pressedKey = Keys.None;

        // Holds the last pressed key
        private Keys lastPressedKey = Keys.None;

        // is Speedboost Active?
        public bool speedBoostActive = false;
        public Timer speedBoostTimer = new Timer();
        public int speedBoostLength = 0;


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

        public Game(form_startscreen start, string level)
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
            this.world = new World();

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


        public void EMPReset(object sender, EventArgs e)
        {
            for (int i = 0; i < this.world.npcs.Count; i++)
            {
                this.world.npcs[i].speed = npcSpeed[i];
            }

            EMPTimer.Stop();
            emp = false;
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

            // Normalize
            this.normalize();
        }

        // Add the gamepad
        private void addGamePad()
        {
            this.gamepad = new Buttons(this);
            Control up = gamepad.AddButton(Direction.up, Width, Height);
            Control left = gamepad.AddButton(Direction.left, Width, Height);
            Control down = gamepad.AddButton(Direction.down, Width, Height);
            Control right = gamepad.AddButton(Direction.right, Width, Height);
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
                Highscore.Instance.add(this.world.getScore());

                if (levelString == "level5" || levelString.Substring(0, 4) == "custom")
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

                // Move the player
                this.world.player.move(this.pressedKey, this.run, delta, this);

                // Move the NPCs
                foreach (var npc in this.world.npcs)
                {
                    npc.moveNPC(this.world);
                    npc.checkForPlayer(this.world, this);
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
            this.world.player.animate(this.pressedKey, this.lastPressedKey);
            foreach (Npc npc in this.world.npcs)
            {
                npc.animate();
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
                        npc.draw(g, this.Size, "Game");
                }

                // Draw the Powerups
                foreach (Powerups powerup in this.world.powerups)
                {
                    powerup.draw(g, this.Size,"Game",powerup.getUsed());
                }

                // Draw the player
                this.world.player.draw(g, this.Size, "Game");

                // Draw the finish
                this.world.finish.draw(g, this.Size,"Game");

                // Draw score bar
                this.world.getScore().draw(g, this.Size);

                // Draw the boss
                //this.world.boss.draw(g, this.Size);
            }
        }

        // Starts the timers
        private void startTimers(bool iAnimate)
        {
            delta.Reset();
            delta.Start();
            loop.Start();

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

                // Start the game timers
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

            OptionsDialog Options = new OptionsDialog(true);
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
            this.load();
            this.toggleGameOver();
        }
    }
}
