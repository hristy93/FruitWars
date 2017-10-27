using FruitWars.Models.Fruits;
using FruitWars.Models.Warriors;
using FruitWars.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitWars.GamePlay
{
    public class Game
    {
        public const int MAX_CELLS_COUNT = 8;
        public const int PLAYERS_COUNT = 2;

        public GameStatusType Status { get; set; }
        public Warrior Winner { get; set; }
    }
}
