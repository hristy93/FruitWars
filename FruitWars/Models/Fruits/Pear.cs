﻿using System;
using System.Collections.Generic;
using System.Text;
using FruitWars.Models.Warriors;
using FruitWars.Utilities;

namespace FruitWars.Models.Fruits
{
    public class Pear : Fruit
    {
        private int _speedPointsBonus = 1;

        public Pear() => Symbol = GameSymbols.PEAR_SYMBOL;

        public override void GiveBonus(Warrior warrior) => warrior.SpeedPoints += _speedPointsBonus;
    }
}
