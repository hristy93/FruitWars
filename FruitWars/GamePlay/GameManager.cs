using FruitWars.GamePlay;
using FruitWars.Interfaces;
using FruitWars.Models;
using FruitWars.Models.Fruits;
using FruitWars.Models.Warriors;
using FruitWars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FruitWars.GamePlay
{
    public class GameManager : IGameManager
    {
        public const int INITIAL_PLAYERS_MOVE_DISTANCE = 3;
        public const int INITIAL_FRUITS_MOVE_DISTANCE = 2;
        public const int INITIAL_PEARS_COUNT = 3;
        public const int INITIAL_APPLES_COUNT = 4;

        private Game _game;
        private IGridManager _gridManager;
        private IPlayersManager _playersManager;
        private Random _random = StaticRandom.Instance;
        private const string TRIM_NAMESPACE_REGEX = @"[.\w]+\.(\w+)";
        private List<Figure> _figures = new List<Figure>();

        public GameManager(IGridManager gridManager, IPlayersManager playersManager)
        {
            _gridManager = gridManager;
            _playersManager = playersManager;
        }

        public void StartGame(bool ForTestOnly = false)
        {
            InitiatializeGameState();
            _gridManager.InitiateGrid();

            _playersManager.ChooseWarriors();
            PlaceFigures();

            _gridManager.PrintGrid();
            _playersManager.PrintPlayersStatistics();

            if(!ForTestOnly)
                RunGame();
        }

        private void InitiatializeGameState()
        {
            _game = new Game();
            _figures = new List<Figure>();
        }

        private void RunGame()
        {
            IConsoleWrapper consoleWrapper = new ConsoleWrapper();
            while (_game.Status == GameStatusType.Running)
            {
                MakeATurn(_playersManager.FirstPlayer, consoleWrapper);
                MakeATurn(_playersManager.SecondPlayer, consoleWrapper);
            }

            FinalizeGame();
        }

        private void MakeATurn(Warrior player, IConsoleWrapper consoleWrapper)
        {
            (int x, int y) oldPosition;
            int currentSpeedPoints;
            int moves = 0;
            bool isInputValid = true;

            currentSpeedPoints = player.SpeedPoints;

            while (moves < currentSpeedPoints && _game.Status == GameStatusType.Running)
            {
                oldPosition = (player.Position.X, player.Position.Y);
                if (isInputValid)
                {
                    Console.WriteLine($"Player{player.Symbol}, make a move please!");
                }

                DirectionType directionType = _playersManager.GetPlayerDirection(consoleWrapper);

                if (player.Move(directionType))
                {
                    isInputValid = true;
                    _playersManager.EatFruits(player, _figures);

                    _gridManager.DisplayOnGrid(oldPosition);
                    _gridManager.DisplayOnGrid(player);

                    moves++;

                    if (CheckHasPlayerWon(player))
                    {
                        break;
                    }

                    _gridManager.PrintGrid();
                    _playersManager.PrintPlayersStatistics();
                }
                else
                {
                    Console.WriteLine("Wrong input! Please choose a correct direction.");
                    isInputValid = false;
                }
            }
        }

        private void FinalizeGame()
        {
            Console.WriteLine(Environment.NewLine);

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
                switch (userInput)
                {
                    case "y":
                        Console.WriteLine(Environment.NewLine);
                        StartGame();
                        isInputValid = true;
                        break;
                    case "n":
                        isInputValid = true;
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
            if (_playersManager.FirstPlayer.Position == _playersManager.SecondPlayer.Position)
            {
                FindWinner();
                return true;
            }

            return false;
        }

        private void FindWinner()
        {
            if (_playersManager.FirstPlayer.PowerPoints > _playersManager.SecondPlayer.PowerPoints)
            {
                _game.Winner = _playersManager.FirstPlayer;
                _gridManager.DisplayOnGrid(_playersManager.FirstPlayer);
                _game.Status = GameStatusType.Won;
            }
            else if (_playersManager.FirstPlayer.PowerPoints < _playersManager.SecondPlayer.PowerPoints)
            {
                _game.Winner = _playersManager.SecondPlayer;
                _gridManager.DisplayOnGrid(_playersManager.SecondPlayer);
                _game.Status = GameStatusType.Won;
            }
            else
            {
                _game.Winner = null;
                _game.Status = GameStatusType.Draw;
            }

        }

        private void PlaceFigures()
        {
            SetFigurePosition(_playersManager.FirstPlayer);
            SetFigurePosition(_playersManager.SecondPlayer);

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
            } while (_figures.Any(x => x.IntoDeprecatedZone(figure)));
            _figures.Add(figure);
           _gridManager.DisplayOnGrid(figure);
        }

        private Point GetPseudoRandomPosition => 
            new Point() { X = _random.Next(0, Game.MAX_CELLS_COUNT), Y = _random.Next(0, Game.MAX_CELLS_COUNT) };
    }
}
