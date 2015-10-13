using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
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

   struct Point
    {
        public int x;
        public int y;
    }
    struct Movement
    {
        public Point walk;
        public Point run;
    }

    class Player1 : ResizableObject
    {
        public string img;
        public Point position;
        public Point speed;
        public Movement movement;
        public int sizeBreedte = Screen.PrimaryScreen.Bounds.Width / 40;
        public int sizeHoogte = Screen.PrimaryScreen.Bounds.Height / 20;
        public static Bitmap bitmap = Properties.Resources.brockSprite11;

        public void draw(Graphics g,Size screenSize)
        {
            g.DrawImage(bitmap, this.position.x, this.position.y, sizeBreedte , sizeHoogte);
        }
    }

    class NPC
    {
        public Point position;
        public Point speed;
        public Type type;

        
    }
}
