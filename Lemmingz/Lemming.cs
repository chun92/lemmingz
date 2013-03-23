using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lemmingz
{
    public class Lemming
    {
        private static int totalNumber = 0;
        private int id;
        private double movingSpeed;
        private Vector2 currentPosition;
        private Vector2 previousPosition;
        private Direction direction;
        private Side side;
        private Map map;
        private bool onDisplay;

        public Lemming(double movingSpeed, Vector2 position, Direction direction, Side side, Map map)
        {
            this.movingSpeed = movingSpeed;
            this.currentPosition = position;
            this.direction = direction;
            this.side = side;
            id = ++totalNumber;
            this.previousPosition = new Vector2();
            this.map = map;
            this.onDisplay = false;
        }
        public Vector2 getCurrentPosition()
        {
            return currentPosition;
        }
        public Vector2 getPreviousPosition()
        {
            return previousPosition;
        }
        public int getId()
        {
            return this.id;
        }
        public double getSpeed()
        {
            return this.movingSpeed;
        }
        public void addSpeed(double add)
        {
            movingSpeed += add;
        }
        public Direction getDirection()
        {
            return this.direction;
        }
        public void setDirection(Direction direction)
        {
            this.direction = direction;
        }
        public Side getSide()
        {
            return this.side;
        }
        public void putOnDisplay()
        {
            this.onDisplay = true;
        }
        public bool isOnDisplay()
        {
            return this.onDisplay;
        }


        private bool canMove(Vector2 target)
        {
            if (!map.CanUsePosition(target))
                return false;

            // Object 방해 경우 추가

            if (Math.Abs(currentPosition.X - target.X) == 1 || Math.Abs(currentPosition.Y - target.Y) == 1)
                return true;
            else
                return false;
        }
        private Vector2 getForward()
        {
            switch (direction)
            {
                case Direction.LEFT:
                    return new Vector2(currentPosition.X - 1, currentPosition.Y);
                case Direction.RIGHT:
                    return new Vector2(currentPosition.X + 1, currentPosition.Y);
                case Direction.UP:
                    return new Vector2(currentPosition.X, currentPosition.Y + 1);
                case Direction.DOWN:
                    return new Vector2(currentPosition.X, currentPosition.Y - 1);
                default:
                    return new Vector2(-1, -1);
            }
        }
        private Vector2 getBackward()
        {
            switch (direction)
            {
                case Direction.LEFT:
                    return new Vector2(currentPosition.X + 1, currentPosition.Y);
                case Direction.RIGHT:
                    return new Vector2(currentPosition.X - 1, currentPosition.Y);
                case Direction.UP:
                    return new Vector2(currentPosition.X, currentPosition.Y - 1);
                case Direction.DOWN:
                    return new Vector2(currentPosition.X, currentPosition.Y + 1);
                default:
                    return new Vector2(-1, -1);
            }
        }
        private bool canGoForward()
        {
            return canMove(getForward());
        }
        private bool canGoBackward()
        {
            return canMove(getForward());
        }
        private Vector2 getNextDestination()
        {
            List<Vector2> possibleDestination = getPossibleNextDestination();
            Random random = new Random();

            if (canGoForward() && possibleDestination.Count == 1)
                return getForward();
            else if (possibleDestination.Count >= 1)
            {
                int index = random.Next(possibleDestination.Count);
                return possibleDestination[index];
            }
            else if (canGoBackward())
                return getBackward();
            else
                return new Vector2(-1,-1); // 멈춤. 망함. 이러면 안됨.
        }
        private List<Vector2> getPossibleNextDestination()
        {
            List<Vector2> destinationList = new List<Vector2>();
            Vector2 targetPosition;
            if (direction != Direction.RIGHT)
            {
                targetPosition = new Vector2(currentPosition.X - 1, currentPosition.Y);
                if (canMove(targetPosition))
                    destinationList.Add(targetPosition);
            }
            if (direction != Direction.LEFT)
            {
                targetPosition = new Vector2(currentPosition.X + 1, currentPosition.Y);
                if (canMove(targetPosition))
                    destinationList.Add(targetPosition);
            }
            if (direction != Direction.UP)
            {
                targetPosition = new Vector2(currentPosition.X, currentPosition.Y + 1);
                if (canMove(targetPosition))
                    destinationList.Add(targetPosition);
            }
            if (direction != Direction.DOWN)
            {
                targetPosition = new Vector2(currentPosition.X, currentPosition.Y - 1);
                if (canMove(targetPosition))
                    destinationList.Add(targetPosition);
            }

            return destinationList;
        }
        public bool moveToNextDestination()
        {
            Vector2 destination = getNextDestination();
            if (destination.X == -1 || destination.Y == -1)
                return false;
            else
            {
                moveToPoint(destination);
                return true;
            }
        }
        public void moveToPoint(Vector2 destination)
        {
            previousPosition.X = currentPosition.X;
            previousPosition.Y = currentPosition.Y;
            currentPosition.X = destination.X;
            currentPosition.Y = destination.Y;
        }
    }
}
