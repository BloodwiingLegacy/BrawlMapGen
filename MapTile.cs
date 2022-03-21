using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMG
{
    public struct MapTile
    {
        public char code;
        public List<string> tags;

        public static MapTile[][] ConstructMap(string[] data)
        {
            var res = new MapTile[data.Length][];

            for (int y = 0; y < data.Length; y++)
            {
                res[y] = new MapTile[data[y].Length];

                for (int x = 0; x < data[y].Length; x++)
                    res[y][x] = new MapTile() { code = data[y][x] };
            }

            return res;
        }

        public static void ReplaceRow(MapTile[] row, char find, char repl)
        {
            for (int i = 0; i < row.Length; i++)
                if (row[i].code == find)
                    row[i].code = repl;
        }

        public static bool IsRowEmpty(MapTile[] row)
        {
            for (int i = 0; i < row.Length; i++)
                if (row[i].code != 0)
                    return false;
            return true;
        }

        public static MapTile[][] CropMap(MapTile[][] data, AMGState.Map.Size size, char[] tiles)
        {
            //int t = 0, b = 0, l = size.width, r = 0;

            //for (int y = 0; y < data.Length; y++)
            //    for (int x = 0; x < data[y].Length; x++)
            //        if (tiles.Contains(data[y][x].code))
            //            data[y][x].code = (char)0;

            //for (int y = 0; y < data.Length; y++)
            //{
            //    if (IsRowEmpty(data[y]))
            //        break;
            //    t += 1;
            //}

            //for (int y = size.height - 1; b >= 0; b--)
            //{
            //    if (IsRowEmpty(data[y]))
            //        break;
            //    b += 1;
            //}

            //int temp;
            //for (int y = t; y < data.Length - b; y++)
            //{
            //    temp = 0;
            //    for (int x = 0; x < data[y].Length; x++)
            //    {
            //        if (data[y][x].code == 0)
            //            temp
            //    }
            //}

            return data;
        }
    }
}
