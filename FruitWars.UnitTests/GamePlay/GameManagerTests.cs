using FruitWars.GamePlay;
using FruitWars.Interfaces;
using FruitWars.Models;
using FruitWars.Models.Warriors;
using FruitWars.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FruitWars.UnitTests.GamePlay
{
    [TestClass]
    public class GameManagerTests
    {
        private IGameManager _gameManager;
        private IPlayersManager _playersManager;
        private IGridManager _gridManager;
        private IUserInterfaceManager _userInterfaceManager;
        private StringWriter _stringWriter;
        

        #region Tests initialize and cleanup
        [TestInitialize]
        public void TestInitialize()
        {
            _stringWriter = new StringWriter();
            _userInterfaceManager = new UserInterfaceManager();
            _gridManager = new GridManager(_userInterfaceManager);
            _playersManager = new PlayersManager(_userInterfaceManager);
            _gameManager = new GameManager(_gridManager, _playersManager, _userInterfaceManager);
        }
        #endregion
        
        [TestMethod]
        public void StartGameTest()
        {
            string input = "1" + Environment.NewLine + "3" + Environment.NewLine;
            Console.SetIn(new StringReader(input));
            _gameManager.StartGame(true);
        }

        [TestMethod]
        public void CheckHasPlayerWonTestFalse()
        {
            string input = "1" + Environment.NewLine + "3" + Environment.NewLine;
            Console.SetIn(new StringReader(input));
            _gameManager.StartGame(true);
            _playersManager.FirstPlayer.Position = new Point() { X = 1, Y = 1 };
            _playersManager.SecondPlayer.Position = new Point() { X = 2, Y = 2 };
            bool result = _gameManager.CheckHasPlayerWon(_playersManager.FirstPlayer);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckHasPlayerWonTestTrueFirst()
        {
            string input = "1" + Environment.NewLine + "3" + Environment.NewLine;
            Console.SetIn(new StringReader(input));
            _gameManager.StartGame(true);
            _playersManager.FirstPlayer.Position = new Point() { X = 1, Y = 1 };
            _playersManager.SecondPlayer.Position = new Point() { X = 1, Y = 1 };
            _playersManager.FirstPlayer.PowerPoints = 3;
            _playersManager.SecondPlayer.PowerPoints = 2;
            bool result = _gameManager.CheckHasPlayerWon(_playersManager.FirstPlayer);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckHasPlayerWonTestTrueSecond()
        {
            string input = "1" + Environment.NewLine + "3" + Environment.NewLine;
            Console.SetIn(new StringReader(input));
            _gameManager.StartGame(true);
            _playersManager.FirstPlayer.Position = new Point() { X = 1, Y = 1 };
            _playersManager.SecondPlayer.Position = new Point() { X = 1, Y = 1 };
            _playersManager.FirstPlayer.PowerPoints = 2;
            _playersManager.SecondPlayer.PowerPoints = 3;
            bool result = _gameManager.CheckHasPlayerWon(_playersManager.FirstPlayer);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckHasPlayerWonTestTrueDraw()
        {
            string input = "1" + Environment.NewLine + "3" + Environment.NewLine;
            Console.SetIn(new StringReader(input));
            _gameManager.StartGame(true);
            _playersManager.FirstPlayer.Position = new Point() { X = 1, Y = 1 };
            _playersManager.SecondPlayer.Position = new Point() { X = 1, Y = 1 };
            _playersManager.FirstPlayer.PowerPoints = 2;
            _playersManager.SecondPlayer.PowerPoints = 2;
            bool result = _gameManager.CheckHasPlayerWon(_playersManager.FirstPlayer);
            Assert.IsTrue(result);
        }
    }
}
