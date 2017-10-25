using FruitWars.Models.Warriors;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitWars.Models
{
    public abstract class Fruit
    {
        public Fruit()
        {

        }

        public abstract void GiveBonus(Warrior warrior);
    }
}
