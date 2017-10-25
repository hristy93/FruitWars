using FruitWars.GamePlay;
using FruitWars.Models.Fruits;
using FruitWars.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitWars.Models.Warriors
{
    public class Warrior
    {
        //private (int x, int Y) _coordinates;
        //private List<Fruit> _takenFruits;


        public int SpeedPoints { get; set; }

        public int PowerPoints { get; set; }

        public (int X, int Y) Position { get; set; }

        public bool Move(DirectionType direction)
        {
            bool isMoveValid = true;
            (int x, int y) newPosition;
            switch (direction)
            {
                case DirectionType.Left:
                    newPosition = (Position.X, Position.Y - 1);
                    if (CheckPosition(newPosition))
                    {
                        Position = newPosition;
                    }
                    else
                    {
                        isMoveValid = false;
                    }
                    break;

                case DirectionType.Right:
                    newPosition = (Position.X, Position.Y + 1);
                    if (CheckPosition(newPosition))
                    {
                        Position = newPosition;
                    }
                    else
                    {
                        isMoveValid = false;
                    }
                    break;

                case DirectionType.Up:
                    newPosition = (Position.X - 1, Position.Y);
                    if (CheckPosition(newPosition))
                    {
                        Position = newPosition;
                    }
                    else
                    {
                        isMoveValid = false;
                    }
                    break;

                case DirectionType.Down:
                    newPosition = (Position.X + 1, Position.Y);
                    if (CheckPosition(newPosition))
                    {
                        Position = newPosition;
                    }
                    else
                    {
                        isMoveValid = false;
                    }
                    break;

                default:
                    break;
            }

            return isMoveValid;
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

        private bool CheckPosition((int x, int y) position)
        {
            bool isPositionValid = true;
            if (position.x >= Game.MAX_CELLS_COUNT || position.x < 0
                || position.y >= Game.MAX_CELLS_COUNT || position.y < 0)
            {
                isPositionValid = false;
            }

            return isPositionValid;
        }
    }
}