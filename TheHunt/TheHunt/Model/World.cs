﻿using System;
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
        public List<NPC> NPC = new List<NPC>();

        public Player Player = new Player();
        public Boss Boss = new Boss();
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

    struct Positions
    {
        public Point current_position;
        public Point return_position;
        public Point last_position;
    }
}

