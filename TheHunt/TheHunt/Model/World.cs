using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHunt.Model
{
    class World
    {
        public List<FieldObject> FieldObjects = new List<FieldObject>();
        public Player1 Player = new Player1();
    }

    public struct Point
    {
        public int x;
        public int y;
    }

    public class Player1
    {
        public string img;
        public Point position;
        public Point speed;
        public static Bitmap bitmap = Properties.Resources.brockSprite11;

        public void draw(Graphics g)
        {
            g.DrawImage(bitmap, this.position.x, this.position.y, 32, 32);
        }
    }
}
