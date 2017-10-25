using System;
using System.Collections.Generic;
using System.Text;

namespace FruitWars.GamePlay
{
    public class Game
    {
        public const int MAX_CELLS_COUNT = 8;

        private char[,] _grid;
        private bool isEnded = false;

        public Game()
        {
            Initiate();
        }

        public void Reset()
        {

        }

        public void PrintGrid()
        {
            
            for (int i = 0; i < MAX_CELLS_COUNT; i++)
            {
                for (int j = 0; j < MAX_CELLS_COUNT; j++)
                {
                    Console.Write($"{_grid[i,j]} ");
                }

                Console.WriteLine("\n");
            }

        }

        private void Initiate()
        {
            _grid = new char[MAX_CELLS_COUNT, MAX_CELLS_COUNT];
            for (int i = 0; i < MAX_CELLS_COUNT; i++)
            {
                for (int j = 0; j < MAX_CELLS_COUNT; j++)
                {
                    _grid[i, j] = '_';
                }
            }
        }


    }
}
