using System;
using System.Collections.Generic;
using System.Text;
using FruitWars.Models.Warriors;
using FruitWars.Utilities;

namespace FruitWars.Models.Fruits
{
    public class Apple : Fruit
    {
        private int _powerPointsBonus = 1;

        public Apple() => Symbol = GameSymbols.APPLE_SYMBOL;

        public override void GiveBonus(Warrior warrior) => warrior.PowerPoints += _powerPointsBonus;
    }
}
