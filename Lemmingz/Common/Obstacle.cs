using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lemmingz
{
    public abstract class Obstacle
    {
        protected ObstacleType type;
        protected bool movable;

        public bool isMovable()
        {
            return movable;
        }

        public ObstacleType getType()
        {
            return type;
        }
    }
}
