using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHunt.Model
{
    class FieldObject
    {
        private Image image = null;

        public enum Type
        {
            Wall,
            Enemy,
            Boss,
            Character
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

        public void draw(Graphics g)
        {
            for(int x = 0; x < this.getImageSizeWidth(); x+=32)
            {
                for(int y = 0; y < this.getImageSizeHeight(); y+=32)
                {
                    g.DrawImage(getImage(), this.x + x, this.y + y, 32, 32);
                }
            }
        }

        public bool collision(int x, int y, int width, int height)
        {
            return ((x >= this.x && x <= this.x + this.getImageSizeWidth() || x + width >= this.x && x + width <= this.x) &&
               (y >= this.y && y <= this.y + this.getImageSizeHeight() || y + height >= this.y && y + height <= this.y));
        }

        private int getImageSizeWidth()
        {
            return this.width * 32;
        }
        private int getImageSizeHeight()
        {
            return this.height * 32;
        }

        private Image getImage()
        {
            if(this.image == null)
            {
                if (this.type == Type.Wall)
                {
                    this.image = Image.FromFile(Directory.GetCurrentDirectory() + "../Resources/wall.png");
                }
                else if (this.type == Type.Enemy)
            {
                    this.image = Image.FromFile(Directory.GetCurrentDirectory() + "../Resources/enemy.gif");
                }
            }       

            return this.image;

        }
    }
}
