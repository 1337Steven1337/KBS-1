using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheHunt.Service;

namespace TheHunt.Model
{
    class Npc : Item
    {
        private Label infoLabel;
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

        //These variables will be used to make the bouncer NPC look like they're moving
        private List<Bitmap> VBouncerList = new List<Bitmap> { Properties.Resources.VBouncer1, Properties.Resources.VBouncer2, Properties.Resources.VBouncer3, Properties.Resources.VBouncer4 };
        private List<Bitmap> HBouncerList = new List<Bitmap> { Properties.Resources.HBouncer1, Properties.Resources.HBouncer2, Properties.Resources.HBouncer3, Properties.Resources.HBouncer4 };
        private int currentBouncerSprite = 0;

        //This will set the spawntime for the SuicideBomberNPC
        private List<Bitmap> SSBSpriteList = new List<Bitmap> { Properties.Resources.SSB1, Properties.Resources.SSB2, Properties.Resources.SSB3, Properties.Resources.SSB4, Properties.Resources.SSB5, Properties.Resources.SSB6, Properties.Resources.SSB7, Properties.Resources.SSB8, Properties.Resources.SSB9, Properties.Resources.SSB10, Properties.Resources.SSB11, Properties.Resources.SSB12 };
        private int currentSSBSprite = 0;
        private int spriteRichtingCount = 0;
        private string richting = "";
        public int SSBspawnTimer = 3000;
        private int lastPosCount = Player.lastPositionsList.Count; //Used for SSB Movement.
        private int currentSSBpos = 0;
        private Game game;

        private int oldx, oldy, newRange;

        //Enemy's start position,
        private int randomPosition = 0;
       
        //Enemy's normal start range
        private int normalRange = 100;

        //Maximum range of the enemy 
        private int maximumRange = 200;

        //Speed of the range when player is in it.
        private int rangeSpeed = 10;

        //Boolean player in range of the Enemy
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
            V_Bouncer,
            SuicideBomber
        }

        private void substractScore()
        {
            if (this.type == Type.Enemy)
            {
                world.getScore().subtract(20);
            }
            else if (this.type == Type.H_Bouncer)
            {
                world.getScore().subtract(40);
            }
            else
            {
                world.getScore().subtract(40);
            }
        }

        public void animateBouncers()
        {
            if (currentBouncerSprite < 3)
            {
                currentBouncerSprite++;
            }
            else
            {
                currentBouncerSprite = 0;
            }
        }


        public void animateSSB()
        {
            string tempRichting = "";
            if (this.positions.current_position.x < Player.lastPositionsList[currentSSBpos].x)
            {
                tempRichting = "rechts";
                currentSSBSprite = 7;
            }
            else if (this.positions.current_position.x > Player.lastPositionsList[currentSSBpos].x)
            {
                tempRichting = "links";
                currentSSBSprite = 10;
            }
            else if (this.positions.current_position.y > Player.lastPositionsList[currentSSBpos].y)
            {
                tempRichting = "boven";
                currentSSBSprite = 4;
            }
            else if (this.positions.current_position.y < Player.lastPositionsList[currentSSBpos].y)
            {
                tempRichting = "beneden";
                currentSSBSprite = 1;
            }
            richting = tempRichting;


            if (tempRichting == richting)
            {
                if (spriteRichtingCount + 1 < 3)
                {
                    spriteRichtingCount++;
                }
                else
                {
                    spriteRichtingCount = 0;
                }
                switch (richting)
                {
                    case "links":
                        switch (spriteRichtingCount)
                        {
                            case 0:
                                currentSSBSprite = 9;
                                break;
                            case 1:
                                currentSSBSprite = 10;
                                break;
                            case 2:
                                currentSSBSprite = 11;
                                break;
                        }
                        break;
                    case "rechts":
                        switch (spriteRichtingCount)
                        {
                            case 0:
                                currentSSBSprite = 6;
                                break;
                            case 1:
                                currentSSBSprite = 7;
                                break;
                            case 2:
                                currentSSBSprite = 8;
                                break;
                        }
                        break;
                    case "boven":
                        switch (spriteRichtingCount)
                        {
                            case 0:
                                currentSSBSprite = 3;
                                break;
                            case 1:
                                currentSSBSprite = 4;
                                break;
                            case 2:
                                currentSSBSprite = 5;
                                break;
                        }
                        break;
                    case "beneden":
                        switch (spriteRichtingCount)
                        {
                            case 0:
                                currentSSBSprite = 0;
                                break;
                            case 1:
                                currentSSBSprite = 1;
                                break;
                            case 2:
                                currentSSBSprite = 2;
                                break;
                        }
                        break;

                }
            }
            else
            {
                spriteRichtingCount = 0;
            }

        }

        public void draw(Graphics g, Size screenSize, string drawMode)
        {
            float screenWidth = (float)(screenSize.Width / 40.00);
            float screenHeight = (float)(screenSize.Height / 20.00);

            Pen pen = new Pen(Color.Red, 1);
            SolidBrush myBrush = new SolidBrush(Color.FromArgb(50, Color.DarkRed));

            if (drawMode == "Game") { 
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
                g.DrawImage(getImage(), (int)(positions.current_position.x * screenSize.Width / 40.00), (int)(positions.current_position.y * screenSize.Height / 20.00), sizeBreedte, sizeHoogte);
            }

            if (type == Type.V_Bouncer && drawHitAroundPlayer == true || type == Type.H_Bouncer && drawHitAroundPlayer == true)
            {
                Rectangle radiusRect = new Rectangle(this.world.player.positions.current_position.x, this.world.player.positions.current_position.y, (int)screenWidth, (int)screenHeight);
                g.FillRectangle(myBrush, radiusRect);
                g.DrawRectangle(pen, radiusRect);
            }
            this.screenSize = screenSize;
        }

        public void moveNPC(World world)
        {
            this.world = world;
            npc = new Rectangle(positions.current_position.x, positions.current_position.y, (int)sizeBreedte, (int)sizeHoogte);
            oldx = positions.current_position.x;//OLD X POSITION NPC
            oldy = positions.current_position.y;//OLD Y POSITION NPC

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
                        if (newRange < maximumRange)
                        {
                            newRange += rangeSpeed;
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
                    newRange -= rangeSpeed / 5;
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

            if (type == Type.V_Bouncer)
            {
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
            if (type == Type.SuicideBomber)
            {
                if (Player.lastPositionsList.Count > 0)
                {
                    Rectangle PlayerRectangle = new Rectangle(this.world.player.positions.current_position.x, this.world.player.positions.current_position.y, this.world.player.sizeBreedte, this.world.player.sizeHoogte);
                    Rectangle SSBRectangle = new Rectangle(this.positions.current_position.x,this.positions.current_position.y,this.sizeBreedte,this.sizeHoogte);
                    if (SSBRectangle.IntersectsWith(PlayerRectangle))
                    {
                        Game.SSBPlayerCollision = true;
                    }
                    this.positions.current_position.x = Player.lastPositionsList[currentSSBpos].x;
                    this.positions.current_position.y = Player.lastPositionsList[currentSSBpos].y;
                    if (currentSSBpos < Player.lastPositionsList.Count -1)
                    {
                        currentSSBpos++;
                    }
                    
                }                
            }


        }

        private bool playerIntersectWithBouncers()
        {
            //check if player intersects with Bouncers 
            Rectangle newPlayerRectangle = new Rectangle(this.world.player.positions.current_position.x, this.world.player.positions.current_position.y, this.world.player.sizeBreedte, this.world.player.sizeHoogte);

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
                Rectangle wall = new Rectangle(item.x, item.y, (int)item.getPixelWidth(this.screenSize), (int)item.getPixelHeight(this.screenSize));

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
                    Rectangle otherNPC = new Rectangle(item.positions.current_position.x + 20, item.positions.current_position.y + 5, item.width, item.height);

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
                if (this.type == Type.Enemy)
                {
                    this.image = new Bitmap(TheHunt.Properties.Resources.Enemy);
                }
                else if (this.type == Type.H_Bouncer)
                {
                    this.image = this.HBouncerList[currentBouncerSprite];
                }
                else if (this.type == Type.V_Bouncer)
                {
                    this.image = this.VBouncerList[currentBouncerSprite];
                }else if (this.type == Type.SuicideBomber)
            {
                this.image = this.SSBSpriteList[currentSSBSprite];
            }
            return this.image;
        }

        public Npc clone()
        {
            return (Npc)this.MemberwiseClone();
        }

        public void removeLabel()
        {
            if(this.infoLabel != null && this.game != null)
            {
                this.game.Controls.Remove(infoLabel);
                this.infoLabel = null;
            }
        }
        
        //methode om te kijken of er een player in range is
        public void checkForPlayer(World world, Game game)
        {
            //kijk of de informatie aan gezet is en of er een speler in range is
            if (Properties.Settings.Default.enemyInformation && inRange(300))
            {
                //kijk of de label leeg is
                if (this.infoLabel == null)
                {
                    this.game = game;
                    //als de label leeg is doe dit
                    this.infoLabel = new Label();
                    this.infoLabel.AutoSize = true;
                    this.infoLabel.Visible = true;
                    //voeg de label toe aan het form
                    game.Controls.Add(infoLabel);
                }
                //update de informatie en de locatie van het label zolang deze in range blijft
                this.infoLabel.Location = new System.Drawing.Point((int)this.positions.current_position.x - 50, (int)(this.positions.current_position.y - 20));
                this.infoLabel.Text = "X: " + this.positions.current_position.x + ", Y: " + this.positions.current_position.y + ", Speed:  " + this.speed.x;
            }
            else
            {
                //is hij niet in range of is het uit gezet verwijder dan het label van het form en maak het label leeg voor de volgende keer
                game.Controls.Remove(infoLabel);
                this.infoLabel = null;
            }
        }
    }
}
