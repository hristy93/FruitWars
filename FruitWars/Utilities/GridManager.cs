using FruitWars.GamePlay;
using FruitWars.Models;
using FruitWars.Models.Warriors;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitWars.Utilities
{
    public class GridManager
    {
        public const int PLAYERS_COUNT = 2;
        public const int INITIAL_PEARS_COUNT = 3;
        public const int INITIAL_APPLES_COUNT = 4;
        public const int INITIAL_PLAYERS_MOVE_DISTANCE = 3;
        public const int INITIAL_FRUITS_MOVE_DISTANCE = 2;

        private Random _random = StaticRandom.Instance;
        private char[,] _grid;

        public GridManager()
        {
            _grid = new char[Game.MAX_CELLS_COUNT, Game.MAX_CELLS_COUNT];
        }

        public void InitiateGrid()
        {
            _grid = new char[Game.MAX_CELLS_COUNT, Game.MAX_CELLS_COUNT];
            for (int i = 0; i < Game.MAX_CELLS_COUNT; i++)
            {
                for (int j = 0; j < Game.MAX_CELLS_COUNT; j++)
                {
                    _grid[i, j] = '_';
                }
            }
        }

        public void PrintGrid()
        {
            Console.WriteLine(Environment.NewLine);

            for (int i = 0; i < Game.MAX_CELLS_COUNT; i++)
            {
                for (int j = 0; j < Game.MAX_CELLS_COUNT; j++)
                {
                    Console.Write($"{_grid[i, j]} ");
                }

                Console.WriteLine("\n");
            }

        }

        public void DisplayOnGrid((int x, int y) position, char symblol)
        {
            _grid[position.x, position.y] = symblol;
        }

        //public (int, int) MovePlayer((int x, int y) position, DirectionType directionType)
        //{
        //    DisplayOnGrid(position, '_');
        //    switch (directionType)
        //    {
        //        case DirectionType.Left:
        //            position = (position.x)
        //            break;
        //        case DirectionType.Right:
        //            break;
        //        case DirectionType.Up:
        //            break;
        //        case DirectionType.Down:
        //            break;
        //        default:
        //            break;
        //    }

            //private void PlaceFruits()
            //{
            //    (int x, int y) position = (0,0);
            //    for (int i = 1; i <= INITIAL_APPLES_COUNT; i++)
            //    {
            //        position = GetPseudoRandomPosition();

            //    }

            //    for (int i = 1; i <= INITIAL_PEARS_COUNT; i++)
            //    {
            //        position = GetPseudoRandomPosition();

            //    }
            //}

            //private void PlacePlayers(Warrior firstPlayer, Warrior secondPlayer)
            //{
            //    firstPlayer.Position = GetPseudoRandomPosition();
            //    secondPlayer.Position = GetPseudoRandomPosition();
            //}

            //private (int x, int y) GetPseudoRandomPosition()
            //{
            //    int tempX = _random.Next(0, Game.MAX_CELLS_COUNT);
            //    int tempY = _random.Next(0, Game.MAX_CELLS_COUNT);
            //    (int x, int y) position = (tempX, tempY);


            //    //do
            //    //{
            //    //    if (CheckPosition(position))
            //    //    {

            //    //    }
            //    //    _random.Next(0, Game.MAX_CELLS_COUNT);
            //    //} while (true);

            //    return position;
            //}

            //private bool CheckPosition((int x, int y) position)
            //{
            //    bool isPositionValid = true;
            //    if (position.x >= Game.MAX_CELLS_COUNT || position.x < 0
            //        || position.y >= Game.MAX_CELLS_COUNT || position.y < 0)
            //    {
            //        isPositionValid = false;
            //    }

            //    return isPositionValid;
            //}

            //private static int ManhattanDistance(int x1, int x2, int y1, int y2)
            //{
            //    return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
            //}
        //}
    }
}