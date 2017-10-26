using System;
using System.Collections.Generic;
using System.Text;

namespace FruitWars.Models
{
    public abstract class Figure
    {
        public Point Position { get; set; }

        public char Symbol { get; set; }

        public abstract bool IntoDeprecatedZone(Figure figure);
    }
}
