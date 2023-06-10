using MapLoad_v2.Game.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MapLoad_v2.Game.Room
{
    public struct Vector2Int
    {
        public int x;
        public int y;

        public Vector2Int(int x, int y) { this.x = x; this.y = y; }
    }
    public struct Pos
    {
        public int Y;
        public int X;

        public Pos(int y, int x) { Y = y; X = x; }
    }


    public class Map
    {
        public int MinX { get; set; }
        public int MaxX { get; set; }
        public int MinY { get; set; }
        public int MaxY { get; set; }
        bool[,] _collision;
        object[,] _objects;

        public void LoadMap(int mapId, string pathPrefix = "../../../../../../Ref-Rookiss-Skill-Map/MapData")
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
            _objects = new object[yCount, xCount];
            for (int y = 0; y < yCount; y++)
            {
                string line = reader.ReadLine();
                for (int x = 0; x < xCount; x++)
                {
                    _collision[y, x] = (line[x] == '1' ? true : false);
                }
            }


            string format = "LoadMap - Name({0}) X({1}~{2}) Y({3}~{4}) xCnt({5}) yCnt({6})";
            string result = string.Format(format, mapName, MinX, MaxX, MinY, MaxY, xCount , yCount);

            Console.WriteLine(result);
        }

        public bool ApplyLeave(GameObject gameObject)
        {
            return true;
        }

        public bool ApplyMove(GameObject gameObject, Vector3 dest)
        {
            ApplyLeave(gameObject);


            // 실제 좌표 이동!
            gameObject.Pos.X = dest.X;
            gameObject.Pos.Y = dest.Y;

            return true;
        }

        #region A* PathFinding
        // U D L R
        int[] _deltaY = new int[] { 1, -1, 0, 0 };
        int[] _deltaX = new int[] { 0, 0, -1, 1 };
        int[] _cost = new int[] { 10, 10, 10, 10 };


        Pos Cell2Pos(Vector2Int cell)
        {
            return new Pos(MaxY - cell.y, cell.x - MinX);
        }

        Vector2Int Pos2Cell(Pos pos)
        {
            return new Vector2Int(pos.X + MinX, MaxY - pos.Y);
        }


        public void DemoCell2Pos()
        {
            Vector2Int cell = new Vector2Int();

            cell.x = MinX;
            cell.y = MinY;
            for (cell.x = MinX; cell.x< MaxX; cell.x++)
            {
                for (cell.y = MinY; cell.y < MaxY; cell.y++)
                {
                    Pos pos = Cell2Pos(cell);
                    Console.WriteLine($"Cell2Pos cell({cell.x}, {cell.y}) pos({pos.X}, {pos.Y})");
                }
            }
        }

        public void DemoPos2Cell()
        {
            Pos pos = new Pos();
        }

        #endregion
    }
}
