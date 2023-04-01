using MapLoad_v1.Room;

namespace MapLoad_v1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MapLoad_v1 Start!");

            int mapId = 1;
            GameRoom gameRoom = new GameRoom();
            gameRoom.Init(mapId);
            gameRoom.TestCollision();
        }
    }
}