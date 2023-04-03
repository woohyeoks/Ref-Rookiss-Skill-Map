using FindPathTest_v1;
using FindPathTest_v1.Object;
using FindPathTest_v1.Room;

namespace FindPathTest_v1
{
    internal class Program
    {
        const int WAIT_TICK = 1000 / 30;

        static void Main(string[] args)
        {

            var gameRoom = new GameRoom();
            gameRoom.Init(1);

            var myPlayer = new GameObject();
            gameRoom.EnterGame(myPlayer);

            Console.CursorVisible = false;
            int lastTick = System.Environment.TickCount;
            gameRoom.HandleMove(gameRoom._myPlayer, new Vector2Int(-5, 0));


            while (true)
            {
                #region 프레임 관리
                int currentTick = System.Environment.TickCount;
                // 만약 경과 시간이 1/ 30 초 보다 작다면 
                if (currentTick - lastTick < WAIT_TICK)
                    continue;
                int deltaTick = currentTick - lastTick; // 경과된 틱..
                lastTick = currentTick;
                #endregion


                // 로직!!
                gameRoom.Update();
                Console.SetCursorPosition(0, 0);
                gameRoom.RenderConsole();
            }
        }
    }
}