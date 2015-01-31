using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace SharpShapes
{
    public class Trapezoid : Quadrilateral
    {
        private decimal base1;
        public decimal Base1
        {
            get { return base1; }
        }

        private decimal base2;
        public decimal Base2
        {
            get { return base2; }
        }

        private decimal height;
        public decimal Height
        {
            get { return height; }
        }

        public decimal AcuteAngle { get; private set; }

        public decimal ObtuseAngle { get; private set; }

        public Trapezoid(decimal base1, decimal base2, decimal height) 
        {
            if (base1 <= 0 || base2 <= 0 || height <= 0)
            {
                throw new ArgumentException();
            }

            this.base1 = base1;
            this.base2 = base2;
            this.height = height;

            decimal wingWidth = (Base1 - Base2) / 2;

            if (base1 == base2)
            {
                this.AcuteAngle = 90;
            }
            else
            {
                this.AcuteAngle = Decimal.Round((decimal)(Math.Atan((double)(Height / wingWidth)) * (180.0 / Math.PI)), 2);
            }        
            this.ObtuseAngle = 180 - this.AcuteAngle;
        }

        public override decimal Area()
        {
            return ((base1 + base2) / 2) * height;
        }

        private decimal WingLength()
        {
            return (base1 - base2) / 2;
        }

        public override decimal Perimeter()
        {
            double squares = (double)(WingLength() * WingLength() + Height * Height);
            decimal legLength = Decimal.Round((decimal)Math.Sqrt(squares), 2);
            return base1 + base2 + 2 * legLength;
        }

        public override void Scale(int percent)
        {
            if (percent <= 0)
            {
                throw new ArgumentException();
            }
            this.base1 = this.Base1 * percent / 100;
            this.base2 = this.Base2 * percent / 100;
            this.height = this.Height * percent / 100;
        }

        public override void DrawOnCanvas(System.Windows.Controls.Canvas canvasName, int x, int y)
        {
            System.Windows.Shapes.Polygon myPolygon = new System.Windows.Shapes.Polygon();

            System.Drawing.Color myFillColor = this.FillColor;
            System.Drawing.Color myBorderColor = this.BorderColor;

            SolidColorBrush mediaFillColor = new SolidColorBrush();
            mediaFillColor.Color = System.Windows.Media.Color.FromArgb(myFillColor.A, myFillColor.R, myFillColor.G, myFillColor.B);

            SolidColorBrush mediaBorderColor = new SolidColorBrush();
            mediaBorderColor.Color = System.Windows.Media.Color.FromArgb(myBorderColor.A, myBorderColor.R, myBorderColor.G, myBorderColor.B);

            myPolygon.Stroke = mediaBorderColor;
            myPolygon.Fill = mediaFillColor;
            myPolygon.StrokeThickness = 2;
            System.Windows.Point Point1 = new System.Windows.Point(x, y);
            System.Windows.Point Point2 = new System.Windows.Point(x + (int)base1, y);
            System.Windows.Point Point3 = new System.Windows.Point(x + (int)base1 - (int)WingLength(), y + (int)height);
            System.Windows.Point Point4 = new System.Windows.Point(x + (int)WingLength(), y + (int)height);
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPointCollection.Add(Point4);
            myPolygon.Points = myPointCollection;
            canvasName.Children.Add(myPolygon);
        }
    }
}
