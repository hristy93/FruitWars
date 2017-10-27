using Microsoft.VisualStudio.TestTools.UnitTesting;
using FruitWars.Models.Warriors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitWars.Utilities;

namespace FruitWars.Models.Warriors.Tests
{
    [TestClass()]
    public class WarriorTests
    {
        private Warrior _warrior = new Warrior() { Position = new Point() { X = 3, Y = 5 } };

        [TestMethod]
        public void IntoDeprecatedZoneTest()
        {
            Warrior otherWarrior = new Warrior();
            otherWarrior.Position = new Point() { X = 3, Y = 6 };
            Assert.IsTrue(_warrior.IntoDeprecatedZone(otherWarrior));
        }

        [TestMethod()]
        public void MoveTest()
        {
            Point point = new Point() { X = 3, Y = 5 };
            point.X += 1;
            _warrior.Move(DirectionType.Down);
            Assert.AreEqual(_warrior.Position, point);
        }
    }
}