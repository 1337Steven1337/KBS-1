using System;
using System.Collections.Generic;
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

        public FieldObject(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int x = 0;
        public int y = 0;

        public Type type = Type.Wall;
    }
}
