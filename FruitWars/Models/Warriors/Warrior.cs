using FruitWars.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitWars.Models.Warriors
{
    public class Warrior
    {
        //private (int x, int Y) _coordinates;

        public int SpeedPoints { get; set; }

        public int PowerPoints { get; set; }

        public (int X, int Y) Coordinates { get; set; }

        public void Move(DirectionType direction)
        {
            switch (direction)
            {
                case DirectionType.Left:
                    Coordinates = (Coordinates.X, Coordinates.Y - 1);
                    break;

                case DirectionType.Right:
                    Coordinates = (Coordinates.X, Coordinates.Y + 1);
                    break;

                case DirectionType.Up:
                    Coordinates = (Coordinates.X - 1, Coordinates.Y);
                    break;

                case DirectionType.Down:
                    Coordinates = (Coordinates.X + 1, Coordinates.Y);
                    break;

                default:
                    break;
            }
        }

        public void EatFruit(Fruit fruit)
        {
            fruit.GiveBonus(this);
        }
    }
}