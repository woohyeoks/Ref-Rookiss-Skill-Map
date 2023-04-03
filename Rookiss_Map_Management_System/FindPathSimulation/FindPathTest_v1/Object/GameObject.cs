using FindPathTest_v1.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPathTest_v1.Object
{
    public enum State { PLAYER_IDEL ,PLAYER_MOVE }
    public class GameObject
    {
        public int Id { get; set; }
        public GameRoom Room { get; set; }
        public Vector2Int Pos;
        public Vector2Int TargetPos;

        public State State = State.PLAYER_IDEL;

        public void Update()
        {
            switch (State)
            {
                case State.PLAYER_IDEL:
                    break;
                case State.PLAYER_MOVE:
                    UpdateMoving();
                    break;
            }
        }

        float _speed = 5.0f;
        long _nextMoveTick = 0;
        public void UpdateMoving()
        {

            if (_nextMoveTick > Environment.TickCount64)
                return;

            // 움직이는게 한칸 한칸 단위로 움직이다 보니
            // 우리가 스피드라는 개념을 쓰고 있었는데, 1초동안 몇칸을 움직이냐에 개념이다.
            int moveTick = (int)(1000 / _speed);
            _nextMoveTick = Environment.TickCount64 + moveTick;

            if (TargetPos == Pos)
            {
                State = State.PLAYER_IDEL; // 목적지 도착
                Console.WriteLine("목적지 도착!!");
                return;
            }

            Room.Map.FindPath(Pos, TargetPos);


        }
    }
}
