﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpShapes;
using System.Drawing;
using System.Media;
using System.Windows.Controls;


namespace TestSharpShapes
{
    public class MyShape : Shape
    {
        public override void DrawOnCanvas(System.Windows.Controls.Canvas canvasName, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override decimal Area()
        {
            throw new NotImplementedException();
        }

        public override decimal Perimeter()
        {
            throw new NotImplementedException();
        }

        public override void Scale(int percent)
        {
            throw new NotImplementedException();
        }

        public override int SidesCount
        {
            get { throw new NotImplementedException(); }
        }
    }

    [TestClass]
    public class UnitTestShape
    {
        [TestMethod]
        public void TestSettingBorderColor()
        {
            Shape shape = new MyShape();
            shape.BorderColor = Color.AliceBlue;
            Assert.AreEqual(Color.AliceBlue, shape.BorderColor);
        }

        [TestMethod]
        public void TestSettingFillColor()
        {
            Shape shape = new MyShape();
            shape.FillColor = Color.AliceBlue;
            Assert.AreEqual(Color.AliceBlue, shape.FillColor);
        }

        [TestMethod]
        public void TestDefaultFillColor()
        {
            Shape shape = new MyShape();
            Assert.AreEqual(Color.Tomato, shape.FillColor);
        }

        [TestMethod]
        public void TestDefaultBorderColor()
        {
            Shape shape = new MyShape();
            Assert.AreEqual(Color.Bisque, shape.BorderColor);
        }
    }
}