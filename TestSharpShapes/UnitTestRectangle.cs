using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpShapes;

namespace TestSharpShapes
{
    [TestClass]
    public class UnitTestRectangle
    {
        [TestMethod]
        public void TestRectangleConstructor()
        {
            Rectangle rectangle = new Rectangle(40, 50);
            Assert.AreEqual(40, rectangle.Width);
            Assert.AreEqual(50, rectangle.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRectangleConstructorSanityCheckWidth()
        {
            Rectangle rectangle = new Rectangle(0, 50);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRectangleConstructorSanityCheckHeight()
        {
            Rectangle rectangle = new Rectangle(50, 0);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRectangleConstructorSanityCheckNegativeHeight()
        {
            Rectangle rectangle = new Rectangle(40, -50);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRectangleConstructorSanityCheckNegativeWidth()
        {
            Rectangle rectangle = new Rectangle(-40, 50);

        }

        [TestMethod]
        public void RectangleTestScale200Percent()
        {
            Rectangle rectangle = new Rectangle(10, 15);
            rectangle.Scale(200);
            Assert.AreEqual(20, rectangle.Width);
            Assert.AreEqual(30, rectangle.Height);
        }

        [TestMethod]
        public void RectangleTestScale150Percent()
        {
            Rectangle rectangle = new Rectangle(10, 15);
            rectangle.Scale(150);
            Assert.AreEqual((decimal) 15, rectangle.Width);
            Assert.AreEqual((decimal) 22.5, rectangle.Height);
        }

        [TestMethod]
        public void RectangleTestScale100Percent()
        {
            Rectangle rectangle = new Rectangle(10, 15);
            rectangle.Scale(100);
            Assert.AreEqual(10, rectangle.Width);
            Assert.AreEqual(15, rectangle.Height);
        }

        [TestMethod]
        public void RectangleTestScale37Percent()
        {
            Rectangle rectangle = new Rectangle(10, 15);
            rectangle.Scale(37);
            Assert.AreEqual((decimal) 3.7, rectangle.Width);
            Assert.AreEqual((decimal) 5.55, rectangle.Height);
        }

        [TestMethod]
        public void RectangleTestScaleUpAndDown()
        {
            Rectangle rectangle = new Rectangle(10, 15);
            rectangle.Scale(50);
            rectangle.Scale(200);
            Assert.AreEqual((decimal)10, rectangle.Width);
            Assert.AreEqual((decimal)15, rectangle.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RectangleTestScale0Percent()
        {
            Rectangle rectangle = new Rectangle(10, 15);
            rectangle.Scale(0);
           
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RectangleTestScaleNegativePercent()
        {
            Rectangle rectangle = new Rectangle(10, 15);
            rectangle.Scale(-10);
        }

        [TestMethod]
        public void TestRectangleDefaultBorderColor()
        {
            Rectangle rectangle = new Rectangle(10, 15);
            Assert.AreEqual(System.Drawing.Color.Bisque, rectangle.BorderColor);
            Assert.AreEqual(System.Drawing.Color.Tomato, rectangle.FillColor);
        }

        [TestMethod]
        public void TestSidesCount()
        {
            Rectangle rectangle = new Rectangle(10, 40);
            Assert.AreEqual(4, rectangle.SidesCount);
        }

        [TestMethod]
        public void TestRectangleArea()
        {
            Rectangle rectangle = new Rectangle(1, 5);
            Assert.AreEqual(5, rectangle.Area());
        }

        [TestMethod]
        public void TestBiggerRectangleArea()
        {
            Rectangle rectangle = new Rectangle(10, 100);
            Assert.AreEqual(1000, rectangle.Area());
        }

        [TestMethod]
        public void TestRectanglePerimeter()
        {
            Rectangle rectangle = new Rectangle(1, 5);
            Assert.AreEqual(12, rectangle.Perimeter());
        }

        [TestMethod]
        public void TestBiggerRectanglePerimeter()
        {
            Rectangle rectangle = new Rectangle(10, 100);
            Assert.AreEqual(220, rectangle.Perimeter());
        }
    }
}
