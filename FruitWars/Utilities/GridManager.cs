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
                    _grid[i, j] = GameSymbols.EMPTY_SPACE_SYMBOL;
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

        public void DisplayOnGrid(Figure figure)
        {
            try
            {
                _grid[figure.Position.X, figure.Position.Y] = figure.Symbol;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DisplayOnGrid((int x, int y) position)
        {
            try
            {
                _grid[position.x, position.y] = GameSymbols.EMPTY_SPACE_SYMBOL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}