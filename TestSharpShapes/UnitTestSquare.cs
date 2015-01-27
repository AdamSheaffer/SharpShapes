using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpShapes;

namespace TestSharpShapes
{
    [TestClass]
    public class UnitTestSquare
    {
        [TestMethod]
        public void TestSquareConstructor()
        {
            Square square = new Square(40);
            Assert.AreEqual(40, square.Width);
            Assert.AreEqual(40, square.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSquareConstructorSanityCheckSize()
        {
            Square square = new Square(0);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSquareConstructorSanityCheckNegativeSize()
        {
            Square square = new Square(-50);

        }

        [TestMethod]
        public void SquareTestScale200Percent()
        {
            Square square = new Square(10);
            square.Scale(200);
            Assert.AreEqual(20, square.Width);
            Assert.AreEqual(20, square.Height);
        }

        [TestMethod]
        public void SquareTestScale150Percent()
        {
            Square square = new Square(10);
            square.Scale(150);
            Assert.AreEqual((decimal) 15, square.Width);
            Assert.AreEqual((decimal) 15, square.Height);
        }

        [TestMethod]
        public void SquareTestScale100Percent()
        {
            Square square = new Square(15);
            square.Scale(100);
            Assert.AreEqual(15, square.Width);
            Assert.AreEqual(15, square.Height);
        }

        [TestMethod]
        public void SquareTestScale37Percent()
        {
            Square square = new Square(10);
            square.Scale(37);
            Assert.AreEqual((decimal)3.7, square.Width);
            Assert.AreEqual((decimal)3.7, square.Height);
        }

        [TestMethod]
        public void SquareTestScaleUpAndDown()
        {
            Square square = new Square(10);
            square.Scale(25);
            square.Scale(200);
            Assert.AreEqual((decimal)5, square.Width);
            Assert.AreEqual((decimal)5, square.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SquareTestScale0Percent()
        {
            Square square = new Square(10);
            square.Scale(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SquareTestScaleNegativePercent()
        {
            Square square = new Square(10);
            square.Scale(-10);
        }

        [TestMethod]
        public void TestSquareDefaultBorderColor()
        {
            Square square = new Square(10);
            Assert.AreEqual(System.Drawing.Color.Bisque, square.BorderColor);
            Assert.AreEqual(System.Drawing.Color.Tomato, square.FillColor);
        }

        [TestMethod]
        public void TestSidesCount()
        {
            Square square = new Square(10);
            Assert.AreEqual(4, square.SidesCount);
        }

        [TestMethod]
        public void TestSquareArea()
        {
            Square square = new Square(5);
            Assert.AreEqual(25, square.Area());
        }

        [TestMethod]
        public void TestBiggerSquareArea()
        {
            Square square = new Square(100);
            Assert.AreEqual(10000, square.Area());
        }

        [TestMethod]
        public void TestSquarePerimeter()
        {
            Square square = new Square(5);
            Assert.AreEqual(20, square.Perimeter());
        }

        [TestMethod]
        public void TestBiggerSquarePerimeter()
        {
            Square square = new Square(100);
            Assert.AreEqual(400, square.Perimeter());
        }

    }
}
