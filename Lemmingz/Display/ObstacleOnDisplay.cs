using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lemmingz
{
    public class ObstacleOnDisplay
    {
        private Obstacle obstacle;
        private Vector2 displayedPosition;
        private int cellPixel = 48;
        private Tile tile;
        private String ImageFile;

        public ObstacleOnDisplay(Tile tile)
        {
            cellPixel = 48;
            this.tile = tile;
            this.obstacle = tile.getObstacle();
            ImageFile = getImageFileName();
        }

        private String getImageFileName()
        {
            switch (obstacle.getType())
            {
                case ObstacleType.EMPTY:
                    return "Content" + "ground";
                case ObstacleType.SOIL:
                    return "Content" + "soil";
                default:
                    return null;
            }
        }

        public Obstacle getObstacle()
        {
            return obstacle;
        }

        public Tile getTile()
        {
            return tile;
        }

        public void setDisplay(GameTime gametime)
        {
            double currentX = tile.getPoint().X * cellPixel;
            double currentY = tile.getPoint().Y * cellPixel;
            displayedPosition = new Vector2((float)currentX, (float)currentY);
        }

        public Vector2 getDisplay()
        {
            return displayedPosition;
        }
    }
}