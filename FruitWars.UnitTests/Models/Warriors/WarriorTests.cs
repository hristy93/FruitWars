using Microsoft.VisualStudio.TestTools.UnitTesting;
using FruitWars.Models.Warriors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitWars.Utilities;
using FruitWars.Models.Fruits;

namespace FruitWars.Models.Warriors.Tests
{
    [TestClass()]
    public class WarriorTests
    {
        private Warrior _warrior;

        #region Tests initialize and cleanup
        [TestInitialize]
        public void InitializeTest()
        {
            _warrior = new Warrior() { Position = new Point() { X = 3, Y = 5 } };
        }
        #endregion

        [TestMethod]
        public void WarriorIntoDeprecatedZoneTest()
        {
            Warrior otherWarrior = new Warrior();
            otherWarrior.Position = new Point() { X = 3, Y = 6 };
            Assert.IsTrue(_warrior.IntoDeprecatedZone(otherWarrior));
        }

        [TestMethod()]
        public void WarriorMoveDownTest()
        {
            Point point = new Point() { X = 3, Y = 5 };
            point.X += 1;
            _warrior.Move(DirectionType.Down);
            Assert.AreEqual(_warrior.Position, point);
        }

        [TestMethod()]
        public void WarriorMoveUpTest()
        {
            Point point = new Point() { X = 3, Y = 5 };
            point.X -= 1;
            _warrior.Move(DirectionType.Up);
            Assert.AreEqual(_warrior.Position, point);
        }

        [TestMethod()]
        public void WarriorMoveLeftTest()
        {
            Point point = new Point()
            {
                X = 3,
                Y = 5
            };
            point.Y -= 1;
            _warrior.Move(DirectionType.Left);
            Assert.AreEqual(_warrior.Position, point);
        }

        [TestMethod()]
        public void WarriorMoveRightTest()
        {
            Point point = new Point()
            {
                X = 3,
                Y = 5
            };
            point.Y += 1;
            _warrior.Move(DirectionType.Right);
            Assert.AreEqual(_warrior.Position, point);
        }

        [TestMethod()]
        public void WarriorInvalidMoveDownTest()
        {
            _warrior.Position = new Point()
            {
                X = 7
            };
            Assert.IsFalse(_warrior.Move(DirectionType.Down));
        }


        [TestMethod()]
        public void WarriorInvalidMoveUpTest()
        {
            _warrior.Position = new Point()
            {
                X = 0
            };
            Assert.IsFalse(_warrior.Move(DirectionType.Up));
        }

        [TestMethod()]
        public void WarriorInvalidMoveLeftTest()
        {
            _warrior.Position = new Point()
            {
                Y = 0
            };
            Assert.IsFalse(_warrior.Move(DirectionType.Left));
        }

        [TestMethod()]
        public void WarriorInvalidMoveRightTest()
        {
            _warrior.Position = new Point()
            {
                Y = 7
            };
            Assert.IsFalse(_warrior.Move(DirectionType.Right));
        }

        [TestMethod()]
        public void WarriorEatAppleTest()
        {
            Fruit fruit = new Apple();
            int powerPoints = _warrior.PowerPoints;
            _warrior.EatFruit(fruit);
            powerPoints += 1;
            Assert.AreEqual(powerPoints, _warrior.PowerPoints);
        }

        [TestMethod()]
        public void WarriorEatPearTest()
        {
            Fruit fruit = new Pear();
            int speedPoints = _warrior.SpeedPoints;
            _warrior.EatFruit(fruit);
            speedPoints += 1;
            Assert.AreEqual(speedPoints, _warrior.SpeedPoints);
        }
    }
}