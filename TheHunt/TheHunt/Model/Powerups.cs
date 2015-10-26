using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace TheHunt.Model
{
    class Powerups : Item
    {
        public Boolean used;

        public Size screenSize;
        public Rectangle powerup;

        public int sizeBreedte = Screen.PrimaryScreen.Bounds.Width / 40;
        public int sizeHoogte = Screen.PrimaryScreen.Bounds.Height / 20;

        public int x = 0;
        public int y = 0;
        public int height = 1;
        public int width = 1;
        public Type type;

        private World world = null;
        private Game game = null;
        public Image image = null;


        public Boolean getUsed()
        {
            return used;
        }

        public void UsePowerup()
        {
            used = true;

            if(type == Type.Speedboost) {
                game.speedBoostActive = true;
            }
            if(type == Type.Scoreboost)
            {
                //addscore , currentscore / 100 
            }
        }

        public enum Type
        {
            Speedboost,
            Scoreboost
        }

        public void draw(Graphics g, Size screenSize)
        {
            if (!used)
            {
                float screenWidth = getOnScreenHeight(screenSize);
                float screenHeight = getOnScreenHeight(screenSize);

                g.DrawImage(getImage(), this.x, this.y, sizeBreedte, sizeHoogte);
                this.screenSize = screenSize;
            }
        }

        public void checkCollision(World world, Game game)
        {
            this.game = game;
            this.world = world;
            powerup = new Rectangle(this.x, this.y, (int)sizeBreedte, (int)sizeHoogte);

            if (playerIntersectWithPowerup())
            {
                if (!getUsed())
                {
                    UsePowerup();
                }
            }
        }

        private bool playerIntersectWithPowerup()
        {
            //check if player intersects with Bouncers 
            Rectangle newPlayerRectangle = new Rectangle(this.world.player.positions.current_position.x, this.world.player.positions.current_position.y, (int)this.world.player.sizeBreedte, (int)this.world.player.sizeHoogte);

            foreach (var pu in this.world.powerups)
            {
                if (newPlayerRectangle.IntersectsWith(powerup))
                {
                    return true;
                }                
            }
            return false;
        }

        public float getPixelWidth(Size screenSize)
        {
            return this.width * screenSize.Width / 40;
        }

        public float getPixelHeight(Size screenSize)
        {
            return this.height * screenSize.Height / 20;
        }

        private Image getImage()
        {
            if (this.image == null)
            {
                if (this.type == Type.Speedboost)
                {
                    this.image = new Bitmap(TheHunt.Properties.Resources.Speedboost);
                }
                else if (this.type == Type.Scoreboost)
                {
                    this.image = new Bitmap(TheHunt.Properties.Resources.Scoreboost);
                }
            }
            return this.image;
        }

        public Powerups clone()
        {
            return (Powerups)this.MemberwiseClone();
        }
    }
}
