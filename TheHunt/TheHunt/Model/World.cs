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
        public List<Obstacle> obstacles = new List<Obstacle>();
        public List<Model.Npc> npcs = new List<Model.Npc>();
        public List<Model.Powerups> powerups = new List<Model.Powerups>();

        public Player player = new Player();
        public Boss boss = new Boss();

        private int score = 100000;

        public int getScore()
        {
            return this.score;
        }

        public void substractScore(int amount)
        {
            if(this.score > 0)
            {
                this.score -= amount;
            }
            else
            {
                this.score = (this.score < 0) ? 0 : this.score;
            }
        }
    }

   struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    struct Movement
    {
        public Point walk;
        public Point run;
    }

    struct Positions
    {
        public Point current_position;
        public Point last_position;
    }
}

