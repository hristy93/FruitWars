using FruitWars.Models.Warriors;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitWars.Models
{
    public abstract class Fruit
    {
        public (int X, int Y) Position { get; set; }

        public Fruit((int x, int y) position)
        {
            Position = position;
        }

        public abstract void GiveBonus(Warrior warrior);
    }
}
