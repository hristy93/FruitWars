using FruitWars.Models.Warriors;

namespace FruitWars.Interfaces
{
    public interface IGameManager
    {
        bool CheckHasPlayerWon(Warrior player);
        void StartGame(bool ForTestOnly = false);
    }
}