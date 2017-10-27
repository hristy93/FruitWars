using FruitWars.Models.Warriors;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitWars.Models
{
    public abstract class Fruit : Figure
    {
        public const int INITIAL_FRUITS_DISTANCE = 2;

        public override bool IntoDeprecatedZone(Figure otherFigure)
        {
            int distance = otherFigure is Fruit ? INITIAL_FRUITS_DISTANCE : 1;
            return Position.IsIntoDeprecatedZone(otherFigure.Position, distance);
        }

        public abstract void GiveBonus(Warrior warrior);
    }
}
