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
        private int createdNumber;
        private int creatingNumber;

        public LemmingzFactory(Side side, Direction direction, double speed, Vector2 spwaningPoint, int number, Map map)
        {
            this.side = side;
            this.direction = direction;
            this.speed = speed;
            this.spwaningPoint = spwaningPoint;
            this.creatingNumber = number;
            this.createdNumber = 0;
            this.map = map;
        }

        public Lemming createLemming(double time)
        {
            if (canCreateMoreLemming())
            {
                Lemming created = new Lemming(speed, spwaningPoint, direction, side, time, map);
                createdNumber++;
                return created;
            }
            else
                return null;
        }

        public bool canCreateMoreLemming()
        {
            if (creatingNumber == -1)
                return true;
            if (createdNumber < creatingNumber)
                return true;
            else
                return false;
        }
    }
}
