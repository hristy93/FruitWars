using System;
using System.Collections.Generic;
using System.Text;

namespace FruitWars.Utilities
{
    /// <summary>
    /// https://stackoverflow.com/questions/13963369/how-to-unit-test-this-function
    /// </summary>
    public class ConsoleWrapper : IConsoleWrapper
    {
        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }
    }
}
