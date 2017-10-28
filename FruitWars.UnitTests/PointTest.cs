using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FruitWars.Models.Tests
{
    [TestClass]
    public class PointTest
    {
        public bool IsIntoDeprecatedZone(Point target, Point point, int distance)
        {
            bool result = target.IsIntoDeprecatedZone(point, distance);
            return result;
        }

        public bool Move(Point target, int newX, int newY)
        {
            bool result = target.Move(newX, newY);
            return result;
        }

        public bool PointEquals(Point target, object otherPoint)
        {
            bool result = target.Equals(otherPoint);
            return result;
        }

        [TestMethod]
        public void PointEqualsTestPointNULL()
        {
            bool result;
            Point point = new Point
            {
                X = 0,
                Y = 0
            };
            result = this.PointEquals(point, (object)null);
            Assert.AreEqual<bool>(false, result);
            Assert.IsNotNull((object)point);
            Assert.AreEqual<int>(0, point.X);
            Assert.AreEqual<int>(0, point.Y);
        }

        [TestMethod]
        public void PointEqualsTestObject()
        {
            bool result;
            Point point = new Point
            {
                X = 0,
                Y = 0
            };
            object newObject = new object();
            result = this.PointEquals(point, newObject);
            Assert.AreEqual<bool>(false, result);
            Assert.IsNotNull((object)point);
            Assert.AreEqual<int>(0, point.X);
            Assert.AreEqual<int>(0, point.Y);
        }

        [TestMethod]
        public void PointEqualsTestOtherPointSuccess()
        {
            bool result;
            Point point = new Point
            {
                X = 0,
                Y = 0
            };
            Point otherPoint = new Point
            {
                X = 0,
                Y = 0
            };
            result = this.PointEquals(point, (object)otherPoint);
            Assert.AreEqual<bool>(true, result);
            Assert.IsNotNull((object)point);
            Assert.AreEqual<int>(0, point.X);
            Assert.AreEqual<int>(0, point.Y);
        }

        [TestMethod]
        public void PointEqualsTestOtherPointFail()
        {
            bool result;
            Point point = new Point
            {
                X = 1,
                Y = 0
            };
            Point otherPoint = new Point
            {
                X = 0,
                Y = 0
            };
            result = this.PointEquals(point, (object)otherPoint);
            Assert.AreEqual<bool>(false, result);
            Assert.IsNotNull((object)point);
            Assert.AreEqual<int>(1, point.X);
            Assert.AreEqual<int>(0, point.Y);
        }

        [TestMethod]
        public void IsIntoDeprecatedZoneTestPointNULL()
        {
            bool result;
            Point point = new Point
            {
                X = 0,
                Y = 0
            };
            result = this.IsIntoDeprecatedZone(point, (Point)null, 0);
        }

        [TestMethod]
        public void IsIntoDeprecatedZoneTest()
        {
            bool result;
            Point point = new Point
            {
                X = 0,
                Y = 0
            };
            Point otherPoint = new Point
            {
                X = 0,
                Y = 0
            };
            result = this.IsIntoDeprecatedZone(point, otherPoint, 0);
            Assert.AreEqual<bool>(false, result);
            Assert.IsNotNull((object)point);
            Assert.AreEqual<int>(0, point.X);
            Assert.AreEqual<int>(0, point.Y);
        }

        [TestMethod]
        public void IsIntoDeprecatedZoneTestXCoordinateOverflow()
        {
            bool result;
            Point point = new Point();
            point.X = -478150656;
            point.Y = 0;
            Point otherPoint = new Point();
            otherPoint.X = 1669332992;
            otherPoint.Y = 0;
            result = this.IsIntoDeprecatedZone(point, otherPoint, 0);
        }

        [TestMethod]
        public void IsIntoDeprecatedZoneTestYCoordinateOverflow()
        {
            bool result;
            Point point = new Point
            {
                X = 0,
                Y = -241867776
            };
            Point s1 = new Point
            {
                X = int.MaxValue,
                Y = 1905615872
            };
            result = this.IsIntoDeprecatedZone(point, s1, 0);
        }

        [TestMethod]
        public void MoveTestFirst()
        {
            bool result;
            Point point = new Point
            {
                X = 0,
                Y = 0
            };
            result = this.Move(point, 0, 0);
            Assert.AreEqual<bool>(true, result);
            Assert.IsNotNull((object)point);
            Assert.AreEqual<int>(0, point.X);
            Assert.AreEqual<int>(0, point.Y);
        }

        [TestMethod]
        public void MoveTestSecond()
        {
            bool result;
            Point point = new Point
            {
                X = 0,
                Y = 480
            };
            result = this.Move(point, 0, 640);
            Assert.AreEqual<bool>(false, result);
            Assert.IsNotNull((object)point);
            Assert.AreEqual<int>(0, point.X);
            Assert.AreEqual<int>(480, point.Y);
        }

        [TestMethod]
        public void MoveTestThird()
        {
            bool result;
            Point point = new Point
            {
                X = 16777844,
                Y = 0
            };
            result = this.Move(point, -1071644272, 0);
            Assert.AreEqual<bool>(false, result);
            Assert.IsNotNull((object)point);
            Assert.AreEqual<int>(16777844, point.X);
            Assert.AreEqual<int>(0, point.Y);
        }

        [TestMethod]
        public void MoveTestFourth()
        {
            bool result;
            Point point = new Point
            {
                X = 640,
                Y = 0
            };
            result = this.Move(point, 480, 0);
            Assert.AreEqual<bool>(false, result);
            Assert.IsNotNull((object)point);
            Assert.AreEqual<int>(640, point.X);
            Assert.AreEqual<int>(0, point.Y);
        }
    }
}
