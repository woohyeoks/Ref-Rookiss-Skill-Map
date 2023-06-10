using MapLoad_v2.Game.Object;
using MapLoad_v2.Game.Room;

namespace MapLoad_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gameRoom = new GameRoom();
            gameRoom.Init(1);
            gameRoom.Map.DemoCell2Pos();

            return;
            var player = new GameObject();
            player.Room = gameRoom;
            
            Console.WriteLine("이동 전 좌표 {0}, {1}", player.Pos.X, player.Pos.Y);
            gameRoom.EnterGame(player);
            Console.WriteLine("이동 후 좌표 {0}, {1}", player.Pos.X, player.Pos.Y);
        }
    }
}