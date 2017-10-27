using FruitWars.Models.Warriors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FruitWars.UnitTests.Models.Warriors
{
    [TestClass()]
    public class TurtleTests
    {
        [TestMethod()]
        public void CreateTurtleTest()
        {
            Turtle turtle = new Turtle();
            Assert.AreEqual(turtle.PowerPoints, 3);
            Assert.AreEqual(turtle.SpeedPoints, 1);
        }
    }
}
