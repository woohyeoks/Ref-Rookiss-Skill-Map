using FindPathTest_v1.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPathTest_v1
{
    public struct Vector2Int
    {
        public int x;
        public int y;

        public Vector2Int(int x, int y) { this.x = x; this.y = y; }

        public static Vector2Int up { get { return new Vector2Int(0, 1); } }
        public static Vector2Int down { get { return new Vector2Int(0, -1); } }
        public static Vector2Int left { get { return new Vector2Int(-1, 0); } }
        public static Vector2Int right { get { return new Vector2Int(1, 0); } }

        public static Vector2Int operator +(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.x + b.x, a.y + b.y);
        }

        public static Vector2Int operator -(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.x - b.x, a.y - b.y);
        }

        public float magnitude { get { return (float)Math.Sqrt(sqrMagnitude); } }
        public int sqrMagnitude { get { return (x * x + y * y); } }
        public int cellDistFromZero { get { return Math.Abs(x) + Math.Abs(y); } } // 0,0 에서  우측으로 위로 몇번 갈수있는지..
    }

    public class Map
    {
        const char CIRCLE = '\u25cf';

        public int MinX { get; set; }
        public int MaxX { get; set; }
        public int MinY { get; set; }
        public int MaxY { get; set; }

        public int SizeX { get { return MaxX - MinX + 1; } }
        public int SizeY { get { return MaxY - MinY + 1; } }


        bool[,] _collision;
        GameObject[,] _objects;
        public void LoadMap(int mapId, string pathPrefix)
        {
            string mapName = "TestMap_" + mapId.ToString("000");
            string text = File.ReadAllText($"{pathPrefix}/{mapName}.txt");
            StringReader reader = new StringReader(text);
            MinX = int.Parse(reader.ReadLine());
            MaxX = int.Parse(reader.ReadLine());
            MinY = int.Parse(reader.ReadLine());
            MaxY = int.Parse(reader.ReadLine());

            int xCount = MaxX - MinX + 1;
            int yCount = MaxY - MinY + 1;
            _collision = new bool[yCount, xCount];
            _objects = new GameObject[yCount, xCount];
            for (int y = 0; y < yCount; y++)
            {
                string line = reader.ReadLine();
                for (int x = 0; x < xCount; x++)
                {
                    _collision[y, x] = line[x] == '1' ? true : false;
                }
            }


        }

        public bool ApplyLeave(GameObject gameObject)
        {
            if (gameObject.Room == null || gameObject.Room.Map != this)
                return false;

            if (gameObject.Pos.x < MinX || gameObject.Pos.x > MaxX)
                return false;
            if (gameObject.Pos.y < MinY || gameObject.Pos.y > MaxY)
                return false;
            // 해당 위치에 객체 날림..
            int x = gameObject.Pos.x - MinX;
            int y = MaxY - gameObject.Pos.y;

            // 엉뚱한 위치에서 날리면안되니 검증
            if (_objects[y, x] == gameObject)
                _objects[y, x] = null;

            return true;

        }

        public bool ApplyMove(GameObject gameObject, Vector2Int dest)
        {
            ApplyLeave(gameObject);
            if (gameObject.Room == null || gameObject.Room.Map != this)
                return false;

            int x = gameObject.Pos.x - MinX;
            int y = MaxY - gameObject.Pos.y;
            _objects[y, x] = gameObject;

            gameObject.Pos.x = dest.x;
            gameObject.Pos.y = dest.y;
            return true;
        }

        public void RenderConsole()
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            for (int y = 0; y < SizeY; y++)
            {
                for (int x = 0; x < SizeX; x++)
                {
                    if (_collision[y, x] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (_objects[y, x] != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = prevColor;
        }
    }
}
