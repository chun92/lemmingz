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
        private List<Tile> tiles;
        private List<Tile> modifiedTiles;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            modifiedTiles = new List<Tile>(width * height);
            tiles = new List<Tile>(width * height);
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    modifiedTiles.Add(new Tile(new Vector2(i, j))); // ?
            // setTilesRandomly();
            // 임시코드
            List<Vector2> tempMap = new List<Vector2>();
            tempMap.Add(new Vector2(0, 1));
            tempMap.Add(new Vector2(1, 1));
            tempMap.Add(new Vector2(2, 1));
            tempMap.Add(new Vector2(3, 1));
            tempMap.Add(new Vector2(4, 1));
            tempMap.Add(new Vector2(5, 1));
            tempMap.Add(new Vector2(5, 2));
            tempMap.Add(new Vector2(5, 3));
            tempMap.Add(new Vector2(5, 4));
            tempMap.Add(new Vector2(5, 5));
            tempMap.Add(new Vector2(4, 5));
            tempMap.Add(new Vector2(3, 5));
            tempMap.Add(new Vector2(2, 5));
            tempMap.Add(new Vector2(1, 5));
            tempMap.Add(new Vector2(1, 4));
            tempMap.Add(new Vector2(1, 3));
            setTiles(tempMap);
        }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }


        public List<Tile> getTiles()
        {
            return tiles;
        }

        public List<Tile> getModifiedTiles()
        {
            return modifiedTiles;
        }

        public Tile getTile(int x, int y)
        {
            return tiles[x*width + y];
        }

        public Tile getModifiedTile(int x, int y)
        {
            return modifiedTiles[x * width + y];
        }

        public void modifyTile(Tile tile)
        {
            tile.setModified();
            tiles.Add(tile);
        }

        public void setTile(Tile tile, ObstacleType obstacleType)
        {
            tile.setTile(obstacleType);
            tiles.Remove(tile);
            modifiedTiles.Add(tile);
        }

        public bool CanUsePosition(Vector2 position)
        {
            float x = position.X;
            float y = position.Y;
            bool outOfMap = x >= 0 && x < width && y >= 0 && y < width;
            if (!outOfMap)
                return false;
            bool obstacle = true;
            obstacle = getTile((int)x, (int)y).isMovable();
            return obstacle;
        }

        private void setTilesRandomly()
        {
            Random random = new Random();
            int max = 10;
            int percentage = 9;
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    if (random.Next(max) > percentage)
                    {
                        getTile(i,j).setTile(ObstacleType.SOIL);
                    }
        }

        private void setTiles(List<Vector2> positions)
        {
            foreach (Vector2 v in positions)
            {
                int i = (int)v.X;
                int j = (int)v.Y;
                setTile(getModifiedTile(i, j), ObstacleType.SOIL);
            }
        }

    }
}
