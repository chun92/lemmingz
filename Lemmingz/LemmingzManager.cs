using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lemmingz
{
    public class LemmingzManager
    {
        private double speed;
        private double lastUpdatedMovingTime;
        private double elapsedMovingTime;
        private double spwaningTiming;
        private double lastUpdatedSpwaningTime;
        private double elapsedSpwaningTime;
        private Direction directionAtStart;
        private Side side;
        private List<Lemming> lemmingzList;
        private Vector2 spwaningPoint;
        private Vector2 endPoint;
        private LemmingzFactory factory;
        private Map map;

        public LemmingzManager(double speed, Direction direction, Side side, Vector2 spwaningPoint, Vector2 endPoint, Map map, int count, double spwaningTiming = 1000)
        {
            this.speed = speed;
            this.spwaningTiming = spwaningTiming;
            this.lastUpdatedMovingTime = 0;
            this.lastUpdatedSpwaningTime = 0;
            this.elapsedMovingTime = 0;
            this.elapsedSpwaningTime = 0;
            this.directionAtStart = direction;
            this.side = side;
            this.spwaningPoint = spwaningPoint;
            this.endPoint = endPoint;
            this.lemmingzList = new List<Lemming>();
            this.factory = new LemmingzFactory(side, directionAtStart, speed, spwaningPoint, count, map);
            this.map = map;
        }

        public List<Lemming> getLemmingzList()
        {
            return lemmingzList;
        }

        public Map getMap()
        {
            return map;
        }

        public double getLastUpdatedMovingTime()
        {
            return lastUpdatedMovingTime;
        }

        public double getLastUpdatedSpwaningTime()
        {
            return lastUpdatedSpwaningTime;
        }

        public void moveLemmingz(GameTime gameTime)
        {
            double time = (double)gameTime.TotalGameTime.TotalMilliseconds;
            foreach (Lemming lemming in lemmingzList)
            {
                if (lemming.isTimeToMove(time))
                    lemming.moveToNextDestination();
            }
        }

        public void createLemmingz(GameTime gameTime)
        {
            if (factory.canCreateMoreLemming())
            {
                double time = (double)gameTime.TotalGameTime.TotalMilliseconds;
                elapsedSpwaningTime = time - lastUpdatedSpwaningTime;
                if (spwaningTiming < elapsedSpwaningTime)
                {
                    lastUpdatedSpwaningTime = time;
                    lemmingzList.Add(factory.createLemming(time));
                }
            }
        }
    }
}
