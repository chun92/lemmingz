using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lemmingz
{
    public class LemmingzFactory
    {
        private double speed;
        private Direction direction;
        private Side side;
        private Vector2 spwaningPoint;
        private Map map;

        public LemmingzFactory(Side side, Direction direction, double speed, Vector2 spwaningPoint, Map map)
        {
            this.side = side;
            this.direction = direction;
            this.speed = speed;
            this.spwaningPoint = spwaningPoint;
            this.map = map;
        }

        public Lemming createLemming()
        {
            Lemming created = new Lemming(speed, spwaningPoint, direction, side, map);
            return created;
        }
    }
}
