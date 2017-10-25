using FruitWars.Models.Warriors;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitWars.Models
{
    public abstract class Fruit
    {
        public (int X, int Y) Position { get; set; }

        public Fruit()
        {

        }

        public abstract void GiveBonus(Warrior warrior);
    }
}
