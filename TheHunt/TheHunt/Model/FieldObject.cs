using System;
using System.Collections.Generic;
using System.Drawing;
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
            Boss
        }

        public int x = 0;
        public int y = 0;

        public Type type = Type.Wall;//remco

        public FieldObject(int x, int y, Type type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }

        public void draw(Graphics g)
        {
            g.DrawImage(getImage(),100,100);     
        }

        private Image getImage()
        {
            if(this.type == Type.Wall)
            {
                return Image.FromFile("Resources/wall.png");
            }
            return null;

        }
    }
}
