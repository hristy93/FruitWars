using FruitWars.GamePlay;
using FruitWars.Models;
using FruitWars.Models.Fruits;
using FruitWars.Models.Warriors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FruitWars.Utilities
{
    public class GameManager
    {
        public const int INITIAL_PLAYERS_MOVE_DISTANCE = 3;
        public const int INITIAL_FRUITS_MOVE_DISTANCE = 2;
        public const int INITIAL_PEARS_COUNT = 3;
        public const int INITIAL_APPLES_COUNT = 4;

        //private char[,] _grid;
        //private bool _isEnded = false;

        private Game _game;
        private GridManager _gridManager;
        private Random _random = StaticRandom.Instance;

        public Warrior FirstPlayer { get; set; }
        public Warrior SecondPlayer { get; set; }
        public List<Pear> Pears { get; set; }
        public List<Apple> Apples { get; set; }

        public GameManager(GridManager gridManager)
        {
            //_game = game;
            _gridManager = gridManager;
        }

        public void StartGame()
        {
            _game = new Game();
            Pears = new List<Pear>(INITIAL_PEARS_COUNT);
            Apples = new List<Apple>(INITIAL_APPLES_COUNT);
            _gridManager.InitiateGrid();
            PlaceFruits(Pears, Apples); 
            ChooseWarriors();
            PlacePlayers(FirstPlayer, SecondPlayer);
            _gridManager.PrintGrid();
            RunGame();
        }

        private void RunGame()
        {
            DirectionType directionType;
            (int x, int y) oldPosition;
            int currentSpeedPoints;

            int moves = 0;
            while(!_game.IsEnded)
            {
                moves = 0;
                currentSpeedPoints = FirstPlayer.SpeedPoints;

                while (moves < currentSpeedPoints)
                {
                    directionType = GetPlayerDirection();

                    oldPosition = FirstPlayer.Position;
                    if (FirstPlayer.Move(directionType))
                    {
                        CheckForEatenFruits();

                        _gridManager.DisplayOnGrid(oldPosition, '_');
                        _gridManager.DisplayOnGrid(FirstPlayer.Position, '1');

                        moves++;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input! Please choose a direction that you can move.");
                    }

                    //_gridManager.MovePlayer(FirstPlayer.Position, directionType);
                    _gridManager.PrintGrid();
                    PrintPlayersStatistics();
                }

                moves = 0;
                currentSpeedPoints = FirstPlayer.SpeedPoints;

                while (moves < currentSpeedPoints)
                {
                    directionType = GetPlayerDirection();

                    oldPosition = SecondPlayer.Position;
                    if (SecondPlayer.Move(directionType))
                    {
                        _gridManager.DisplayOnGrid(oldPosition, '_');
                        _gridManager.DisplayOnGrid(SecondPlayer.Position, '2');
                        moves++;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input! Please choose a direction that you can move.");
                    }

                    //_gridManager.MovePlayer(FirstPlayer.Position, directionType);
                    _gridManager.PrintGrid();
                    PrintPlayersStatistics();
                }
            }
        }

        private void CheckForEatenFruits()
        {
            Pear tempPear = Pears.Where(pear => pear.Position.X == FirstPlayer.Position.X &&
                pear.Position.Y == FirstPlayer.Position.Y).SingleOrDefault();
            if (tempPear != null)
            {
                FirstPlayer.EatFruit(tempPear);
            }

            Apple tempApple = Apples.Where(apple => apple.Position.X == FirstPlayer.Position.X &&
               apple.Position.Y == FirstPlayer.Position.Y).SingleOrDefault();
            if (tempApple != null)
            {
                FirstPlayer.EatFruit(tempApple);
            }
        }

        private void PrintPlayersStatistics()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Plater1: {FirstPlayer.PowerPoints} Power and {FirstPlayer.SpeedPoints} Speed");
            Console.WriteLine($"Plater1: {SecondPlayer.PowerPoints} Power and {SecondPlayer.SpeedPoints} Speed");
            Console.WriteLine(Environment.NewLine);
            //Player1: 1 Power; 3 Speed
            //Player2: 3 Power; 1 Speed
        }

        private void ChooseWarriors()
        {
            (int firstWarriorType, int secondWarriorType) = WarriorTypesInput();

            switch (firstWarriorType)
            {
                case 1:
                    FirstPlayer = new Turtle();
                    break;
                case 2:
                    FirstPlayer = new Monkey();
                    break;
                case 3:
                    FirstPlayer = new Pigeon();
                    break;
                default:
                    break;
            }

            switch (secondWarriorType)
            {
                case 1:
                    SecondPlayer = new Turtle();
                    break;
                case 2:
                    SecondPlayer = new Monkey();
                    break;
                case 3:
                    SecondPlayer = new Pigeon();
                    break;
                default:
                    break;
            }
        }

        private (int, int) WarriorTypesInput()
        {
            int firstWarriorType;
            int secondWarriorType;

            bool isInputValid = false;
            do
            {
                Console.WriteLine("Player1, please choose a warrior. Insert 1 for turtle / 2 for monkey / 3 for pigeon");
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out firstWarriorType))
                {
                    isInputValid = true;
                }
            } while (!isInputValid);


            isInputValid = false;
            do
            {
                Console.WriteLine("Player2, please choose a warrior. Insert 1 for turtle / 2 for monkey / 3 for pigeon");
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out secondWarriorType))
                {
                    isInputValid = true;
                }
            } while (!isInputValid);

            return (firstWarriorType, secondWarriorType);
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
                        break;
                    case ConsoleKey.DownArrow:
                        directionType = DirectionType.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                        directionType = DirectionType.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        directionType = DirectionType.Right;
                        break;
                    default:
                        isInputValid = false;
                        Console.WriteLine("Wrong input! Please press some of the arrow keys.");
                        break;
                } 
            } while (!isInputValid);

            return directionType;
        }

            public void ResetGame()
        {

        }

        private void PlaceFruits(List<Pear> pears, List<Apple> apples)
        {
            (int x, int y) position = (0, 0);
            for (int i = 1; i <= INITIAL_APPLES_COUNT; i++)
            {
                position = GetPseudoRandomPosition();
                _gridManager.DisplayOnGrid(position, 'A');

            }

            for (int i = 1; i <= INITIAL_PEARS_COUNT; i++)
            {
                position = GetPseudoRandomPosition();
                _gridManager.DisplayOnGrid(position, 'P');

            }
        }

        private void PlacePlayers(Warrior firstPlayer, Warrior secondPlayer)
        {
            firstPlayer.Position = GetPseudoRandomPosition();
            _gridManager.DisplayOnGrid(firstPlayer.Position, '1');
            secondPlayer.Position = GetPseudoRandomPosition();
            _gridManager.DisplayOnGrid(secondPlayer.Position, '2');
        }

        private (int x, int y) GetPseudoRandomPosition()
        {
            int tempX = _random.Next(0, Game.MAX_CELLS_COUNT);
            int tempY = _random.Next(0, Game.MAX_CELLS_COUNT);
            (int x, int y) position = (tempX, tempY);


            //do
            //{
            //    if (CheckPosition(position))
            //    {

            //    }
            //    _random.Next(0, Game.MAX_CELLS_COUNT);
            //} while (true);

            return position;
        } 

        private static int ManhattanDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

    }
}
