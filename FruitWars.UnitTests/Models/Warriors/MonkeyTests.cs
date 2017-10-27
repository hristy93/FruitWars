using Microsoft.VisualStudio.TestTools.UnitTesting;
using FruitWars.Models.Warriors;

namespace FruitWars.Models.Warriors.Tests
{
    [TestClass()]
    public class MonkeyTests
    {
        [TestMethod()]
        public void CreateMonkeyTest()
        {
            Monkey monkey = new Monkey();
            Assert.AreEqual(monkey.PowerPoints, 2);
            Assert.AreEqual(monkey.SpeedPoints, 2);
        }
    }
}