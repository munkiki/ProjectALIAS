using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12
{
    class Program
    {
        static void Main(string[] args)
        {
            Point zero = new Point(0, 0);
            Point maxPoint = new Point(1000, 1000);
            Point Point1 = new Point(5, 8);
            Point Point2 = new Point(10, 70);
            Point Point3 = new Point(15, 40);
            Point Point4 = new Point(31, 99);
            Point Point5 = new Point(1, 2);
            Point Point6 = new Point(0, 8);
            Point Point7 = new Point(1, 5);
            Point Point8 = new Point(43, 17);
            Point Point9 = new Point(2, 6);
            Triangle triangle1 = new Triangle(Point1, Point2, Point3);
            Triangle triangle2 = new Triangle(Point4, Point5, Point6);
            Triangle triangle3 = new Triangle(Point7, Point8, Point9);
            Triangle triangleMedium = new Triangle(maxPoint, maxPoint, maxPoint);
            triangle1.Print();
            triangle2.Print();
            triangle3.Print();
            List<Triangle> triangleList = new List<Triangle>();
            triangleList.Add(triangle1);
            triangleList.Add(triangle2);
            triangleList.Add(triangle3);
            Console.WriteLine(triangleMedium.DistanceTo(zero));
            foreach (Triangle tr in triangleList)
            {
                Console.WriteLine("Distance to (0,0) is: {0:F2}", tr.DistanceTo(zero));
                if (tr.DistanceTo(zero) < triangleMedium.DistanceTo(zero))
                {
                    triangleMedium = tr;
                }
            }
            Console.WriteLine("The triangle closest to the beginning of coordinates is:");
            triangleMedium.Print();
            Console.ReadLine();
        }
        public struct Point
        {
            int x;
            int y;
            public Point(int x1, int y1)
            {
                x = x1;
                y = y1;
            }
            public double Distance(Point anotherPoint)
            {
                double distanceBetweenPoints = Math.Sqrt((this.x - anotherPoint.x) * (this.x - anotherPoint.x) + (this.y - anotherPoint.y) * (this.y - anotherPoint.y));
                return distanceBetweenPoints;
            }
            public string ShowCoordinates()
            {
                string coordinates = "(" + x + "," + y + ")";
                return coordinates;
            }
        }
        public class Triangle
        {
            private Point p1, p2, p3;
            public Triangle(Point A, Point B, Point C)
            {
                p1 = A;
                p2 = B;
                p3 = C;
            }
            public double Perimeter()
            {
                double PerimeterValue = p1.Distance(p2) + p2.Distance(p3) + p3.Distance(p1);
                return PerimeterValue;
            }
            public double Square()
            {
                double squareValue = Math.Sqrt(Perimeter() / 2 * (Perimeter() / 2 - p1.Distance(p2)) * (Perimeter() / 2 - p2.Distance(p3)) * (Perimeter() / 2 - p3.Distance(p1)));
                return squareValue;
            }
            public double DistanceTo(Point p)
            {
                double distanceValue = double.MaxValue;
                if (p1.Distance(p) < distanceValue)
                {
                    distanceValue = p1.Distance(p);
                }
                if (p2.Distance(p) < distanceValue)
                {
                    distanceValue = p2.Distance(p);
                }
                if (p3.Distance(p) < distanceValue)
                {
                    distanceValue = p3.Distance(p);
                }
                return distanceValue;
            }
            public void Print()
            {
                Console.WriteLine("Points of the triangle: A{0}, B{1}, C{2}.", p1.ShowCoordinates(), p2.ShowCoordinates(), p3.ShowCoordinates());
            }
        }
    }
}