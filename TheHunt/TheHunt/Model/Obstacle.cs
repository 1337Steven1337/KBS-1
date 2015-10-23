using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHunt.Model
{
    class Obstacle : Item
    {
        private Image image = null;

        public int x = 0;
        public int y = 0;
        public int height = 1;
        public int width = 1;

        public Type type;

        public enum Type
        {
            wall,
            worldground,
            fenceLeft,
            fenceRight,
            fenceUp,
            fenceDown,
            fenceUpLeft,
            fenceUpRight,
            fenceDownLeft,
            fenceDownRight
        }

        public void draw(Graphics g, Size screenSize)
        {
                    float screenWidth = (float)(screenSize.Width/ 40.00);
                    float screenHeight = (float)(screenSize.Height / 20.00);
                    g.DrawImage(getImage(), this.x * screenWidth, this.y * screenHeight, screenWidth, screenHeight);
        }

        public float getPixelWidth(Size screenSize)
        {
            return this.width * screenSize.Width/40;
        }

        public float getPixelHeight(Size screenSize)
        {
            return this.height * screenSize.Height / 20;
        }


        public Image getImage()
        {
            if (type == Type.wall)
            {
                this.image = Properties.Resources.wall;
            }else if (type == Type.worldground)
            {
                this.image = Properties.Resources.worldground;
            }
            else if (type == Type.fenceLeft)
            {
                this.image = Properties.Resources.fenceLeft;
            }
            else if (type == Type.fenceRight)
            {
                this.image = Properties.Resources.fenceRight;
            }
            else if (type == Type.fenceUp)
            {
                this.image = Properties.Resources.fenceUp;
            }
            else if (type == Type.fenceDown)
            {
                this.image = Properties.Resources.fenceDown;
            }
            else if (type == Type.fenceUpLeft)
            {
                this.image = Properties.Resources.fenceUpLeft;
            }
            else if (type == Type.fenceUpRight)
            {
                this.image = Properties.Resources.fenceUpRight;
            }
            else if (type == Type.fenceDownLeft)
            {
                this.image = Properties.Resources.fenceDownLeft;
            }
            else if (type == Type.fenceDownRight)
            {
                this.image = Properties.Resources.fenceDownRight;
            }
            return this.image;
        }

        public Obstacle clone()
        {
            return (Obstacle)this.MemberwiseClone();
        }
    }
}
