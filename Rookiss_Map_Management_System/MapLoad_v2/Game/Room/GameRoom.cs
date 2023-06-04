using MapLoad_v2.Game.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MapLoad_v2.Game.Room
{
    public class GameRoom
    {
        public Map Map { get; private set; } = new Map();

        public void Init(int mapId)
        {
            Map.LoadMap(mapId);
        }

        public void EnterGame(GameObject gameObject)
        {
            if (gameObject == null)
                return;

            Map.ApplyMove(gameObject, new Vector3(1, 5, 0));

        }
    }
}
