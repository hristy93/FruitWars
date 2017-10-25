using FruitWars.GamePlay;
using System;

namespace FruitWars
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.PrintGrid();
            Console.ReadLine();
        }
    }
}
