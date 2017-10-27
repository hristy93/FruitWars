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
        public const int INITIAL_PLAYERS_DISTANCE = 3;

        public int SpeedPoints { get; set; }

        public int PowerPoints { get; set; }

        public override bool IntoDeprecatedZone(Figure otherFigure)
        {
            int distance = otherFigure is Warrior ? INITIAL_PLAYERS_DISTANCE : 1;
            return Position.IsIntoDeprecatedZone(otherFigure.Position, distance);
        }

        public bool Move(DirectionType direction)
        {
            switch (direction)
            {
                case DirectionType.Left:
                    return Position.Move(0, -1);

                case DirectionType.Right:
                    return Position.Move(0, 1);

                case DirectionType.Up:
                    return Position.Move(-1, 0);

                case DirectionType.Down:
                    return Position.Move(1, 0);

                default:
                    throw new IndexOutOfRangeException("Invalid DirectionType");
            }
        }

        public void EatFruit(Fruit fruit) => fruit.GiveBonus(this);
    }
}