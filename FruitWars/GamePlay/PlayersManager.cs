using FruitWars.GamePlay;
using FruitWars.Interfaces;
using FruitWars.Models;
using FruitWars.Models.Warriors;
using FruitWars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FruitWars.GamePlay
{
    public class PlayersManager : IPlayersManager
    {
        private const int WARRIOR_TYPES_MIN_COUNT = 1;
        private const int WARRIOR_TYPES_MAX_COUNT = 3;

        public Warrior FirstPlayer { get; private set; }
        public Warrior SecondPlayer { get; private set; }

        public void PrintPlayerScores(Warrior player)
        {
            Console.WriteLine($"Player{player?.Symbol}: {player?.PowerPoints} Power; {player?.SpeedPoints} Speed");
        }

        public void ChooseWarriors()
        {
            FirstPlayer = InputWarriorsTypes(GameSymbols.FIRST_PLAYER_SYMBOL);
            SecondPlayer = InputWarriorsTypes(GameSymbols.SECOND_PLAYER_SYMBOL);
        }

        public Warrior InputWarriorsTypes(char symbol)
        {
            int warriorType;
            bool isInputValid = false;

            Console.WriteLine($"Player{symbol}, please choose a warrior.");
            Console.WriteLine("Insert 1 for turtle / 2 for monkey / 3 for pigeon");

            do
            {
                var userInput = Console.ReadLine();

                if (int.TryParse(userInput, out warriorType) 
                    && warriorType >= WARRIOR_TYPES_MIN_COUNT && warriorType <= WARRIOR_TYPES_MAX_COUNT)
                {
                    isInputValid = true;
                }
                else
                {
                    Console.WriteLine("Wrong input! Please enter 1, 2 or 3.");
                }
            } while (!isInputValid);

            Warrior warrior = null;

            switch (warriorType)
            {
                case 1:
                    warrior = new Turtle();
                    break;
                case 2:
                    warrior = new Monkey();
                    break;
                case 3:
                    warrior = new Pigeon();
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid Warrior type");
            }

            warrior.Symbol = symbol;
            return warrior;
        }

        public DirectionType GetPlayerDirection(IConsoleWrapper consoleWrapper)
        {
            bool isInputValid = true;
            DirectionType directionType = DirectionType.Down;
            do
            {
                ConsoleKeyInfo keyInfo = consoleWrapper.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        directionType = DirectionType.Up;
                        isInputValid = true;
                        break;
                    case ConsoleKey.DownArrow:
                        directionType = DirectionType.Down;
                        isInputValid = true;
                        break;
                    case ConsoleKey.LeftArrow:
                        directionType = DirectionType.Left;
                        isInputValid = true;
                        break;
                    case ConsoleKey.RightArrow:
                        directionType = DirectionType.Right;
                        isInputValid = true;
                        break;
                    default:
                        isInputValid = false;
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine("Wrong input! Please press some of the arrow keys.");
                        break;
                }
            } while (!isInputValid);

            return directionType;
        }

        public void EatFruits(Warrior player, List<Figure> figures)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player is NULL");
            }
                

            if (figures == null)
            {
                throw new ArgumentNullException("figures is NULL");
            }
                
            Figure figure = figures.FirstOrDefault(x => x is Fruit && x.Position == player.Position);
            if (figure is Fruit fruit)
            {
                player.EatFruit(fruit);
                figures.Remove(figure);
            }
        }

        public void PrintPlayersStatistics()
        {
            Console.WriteLine(Environment.NewLine);
            PrintPlayerScores(FirstPlayer);
            PrintPlayerScores(SecondPlayer);
            Console.WriteLine(Environment.NewLine);
        }
    }
}
