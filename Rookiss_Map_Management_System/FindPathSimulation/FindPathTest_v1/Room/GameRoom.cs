using FindPathTest_v1.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FindPathTest_v1.Room
{
    public class GameRoom
    {
        Dictionary<int, GameObject> _players = new Dictionary<int, GameObject>();
        public GameObject _myPlayer = null;
        public Map Map { get; private set; } = new Map();

        public void Init(int mapId)
        {
            _players.Clear();
            Map.LoadMap(mapId, "../../../../../../MapData");
        }


        public void EnterGame(GameObject gameObject)
        {
            if (gameObject == null)
                return;
            gameObject.Pos = new Vector2Int(0, 0);
            gameObject.Room = this; // 플레이어에 방 연결
            _myPlayer = gameObject;
            _players.Add(gameObject.Id, gameObject);
            Map.ApplyMove(gameObject, gameObject.Pos);
        }

        public void Update()
        {
            if (_myPlayer != null)
            {
                _myPlayer.Update();
            }
        }

        public void RenderConsole()
        {
            Map.RenderConsole();
        }

        public void HandleMove(GameObject player, Vector2Int dest)
        {
            if (_myPlayer == null)
                return;

            // 다른 좌표로 이동할 경우, 갈 수 있는지 체크
            if (Map.CanGo(dest) == false)
            {
                return;
            }
            player.State = State.PLAYER_MOVE;
            player.TargetPos = dest;
        }
    }
}
