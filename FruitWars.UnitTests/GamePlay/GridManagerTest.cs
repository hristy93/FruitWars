using FruitWars.Models;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FruitWars.Models.Warriors;
using FruitWars.GamePlay;

namespace FruitWars.UnitTests.GamePlay
{
    [TestClass]
    public class GridManagerTest
    {
        private GridManager _gridManager;

        #region Tests initialize and cleanup
        [TestInitialize]
        public void InitializeTest()
        {
            _gridManager = new GridManager();
        }
        #endregion

        public GridManager CreateGridManager()
        {
            GridManager target = new GridManager();
            return target;
        }

        public void InitiateGrid(GridManager target)
        {
            target.InitiateGrid();
        }

        public void DisplayOnGrid(GridManager target, Figure figure)
        {
            target.DisplayOnGrid(figure);
        }

        [TestMethod]
        public void CreateGridManagerTest()
        {

            Assert.IsNotNull((object)_gridManager);
        }

        [TestMethod]
        public void InitiateGridTest()
        {
            this.InitiateGrid(_gridManager);
            Assert.IsNotNull((object)_gridManager);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void DisplayOnGridTestFigureNULL()
        {;
            this.DisplayOnGrid(_gridManager, (Figure)null);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void DisplayOnGridTestPointNULL()
        {
            Warrior warrior = new Warrior
            {
                SpeedPoints = 0,
                PowerPoints = 0
            };
            ((Figure)warrior).Position = (Point)null;
            ((Figure)warrior).Symbol = '\0';
            DisplayOnGrid(_gridManager, (Figure)warrior);
        }

        [TestMethod]
        public void DisplayOnGridTest()
        {
            Warrior warrior = new Warrior
            {
                SpeedPoints = 0,
                PowerPoints = 0
            };
            Point point = new Point
            {
                X = 0,
                Y = 0
            };
            ((Figure)warrior).Position = point;
            ((Figure)warrior).Symbol = '\0';
            this.DisplayOnGrid(_gridManager, (Figure)warrior);
            Assert.IsNotNull((object)_gridManager);
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void DisplayOnGridTestThrowsIndexOutOfRangeException()
        {
            Warrior warrior = new Warrior
            {
                SpeedPoints = 0,
                PowerPoints = 0
            };
            Point point = new Point
            {
                X = int.MinValue,
                Y = 0
            };
            ((Figure)warrior).Position = point;
            ((Figure)warrior).Symbol = '\0';
            DisplayOnGrid(_gridManager, (Figure)warrior);
        }
    }
}

