using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemmingz
{
    public class Soil : Obstacle
    {
        public Soil()
        {
            this.movable = false;
            this.type = ObstacleType.SOIL;
        }
    }
}
