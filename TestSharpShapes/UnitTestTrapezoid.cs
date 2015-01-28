using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpShapes;

namespace TestSharpShapes
{
    [TestClass]
    public class UnitTestTrapezoid
    {
        [TestMethod]
        public void TestTrapezoidConstructor()
        {
            Trapezoid trap = new Trapezoid(8, 2, 4);
            Assert.AreEqual(8, trap.Base1);
            Assert.AreEqual(2, trap.Base2);
            Assert.AreEqual(4, trap.Height);
        }

        [TestMethod]
        public void TestTrapezoidConstructorAngles()
        {
            Trapezoid trap = new Trapezoid(8, 4, 2);
            Assert.AreEqual(45, trap.AcuteAngle);
            Assert.AreEqual(135, trap.ObtuseAngle);
        }

        [TestMethod]
        public void TestTrapezoidConstructorAngles2()
        {
            Trapezoid trap = new Trapezoid(20, 15, 2);
            Assert.AreEqual((decimal)38.66, trap.AcuteAngle);
            Assert.AreEqual((decimal)141.34, trap.ObtuseAngle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidConstructorSanityCheckBaseOne()
        {
            Trapezoid trap = new Trapezoid(0, 50, 40);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidConstructorSanityCheckBaseTwo()
        {
            Trapezoid trap = new Trapezoid(50, 0, 40);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidConstructorSanityCheckHeight()
        {
            Trapezoid trap = new Trapezoid(50, 0, 40);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidConstructorSanityCheckNegativeParam()
        {
            Trapezoid trap = new Trapezoid(40, -50, 20);

        }


        [TestMethod]
        public void TrapezoidTestScale200Percent()
        {
            Trapezoid trap = new Trapezoid(10, 15, 20);
            trap.Scale(200);
            Assert.AreEqual(20, trap.Base1);
            Assert.AreEqual(30, trap.Base2);
            Assert.AreEqual(40, trap.Height);
        }

        [TestMethod]
        public void TrapezoidTestScale150Percent()
        {
            Trapezoid trap = new Trapezoid(10, 15, 20);
            trap.Scale(150);
            Assert.AreEqual((decimal)15, trap.Base1);
            Assert.AreEqual((decimal)22.5, trap.Base2);
            Assert.AreEqual((decimal)30, trap.Height);
        }

        [TestMethod]
        public void TrapezoidTestScale100Percent()
        {
            Trapezoid trap = new Trapezoid(10, 15, 20);
            trap.Scale(100);
            Assert.AreEqual(10, trap.Base1);
            Assert.AreEqual(15, trap.Base2);
            Assert.AreEqual(20, trap.Height);
        }

        [TestMethod]
        public void TrapezoidTestScale37Percent()
        {
            Trapezoid trap = new Trapezoid(10, 15, 20);
            trap.Scale(37);
            Assert.AreEqual((decimal)3.7, trap.Base1);
            Assert.AreEqual((decimal)5.55, trap.Base2);
            Assert.AreEqual((decimal)7.4, trap.Height);
        }

        [TestMethod]
        public void TrapezoidTestScaleUpAndDown()
        {
            Trapezoid trap = new Trapezoid(10, 15, 20);
            trap.Scale(50);
            trap.Scale(200);
            Assert.AreEqual((decimal)10, trap.Base1);
            Assert.AreEqual((decimal)15, trap.Base2);
            Assert.AreEqual((decimal)20, trap.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TrapezoidTestScale0Percent()
        {
            Trapezoid trap = new Trapezoid(10, 15, 20);
            trap.Scale(0);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TrapezoidTestScaleNegativePercent()
        {
            Trapezoid trap = new Trapezoid(10, 15, 20);
            trap.Scale(-10);
        }

        [TestMethod]
        public void TestTrapezoidDefaultBorderColor()
        {
            Trapezoid trap = new Trapezoid(10, 15, 20);
            Assert.AreEqual(System.Drawing.Color.Bisque, trap.BorderColor);
            Assert.AreEqual(System.Drawing.Color.Tomato, trap.FillColor);
        }

        [TestMethod]
        public void TestSidesCount()
        {
            Trapezoid trap = new Trapezoid(10, 40, 20);
            Assert.AreEqual(4, trap.SidesCount);
        }

        [TestMethod]
        public void TestTrapezoidArea()
        {
            Trapezoid trap = new Trapezoid(1, 5, 10);
            Assert.AreEqual(30, trap.Area());
        }

        [TestMethod]
        public void TestBiggerTrapezoidArea()
        {
            Trapezoid trap = new Trapezoid(20, 30, 20);
            Assert.AreEqual(500, trap.Area());
        }

        [TestMethod]
        public void TestTrapezoidPerimeter()
        {
            Trapezoid trap = new Trapezoid(8, 2, 4);
            Assert.AreEqual(20, trap.Perimeter());
        }

        [TestMethod]
        public void TestBiggerTrapezoidPerimeter()
        {
            Trapezoid trap = new Trapezoid(20, 15, 10);
            Assert.AreEqual((decimal)55.62, trap.Perimeter());
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentException))]
        public void CheckForEqualBaseAndHeight()
        {
            Trapezoid trap = new Trapezoid(20, 20, 30);
        }
    }
}
