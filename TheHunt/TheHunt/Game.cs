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

namespace TheHunt
{
    public partial class Game : Form
    {
        // Keep the world data
        private World world = null;

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

        // Are we running?
        private bool run = false;

        // Movement keys
        private List<Keys> movementKeys = new List<Keys>() { Keys.Up, Keys.Down, Keys.Left, Keys.Right };

        // Shift keys
        private List<Keys> shiftKeys = new List<Keys>() { Keys.Shift, Keys.LShiftKey, Keys.RShiftKey, Keys.ShiftKey };

        public Game(form_startscreen start)
        {
            InitializeComponent();

            // Set the start form
            this.startScreen = start;

            // Set double buffer to prevent flickering
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        // Prepare the game
        private void Game_Load(object sender, EventArgs e)
        {
            this.world = new World();

            // Set initial location
            this.Location = this.startScreen.Location;

            // Set the initial size
            this.setFullScreenSize(this, null);

            // Add gamepad
            this.addGamePad();

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

            // Set the stopwatch
            this.delta = new Stopwatch();

            // Start the game timer/stopwatch
            startTimers(true);
        }

        // Load the world
        private void load()
        {
            // Open the JSON file
            using (StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + "/../../World/World1.json"))
            {
                // Assign the world variable
                this.world = JsonConvert.DeserializeObject<World>(reader.ReadToEnd());
            }
        }

        // Add the gamepad
        private void addGamePad()
        {
            /**this.gamepad = new Buttons(this);
            Control up = gamepad.AddButton(Direction.up, Width, Height);
            Control left = gamepad.AddButton(Direction.left, Width, Height);
            Control down = gamepad.AddButton(Direction.down, Width, Height);
            Control right = gamepad.AddButton(Direction.right, Width, Height);
            Controls.Add(up);
            Controls.Add(left);
            Controls.Add(down);
            Controls.Add(right);**/
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
            // Stop the timers
            this.loop.Stop();
            this.delta.Stop();
            
            // Calculate the delta time
            double delta = this.delta.ElapsedMilliseconds / (1000 / this.targetFps);

            // Move the player
            this.world.player.move(this.pressedKey, this.run, delta, this);

            // Move the NPCs
            foreach (var npc in this.world.npcs)
            {
                npc.moveNPC(this.world);
            }

            // Redraw
            this.Invalidate();

            // Restart the timers
            this.delta.Reset();
            this.delta.Start();
            this.loop.Start();
        }

        // Function to update the animations
        private void updateAnimations(object sender, EventArgs e)
        {
            // Animate the player
            this.world.player.animate(this.pressedKey, this.lastPressedKey);
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
        private void extractKeyCode(Keys keyCode, bool down)
        {
            if (movementKeys.Contains(keyCode)) // Check if the key is a movement key
            {
                this.lastPressedKey = this.pressedKey;
                this.pressedKey = (down) ? keyCode : Keys.None;
            }
            else if(shiftKeys.Contains(keyCode)) // Check if the shiftkey is pressed
            {
                this.run = down;
                this.animate.Interval = (this.run) ? 50 : 100;
            }
            else if(keyCode == Keys.Escape && down == false) // Check if the scape key is pressed
            {
                this.toggleMenu();
            }
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
                Rectangle rObstacle = new Rectangle(obstacle.x, obstacle.y, (int)obstacle.getPixelWidth(this.Size), (int)obstacle.getPixelHeight(this.Size));

                // Check if the obstacle intersects with the object
                if (rectangle.IntersectsWith(rObstacle))
                {
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
                    this.Size = new Size((int)(this.startScreen.Size.Width * 0.8), this.startScreen.Size.Height);
                }

                // Set the menu location
                this.pnlMenu.Location = new System.Drawing.Point(this.Size.Width / 2 - this.pnlMenu.Width / 2, this.Size.Height / 2 - this.pnlMenu.Height / 2);

                // Redraw the form
                this.Invalidate();
            }
        }

        // Override the paint method to draw the game items
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Get the graphic context
            Graphics g = e.Graphics;

            // Draw the obstacles
            foreach(Obstacle obstacle in this.world.obstacles)
            {
                obstacle.draw(g, this.Size);
            }

            // Draw the NPCs
            foreach (NPC npc in this.world.npcs)
            {
                npc.draw(g, this.Size);
            }

            // Draw the player
            this.world.player.draw(g, this.Size);

            // Draw the boss
            this.world.boss.draw(g, this.Size);
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

        // Toggle the menu
        private void toggleMenu()
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
    }
}
