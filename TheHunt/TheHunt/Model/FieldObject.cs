using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHunt.Model
{
    class FieldObject : ResizableObject
    {        
        private Image image = null;

        public enum Type
        {
            Wall,
            Enemy,
            Boss
        }

        public int x = 0;
        public int y = 0;
        public int height = 0;
        public int width = 0;

        public Type type = Type.Wall;

        public FieldObject(int x, int y, Type type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }

        public int screenWidth()
        {
            return Screen.PrimaryScreen.Bounds.Width;
        }


        public void draw(Graphics g, Size screenSize)
        {
            for (int x = 0; x < this.width; x++)
            {
                for (int y = 0; y < this.height; y++)
                {
                    float screenWidth = getOnScreenWidth(screenSize);
                    float screenHeight = getOnScreenHeight(screenSize);

                    g.DrawImage(getImage(), this.x + (screenWidth * x), this.y + (screenHeight * y), screenWidth, screenHeight);
                }
            }
        }

        public float getPixelWidth(Size screenSize) 
        {
            return this.width * this.getOnScreenHeight(screenSize);
        }
        public float getPixelHeight(Size screenSize)
        {
            return this.height * this.getOnScreenWidth(screenSize);
        }

        private Image getImage()
        {
            if(this.image == null)
            {
                if (this.type == Type.Wall)
                {
                    this.image = new Bitmap(TheHunt.Properties.Resources.wall);
                }
                else if (this.type == Type.Enemy)
                {
                    this.image = new Bitmap(TheHunt.Properties.Resources.Enemy);
                }
            }


            return this.image;

        }
    }
}
