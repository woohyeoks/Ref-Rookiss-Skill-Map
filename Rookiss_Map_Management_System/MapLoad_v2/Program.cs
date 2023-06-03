using MapLoad_v2.Game.Room;

namespace MapLoad_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gameRoom = new GameRoom();
            gameRoom.Init(1);
        }
    }
}