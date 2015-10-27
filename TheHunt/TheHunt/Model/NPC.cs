using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheHunt.Controller.Highscore;
namespace TheHunt.Model
{
    class Npc : Item
    {
        private World world = null;
        private Image image = null;
        private Highscore highscore = null;
        public Point speed;
        public Positions positions;
        public Size screenSize;
        public Rectangle npc;

        Random rnd = new Random();

        public int sizeBreedte = Screen.PrimaryScreen.Bounds.Width / 40;
        public int sizeHoogte = Screen.PrimaryScreen.Bounds.Height / 20;

        private int isEersteDraw = 0;

        private int oldx, oldy, newRange;

        //Enemy's start position
        private int randomPosition = 0;
       
        //Enemy's normal start range
        private int normalRange = 100;

        private Boolean playerIsInRange = false;

        //Bouncer objects booleans
        private Boolean v_bouncer_up = true;
        private Boolean v_bouncer_down = false;
        private Boolean h_bouncer_left = true;
        private Boolean h_bouncer_right = false;
        private Boolean drawHitAroundPlayer = false;
        
        public int width = 1;
        public int height = 1;
        public Type type;

        public enum Type
        {
            Enemy,
            H_Bouncer,
            V_Bouncer
        }

        private void substractScore()
        {
            if (this.type == Type.Enemy)
            {
                world.substractScore(2);
            }
            else if (this.type == Type.H_Bouncer)
            {
                world.substractScore(4);
            }
            else
            {
                world.substractScore(4);
            }
        }

        public void draw(Graphics g, Size screenSize, string drawMode)
        {
            float screenWidth = getOnScreenHeight(screenSize);
            float screenHeight = getOnScreenHeight(screenSize);
            Pen pen = new Pen(Color.Red, 1);
            SolidBrush myBrush = new SolidBrush(Color.FromArgb(50, Color.DarkRed));

            if (isEersteDraw == 0 && drawMode == "Game") {
                this.positions.current_position = new Point((int)(this.positions.current_position.x * screenSize.Width / 40.00), (int)(this.positions.current_position.y * screenSize.Height / 20.00));
                isEersteDraw++;
            }else if (isEersteDraw > 0 && drawMode == "Game")
            {
                if (type == Type.Enemy)
                {
                    Rectangle radiusRect = new Rectangle(positions.current_position.x + sizeBreedte / 2 - (newRange * 2 / 2), positions.current_position.y + sizeHoogte / 2 - (newRange * 2 / 2), newRange * 2, newRange * 2);
                    g.FillEllipse(myBrush, radiusRect);
                    g.DrawEllipse(pen, radiusRect);
                }
                g.DrawImage(getImage(), positions.current_position.x, positions.current_position.y, sizeBreedte, sizeHoogte);
            }
            else //Will be used in designer
            {
                g.DrawImage(getImage(), (int)(positions.current_position.x * screenSize.Width/40.00), (int)(positions.current_position.y * screenSize.Height/20.00), sizeBreedte, sizeHoogte);
            }

            if (type == Type.V_Bouncer && drawHitAroundPlayer == true || type == Type.H_Bouncer && drawHitAroundPlayer == true)
            {
                Rectangle radiusRect = new Rectangle(this.world.player.positions.current_position.x, this.world.player.positions.current_position.y, sizeBreedte, sizeHoogte);
                g.FillRectangle(myBrush, radiusRect);
                g.DrawRectangle(pen, radiusRect);
            }
            this.screenSize = screenSize;
        }

        public void moveNPC(World world)
        {
            this.world = world;
            npc = new Rectangle(positions.current_position.x, positions.current_position.y, (int)sizeBreedte, (int)sizeHoogte);
            oldx = positions.current_position.x;//OUDE X POSITIE NPC
            oldy = positions.current_position.y;//OUDE Y POSITIE NPC

            if (type == Type.Enemy)
            {
                if (newRange < normalRange)
                {
                    newRange = normalRange;
                }
                playerIsInRange = inRange(newRange);
                if (playerIsInRange)
                {
                    this.substractScore();
                    if (!npcIntersectsWithObjects())
                    {
                        if (newRange < normalRange * 2)
                        {
                            newRange += 3;
                        }

                        if (Game.isPlayerMoving)
                        {
                            var playerCurrentX = (int)(this.world.player.positions.current_position.x);
                            var playerCurrentY = (int)(this.world.player.positions.current_position.y);
                            var playerLastX = (int)(this.world.player.positions.last_position.x);
                            var playerLastY = (int)(this.world.player.positions.last_position.y);
                            if (playerCurrentX > playerLastX && positions.current_position.x < playerCurrentX)
                            {
                                positions.current_position.x += speed.x;
                            }
                            else if (playerCurrentX > playerLastX && positions.current_position.x > playerCurrentX)
                            {
                                positions.current_position.x -= speed.x;
                            }
                            else if (playerCurrentX < playerLastX && positions.current_position.x > playerCurrentX)
                            {
                                positions.current_position.x -= speed.x;
                            }
                            else if (playerCurrentX < playerLastX && positions.current_position.x < playerCurrentX)
                            {
                                positions.current_position.x += speed.x;
                            }
                            else if (playerCurrentY > playerLastY && positions.current_position.y < playerCurrentY)
                            {
                                positions.current_position.y += speed.y;

                            }
                            else if (playerCurrentY > playerLastY && positions.current_position.y > playerCurrentY)
                            {
                                positions.current_position.y -= speed.y;

                            }
                            else if (playerCurrentY < playerLastY && positions.current_position.y > playerCurrentY)
                            {
                                positions.current_position.y -= speed.y;
                            }
                            else if (playerCurrentY < playerLastY && positions.current_position.y < playerCurrentY)
                            {
                                positions.current_position.y += speed.y;
                            }
                        }
                        else
                        {
                            var playerCurrentX = (int)(this.world.player.positions.current_position.x);
                            var playerCurrentY = (int)(this.world.player.positions.current_position.y);
                            if (playerCurrentX > positions.current_position.x)
                            {
                                positions.current_position.x += speed.x;
                            }
                            if (playerCurrentX < positions.current_position.x)
                            {
                                positions.current_position.x -= speed.x;
                            }
                            if (playerCurrentY > positions.current_position.y)
                            {
                                positions.current_position.y += speed.y;
                            }
                            if (playerCurrentY < positions.current_position.y)
                            {
                                positions.current_position.y -= speed.y;
                            }
                        }




                    }
                }
                else
                {
                    newRange -= 2;
                    if (EnemyChooseNewRoute())
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

            if (type == Type.V_Bouncer){
                if (v_bouncer_up)
                {
                    positions.current_position.y -= speed.y;          
        }
                else if (v_bouncer_down)
                {
                    positions.current_position.y += speed.y;               
                }

                npc.X = positions.current_position.x;
                npc.Y = positions.current_position.y;

                //check of er intersect is met objecten als de positie wordt veranderd
                if (npcIntersectsWithObjects())
        {
                    if (v_bouncer_up)
                    {
                        v_bouncer_up = false;
                        v_bouncer_down = true;
                    }
                    else if (v_bouncer_down)
                    {
                        v_bouncer_up = true;
                        v_bouncer_down = false;
                    }

                    //intersect verwacht dus zet oude coordinaten
                    this.positions.current_position.x = oldx;
                    this.positions.current_position.y = oldy;
                }
                //Check if player intersects with bouncer, yes draw a border around te player(visual)
                if (playerIntersectWithBouncers())
                {
                    this.substractScore();
                    drawHitAroundPlayer = true;
                }
                else
                {
                    drawHitAroundPlayer = false;
                }
            }

            if (type == Type.H_Bouncer)
            {
                if (h_bouncer_left)
                {
                    positions.current_position.x -= speed.x;
                }
                else if (h_bouncer_right)
                {
                    positions.current_position.x += speed.x;
                }

                npc.X = positions.current_position.x;
                npc.Y = positions.current_position.y;

                //check of er intersect is met objecten als de positie wordt veranderd
                if (npcIntersectsWithObjects())
                {
                    if (h_bouncer_left)
            {
                        h_bouncer_left = false;
                        h_bouncer_right = true;
            }
                    else if (h_bouncer_right)
            {
                        h_bouncer_left = true;
                        h_bouncer_right = false;
                    }

                    //intersect verwacht dus zet oude coordinaten
                    this.positions.current_position.x = oldx;
                    this.positions.current_position.y = oldy;
            }

                //Check if player intersects with bouncer, yes draw a border around te player(visual)
                if (playerIntersectWithBouncers()) {
                    this.substractScore();
                    drawHitAroundPlayer = true;
                }
                else {
                        drawHitAroundPlayer = false;
                }
            }
        }

        private bool playerIntersectWithBouncers()
        {
            //check if player intersects with Bouncers 
            Rectangle newPlayerRectangle = new Rectangle(this.world.player.positions.current_position.x , this.world.player.positions.current_position.y, this.world.player.sizeBreedte, this.world.player.sizeHoogte);

            foreach (var item in this.world.npcs)
            {
                if (item.type == Type.V_Bouncer | item.type == Type.H_Bouncer)
                {
                    if (npc.IntersectsWith(newPlayerRectangle))
            {
                        
                        return true;
                    }
                }
            }
            return false;
        }

        private bool npcIntersectsWithObjects()
        {
            if (npc.Top < 0 || npc.Left < 0 || npc.Bottom > this.screenSize.Height || npc.Right > this.screenSize.Width)
            {
                return true;
            }

            //check if NPC intersect with wall
            foreach (var item in this.world.obstacles)
            {
                Rectangle wall = new Rectangle((int)(item.x * this.screenSize.Width/40), (int)(item.y * this.screenSize.Height/20), (int)item.getPixelWidth(this.screenSize), (int)item.getPixelHeight(this.screenSize));

                if (npc.IntersectsWith(wall))
                {
                    return true;
                }
            }

            //check if NPC intersect with Boss

            Rectangle boss = new Rectangle(world.boss.position.x, world.boss.position.y, world.boss.sizeBreedte, world.boss.sizeHoogte);

            if (npc.IntersectsWith(boss))
            {
                return true;
            }

            //check if NPC intersect with other NPC
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


        private bool EnemyChooseNewRoute()
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

            if (npcIntersectsWithObjects())
            {
                return true;
            }
            return false;
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

        public Image getImage()
        {
            if (this.image == null)
            {
                if (this.type == Type.Enemy)
                {
                    this.image = new Bitmap(TheHunt.Properties.Resources.Enemy);
                }
                else if (this.type == Type.H_Bouncer)
                {
                    this.image = new Bitmap(TheHunt.Properties.Resources.H_bouncer);
                }
                else if (this.type == Type.V_Bouncer)
                {
                    this.image = new Bitmap(TheHunt.Properties.Resources.V_bouncer);
                }
            }
            return this.image;
        }

        public Npc clone()
        {
            return (Npc)this.MemberwiseClone();
        }
    }
}
