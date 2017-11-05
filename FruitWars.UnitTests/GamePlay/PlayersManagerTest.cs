using FruitWars.Models;
using System;
using FruitWars.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FruitWars.Models.Warriors;
using System.IO;
using System.Collections.Generic;
using FruitWars.Models.Fruits;
using FruitWars.UnitTests.Utilities;
using FruitWars.GamePlay;
using FruitWars.Interfaces;

namespace FruitWars.UnitTests.GamePlay
{
    [TestClass]
    public class PlayersManagerTest
    {
        private IPlayersManager _playersManager;
        private IUserInterfaceManager _userInterfaceManager;
        private StringWriter _stringWriter;

        #region Tests initialize and cleanup
        [TestInitialize]
        public void InitializeTest()
        {
            _userInterfaceManager = new UserInterfaceManager();
            _playersManager = new PlayersManager(_userInterfaceManager);
            _stringWriter = new StringWriter();
        }
        #endregion

        [TestMethod]
        public void InputWarriorsTypesTest()
        {
            CreateWarriorTest("1", typeof(Turtle));
            CreateWarriorTest("2", typeof(Monkey));
            CreateWarriorTest("3", typeof(Pigeon));
        }

        public void CreateWarriorTest(string input, Type type)
        {
            Console.SetIn(new StringReader(input));
            Warrior warrior = _playersManager.InputWarriorsTypes('1');
            Assert.IsInstanceOfType(warrior, type);
        }

        [TestMethod]
        public void ChooseWarriorsAndPrintPlayersStatisticsTest()
        {
            string input = "1" + Environment.NewLine + "4" + Environment.NewLine + "3" + Environment.NewLine;
            Console.SetIn(new StringReader(input));
            _playersManager.ChooseWarriors();
            Assert.IsInstanceOfType(_playersManager.FirstPlayer, typeof(Turtle));
            Assert.IsInstanceOfType(_playersManager.SecondPlayer, typeof(Pigeon));
            Console.SetOut(_stringWriter);
            _userInterfaceManager.PrintPlayersStatistics(_playersManager.FirstPlayer, _playersManager.SecondPlayer);
            StringAssert.Contains(_stringWriter.ToString(), "Player1: 3 Power; 1 Speed\r\nPlayer2: 1 Power; 3 Speed");
        }

        [TestMethod]
        public void ChooseWarriorsTestWrongInput()
        {
            string input = "1" + Environment.NewLine + "4" + Environment.NewLine + "3" + Environment.NewLine;
            Console.SetIn(new StringReader(input));
            Console.SetOut(_stringWriter);
            _playersManager.ChooseWarriors();
            StringAssert.Contains(_stringWriter.ToString(), "Wrong input! Please enter 1, 2 or 3.");
        }

        [TestMethod]
        public void PrintPlayerScoresTestNULL()
        {
            _userInterfaceManager.PrintPlayerInformation(null);
        }

        [TestMethod]
        public void GetPlayerDirectionTest()
        {
            GetDirection(ConsoleKey.UpArrow, DirectionType.Up);
            GetDirection(ConsoleKey.DownArrow, DirectionType.Down);
            GetDirection(ConsoleKey.LeftArrow, DirectionType.Left);
            GetDirection(ConsoleKey.RightArrow, DirectionType.Right);
        }

        private void GetDirection(ConsoleKey consoleKey, DirectionType directionType)
        {
            IConsoleWrapper stub = new ConsoleWrapperStub(new List<ConsoleKey> { consoleKey });
            var result = _playersManager.GetPlayerDirection(stub);
            Assert.IsTrue(result == directionType);
        }

        [TestMethod]
        public void GetPlayerDirectionTestFail()
        {
            IConsoleWrapper stub = new ConsoleWrapperStub(new List<ConsoleKey>
            {
                ConsoleKey.Enter,
                ConsoleKey.RightArrow
            });
            Console.SetOut(_stringWriter);
            var result = _playersManager.GetPlayerDirection(stub);
            Assert.IsTrue(result == DirectionType.Right);
            StringAssert.Contains(_stringWriter.ToString(), "Wrong input! Please press some of the arrow keys.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EatFruitsTestPlayerNULL()
        {
            _playersManager.EatFruits(null, new List<Figure>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EatFruitsTestFiguresNULL()
        {
            _playersManager.EatFruits(new Warrior(), null);
        }

        [TestMethod]
        public void EatFruitsTestEatAppleSuccess()
        {
            Point point = new Point() { X = 1, Y = 1 };
            Pigeon warior = new Pigeon() { Position = point };
            Fruit fruit = new Apple() { Position = point };
            List<Figure> fruits = new List<Figure>() { fruit };
            int wariorPower = warior.PowerPoints;
            _playersManager.EatFruits(warior, fruits);
            Assert.AreEqual(++wariorPower, warior.PowerPoints);
            CollectionAssert.DoesNotContain(fruits, fruit);
        }

        [TestMethod]
        public void EatFruitsTestEatAppleFail()
        {
            Point point = new Point() { X = 1, Y = 1 };
            Pigeon warior = new Pigeon() { Position = point };
            Fruit fruit = new Apple()
            {
                Position = new Point() { X = 0, Y = 0 }
            };
            List<Figure> fruits = new List<Figure>() { fruit };
            int wariorPower = warior.PowerPoints;
            _playersManager.EatFruits(warior, fruits);
            Assert.AreEqual(wariorPower, warior.PowerPoints);
            CollectionAssert.Contains(fruits, fruit);
        }

        [TestMethod]
        public void EatFruitsTestEatPearSuccess()
        {
            Point point = new Point() { X = 1, Y = 1 };
            Pigeon warior = new Pigeon() { Position = point };
            Fruit fruit = new Pear() { Position = point };
            List<Figure> fruits = new List<Figure>() { fruit };
            int wariorSpeed = warior.SpeedPoints;
            _playersManager.EatFruits(warior, fruits);
            Assert.AreEqual(++wariorSpeed, warior.SpeedPoints);
            CollectionAssert.DoesNotContain(fruits, fruit);
        }

        [TestMethod]
        public void EatFruitsTestEatPeaFail()
        {
            Point point = new Point() { X = 1, Y = 1 };
            Pigeon warior = new Pigeon() { Position = point };
            Fruit fruit = new Pear() { Position = new Point() { X = 0, Y = 0 } };
            List<Figure> fruits = new List<Figure>() { fruit };
            int wariorSpeed = warior.SpeedPoints;
            _playersManager.EatFruits(warior, fruits);
            Assert.AreEqual(wariorSpeed, warior.SpeedPoints);
            CollectionAssert.Contains(fruits, fruit);
        }
    }
}
