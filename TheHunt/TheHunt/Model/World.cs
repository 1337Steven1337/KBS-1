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
        public List<NPC> NPC = new List<NPC>();
        public Player1 Player = new Player1();        
    }

   struct Point
    {
        public int x;
        public int y;
        private int v1;
        private int v2;

        public Point(int v1, int v2) : this()
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }

    class Player1 : ResizableObject
    {
        public string img;
        public Point position;
        public Point speed;
        public static Bitmap bitmap = Properties.Resources.brockSprite11;

        public void draw(Graphics g,Size screenSize)
        {
            g.DrawImage(bitmap, this.position.x, this.position.y, getOnScreenWidth(screenSize), getOnScreenHeight(screenSize));
        }
    }
}
