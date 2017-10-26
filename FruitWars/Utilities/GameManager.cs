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

        //private char[,] _grid;
        //private bool _isEnded = false;

        private Game _game;
        private GridManager _gridManager;
        private Random _random = StaticRandom.Instance;
        private const string TRIM_NAMESPACE_REGEX = @"[.\w]+\.(\w+)";


        //private Pear _eatenPear;
        //private Apple _eatenApple;

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
            InitiatializeGameState();
            _gridManager.InitiateGrid();
            PlaceFruits();
            ChooseWarriors();
            PlacePlayers(FirstPlayer, SecondPlayer);
            _gridManager.PrintGrid();
            RunGame();
        }

        private void InitiatializeGameState()
        {
            _game = new Game();
            Pears = new List<Pear>(INITIAL_PEARS_COUNT);
            Apples = new List<Apple>(INITIAL_APPLES_COUNT);
            //_eatenPear = null;
            //_eatenApple = null;
        }

        private void RunGame()
        {
            while (_game.Status == GameStatusType.Running)
            {
                MakeAMove(FirstPlayer);
                MakeAMove(SecondPlayer);
            }

            FinilizeGame();
        }

        private void MakeAMove(Warrior player)
        {
            DirectionType directionType;
            (int x, int y) oldPosition;
            int currentSpeedPoints;
            int moves = 0;

            currentSpeedPoints = player.SpeedPoints;

            while (moves < currentSpeedPoints)
            {
                Console.WriteLine($"{(player == FirstPlayer ? "First player" : "Second player")}, make a move please!");
                directionType = GetPlayerDirection();

                oldPosition = player.Position;
                if (player.Move(directionType))
                {
                    EatFruits(FirstPlayer);

                    _gridManager.DisplayOnGrid(oldPosition, GameSymbols.EMPTY_SPACE_SYMBOL);
                    _gridManager.DisplayOnGrid(player.Position, 
                        (player == FirstPlayer ? GameSymbols.FIRST_PLAYER_SYMBOL : GameSymbols.SECOND_PLAYER_SYMBOL));

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

                //_gridManager.MovePlayer(FirstPlayer.Position, directionType);
            }
        }

        private void FinilizeGame()
        {
            if (_game.Status == GameStatusType.Draw)
            {
                Console.WriteLine("Draw game! Nobody won!");
            }
            else
            {
                _gridManager.PrintGrid();
                if (_game.Winner == FirstPlayer)
                {
                    Console.WriteLine("The first player won the game!");

                }
                else
                {
                    Console.WriteLine("The second player won the game!");
                    //Console.WriteLine($"He/She is a {SecondPlayer.GetType()} and has {SecondPlayer.PowerPoints}"
                    //    + $" power and {SecondPlayer.SpeedPoints} speed");
                }

                Console.WriteLine($"He/She is a {Regex.Replace(_game.Winner.GetType().Name, TRIM_NAMESPACE_REGEX, "$1")} and has {_game.Winner.PowerPoints}"
                        + $" power and {_game.Winner.SpeedPoints} speed");

                Console.WriteLine();
            }
        }

        //private void ProposeRestart()
        //{
        //    Console.WriteLine("Do you want to restart the game: y or n");

        //    bool isInputValid = true;
        //    string userRestartInput;
        //    do
        //    {
        //        var userInput = Console.ReadLine();
        //        switch (userInput[0])
        //        {
        //            case 'y':
        //                RestartGame();
        //                break;
        //            case 'n':
        //                break;
        //            default:
        //                isInputValid = false;
        //                Console.WriteLine("Wrong input! Please press y or n.");
        //                break;
        //        }
        //    } while (!isInputValid);

        //}

        public bool CheckHasPlayerWon(Warrior player)
        {
            if (player == FirstPlayer)
            {
                if (SecondPlayer.Position.X == player.Position.X
                    && SecondPlayer.Position.Y == player.Position.Y)
                {
                    FindWinner();
                    return true;
                }
            }
            else
            {
                if (FirstPlayer.Position.X == player.Position.X
                   && FirstPlayer.Position.Y == player.Position.Y)
                {
                    FindWinner();
                    return true;
                }
            }

            return false;
        }

        private void FindWinner()
        {
            if (FirstPlayer.PowerPoints > SecondPlayer.PowerPoints)
            {
                _game.Winner = FirstPlayer;
                _gridManager.DisplayOnGrid(FirstPlayer.Position, GameSymbols.FIRST_PLAYER_SYMBOL);
                _game.Status = GameStatusType.Won;
            }
            else if (FirstPlayer.PowerPoints < SecondPlayer.PowerPoints)
            {
                _game.Winner = SecondPlayer;
                _gridManager.DisplayOnGrid(SecondPlayer.Position, GameSymbols.SECOND_PLAYER_SYMBOL);
                _game.Status = GameStatusType.Won;
            }
            else
            {
                _game.Winner = null;
                _game.Status = GameStatusType.Draw;
            }

        }

        //private void CheckForEatenFruits(Warrior player, Fruit eatenFruit)
        //{
        //    (int x, int y) fruitPosition;
        //    if (eatenFruit !=  null)
        //    {
        //        fruitPosition = eatenFruit.Position;
        //        if (fruitPosition.x != player.Position.X
        //            || fruitPosition.y != player.Position.Y)
        //        {
        //            if (eatenFruit is Apple)
        //            {
        //                _gridManager.DisplayOnGrid(fruitPosition, 'A');
        //                _eatenApple = null;
        //            }
        //            else if (eatenFruit is Pear)
        //            {
        //                _gridManager.DisplayOnGrid(fruitPosition, 'P');
        //                _eatenPear = null;
        //            }

        //        }

        //    }


        //    //(int x, int y) fruitPosition;
        //    //if (_eatenApple != null)
        //    //{
        //    //    fruitPosition = _eatenApple.Position;
        //    //    if (fruitPosition.x != player.Position.X
        //    //        || fruitPosition.y != player.Position.Y)
        //    //    {
        //    //        _gridManager.DisplayOnGrid(fruitPosition, 'A');
        //    //    }

        //    //}

        //    //if (_eatenPear != null)
        //    //{
        //    //    fruitPosition = _eatenPear.Position;
        //    //    if (fruitPosition.x != player.Position.X
        //    //        || fruitPosition.y != player.Position.Y)
        //    //    {
        //    //        _gridManager.DisplayOnGrid(fruitPosition, 'A');
        //    //    }

        //    //}
        //}

        private void EatFruits(Warrior player)
        {
            Pear tempPear = Pears.Where(pear => pear.Position.X == player.Position.X &&
              pear.Position.Y == player.Position.Y).SingleOrDefault();
            if (tempPear != null)
            {
                player.EatFruit(tempPear);
                Pears.Remove(tempPear);
                //_eatenPear = tempPear;
            }

            Apple tempApple = Apples.Where(apple => apple.Position.X == player.Position.X &&
               apple.Position.Y == player.Position.Y).SingleOrDefault();
            if (tempApple != null)
            {
                player.EatFruit(tempApple);
                Apples.Remove(tempApple);
                //_eatenApple = tempApple;
            }

            //Pear tempPear = Pears.Where(pear => pear.Position.X == FirstPlayer.Position.X &&
            //    pear.Position.Y == FirstPlayer.Position.Y).SingleOrDefault();
            //if (tempPear != null)
            //{
            //    FirstPlayer.EatFruit(tempPear);
            //    Pears.Remove(tempPear);
            //    _eatenPear = tempPear;
            //}

            //Apple tempApple = Apples.Where(apple => apple.Position.X == FirstPlayer.Position.X &&
            //   apple.Position.Y == FirstPlayer.Position.Y).SingleOrDefault();
            //if (tempApple != null)
            //{
            //    FirstPlayer.EatFruit(tempApple);
            //    Apples.Remove(tempApple);
            //    _eatenApple = tempApple;
            //}
        }

        private void PrintPlayersStatistics()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"The first player has {FirstPlayer.PowerPoints} power and {FirstPlayer.SpeedPoints} ppeed");
            Console.WriteLine($"The second player has {SecondPlayer.PowerPoints} power and {SecondPlayer.SpeedPoints} speed");
            Console.WriteLine(Environment.NewLine);
        }

        private void ChooseWarriors()
        {
            int firstWarriorType = InputWarriorsTypes(FirstPlayer);
            int secondWarriorType = InputWarriorsTypes(SecondPlayer);

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

        private int InputWarriorsTypes(Warrior player)
        {
            int warriorType;

            bool isInputValid = false;
            do
            {
                Console.WriteLine($"You are the {(player == FirstPlayer ? "first" : "second" )} player");
                Console.WriteLine("Please choose a warrior: [1] turtle, [2] monkey, [3] pigeon");
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out warriorType))
                {
                    isInputValid = true;
                }
            } while (!isInputValid);

            return warriorType;
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

        public void RestartGame()
        {

        }

        private void PlaceFruits()
        {
            (int x, int y) position = (0, 0);
            for (int i = 1; i <= INITIAL_APPLES_COUNT; i++)
            {

                position = GetPseudoRandomPosition();
                _gridManager.DisplayOnGrid(position, GameSymbols.APPLE_SYMBOL);
                Apples.Add(new Apple(position));
            }


            for (int i = 1; i <= INITIAL_PEARS_COUNT; i++)
            {
                position = GetPseudoRandomPosition();
                _gridManager.DisplayOnGrid(position, GameSymbols.PEAR_SYMBOL);
                Pears.Add(new Pear(position));

            }
        }

        private void PlacePlayers(Warrior firstPlayer, Warrior secondPlayer)
        {
            firstPlayer.Position = GetPseudoRandomPosition();
            _gridManager.DisplayOnGrid(firstPlayer.Position, GameSymbols.FIRST_PLAYER_SYMBOL);
            secondPlayer.Position = GetPseudoRandomPosition();
            _gridManager.DisplayOnGrid(secondPlayer.Position, GameSymbols.SECOND_PLAYER_SYMBOL);
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
