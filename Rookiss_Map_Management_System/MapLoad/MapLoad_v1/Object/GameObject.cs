using MapLoad_v1.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLoad_v1.Object
{
    public class GameObject
    {
        public GameRoom Room { get; set; }
        public Vector2Int Pos;

        float _speed = 5.0f;
        long _nextMoveTick = 0;
        public void UpdateMoving()
        {
            if (_nextMoveTick > Environment.TickCount)
                return;
            // 움직이는게 한칸한칸 단위로 움직이다 보니
            int moveTick = (int)(1000 / _speed);
            _nextMoveTick = Environment.TickCount64 + moveTick;

        }
    }
}
