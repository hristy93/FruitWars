using FruitWars.GamePlay;
using FruitWars.Interfaces;
using FruitWars.Models;
using FruitWars.Models.Warriors;
using FruitWars.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitWars.GamePlay
{
    public class GridManager : IGridManager
    {
        private Random _random = StaticRandom.Instance;
        private IUserInterfaceManager _userInterfaceManager;
        private char[,] _grid;

        public GridManager(IUserInterfaceManager userInterfaceManager)
        {
            _userInterfaceManager = userInterfaceManager;
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
            _userInterfaceManager.DisplayNewLine();
            string cell = "";

            for (int i = 0; i < Game.MAX_CELLS_COUNT; i++)
            {
                for (int j = 0; j < Game.MAX_CELLS_COUNT; j++)
                {
                    cell = _grid[i, j].ToString();
                    _userInterfaceManager.DisplayGridCell(cell);
                }

                _userInterfaceManager.DisplayNewLine();
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