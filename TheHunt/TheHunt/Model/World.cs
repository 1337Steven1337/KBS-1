using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHunt.Model
{
    class World
    {
        public List<FieldObject> FieldObjects = new List<FieldObject>();
        public Player Player = new Player();
    }

    public struct Position
    {
        public int x;
        public int y;
    }

    public class Player
    {
        public string img;
        public Position start;
    }
}
