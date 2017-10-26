using FruitWars.GamePlay;
using FruitWars.Models.Fruits;
using FruitWars.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitWars.Models.Warriors
{
    public class Warrior : Figure
    {
        //private (int x, int Y) _coordinates;
        //private List<Fruit> _takenFruits;
        public const int INITIAL_PLAYERS_DISTANCE = 3;

        public int SpeedPoints { get; set; }

        public int PowerPoints { get; set; }

        //public (int X, int Y) Position { get; set; }

        public override bool IntoDeprecatedZone(Figure otherFigure)
        {
            int distance = otherFigure is Warrior ? INITIAL_PLAYERS_DISTANCE : 1;
            return Position.IsIntoDeprecatedZone(otherFigure.Position, distance);
        }

        public bool Move(DirectionType direction)
        {
            //bool isMoveValid = true;
            //(int x, int y) newPosition;
            switch (direction)
            {
                case DirectionType.Left:
                    return Position.Move(0, -1);
                    //newPosition = (Position.X, Position.Y - 1);
                    //if (CheckPosition(newPosition))
                    //{
                    //    Position = newPosition;
                    //}
                    //else
                    //{
                    //    isMoveValid = false;
                    //}
                    //break;

                case DirectionType.Right:
                    return Position.Move(0, 1);
                    //newPosition = (Position.X, Position.Y + 1);
                    //if (CheckPosition(newPosition))
                    //{
                    //    Position = newPosition;
                    //}
                    //else
                    //{
                    //    isMoveValid = false;
                    //}
                    //break;

                case DirectionType.Up:
                    return Position.Move(-1, 0);
                    //newPosition = (Position.X - 1, Position.Y);
                    //if (CheckPosition(newPosition))
                    //{
                    //    Position = newPosition;
                    //}
                    //else
                    //{
                    //    isMoveValid = false;
                    //}
                    //break;

                case DirectionType.Down:
                    return Position.Move(1, 0);
                    //newPosition = (Position.X + 1, Position.Y);
                    //if (CheckPosition(newPosition))
                    //{
                    //    Position = newPosition;
                    //}
                    //else
                    //{
                    //    isMoveValid = false;
                    //}
                    //break;

                default:
                    throw new IndexOutOfRangeException("Invalid DirectionType");
            }

            //return isMoveValid;
        }

        public void EatFruit(Fruit fruit)
        {
            fruit.GiveBonus(this);
        }

        //public void EatFruits()
        //{
        //    foreach (var fruit in _takenFruits)
        //    {
        //        fruit.GiveBonus(this); 
        //    }
        //}

        //public void EatFruit(Fruit fruit)
        //{
        //    _takenFruits.Add(fruit);
        //    fruit.
        //}

        //private bool CheckPosition(Point position)
        //{
        //    bool isPositionValid = true;
        //    if (position.X >= Game.MAX_CELLS_COUNT || position.X < 0
        //        || position.Y >= Game.MAX_CELLS_COUNT || position.Y < 0)
        //    {
        //        isPositionValid = false;
        //    }

        //    return isPositionValid;
        //}

    }
}