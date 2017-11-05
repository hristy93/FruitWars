using FruitWars.GamePlay;
using FruitWars.Models.Warriors;

namespace FruitWars.Interfaces
{
    public interface IUserInterfaceManager
    {
        void DisplayChooseWarriorType(char symbol);
        void DisplayDrawGame();
        void DisplayGridCell(string cell);
        void DisplayIncorrectDirection();
        void DisplayIncorrectRematchInput();
        void DisplayIncorrectWarriorType();
        void DisplayMakeAMove(Warrior player);
        void DisplayNewLine();
        void DisplayOutOfTheBoundsDirection();
        void DisplayRequestRematch();
        void DisplayWinningPlayerInforamation(Game game);
        void PrintPlayerInformation(Warrior player);
        void PrintPlayersStatistics(Warrior firstPlayer, Warrior secondPlayer);
    }
}