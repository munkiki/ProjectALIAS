using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HW9
{
    class Program
    {
        static void Main(string[] args)
        {
            Square Square1 = new Square();
            Square Square2 = new Square();
            Square Square3 = new Square();
            Square Square4 = new Square();
            Square Square5 = new Square();
            Circle Circle1 = new Circle();
            Circle Circle2 = new Circle();
            Circle Circle3 = new Circle();
            Circle Circle4 = new Circle();
            Circle Circle5 = new Circle();
            List<Shape> MyList = new List<Shape>();
            List<Shape> MyList2 = new List<Shape>();
            List<Shape> MyListSquares = new List<Shape>();
            List<Shape> MyListCircles = new List<Shape>();
            MyListSquares.Add(Square1);
            MyListSquares.Add(Square2);
            MyListSquares.Add(Square3);
            MyListSquares.Add(Square4);
            MyListSquares.Add(Square5);
            MyListCircles.Add(Circle1);
            MyListCircles.Add(Circle2);
            MyListCircles.Add(Circle3);
            MyListCircles.Add(Circle4);
            MyListCircles.Add(Circle5);
            foreach (Square x in MyListSquares)
            {
                Console.WriteLine("Please, enter the name of the square:");
                x.Name = Console.ReadLine();
                Console.WriteLine("Please, enter the side of the square:");
                x.side = double.Parse(Console.ReadLine());
                MyList.Add(x);
            }
            double medium = 0;
            string mediumStr = "";
            foreach (Circle x in MyListCircles)
            {
                Console.WriteLine("Please, enter the name of the circle:");
                x.Name = Console.ReadLine();
                Console.WriteLine("Please, enter the radius of the circle:");
                x.radius = double.Parse(Console.ReadLine());
                MyList.Add(x);
            }
            Console.WriteLine("The full list of figures:");
            Console.WriteLine("=========================");
            foreach (Shape x in MyList)
            {
                Console.WriteLine("The perimeter of the {2} is {0:F2} meters, the area is {1:F2} m*m.", x.Perimeter(), x.Area(), x.Name);
                if (x.Perimeter() > medium)
                {
                    medium = x.Perimeter();
                    mediumStr = x.Name;
                }
            }
            MyList.Sort();
            Console.WriteLine("The sorted list of figures:");
            Console.WriteLine("===========================");
            foreach (Shape x in MyList)
            {
                Console.WriteLine("The perimeter of the {2} is {0:F2} meters, the area is {1:F2} m*m.", x.Perimeter(), x.Area(), x.Name);
            }
            Console.WriteLine("=====================================================================");
            Console.WriteLine("The figure with the biggest perimeter ({0:F2} m) is {1}.", medium, mediumStr);
            Console.WriteLine("=====================================================================");
            Console.WriteLine("Figures with area in [10;100] m*m.");
            var SelectByArea = from i in MyList
                               where (i.Area() >= 10 && i.Area() <= 100)
                               select i;
            foreach(var x in SelectByArea)
            {
                Console.WriteLine("Figure {0} has area of {1:F2} m*m.", x.Name, x.Area());
            }
            Console.WriteLine("=====================================================================");
            Console.WriteLine("Figures with latter A in the name:");
            string namePattern = @"[aA]+";
            foreach (Shape x in MyList)
            {
                Match aResult = Regex.Match(x.Name, namePattern);
                if (aResult.Success)
                Console.WriteLine("Figure {0} has A in name.", x.Name);
            }
            Console.WriteLine("=====================================================================");
            Console.WriteLine("Figures with perimeter > 5m:");
            foreach (Shape x in MyList)
            {
                if (x.Perimeter() >= 5) MyList2.Add(x);
            }
            foreach (Shape x in MyList2)
            {
                Console.WriteLine("Figure {0} has perimeter {1:F2} m.", x.Name, x.Perimeter());
            }
            Console.ReadLine();
        }
    }
    abstract public class Shape : IComparable<Shape>
    {
        public string Name;
        public abstract double Area();
        public abstract double Perimeter();
        public int CompareTo(Shape other)
        {
            if (Area() < other.Area())
            return -1;
            else if (Area() == other.Area())
            return 0;
            else 
            return 1;
        }
    }
    public class Circle : Shape
    {
        public double radius;
        public override double Area()
        {
            double x = Math.PI*radius*radius;
            return x;
        }
        public override double Perimeter()
        {
            double x = 2 * Math.PI * radius;
            return x;
        }
    }
    public class Square : Shape
    {
        public double side;
        public override double Area()
        {
            double x = side * side;
            return x;
        }
        public override double Perimeter()
        {
            double x = 4 * side;
            return x;
        }
    }
}
