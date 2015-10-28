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


        private Image image = null;


        public Boolean getUsed()
        {
            return used;
        }

        public void setUsed(bool used)
        {
            this.used = used;
        }

        public void UsePowerup(Game game)
        {
            setUsed(true);

            if(type == Type.Speedboost) {
                game.speedBoostActive = true;
                game.speedBoostLength += 5000;
                game.speedBoostTimer.Start();
            }
            if(type == Type.Scoreboost)
            {
                game.addScore(1000);
            }
            if(type == Type.Emp)
            {
                game.emp = true;
                game.Emp();
        }
        }

        public enum Type
        {
            Speedboost,
            Scoreboost,
            Emp
        }

        public void draw(Graphics g, Size screenSize, string drawMode, bool isUsed)
        {
                float screenWidth = (float)(screenSize.Width / 40.00);
                float screenHeight = (float)(screenSize.Height / 20.00);
            if (drawMode == "Game")
            {
                if (isUsed == false)
                {
                    g.DrawImage(getImage(), this.x, this.y, screenWidth, screenHeight);
            }
        }
            else if (drawMode == "Designer")
            {
                g.DrawImage(getImage(), (this.x * screenWidth), (int)(this.y * screenHeight), screenWidth, screenHeight);
            }

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
                    this.image = new Bitmap(TheHunt.Properties.Resources.SpeedUp);
                }
                else if (this.type == Type.Scoreboost)
                {
                    this.image = new Bitmap(TheHunt.Properties.Resources.Scoreboost);
                }
                else if (this.type == Type.Emp)
                {
                    this.image = new Bitmap(TheHunt.Properties.Resources.emp);
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
