using Microsoft.VisualStudio.TestTools.UnitTesting;
using FruitWars.Models;
using System;

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

        public bool PointEquals01Test(Point target, object otherPoint)
        {
            bool result = target.Equals(otherPoint);
            return result;
        }

        [TestMethod]
        public void PointEquals01243Test()
        {
            bool b;
            Point s0 = new Point();
            s0.X = 0;
            s0.Y = 0;
            b = this.PointEquals01Test(s0, (object)null);
            Assert.AreEqual<bool>(false, b);
            Assert.IsNotNull((object)s0);
            Assert.AreEqual<int>(0, s0.X);
            Assert.AreEqual<int>(0, s0.Y);
        }

        [TestMethod]
        public void PointEquals01449Test()
        {
            bool b;
            Point s0 = new Point();
            s0.X = 0;
            s0.Y = 0;
            object s1 = new object();
            b = this.PointEquals01Test(s0, s1);
            Assert.AreEqual<bool>(false, b);
            Assert.IsNotNull((object)s0);
            Assert.AreEqual<int>(0, s0.X);
            Assert.AreEqual<int>(0, s0.Y);
        }

        [TestMethod]
        public void PointEquals0181Test()
        {
            bool b;
            Point s0 = new Point();
            s0.X = 0;
            s0.Y = 0;
            Point s1 = new Point();
            s1.X = 0;
            s1.Y = 0;
            b = this.PointEquals01Test(s0, (object)s1);
            Assert.AreEqual<bool>(true, b);
            Assert.IsNotNull((object)s0);
            Assert.AreEqual<int>(0, s0.X);
            Assert.AreEqual<int>(0, s0.Y);
        }

        [TestMethod]
        public void PointEquals01395Test()
        {
            bool b;
            Point s0 = new Point();
            s0.X = 1;
            s0.Y = 0;
            Point s1 = new Point();
            s1.X = 0;
            s1.Y = 0;
            b = this.PointEquals01Test(s0, (object)s1);
            Assert.AreEqual<bool>(false, b);
            Assert.IsNotNull((object)s0);
            Assert.AreEqual<int>(1, s0.X);
            Assert.AreEqual<int>(0, s0.Y);
        }

        [TestMethod]
        public void IsIntoDeprecatedZoneThrowsNullReferenceException44()
        {
            bool b;
            Point s0 = new Point();
            s0.X = 0;
            s0.Y = 0;
            b = this.IsIntoDeprecatedZone(s0, (Point)null, 0);
        }

        [TestMethod]
        public void IsIntoDeprecatedZone282()
        {
            bool b;
            Point s0 = new Point();
            s0.X = 0;
            s0.Y = 0;
            Point s1 = new Point();
            s1.X = 0;
            s1.Y = 0;
            b = this.IsIntoDeprecatedZone(s0, s1, 0);
            Assert.AreEqual<bool>(false, b);
            Assert.IsNotNull((object)s0);
            Assert.AreEqual<int>(0, s0.X);
            Assert.AreEqual<int>(0, s0.Y);
        }

        [TestMethod]
        public void IsIntoDeprecatedZone672()
        {
            bool b;
            Point s0 = new Point();
            s0.X = 0;
            s0.Y = 0;
            Point s1 = new Point();
            s1.X = 507;
            s1.Y = 0;
            b = this.IsIntoDeprecatedZone(s0, s1, 0);
            Assert.AreEqual<bool>(false, b);
            Assert.IsNotNull((object)s0);
            Assert.AreEqual<int>(0, s0.X);
            Assert.AreEqual<int>(0, s0.Y);
        }

        [TestMethod]
        public void IsIntoDeprecatedZoneThrowsOverflowException676()
        {
            bool b;
            Point s0 = new Point();
            s0.X = -478150656;
            s0.Y = 0;
            Point s1 = new Point();
            s1.X = 1669332992;
            s1.Y = 0;
            b = this.IsIntoDeprecatedZone(s0, s1, 0);
        }

        [TestMethod]
        public void IsIntoDeprecatedZoneThrowsOverflowException838()
        {
            bool b;
            Point s0 = new Point();
            s0.X = 0;
            s0.Y = -241867776;
            Point s1 = new Point();
            s1.X = int.MaxValue;
            s1.Y = 1905615872;
            b = this.IsIntoDeprecatedZone(s0, s1, 0);
        }

        [TestMethod]
        public void Move552()
        {
            bool b;
            Point s0 = new Point();
            s0.X = 0;
            s0.Y = 0;
            b = this.Move(s0, 0, 0);
            Assert.AreEqual<bool>(true, b);
            Assert.IsNotNull((object)s0);
            Assert.AreEqual<int>(0, s0.X);
            Assert.AreEqual<int>(0, s0.Y);
        }

        [TestMethod]
        public void Move414()
        {
            bool b;
            Point s0 = new Point();
            s0.X = 0;
            s0.Y = 480;
            b = this.Move(s0, 0, 640);
            Assert.AreEqual<bool>(false, b);
            Assert.IsNotNull((object)s0);
            Assert.AreEqual<int>(0, s0.X);
            Assert.AreEqual<int>(480, s0.Y);
        }

        [TestMethod]
        public void Move143()
        {
            bool b;
            Point s0 = new Point();
            s0.X = 16777844;
            s0.Y = 0;
            b = this.Move(s0, -1071644272, 0);
            Assert.AreEqual<bool>(false, b);
            Assert.IsNotNull((object)s0);
            Assert.AreEqual<int>(16777844, s0.X);
            Assert.AreEqual<int>(0, s0.Y);
        }

        [TestMethod]
        public void Move722()
        {
            bool b;
            Point s0 = new Point();
            s0.X = 640;
            s0.Y = 0;
            b = this.Move(s0, 480, 0);
            Assert.AreEqual<bool>(false, b);
            Assert.IsNotNull((object)s0);
            Assert.AreEqual<int>(640, s0.X);
            Assert.AreEqual<int>(0, s0.Y);
        }
    }
}
