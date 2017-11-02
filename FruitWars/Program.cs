using FruitWars.GamePlay;
using FruitWars.Interfaces;

namespace FruitWars
{
    class Program
    {
        static void Main(string[] args)
        {
            IGridManager gridManager = new GridManager();
            IPlayersManager playersManager = new PlayersManager();
            IGameManager gameManager = new GameManager(gridManager, playersManager);
            gameManager.StartGame();
        }
    }
}
