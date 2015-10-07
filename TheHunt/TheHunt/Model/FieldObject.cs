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
        public enum Type
        {
            Wall,
            Enemy,
            Boss,
            Character
        }

        public int x = 0;
        public int y = 0;
        private int height = 0;
        private int width = 0;

        public Type type = Type.Wall;

        public FieldObject(int x, int y, Type type)
        {
            this.x = x;
            this.y = y;
            this.type = type;

            if(this.type == Type.Wall)
            {
                this.height = 96;
                this.width = 64;
            }
        }

        public void draw(Graphics g)
        {
            for(int x = 0; x < this.width; x+=32)
            {
                for(int y = 0; y < this.height; y+=32)
                {
                    g.DrawImage(getImage(), this.x + x, this.y + y, 32, 32);
                }
            }
        }

        public bool collision(int x, int y, int width, int height)
        {
            return ((x >= this.x && x <= this.x + this.width || x + width >= this.x && x + width <= this.x) &&
               (y >= this.y && y <= this.y + this.height || y + height >= this.y && y + height <= this.y));
        }

        private Image getImage()
        {
            if(this.type == Type.Wall)
            {
                Console.WriteLine(Directory.GetCurrentDirectory());
                return Image.FromFile(Directory.GetCurrentDirectory()  + "../Resources/wall.png");
            }
            return null;

        }
    }
}
