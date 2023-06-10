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


            // 1. 본인한테 정보 전송 - S_EnterGame

            // 2. 본인 제외 다른 클라 정보들 추가 S_Spawn
            // - 다른 플레이어들
            // - 몬스터
            // - Projectile
            // 본인한테 전송


        }
    }
}
