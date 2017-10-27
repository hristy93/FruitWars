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
            GameManager gameManager = new GameManager(gridManager);
            gameManager.StartGame();
        }
    }
}
