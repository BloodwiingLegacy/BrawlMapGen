﻿namespace BMG
{
    public class OrderedTile
    {

        public OrderedTile()
        {
            str = false;
        }

        public Tiledata.TileType tileTypeData { get; set; }
        public int tileType { get; set; }
        public int xPosition { get; set; }
        public int yPosition { get; set; }
        public char tileCode { get; set; }
        public string tileName { get; set; }
        public bool str { get; set; }

    }

}
