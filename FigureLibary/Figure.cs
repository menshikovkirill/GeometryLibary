using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLibary
{
    //для облегчения просмотра все классы храню в одном файле

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        //
        public double DistanceTo(Point point)
        {
            return Math.Sqrt((X - point.X) * (X - point.X) + (Y - point.Y) * (Y - point.Y));
        }
    }
    public interface IFigure
    {
        double Area { get; } // площадь фигуры
    }

    public class  Circle : IFigure
    {
        private double radius;
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value > 0)
                    radius = value;
                else
                    throw new ArgumentException();
            }
        }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double Area => Math.PI * Radius * Radius;
    }
    public class Triangle : IFigure
    {
        public Point point1, point2, point3;
        public double lengthA, lengthB, lengthC;
        public Triangle(Point point1, Point point2, Point point3)
        {
            lengthA = point1.DistanceTo(point2);
            lengthB = point1.DistanceTo(point3);
            lengthC = point2.DistanceTo(point3);
            if (lengthA >= lengthB + lengthC || lengthB >= lengthA + lengthC || lengthC >= lengthA + lengthB) throw new ArgumentException();

            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
        }
        public Triangle(int x1, int y1, int x2, int y2, int x3, int y3) : this(new Point(x1, y1), new Point(x2, y2), new Point(x3, y3)) { }

        public double Area => 0.5 * Math.Abs((point2.X - point1.X) * (point3.Y - point1.Y) - (point3.X - point1.X) * (point2.Y - point1.Y));

        public bool IsTriagleOrthogonal()
        {
            return Math.Abs(lengthA * lengthA - lengthB * lengthB - lengthC * lengthC) < 10E-9 ||
                   Math.Abs(lengthB * lengthB - lengthA * lengthA - lengthC * lengthC) < 10E-9||
                   Math.Abs(lengthC * lengthC - lengthA * lengthA - lengthB * lengthB) < 10E-9;
        }
        
    }
    //Непонятно, что значит "Вычисление площади фигуры без знания типа фигуры". Могу предположить, что имеется ввиду то, что фигура определяется набором точек
    //тогда площадь можно вычислить по формуле Гаусса

    public class ArbitaryFigure : IFigure
    {
        public Point[] pointArray;
        public ArbitaryFigure(params Point[] pointArray)
        {
            this.pointArray = pointArray;
        }
        public double Area
        {
            get
            {
                double area = 0;
                for (int i = 0; i < pointArray.Length - 1; i++)
                    area += 0.5 * Math.Abs(pointArray[i].X * pointArray[i + 1].Y - pointArray[i + 1].X * pointArray[i].Y);
                return area;
            }
        }
    }

}
