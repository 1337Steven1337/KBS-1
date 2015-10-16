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

        public int sizeBreedte = Screen.PrimaryScreen.Bounds.Width / 40;
        public int sizeHoogte = Screen.PrimaryScreen.Bounds.Height / 20;

        public int oldx, oldy;
        public int randomPosition = 0;

        private Boolean isReturning = false;
        public Boolean playerDetected = false;

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
            oldx = positions.current_position.x;
            oldy = positions.current_position.y;

            if (type == Type.Enemy)
            {
                if (playerDetected)
                {
                    positions.current_position.x = this.world.Player.positions.last_position.x;
                    positions.current_position.y = this.world.Player.positions.last_position.y;                    
                }
                else
                { 
                    if (npcIntersects())
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

        private bool npcIntersects()
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

            Rectangle npc = new Rectangle(positions.current_position.x, positions.current_position.y, (int)sizeBreedte, (int)sizeHoogte);

            Rectangle player = new Rectangle(this.world.Player.positions.current_position.x, this.world.Player.positions.current_position.y, (int)sizeBreedte, (int)sizeHoogte);
            if (npc.IntersectsWith(player))
            {
                playerDetected = true;
            }

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
