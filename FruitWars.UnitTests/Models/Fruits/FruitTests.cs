using Microsoft.VisualStudio.TestTools.UnitTesting;
using FruitWars.Models.Warriors;

namespace FruitWars.Models.Fruits.Tests
{
    [TestClass()]
    public class FruitTest
    {
        [TestMethod]
        public void FruitIntoDeprecatedZoneTest()
        {
            Figure fruit = new Apple()
            {
                Position = new Point { X = 4, Y = 6 }
            };
            Figure otherFruit = new Pear()
            {
                Position = new Point { X = 3, Y = 6 }
            };

            Assert.IsTrue(fruit.IntoDeprecatedZone(otherFruit));
        }
    }
}