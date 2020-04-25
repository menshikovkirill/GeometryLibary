using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FigureLibary;
namespace UnitTestFigureLibary
{
    [TestClass]
    public class UnitTest1
    {
        void CirlceTest(double radius)
        {
            var circle = new Circle(radius);
            Assert.AreEqual(circle.Area, Math.PI * radius*radius);
        }
        [TestMethod]
        public void CheckAreaCircle()
        {
            var radius = (new Random()).NextDouble() *10;
            var circle = new Circle(radius);
            Assert.AreEqual(circle.Area, Math.PI * radius * radius);
        }

        [TestMethod]
        public void CheckAreaTriangle()
        {
            var triagle = new Triangle(-1, 0, 0, 1, 1, 0);
            Assert.AreEqual(triagle.Area, 1);
        }
        [TestMethod]
        public void CheckTriangleOnOrthogonalFalse()
        {
            var triagle = new Triangle(0, 0, 0, 0, 5, 2);
            Assert.AreEqual(triagle.IsTriagleOrthogonal(), false);
        }
        [TestMethod]
        public void CheckTriangleOnOrthogonalTrue()
        {
            var triagle = new Triangle(0, 0, 1, 0, 0, 1);
            Assert.AreEqual(triagle.IsTriagleOrthogonal(), true);
        }
        [TestMethod]
        public void CheckAreaArbitaryFigure()
        {
            var figure = new ArbitaryFigure(new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(1, 0));
            Assert.AreEqual(figure.Area, 1);
        }
    }
}
