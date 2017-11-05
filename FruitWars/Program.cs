using FruitWars.GamePlay;
using FruitWars.Interfaces;

namespace FruitWars
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInterfaceManager userInterfaceManager = new UserInterfaceManager();
            IPlayersManager playersManager = new PlayersManager(userInterfaceManager);
            IGridManager gridManager = new GridManager(userInterfaceManager);
            IGameManager gameManager = new GameManager(gridManager, playersManager, userInterfaceManager);
            gameManager.StartGame();
        }
    }
}
