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
        public static List<Bitmap> PlayerSprites = new List<Bitmap>();
        public static Bitmap bitmap;

        public Player1()
        {
            PlayerSprites.Add(null);
            PlayerSprites.Add(Properties.Resources.brockSprite1);
            PlayerSprites.Add(Properties.Resources.brockSprite2);
            PlayerSprites.Add(Properties.Resources.brockSprite3);
            PlayerSprites.Add(Properties.Resources.brockSprite4);
            PlayerSprites.Add(Properties.Resources.brockSprite5);
            PlayerSprites.Add(Properties.Resources.brockSprite6);
            PlayerSprites.Add(Properties.Resources.brockSprite7);
            PlayerSprites.Add(Properties.Resources.brockSprite8);
            PlayerSprites.Add(Properties.Resources.brockSprite9);
            PlayerSprites.Add(Properties.Resources.brockSprite10);
            PlayerSprites.Add(Properties.Resources.brockSprite11);
            PlayerSprites.Add(Properties.Resources.brockSprite12);

            bitmap = PlayerSprites[1];

        }

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
