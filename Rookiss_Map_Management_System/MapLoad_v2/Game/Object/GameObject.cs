using MapLoad_v2.Game.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MapLoad_v2.Game.Object
{
    public class GameObject
    {
        public GameRoom Room { get; set; }
        public Vector2 Pos;
    }
}
