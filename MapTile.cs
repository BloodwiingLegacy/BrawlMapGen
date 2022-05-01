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

        public static bool IsRowEmpty(bool[,] data, int row)
        {
            for (int i = 0; i < data.GetLength(1); i++)
                if (!data[row,i])
                    return false;
            return true;
        }

        public static bool IsColumnEmpty(bool[,] data, int column)
        {
            for (int i = 0; i < data.GetLength(0); i++)
                if (!data[i,column])
                    return false;
            return true;
        }

        public static MapTile[][] CropMap(MapTile[][] data, char[] tiles)
        {
            int t = 0, b = 0, l = 0, r = 0;
            bool[,] map = new bool[data.Length,data[0].Length];

            for (int y = 0; y < data.Length; y++)
                for (int x = 0; x < data[y].Length; x++)
                    if (tiles.Contains(data[y][x].code))
                        map[y,x] = true;

            for (int y = 0; y < data.Length; y++)
            {
                if (!IsRowEmpty(map, y))
                    break;
                t += 1;
            }

            for (int y = data.Length - 1; y >= 0; y--)
            {
                if (!IsRowEmpty(map, y))
                    break;
                b += 1;
            }

            for (int x = 0; x < data[0].Length; x++)
            {
                if (!IsColumnEmpty(map, x))
                    break;
                l += 1;
            }

            for (int x = data[0].Length - 1; x >= 0; x--)
            {
                if (!IsColumnEmpty(map, x))
                    break;
                r += 1;
            }

            return data
                .Skip(t)
                .Take(data.Length - t - b)
                .Select(x => x
                    .Skip(l)
                    .Take(x.Length - l - r)
                    .ToArray())
                .ToArray();
        }
    }
}
