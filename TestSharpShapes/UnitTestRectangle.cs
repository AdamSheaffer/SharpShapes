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
        [ExpectedException(typeof(ArgumentException))]
        public void TestRectangleConstructorWithNoArgs()
        {
            Rectangle rectangle = new Rectangle();
        }
    }
}
