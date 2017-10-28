using System;
using FruitWars.Models.Warriors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FruitWars.Models.Warriors.Tests
{
    [TestClass]
    public class PigeonTests
    {
        [TestMethod]
        public void CreatePigeonTest()
       {
            Pigeon pigeon = new Pigeon();
            Assert.AreEqual(pigeon.PowerPoints, 1);
            Assert.AreEqual(pigeon.SpeedPoints, 3);
        }
    }
}
