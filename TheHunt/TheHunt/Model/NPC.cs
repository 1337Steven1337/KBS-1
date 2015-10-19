using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHunt.Model
{
    class Npc : Item
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
        public int normalRange = 50;
        public int newRange;
        private Boolean isReturning = false;
        public Boolean playerDetected = false;
        public Boolean playerIsInRange = false;

        public Timer timerPlayerDetect;
       
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
            Pen pen = new Pen(Color.Red, 1);
            SolidBrush myBrush = new SolidBrush(Color.FromArgb(50, Color.DarkRed));
            Rectangle radiusRect = new Rectangle(positions.current_position.x + sizeBreedte / 2 - (newRange * 2 / 2), positions.current_position.y + sizeHoogte / 2 - (newRange * 2 / 2), newRange * 2, newRange * 2);
            g.FillEllipse(myBrush, radiusRect);
            g.DrawEllipse(pen, radiusRect);

            g.DrawImage(getImage(), positions.current_position.x, positions.current_position.y, sizeBreedte, sizeHoogte);
            this.screenSize = screenSize;
        }

        public void moveNPC(World world)
        {
            if(newRange < normalRange)
            {
                newRange = normalRange;
            }
            this.world = world;
            npc = new Rectangle(positions.current_position.x, positions.current_position.y, (int)sizeBreedte, (int)sizeHoogte);
            oldx = positions.current_position.x;//OUDE X POSITIE NPC
            oldy = positions.current_position.y;//OUDE Y POSITIE NPC
            playerIsInRange = inRange(newRange);

            if (type == Type.Enemy)
            {
                if (playerIsInRange)
                {
                    if (!npcIntersectsWithObjects())
                    {
                        if (newRange < normalRange + 100)
                        {
                            newRange += 1;
                        }
                        var playerCurrentX = this.world.player.positions.current_position.x;
                        var playerCurrentY = this.world.player.positions.current_position.y;
                        var playerLastX = this.world.player.positions.last_position.x;
                        var playerLastY = this.world.player.positions.last_position.y;

                        if (playerCurrentX > playerLastX && positions.current_position.x < playerCurrentX)
                        {
                            positions.current_position.x += speed.x;
                        }
                        else if (playerCurrentX < playerLastX && positions.current_position.x > playerCurrentX)
                        {
                            positions.current_position.x -= speed.x;

                        }
                        else if (playerCurrentY > playerLastY && positions.current_position.y < playerCurrentY)
                        {
                            positions.current_position.y += speed.y;

                        }
                        else if (playerCurrentY < playerLastY && positions.current_position.y > playerCurrentY)
                        {
                            positions.current_position.y -= speed.y;
                        }
                    }
                }
                else
                {
                    newRange -= 1;
                    if (npcChooseNewRoute())
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
        }

        public bool inRange(int range)
        {
            int WidthPlayer = world.player.sizeBreedte;
            int HeigthPlayer = world.player.sizeHoogte;
            bool inrange = false;
            int PythagorasX;
            int Pythagorasy;

            int playerX = WidthPlayer / 2 + world.player.positions.current_position.x;
            int playerY = HeigthPlayer / 2 + world.player.positions.current_position.y;

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

        private bool npcIntersectsWithObjects()
        {
            if (npc.Top < 0 || npc.Left < 0 || npc.Bottom > this.screenSize.Height || npc.Right > this.screenSize.Width)
            {
                return true;
            }

            //check if NPS intersect with wall
            foreach (var item in this.world.obstacles)
            {
                Rectangle wall = new Rectangle(item.x, item.y, (int)item.getPixelWidth(this.screenSize), (int)item.getPixelHeight(this.screenSize));

                if (npc.IntersectsWith(wall))
                {
                    return true;
                }
            }

            //check if NPS intersect with Boss

            Rectangle boss = new Rectangle(world.boss.position.x, world.boss.position.y, world.boss.sizeBreedte, world.boss.sizeHoogte);

            if (npc.IntersectsWith(boss))
            {
                return true;
            }

            //check if NPS intersect with other NPC
            foreach (var item in this.world.npcs)
            {
                if (item != this)
                {
                    Rectangle otherNPC = new Rectangle(item.positions.current_position.x, item.positions.current_position.y, (int)item.getPixelWidth(this.screenSize), (int)item.getPixelHeight(this.screenSize));

                    if (npc.IntersectsWith(otherNPC))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool npcChooseNewRoute()
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

            if (npcIntersectsWithObjects()){
                return true;
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
