using FruitWars.GamePlay;
using FruitWars.Utilities;
using System;

namespace FruitWars
{
    class Program
    {
        static void Main(string[] args)
        {
            GridManager gridManager = new GridManager();
            PlayersManager playersManager = new PlayersManager();
            GameManager gameManager = new GameManager(gridManager, playersManager);
            gameManager.StartGame();
        }
    }
}
