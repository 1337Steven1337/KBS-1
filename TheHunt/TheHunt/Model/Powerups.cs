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
        private Boolean used = false;

        public int sizeBreedte = Screen.PrimaryScreen.Bounds.Width / 40;
        public int sizeHoogte = Screen.PrimaryScreen.Bounds.Height / 20;

        public int x = 0;
        public int y = 0;
        public int height = 1;
        public int width = 1;
        public Type type;

        private World world = null;
        private Game game = null;
        private Image image = null;


        public Boolean getUsed()
        {
            return used;
        }

        public void setUsed(bool used)
        {
            this.used = used;
        }

        public void UsePowerup(Powerups pu)
        {
            pu.used = true;

            if(type == Type.Speedboost) {
                game.speedBoostActive = true;
                game.speedBoostLength += 5000;
                game.speedBoostTimer.Start();
            }
            if(type == Type.Scoreboost)
            {
                game.addScore(10000);
            }
        }

        public enum Type
        {
            Speedboost,
            Scoreboost
        }

        public void draw(Graphics g, Size screenSize, bool isUsed)
        {
            if (isUsed == false)
            {
                float screenWidth = (float)(screenSize.Width / 40.00);
                float screenHeight = (float)(screenSize.Height / 20.00);
                g.DrawImage(getImage(), (int)(this.x * screenWidth), (int)(this.y * screenHeight), screenWidth, screenHeight);
            }
        }


        public bool checkCollision(World world, Game game)
        {
            this.game = game;
            this.world = world;

            if (playerIntersectWithPowerup() != null)
            {
                  UsePowerup(playerIntersectWithPowerup());
                return true;
            }
            return false;
        }

        private Powerups playerIntersectWithPowerup()
        {
            Rectangle playerCoords = new Rectangle(this.world.player.positions.current_position.x, this.world.player.positions.current_position.y, (int)(this.game.Width / 40.00), (int)(this.game.Height / 20.00));
            foreach (var pu in this.world.powerups)
            {
                if (playerCoords.IntersectsWith(new Rectangle(pu.x * (int)(this.game.Width/40.00), pu.y * (int)(this.game.Height / 20.00), (int)(this.game.Width / 40.00), (int)(this.game.Height / 20.00))))
                {
                    return pu;
                }
            }
            return null;
        }


        private Image getImage()
        {
            if (this.image == null)
            {
                if (this.type == Type.Speedboost)
                {
                    this.image = new Bitmap(TheHunt.Properties.Resources.SpeedUp);
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
