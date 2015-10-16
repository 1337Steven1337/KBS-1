using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHunt.Model
{
    class NPC : Item
    {
        private World world = null;
        private Image image = null;      
          
        public Point speed;
        public Positions positions;
        public Size screenSize;
        Random rnd = new Random();
        public Rectangle npc;

        public int sizeBreedte = Screen.PrimaryScreen.Bounds.Width / 40;
        public int sizeHoogte = Screen.PrimaryScreen.Bounds.Height / 20;

        public int oldx, oldy;
        public int randomPosition = 0;

        private Boolean isReturning = false;
        public Boolean playerDetected = false;
        public Boolean playerIsInRange = false;

        public int width = 1;
        public int height = 1;      
        public Type type;

        public enum Type
        {
            Enemy,
            Boss
        }

        public void draw(Graphics g, Size screenSize)
        {
            float screenWidth = getOnScreenHeight(screenSize);
            float screenHeight = getOnScreenHeight(screenSize);
            g.DrawImage(getImage(), positions.current_position.x, positions.current_position.y, sizeBreedte, sizeHoogte);
            this.screenSize = screenSize;
        }

        public void moveNPC(World world)
        {
            this.world = world;
            npc = new Rectangle(positions.current_position.x, positions.current_position.y, (int)sizeBreedte, (int)sizeHoogte);
            oldx = positions.current_position.x;//OUDE X POSITIE NPC
            oldy = positions.current_position.y;//OUDE Y POSITIE NPC
            playerIsInRange = inRange(100);

            if (type == Type.Enemy)
            {
                if (playerIsInRange)
                {
                    positions.current_position.x = this.world.Player.positions.last_position.x;
                    positions.current_position.y = this.world.Player.positions.last_position.y;
                }

                if (npcIntersectsWithWall())
                {
                    this.positions.current_position.x = oldx;
                    this.positions.current_position.y = oldy;
                    var lastRandomPosition = randomPosition;

                    while (lastRandomPosition == randomPosition)
                    {
                        randomPosition = rnd.Next(4);
                    }
                }
                
            }
        }

        public bool inRange(int range)
        {
            int WidthPlayer = world.Player.sizeBreedte;
            int HeigthPlayer = world.Player.sizeHoogte;
            bool inrange = false;
            int PythagorasX;
            int Pythagorasy;

            int playerX = WidthPlayer / 2 + world.Player.positions.current_position.x;
            int playerY = HeigthPlayer / 2 + world.Player.positions.current_position.y;

            int npcX = npc.Width / 2 + positions.current_position.x; //moet nog worden verandert als de xlocatie van enemy bekend is
            int npcY = npc.Height / 2 + positions.current_position.y; //moet nog worden verandert als de ylocatie van enemy bekend is

            //xcoordinaar bepalen
            if (playerX >= npcX)
            {
                PythagorasX = playerX - npcX;
            }
            else
            {
                PythagorasX = npcX - playerX;
            }
            //ycoordinaat bepalen

            if (playerY >= npcY)
            {
                Pythagorasy = playerY - npcY;
            }
            else
            {
                Pythagorasy = npcY - playerY;
            }

            //xkwadraat
            int PowerToX = PythagorasX * PythagorasX;
            //ykwadraat
            int PowerToY = Pythagorasy * Pythagorasy;
            //xkwadraat + ykwadraat
            int compareNumber = PowerToX + PowerToY;
            //ckwadraat
            int compareToNumer = range * range;
            //ultimate check
            if (compareNumber < compareToNumer)
            {
                inrange = true;
            }        
            return inrange;
        }
        //wanneer player in range is:
        public int isInRange(int range)
        {
            range += 100;
            return range;
        }

        private bool npcIntersectWithPlayer()
        {
            Rectangle player = new Rectangle(this.world.Player.positions.current_position.x, this.world.Player.positions.current_position.y, (int)sizeBreedte, (int)sizeHoogte);
            if (npc.IntersectsWith(player))
            {
                playerDetected = true;
            }
            return false;
        }

        private bool npcIntersectsWithWall()
        {
            switch (randomPosition)
            {
                case 0:
                    oldy = positions.current_position.y;
                    positions.current_position.y -= speed.y;                    
                    break;
                case 1:
                    oldy = positions.current_position.y;
                    positions.current_position.y += speed.y;
                    break;
                case 2:
                    oldx = positions.current_position.x;
                    positions.current_position.x -= speed.x;
                    break;
                case 3:
                    oldx = positions.current_position.x;
                    positions.current_position.x += speed.x;
                    break;
                default:
                    break;
            }

            npc.X = positions.current_position.x;
            npc.Y = positions.current_position.y;

            if (npc.Top < 0 || npc.Left < 0 || npc.Bottom > this.screenSize.Height || npc.Right > this.screenSize.Width)
            {
                return true;
            }

            foreach (var item in this.world.obstacles)
            {
                Rectangle wall = new Rectangle(item.x, item.y, (int)item.getPixelWidth(this.screenSize), (int)item.getPixelHeight(this.screenSize));

                if (npc.IntersectsWith(wall))
                {
                    return true;
                }
            }            
            return false;            
        }

        public float getPixelWidth(Size screenSize)
        {
            double getScreenRatio = screenSize.Width / screenSize.Height;
            float screenWidth = 32;
            float screenHeight = (float)(screenWidth * getScreenRatio);
            return this.width * this.getOnScreenHeight(screenSize);
        }

        public float getPixelHeight(Size screenSize)
        {
            return this.height * this.getOnScreenWidth(screenSize);
        }

        private Image getImage()
        {
            if (this.image == null)
            {
                if (this.type == Type.Enemy)
                {
                    this.image = new Bitmap(TheHunt.Properties.Resources.Enemy);
                }
                else if (this.type == Type.Boss)
                {
                    this.image = new Bitmap(TheHunt.Properties.Resources.Boss);
                }
            }
            return this.image;
        }
    }
}
