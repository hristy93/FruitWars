using FruitWars.Models;

using System;
using FruitWars.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FruitWars.Models.Warriors;

namespace FruitWars.UnitTests.Utilities
{
    public static class GridManagerFactory
    {
        public static GridManager Create()
        {
            GridManager gridManager = new GridManager();
            return gridManager;
        }
    }

    [TestClass]
    public class GridManagerTest
    {

        public GridManager Constructor()
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
        public void Constructor833()
        {
            GridManager gridManager;
            gridManager = this.Constructor();
            Assert.IsNotNull((object)gridManager);
        }

        [TestMethod]
        public void InitiateGrid649()
        {
            GridManager gridManager;
            gridManager = GridManagerFactory.Create();
            this.InitiateGrid(gridManager);
            Assert.IsNotNull((object)gridManager);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void DisplayOnGridThrowsNullReferenceException356()
        {
            GridManager gridManager;
            gridManager = GridManagerFactory.Create();
            this.DisplayOnGrid(gridManager, (Figure)null);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void DisplayOnGridThrowsNullReferenceException359()
        {
            GridManager gridManager;
            gridManager = GridManagerFactory.Create();
            Warrior s0 = new Warrior();
            s0.SpeedPoints = 0;
            s0.PowerPoints = 0;
            ((Figure)s0).Position = (Point)null;
            ((Figure)s0).Symbol = '\0';
            DisplayOnGrid(gridManager, (Figure)s0);
        }

        [TestMethod]
        public void DisplayOnGrid98()
        {
            GridManager gridManager;
            gridManager = GridManagerFactory.Create();
            Warrior s0 = new Warrior();
            s0.SpeedPoints = 0;
            s0.PowerPoints = 0;
            Point s1 = new Point();
            s1.X = 0;
            s1.Y = 0;
            ((Figure)s0).Position = s1;
            ((Figure)s0).Symbol = '\0';
            this.DisplayOnGrid(gridManager, (Figure)s0);
            Assert.IsNotNull((object)gridManager);
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void DisplayOnGridThrowsIndexOutOfRangeException710()
        {
            GridManager gridManager;
            gridManager = GridManagerFactory.Create();
            Warrior s0 = new Warrior();
            s0.SpeedPoints = 0;
            s0.PowerPoints = 0;
            Point s1 = new Point();
            s1.X = int.MinValue;
            s1.Y = 0;
            ((Figure)s0).Position = s1;
            ((Figure)s0).Symbol = '\0';
            DisplayOnGrid(gridManager, (Figure)s0);
        }
    }
}

