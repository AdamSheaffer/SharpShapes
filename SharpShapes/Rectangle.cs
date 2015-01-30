using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
    public class Rectangle : Quadrilateral
    {

        public override decimal Area()
        {
            return this.Width * this.Height;
        }

        public override decimal Perimeter()
        {
            return (this.Width * 2) + (this.Height * 2);
        }

        private decimal width;
        public decimal Width 
        {
            get { return this.width; }   
        }

        private decimal height;
        public decimal Height 
        {
            get { return this.height; } 
        }

        public Rectangle(decimal width, decimal height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException();
            }
            this.width = width;
            this.height = height;
        }

        public override void Scale(int percent)
        {
            if (percent <= 0)
            {
                throw new ArgumentException();
            }
            this.width = this.Width * percent / 100;
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
            System.Windows.Point Point2 = new System.Windows.Point(x, y + (int)height);
            System.Windows.Point Point3 = new System.Windows.Point(x + (int)width, y + (int)height);
            System.Windows.Point Point4 = new System.Windows.Point(x + (int)width, y);
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
