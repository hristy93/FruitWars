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

        private IUserInterfaceManager _userInterfaceManager;

        public PlayersManager(IUserInterfaceManager userInterfaceManager)
        {
            _userInterfaceManager = userInterfaceManager;
        }

        public Warrior FirstPlayer { get; private set; }
        public Warrior SecondPlayer { get; private set; }

        public void ChooseWarriors()
        {
            FirstPlayer = InputWarriorsTypes(GameSymbols.FIRST_PLAYER_SYMBOL);
            SecondPlayer = InputWarriorsTypes(GameSymbols.SECOND_PLAYER_SYMBOL);
        }

        public Warrior InputWarriorsTypes(char symbol)
        {
            int warriorType;
            bool isInputValid = false;

            _userInterfaceManager.DisplayChooseWarriorType(symbol);
         
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
                    _userInterfaceManager.DisplayIncorrectWarriorType();
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
                        _userInterfaceManager.DisplayNewLine();
                        _userInterfaceManager.DisplayIncorrectDirection();
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
    }
}
