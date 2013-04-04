using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lemmingz
{
    public class Tile
    {
        private Obstacle obstacle;
        private TileType type;
        private Vector2 point;
        private bool modified;

        public Tile(Vector2 p)
        {
            setTile(ObstacleType.EMPTY);
            point.X = p.X;
            point.Y = p.Y;
            modified = false;
        }

        public void setModified()
        {
            modified = false;
        }

        public Vector2 getPoint()
        {
            return point;
        }

        public bool isMovable()
        {
            return obstacle.isMovable();
        }

        public TileType getType()
        {
            return type;
        }

        public Obstacle getObstacle()
        {
            return obstacle;
        }

        public Tile setTile(ObstacleType type)
        {
            switch (type)
            {
                case ObstacleType.EMPTY:
                    obstacle = new EMPTY();
                    break;
                case ObstacleType.SOIL:
                    obstacle = new Soil();
                    break;
            }
            modified = true;
            return this;
        }
    }
}
