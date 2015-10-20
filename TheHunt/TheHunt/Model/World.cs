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

        public Player player = new Player();
        public Boss boss = new Boss();
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

