using System.Collections.Generic;
using FruitWars.Interfaces;
using FruitWars.Models;
using FruitWars.Models.Warriors;
using FruitWars.Utilities;

namespace FruitWars.Interfaces
{
    public interface IPlayersManager
    {
        Warrior FirstPlayer { get; }
        Warrior SecondPlayer { get; }

        void ChooseWarriors();
        void EatFruits(Warrior player, List<Figure> figures);
        DirectionType GetPlayerDirection(IConsoleWrapper consoleWrapper);
        Warrior InputWarriorsTypes(char symbol);
        void PrintPlayerScores(Warrior player);
        void PrintPlayersStatistics();
    }
}