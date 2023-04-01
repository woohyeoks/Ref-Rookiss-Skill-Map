using MapLoad_v1.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MapLoad_v1.Room
{

    public struct Vector2Int
    {
        public int x;
        public int y;

        public Vector2Int(int x , int y )
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Map
    {
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
            string mapName = "Map_" + mapId.ToString("000");

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

        public Vector2Int PosToIndex(Vector2Int cellPos)
        {
            int x = cellPos.x - MinX;
            int y = MaxY - cellPos.x;
            return new Vector2Int(x, y);
        }

        public bool CanGo(Vector2Int cellPos, bool checkObjects = true)
        {
            if (cellPos.x < MinX || cellPos.x > MaxX)
                return false;
            if (cellPos.y < MinY || cellPos.y > MaxY)
                return false;
            var index = PosToIndex(cellPos);
            if (_collision[index.y, index.x] == true)
            {
                return false;
            }
            if (checkObjects == true && _objects[index.y, index.x] != null)
            {
                return false;
            }
            return true;
        }

        /**
         * 공간에 있다고 하면 날려줌...
        */ 
        public bool ApplyLeave(GameObject gameObject)
        {
            if (gameObject.Room == null || gameObject.Room.Map != this)
                return false;

            // 내 좌표가 정상인지 체크
            if (gameObject.Pos.x < MinX || gameObject.Pos.x > MaxX)
                return false;
            if (gameObject.Pos.y < MinY || gameObject.Pos.y > MaxY)
                return false;

            // 해당 위치에 객체 날림
            var index = PosToIndex(gameObject.Pos);

            if (_objects[index.y, index.x] == gameObject)
                _objects[index.y, index.x] = null;
            return true;
        }

        public bool ApplyMove(GameObject gameObject, Vector2Int dest)
        {
            ApplyLeave(gameObject);

            if (gameObject.Room == null || gameObject.Room.Map != this)
                return false;

            // 목적지로 갈 수 있는지 없는지 체크
            if (CanGo(dest, true) == false)
                return false;

            var index = PosToIndex(gameObject.Pos);
            _objects[index.y, index.x] = gameObject;

            // 실제 좌표 이동하는 코드
            gameObject.Pos.x = dest.x;
            gameObject.Pos.y = dest.y;
            return true;
        }

        // 해당 위치에 오브젝트가 있는지 확인!!
        public GameObject Find(Vector2Int cellPos)
        {
            if (cellPos.x < MinX || cellPos.x > MaxX)
                return null;
            if (cellPos.y < MinY || cellPos.y > MaxY)
                return null;
            Vector2Int index = PosToIndex(cellPos);

            return _objects[index.y, index.x];
        }

        public void TestCollision()
        {
            for (int row = MinY; row < MaxY; row++)
            {
                for (int col = MinX; col < MaxX; col++)
                {
                    Vector2Int pos = new Vector2Int(row, col);
                    Vector2Int index = PosToIndex(pos);
                    if (_collision[index.y, index.x] == true)
                        Console.WriteLine($"[{index.y}, {index.x}] - 벽이다!");
                }
            }
        }
    }
}
