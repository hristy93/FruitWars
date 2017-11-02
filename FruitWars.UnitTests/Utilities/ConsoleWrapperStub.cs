using FruitWars.Interfaces;
using FruitWars.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitWars.UnitTests.Utilities
{
    /// <summary>
    /// https://stackoverflow.com/questions/13963369/how-to-unit-test-this-function
    /// </summary>
    public class ConsoleWrapperStub : IConsoleWrapper
    {
        private IList<ConsoleKey> _keyCollection;
        private int _keyIndex = 0;

        public ConsoleWrapperStub(IList<ConsoleKey> keyCollection)
        {
            _keyCollection = keyCollection;
        }

        public ConsoleKeyInfo ReadKey()
        {
            var result = _keyCollection[_keyIndex];
            _keyIndex++;
            return new ConsoleKeyInfo((char)result, result, false, false, false);
        }
    }
}
