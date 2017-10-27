using FruitWars.GamePlay;
using FruitWars.Models;
using FruitWars.Models.Fruits;
using FruitWars.Models.Warriors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FruitWars.Utilities
{
    public class GameManager
    {
        public const int INITIAL_PLAYERS_MOVE_DISTANCE = 3;
        public const int INITIAL_FRUITS_MOVE_DISTANCE = 2;
        public const int INITIAL_PEARS_COUNT = 3;
        public const int INITIAL_APPLES_COUNT = 4;

        private Game _game;
        private GridManager _gridManager;
        private Random _random = StaticRandom.Instance;
        private const string TRIM_NAMESPACE_REGEX = @"[.\w]+\.(\w+)";

        public Warrior FirstPlayer { get; set; }
        public Warrior SecondPlayer { get; set; }
        public List<Figure> Figures { get; set; } = new List<Figure>();

        public GameManager(GridManager gridManager)
        {
            _gridManager = gridManager;
        }

        public void StartGame()
        {
            InitiatializeGameState();
            _gridManager.InitiateGrid();

            ChooseWarriors();
            PlaceFigures();

            _gridManager.PrintGrid();
            PrintPlayersStatistics();

            RunGame();
        }

        private void InitiatializeGameState()
        {
            _game = new Game();
            Figures = new List<Figure>();
        }

        private void RunGame()
        {
            while (_game.Status == GameStatusType.Running)
            {
                MakeAMove(FirstPlayer);
                MakeAMove(SecondPlayer);
            }

            FinalizeGame();
        }

        private void MakeAMove(Warrior player)
        {
            (int x, int y) oldPosition;
            int currentSpeedPoints;
            int moves = 0;

            currentSpeedPoints = player.SpeedPoints;

            while (moves < currentSpeedPoints && _game.Status == GameStatusType.Running)
            {
                oldPosition = (player.Position.X, player.Position.Y);

                Console.WriteLine($"Player{player.Symbol}, make a move please!");
                DirectionType directionType = GetPlayerDirection();

                if (player.Move(directionType))
                {
                    EatFruits(player);

                    _gridManager.DisplayOnGrid(oldPosition);
                    _gridManager.DisplayOnGrid(player);

                    moves++;

                    if (CheckHasPlayerWon(player))
                    {
                        break;
                    }

                    _gridManager.PrintGrid();
                    PrintPlayersStatistics();
                }
                else
                {
                    Console.WriteLine("Wrong input! Please choose a direction that you can move.");
                }
            }
        }

        private void FinalizeGame()
        {
            if (_game.Status == GameStatusType.Draw)
            {
                Console.WriteLine("Draw game.");
            }
            else
            {
                _gridManager.PrintGrid();
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Player {_game.Winner.Symbol} wins the game.");
                Console.WriteLine($"{Regex.Replace(_game.Winner.GetType().Name, TRIM_NAMESPACE_REGEX, "$1")} with Power: {_game.Winner.PowerPoints}"
                        + $", Speed: {_game.Winner.SpeedPoints}");
                Console.WriteLine();
            }

            ProposeRestart();
        }

        private void ProposeRestart()
        {
            bool isInputValid = true;
            Console.WriteLine("Do you want to start a rematch? (y/n)");

            do
            {
                var userInput = Console.ReadLine();
                switch (userInput[0])
                {
                    case 'y':
                        Console.WriteLine(Environment.NewLine);
                        StartGame();
                        break;
                    case 'n':
                        break;
                    default:
                        isInputValid = false;
                        Console.WriteLine("Wrong input! Please press y or n.");
                        break;
                }
            } while (!isInputValid);
        }

        public bool CheckHasPlayerWon(Warrior player)
        {
            if (FirstPlayer.Position == SecondPlayer.Position)
            {
                FindWinner();
                return true;
            }

            return false;
        }

        private void FindWinner()
        {
            if (FirstPlayer.PowerPoints > SecondPlayer.PowerPoints)
            {
                _game.Winner = FirstPlayer;
                _gridManager.DisplayOnGrid(FirstPlayer);
                _game.Status = GameStatusType.Won;
            }
            else if (FirstPlayer.PowerPoints < SecondPlayer.PowerPoints)
            {
                _game.Winner = SecondPlayer;
                _gridManager.DisplayOnGrid(SecondPlayer);
                _game.Status = GameStatusType.Won;
            }
            else
            {
                _game.Winner = null;
                _game.Status = GameStatusType.Draw;
            }

        }

        private void EatFruits(Warrior player)
        {
            Figure figure = Figures.FirstOrDefault(x => x is Fruit && x.Position == player.Position);
            if (figure is Fruit)
            {
                player.EatFruit(figure as Fruit);
                Figures.Remove(figure);
            }
        }

        private void PrintPlayersStatistics()
        {
            Console.WriteLine(Environment.NewLine);
            PrintPlayerScores(FirstPlayer);
            PrintPlayerScores(SecondPlayer);
            Console.WriteLine(Environment.NewLine);
        }

        private void PrintPlayerScores(Warrior player)
        {
            Console.WriteLine($"Player{player.Symbol}: {player.PowerPoints} Power; {player.SpeedPoints} Speed");
        }

        private void ChooseWarriors()
        {
            FirstPlayer = InputWarriorsTypes(GameSymbols.FIRST_PLAYER_SYMBOL);
            SecondPlayer = InputWarriorsTypes(GameSymbols.SECOND_PLAYER_SYMBOL);
        }

        private Warrior InputWarriorsTypes(char symbol)
        {
            int warriorType;
            bool isInputValid = false;

            Console.WriteLine($"Player{symbol}, please choose a warrior.");
            Console.WriteLine("Insert 1 for turtle / 2 for monkey / 3 for pigeon");

            do
            {
                var userInput = Console.ReadLine();

                if (int.TryParse(userInput, out warriorType) && warriorType > 0 && warriorType < 4)
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

        private DirectionType GetPlayerDirection()
        {
            bool isInputValid = true;
            DirectionType directionType = DirectionType.Down;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
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
                        Console.WriteLine("\nWrong input! Please press some of the arrow keys.");
                        break;
                }
            } while (!isInputValid);

            return directionType;
        }

        private void PlaceFigures()
        {
            SetFigurePosition(FirstPlayer);
            SetFigurePosition(SecondPlayer);

            for (int i = 1; i <= INITIAL_APPLES_COUNT; i++)
            {
                SetFigurePosition(new Apple());
            }

            for (int i = 1; i <= INITIAL_PEARS_COUNT; i++)
            {
                SetFigurePosition(new Pear());
            }
        }

        private void SetFigurePosition(Figure figure)
        {
            do
            {
                figure.Position = GetPseudoRandomPosition;
            } while (Figures.Any(x => x.IntoDeprecatedZone(figure)));
            Figures.Add(figure);
           _gridManager.DisplayOnGrid(figure);
        }

        private Point GetPseudoRandomPosition => 
            new Point() { X = _random.Next(0, Game.MAX_CELLS_COUNT), Y = _random.Next(0, Game.MAX_CELLS_COUNT) };
    }
}
