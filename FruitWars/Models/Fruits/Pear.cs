﻿using System;
using System.Collections.Generic;
using System.Text;
using FruitWars.Models.Warriors;

namespace FruitWars.Models.Fruits
{
    public class Pear : Fruit
    {
        private int _speedPointsBonus = 1;

        public Pear((int x, int y) position) : base(position)
        {

        }

        public override void GiveBonus(Warrior warrior)
        {
            warrior.SpeedPoints += _speedPointsBonus;
        }


    }
}
