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
            Type classType = GetShapeTypeOf(className);
            ConstructorInfo classConstructor = classType.GetConstructors().First();
            return classConstructor.GetParameters().Length;
        }

        private static Type GetShapeTypeOf(string className)
        {
            Type classType = Assembly.GetAssembly(typeof(Shape)).GetTypes().Where(shapeType => shapeType.Name == className).First();
            return classType;
        }

        public static Shape InstantiateWithArguments(string className, object[] args)
        {
            Type classType = GetShapeTypeOf(className);
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

            Argument1.IsEnabled = true;
            Argument2.IsEnabled = ArgumentCountFor(className) > 1;
            Argument3.IsEnabled = ArgumentCountFor(className) > 2;
            Argument1.Text = "0";
            Argument2.Text = "0";
            Argument3.Text = "0";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string className = (String)ShapeType.SelectedValue;
            object[] potentialArgs = new object[] {Decimal.Parse(Argument1.Text), Decimal.Parse(Argument2.Text), Decimal.Parse(Argument3.Text)};
            int numOfArgs = ArgumentCountFor(className);
            Shape shape = InstantiateWithArguments(className, potentialArgs.Take(numOfArgs).ToArray());
             
            shape.DrawOnCanvas(ShapeCanvas, 100, 100);
        }
    }
}