using System;

namespace part1
{
//        Реалізувати клас, що представляє трикутник (трикутник задається координатами
//        вершин) і містить опис індексатора для доступу до сторін трикутника( a – перша
//        сторона, b – друга сторона, c – третя сторона). Передбачити методи введення /
//        виведення, знаходження периметру та площі.
    public class Triangle
    {
        protected Point pointA;
        protected Point pointB;
        protected Point pointC;

        public Triangle(Point pointA, Point pointB, Point pointC)
        {
            ValidateTriangleSides(pointA, pointB, pointC);
            this.pointA = pointA;
            this.pointB = pointB;
            this.pointC = pointC;
        }

        private static double GetSideSize(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
        }

        private static void ValidateTriangleSides(Point A, Point B, Point C)
        {
            double a = GetSideSize(A, B);
            double b = GetSideSize(A, C);
            double c = GetSideSize(C, B);

            if (a < 0 || b < 0 || c < 0)
            {
                throw new Exception("Side length must be greater than 0");
            }

            if (a > b + c || b > a + c || c > a + b)
            {
                throw new CustomException("Triangle with that sides cannot exist");
            }
        }

        public double GetPerimeter()
        {
            double a = GetSideSize(pointA, pointB);
            double b = GetSideSize(pointA, pointC);
            double c = GetSideSize(pointB, pointC);
            return a + b + c;
        }

        public double GetArea()
        {
            return Math.Abs(pointA.X * (pointB.Y - pointC.Y) + pointB.X * (pointC.Y - pointA.Y) +
                            pointC.X * (pointA.Y - pointB.Y)) / 2;
        }
    }
}