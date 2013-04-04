using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemmingz
{
    public class EMPTY : Obstacle
    {
        public EMPTY()
        {
            this.movable = true;
            this.type = ObstacleType.EMPTY;
        }
    }
}
