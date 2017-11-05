using FruitWars.Interfaces;
using FruitWars.Models.Warriors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FruitWars.GamePlay
{
    public class UserInterfaceManager : IUserInterfaceManager
    {
        private const string TRIM_NAMESPACE_REGEX = @"[.\w]+\.(\w+)";

        public void DisplayMakeAMove(Warrior player) => Console.WriteLine($"Player{player.Symbol}, make a move please!");

        public void DisplayOutOfTheBoundsDirection() => Console.WriteLine("Wrong input! Please choose a correct direction.");

        public void DisplayIncorrectDirection() => Console.WriteLine("Wrong input! Please press some of the arrow keys.");

        public void DisplayDrawGame() => Console.WriteLine("Draw game.");

        public void DisplayWinningPlayerInforamation(Game game)
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Player {game.Winner.Symbol} wins the game.");
            Console.WriteLine($"{Regex.Replace(game.Winner.GetType().Name, TRIM_NAMESPACE_REGEX, "$1")} with Power: {game.Winner.PowerPoints}"
                    + $", Speed: {game.Winner.SpeedPoints}");
            Console.WriteLine();
        }

        public void DisplayRequestRematch() => Console.WriteLine("Do you want to start a rematch? (y/n)");

        public void DisplayChooseWarriorType(char symbol)
        {
            Console.WriteLine($"Player{symbol}, please choose a warrior.");
            Console.WriteLine("Insert 1 for turtle / 2 for monkey / 3 for pigeon");
        }

        public void DisplayIncorrectRematchInput() => Console.WriteLine("Wrong input! Please press y or n.");

        public void DisplayNewLine() => Console.WriteLine(Environment.NewLine);

        public void DisplayIncorrectWarriorType() => Console.WriteLine("Wrong input! Please enter 1, 2 or 3.");

        public void PrintPlayerInformation(Warrior player) => Console.WriteLine($"Player{player?.Symbol}: {player?.PowerPoints} " +
                                                              $"Power; {player?.SpeedPoints} Speed");

        public void DisplayGridCell(string cell) => Console.Write($"{cell} ");

        public void PrintPlayersStatistics(Warrior firstPlayer, Warrior secondPlayer)
        {
            Console.WriteLine(Environment.NewLine);
            PrintPlayerInformation(firstPlayer);
            PrintPlayerInformation(secondPlayer);
            Console.WriteLine(Environment.NewLine);
        }
    }
}
