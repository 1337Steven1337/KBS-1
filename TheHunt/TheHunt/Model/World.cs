﻿using System.Collections.Generic;

namespace TheHunt.Model
{
    class World
    {
        public List<Obstacle> obstacles = new List<Obstacle>();
        public List<Model.Npc> npcs = new List<Model.Npc>();
        public List<Model.Powerups> powerups = new List<Model.Powerups>();

        public Player player = new Player();
        public Finish finish = new Finish();

        private Score score = null;

        public World()
        {
            this.score = new Score(10000, "World");
        }

        public Score getScore()
        {
            return this.score;
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

