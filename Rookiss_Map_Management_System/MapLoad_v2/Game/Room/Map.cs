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


    }
}
