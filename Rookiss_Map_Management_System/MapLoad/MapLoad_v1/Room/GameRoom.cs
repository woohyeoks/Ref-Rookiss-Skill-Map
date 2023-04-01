using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLoad_v1.Room
{
    public class GameRoom
    {
        public Map Map { get; private set; } = new Map();

        public void Init(int mapId)
        {
            Map.LoadMap(mapId, "../../../../../../MapData");
        }


        public void TestCollision()
        {
            Map.TestCollision();
        }
    }
}
