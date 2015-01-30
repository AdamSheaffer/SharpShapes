using SharpShapes;
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

namespace GrapeShapes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulateClassList();
        }

        public static int ArgumentCountFor(string className)
        {
            Type classType = Assembly.GetAssembly(typeof(Shape)).GetTypes().Where(shapeType => shapeType.Name == className).First();
            ConstructorInfo classConstructor = classType.GetConstructors().First();
            return classConstructor.GetParameters().Length;
        }

        public static Shape InstantiateWithArguments(string className, object[] args)
        {
            Type classType = Type.GetType(className);
            ConstructorInfo classConstructor = classType.GetConstructors().First();
            return (Shape)classConstructor.Invoke(args);
        }

        private void PopulateClassList()
        {
            var classList = new List<string>();
            var shapeType = typeof(Shape);
            foreach (Type type in Assembly.GetAssembly(shapeType).GetTypes())
            {
                if (type.IsSubclassOf(shapeType) && !type.IsAbstract)
                {
                    classList.Add(type.Name);
                }
            }
            ShapeType.ItemsSource = classList;
        }

        private void ShapeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Enable/Disable Inputs based on the number of required arguments.
            string className = (String)ShapeType.SelectedValue;
            Argument1.Text = ArgumentCountFor(className).ToString();

            if (ArgumentCountFor(className) == 1)
            {
                Argument1.IsEnabled = true;
                Argument2.IsEnabled = false;
                Argument3.IsEnabled = false;
            }
            else if (ArgumentCountFor(className) == 2)
            {
                Argument1.IsEnabled = true;
                Argument2.IsEnabled = true;
                Argument3.IsEnabled = false;
            }
            else
            {
                Argument1.IsEnabled = true;
                Argument2.IsEnabled = true;
                Argument3.IsEnabled = true;
            }
        }
    }
}







//using System.Drawing;
//using SharpShapes;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;

//namespace GrapeShapes
//{
//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        public MainWindow()
//        {
//            InitializeComponent();
//            PopulateClassList();
//            DrawRectangle();
//            DrawSquare(1, 50, new Square(30));
//            Square square = new Square(200);
//            square.FillColor = System.Drawing.Color.Navy;
//            square.BorderColor = System.Drawing.Color.Fuchsia;
//            DrawSquare(59, 5, square);
//        }

//        private void PopulateClassList()
//        {
//            List<string> classList = new List<string>();
//            var shapeType = typeof(Shape);
//            foreach (Type type in Assembly.GetAssembly(shapeType).GetTypes())
//            {
//                if (type.IsSubclassOf(shapeType) && !type.IsAbstract)
//                {
//                    classList.Add(type.Name);
//                }
//            }
//            ShapeType.ItemsSource = classList;
//        }

//        private void DrawRectangle()
//        {
//            //Add the Polygon Element
//            System.Windows.Shapes.Polygon myPolygon = new System.Windows.Shapes.Polygon();
//            myPolygon.Stroke = System.Windows.Media.Brushes.Tomato;
//            myPolygon.Fill = System.Windows.Media.Brushes.Bisque;
//            myPolygon.StrokeThickness = 2;
//            //myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
//            //myPolygon.VerticalAlignment = VerticalAlignment.Center;
//            System.Windows.Point Point1 = new System.Windows.Point(1, 50);
//            System.Windows.Point Point2 = new System.Windows.Point(1, 80);
//            System.Windows.Point Point4 = new System.Windows.Point(50, 80);
//            System.Windows.Point Point3 = new System.Windows.Point(50, 50);
//            PointCollection myPointCollection = new PointCollection();
//            myPointCollection.Add(Point1);
//            myPointCollection.Add(Point2);
//            myPointCollection.Add(Point3);
//            myPointCollection.Add(Point4);
//            myPolygon.Points = myPointCollection;
//            ShapeCanvas.Children.Add(myPolygon);   
//        }
//        private void DrawSquare(int x, int y, Square square)
//        {
//            System.Windows.Shapes.Polygon myPolygon = new System.Windows.Shapes.Polygon();
//            int sideLength = (int) square.Height;

//            System.Drawing.Color myFillColor = square.FillColor;
//            System.Drawing.Color myBorderColor = square.BorderColor;

//            SolidColorBrush mediaFillColor = new SolidColorBrush();
//            mediaFillColor.Color = System.Windows.Media.Color.FromArgb(myFillColor.A, myFillColor.R, myFillColor.G, myFillColor.B);

//            SolidColorBrush mediaBorderColor = new SolidColorBrush();
//            mediaBorderColor.Color = System.Windows.Media.Color.FromArgb(myBorderColor.A, myBorderColor.R, myBorderColor.G, myBorderColor.B);

//            myPolygon.Stroke = mediaBorderColor;
//            myPolygon.Fill = mediaFillColor;
//            myPolygon.StrokeThickness = 2;
//            //myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
//            //myPolygon.VerticalAlignment = VerticalAlignment.Center;
//            System.Windows.Point Point1 = new System.Windows.Point(x, y);
//            System.Windows.Point Point2 = new System.Windows.Point(x, y + sideLength);
//            System.Windows.Point Point3 = new System.Windows.Point(x + sideLength, y + sideLength);
//            System.Windows.Point Point4 = new System.Windows.Point(x + sideLength, y);
//            PointCollection myPointCollection = new PointCollection();
//            myPointCollection.Add(Point1);
//            myPointCollection.Add(Point2);
//            myPointCollection.Add(Point3);
//            myPointCollection.Add(Point4);
//            myPolygon.Points = myPointCollection;
//            ShapeCanvas.Children.Add(myPolygon);
//        }
//    }
//}
