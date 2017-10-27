using System;
using FruitWars.Models.Warriors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FruitWars.Models.Warriors.Tests
{
    /// <summary>This class contains parameterized unit tests for Pigeon</summary>
    [TestClass]
    public class PigeonTest
    {

        /// <summary>Test stub for .ctor()</summary>

        [TestMethod]
        public void CreatePigeonTest()
       {
            Pigeon pigeon = new Pigeon();
            Assert.AreEqual(pigeon.PowerPoints, 1);
            Assert.AreEqual(pigeon.SpeedPoints, 3);
        }
    }
}
