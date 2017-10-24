using System;
using System.Collections.Generic;
using System.Text;

namespace FruitWars.Models.Warriors
{
    class Warrior
    {
        /*
Warriors:
    – Turtle. The turtle has 1 speed point and 3 power points
    – Monkey. The monkey has 2 speed points and 2 power points
    – Pigeon. The pigeon has 3 speed points and 1 power point
Fruits:
    – Apple. Apple provides +1 power point to a warrior
    – Pear. Pear provides +1 speed point to a warrior
         * */

        public int SpeedPoints { get; set; }
        public int PowerPoints { get; set; }
    }
}
