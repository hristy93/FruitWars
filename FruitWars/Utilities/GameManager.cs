using System;
using System.Collections.Generic;
using System.Text;

namespace FruitWars.Utilities
{
    public class GameManager
    {
        private GridManager _gridManager;
        private Random _random = StaticRandom.Instance;

        public GameManager(GridManager gridManager)
        {
            _gridManager = gridManager;
        }

        public void ResetGame()
        {

        }

    }
}
