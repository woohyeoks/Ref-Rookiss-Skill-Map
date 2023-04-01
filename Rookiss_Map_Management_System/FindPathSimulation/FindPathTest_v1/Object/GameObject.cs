using FindPathTest_v1.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPathTest_v1.Object
{
    public class GameObject
    {
        public int Id { get; set; }
        public GameRoom Room { get; set; }
        public Vector2Int Pos;
    }
}
