using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHunt.Model
{
    class Player : Item
    {
        public string img;
        public Positions positions;
        public Point speed;
        public Movement movement;
        public int sizeBreedte = Screen.PrimaryScreen.Bounds.Width / 40;
        public int sizeHoogte = Screen.PrimaryScreen.Bounds.Height / 20;

        public static Bitmap bitmap;
        public static List<Bitmap> PlayerSprites = new List<Bitmap>();

        private int lastPositionCounter = 0;
        private int spriteAnimationCounter = 0;
        private int isEersteDraw = 0;

        private Bitmap sprite = null;
        private List<Bitmap> sprites = null;

        public Player()
        {
            PlayerSprites.Add(null);
            PlayerSprites.Add(Properties.Resources.brockSprite1);
            PlayerSprites.Add(Properties.Resources.brockSprite2);
            PlayerSprites.Add(Properties.Resources.brockSprite3);
            PlayerSprites.Add(Properties.Resources.brockSprite4);
            PlayerSprites.Add(Properties.Resources.brockSprite5);
            PlayerSprites.Add(Properties.Resources.brockSprite6);
            PlayerSprites.Add(Properties.Resources.brockSprite7);
            PlayerSprites.Add(Properties.Resources.brockSprite8);
            PlayerSprites.Add(Properties.Resources.brockSprite9);
            PlayerSprites.Add(Properties.Resources.brockSprite10);
            PlayerSprites.Add(Properties.Resources.brockSprite11);
            PlayerSprites.Add(Properties.Resources.brockSprite12);

            bitmap = PlayerSprites[1];
            sprites = PlayerSprites;
        }

        public void move(Keys key, bool run, double delta, Game game)
        {
            Point speed = (run) ? this.movement.run : this.movement.walk;
            Point newPosition = new Point(this.positions.current_position.x, this.positions.current_position.y);

            switch (key)
            {
                case Keys.Up:
                    newPosition.y -= (int)(speed.y * delta);
                    break;
                case Keys.Down:
                    newPosition.y += (int)(speed.y * delta);
                    break;
                case Keys.Left:
                    newPosition.x -= (int)(speed.x * delta);
                    break;
                case Keys.Right:
                    newPosition.x += (int)(speed.x * delta);
                    break;
            }

            if (!game.intersects(newPosition, new Size(sizeBreedte, sizeHoogte)))
            {
                lastPositionCounter++;

                if (lastPositionCounter > 10)
                {
                    this.positions.last_position = this.positions.current_position;
                    lastPositionCounter = 0;
                }

                this.positions.current_position = newPosition;
            }
        }

        public void animate(Keys current, Keys last)
        {
            if (current == Keys.None)
            {
                switch (last)
                {
                    case Keys.Up:
                        this.sprite = this.sprites[4];
                        break;
                    case Keys.Down:
                        this.sprite = this.sprites[1];
                        break;
                    case Keys.Left:
                        this.sprite = this.sprites[10];
                        break;
                    case Keys.Right:
                        this.sprite = this.sprites[7];
                        break;
                }

                this.spriteAnimationCounter = 0;
            }
            else
            {
                switch (current)
                {
                    case Keys.Up:
                        this.sprite = this.sprites[4 + this.spriteAnimationCounter];
                        break;
                    case Keys.Down:
                        this.sprite = this.sprites[1 + this.spriteAnimationCounter];
                        break;
                    case Keys.Left:
                        this.sprite = this.sprites[10 + this.spriteAnimationCounter];
                        break;
                    case Keys.Right:
                        this.sprite = this.sprites[7 + this.spriteAnimationCounter];
                        break;
                }

                this.spriteAnimationCounter = (this.spriteAnimationCounter + 1 > 2) ? 0 : this.spriteAnimationCounter + 1;
            }
        }


        public void draw(Graphics g, Size screenSize, string drawMode)
        {
            //Set Player to the right positions on start.
            if (drawMode == "Game") { 
                g.DrawImage((this.sprite == null) ? bitmap : this.sprite, this.positions.current_position.x, this.positions.current_position.y, sizeBreedte, sizeHoogte);
            }
            else //this part is used in Designer
            {
                g.DrawImage((this.sprite == null) ? bitmap : this.sprite, (int)(this.positions.current_position.x * screenSize.Width / 40.00), (int)(this.positions.current_position.y * screenSize.Height / 20.00), sizeBreedte, sizeHoogte);
            }

        }

        public Image getImage()
        {
            return this.sprites[1];
        }

        public Player clone()
        {
            return (Player)this.MemberwiseClone();
        }
    }
}
