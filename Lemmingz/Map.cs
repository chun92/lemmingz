using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;

namespace Lemmingz
{
    public class Map
    {
        private int width;
        private int height;
        private Tile[][] tiles;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            tiles = new Tile[width][];
            for (int i = 0; i < width; i++)
            {
                tiles[i] = new Tile[height];
            }
        }

        public Tile getTile(int x, int y)
        {
            return tiles[x][y];
        }

        public bool CanUsePosition(Vector2 position)
        {
            float x = position.X;
            float y = position.Y;
            return (x >= 0 && x < width && y >= 0 && y < width);
        }
        
    }
}
