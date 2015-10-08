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
        public Player Player = new Player();
    }

    public struct Point
    {
        public int x;
        public int y;
    }

    public class Player
    {
        public string img;
        public Point position;
        public Point speed;

        public void draw(Graphics g)
        {
            g.DrawImage(Properties.Resources.brockSprite11, this.position.x, this.position.y, 32, 32);
        }
    }
}
