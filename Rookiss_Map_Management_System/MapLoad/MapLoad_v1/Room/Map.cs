using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MapLoad_v1.Room
{
    public class Map
    {
        public int MinX { get; set; }
        public int MaxX { get; set; }
        public int MinY { get; set; }
        public int MaxY { get; set; }

        public int SizeX { get { return MaxX - MinX + 1; } }
        public int SizeY { get { return MaxY - MinY + 1; } }

        bool[,] _collision;

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
          //  _objects = new GameObject[yCount, xCount];
            for (int y = 0; y < yCount; y++)
            {
                string line = reader.ReadLine();
                for (int x = 0; x < xCount; x++)
                {
                    _collision[y, x] = line[x] == '1' ? true : false;
                }
            }

        }
    }
}
