using FruitWars.GamePlay;
using System;

namespace FruitWars.Models
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static bool operator ==(Point firstPoint, Point secondPoint)
        {
            if ((object)firstPoint == null || (object)secondPoint == null)
            {
                return false;
            }
                
            return (firstPoint.X == secondPoint.X && firstPoint.Y == secondPoint.Y);
        }

        public static bool operator !=(Point firstPoint, Point secondPoint)
        {
            if ((object)firstPoint == null || (object)secondPoint == null)
            {
                return false;
            }
               
            return (firstPoint.X != secondPoint.X || firstPoint.Y != secondPoint.Y);
        }

        public override bool Equals(System.Object otherPoint)
        {
            if ((object)otherPoint == null)
            {
                return false;
            }
                
            Point tempPoint = otherPoint as Point;
            if ((System.Object)tempPoint == null)
            {
                return false;
            }
                
            return (X == tempPoint.X && Y == tempPoint.Y);
        }

        public override int GetHashCode() => X ^ Y;

        public override string ToString() => $"[{X},{Y}]";

        /// <summary>
        /// Checks if the Point point is into the deprecated zone
        /// </summary>
        /// <param name="point">Point</param>
        /// <param name="Distance">Deprecated zone length</param>
        /// <returns>True if P is into deprecated zone</returns>
        public bool IsIntoDeprecatedZone(Point point, int distance)
        {
            if (point == null) return false;
            try
            {
                int manhattanDistance = Math.Abs(X - point.X) + Math.Abs(Y - point.Y);
                return manhattanDistance < distance;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Moves a point if it is possible.
        /// </summary>
        /// <param name="newX"></param>
        /// <param name="newY"></param>
        /// <returns>False if the new coordinates are outside of grid's boudaries</returns>
        public bool Move(int newX, int newY)
        {
            int tempX = X + newX;
            int tempY = Y + newY;
            if (tempX >= Game.MAX_CELLS_COUNT || tempX < 0
                || tempY >= Game.MAX_CELLS_COUNT || tempY < 0)
            {
                return false;
            }

            X = tempX;
            Y = tempY;

            return true;
        }
    }
}
