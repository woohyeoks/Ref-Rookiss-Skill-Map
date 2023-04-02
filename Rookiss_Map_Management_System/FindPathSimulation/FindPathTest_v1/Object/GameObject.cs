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

        public State State = State.PLAYER_IDEL;

        public void Update()
        {
            switch (State)
            {
                case State.PLAYER_IDEL:
                    break;
                case State.PLAYER_MOVE:
                   // UpdateMoving();
                    break;
            }
        }
    }
}
