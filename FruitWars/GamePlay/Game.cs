using FruitWars.Models.Fruits;
using FruitWars.Models.Warriors;
using FruitWars.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitWars.GamePlay
{
    public class Game
    {
        public const int MAX_CELLS_COUNT = 8;
        public const int PLAYERS_COUNT = 2;

        //private char[,] _grid;
        //private bool _isEnded = false;

        public GameStatusType Status { get; set; }
        public Warrior Winner { get; set; }

        //private GridManager _gridManager;
        //private PlayersManager _playersManager;


        public Game()
        {
            //Pears = new List<Pear>(INITIAL_PEARS_COUNT);
            //Apples = new List<Apple>(INITIAL_APPLES_COUNT);
            //_gridManager = gridManager;
            //_playersManager = playersManager;
            //playersManager.PlacePlayers();
        }

        //public void Run()
        //{
        //    //gridManager.InitiateGrid();
        //}

        //public void Reset()
        //{

        //}

        //public void PrintGrid()
        //{
        //    //_gridManager.PrintGrid();
        //}

    }
}
