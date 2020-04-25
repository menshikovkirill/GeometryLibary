using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FigureLibary;
namespace Geometry1
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = 2;
            Console.WriteLine(Math.Sqrt(2) * Math.Sqrt(2) - 2 < 10E-16);
        }

        //возможно под "Вычисление площади фигуры без знания типа фигуры" имелось ввиду, что до вычисления площади мы не знаем, какая именно фигура придет на вход
        static double Area(IFigure figure)
        {
            return figure.Area;
        }
    }
}
