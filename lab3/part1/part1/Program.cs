using System;

namespace part1
{
    internal class Program
    {//Кухоль Євгеній Валерійович — варіант 6 для блоку 1,  варіант 5 для блоку 2
//        Реалізувати клас, що представляє трикутник (трикутник задається координатами
//            вершин) і містить опис індексатора для доступу до сторін трикутника( a – перша
//            сторона, b – друга сторона, c – третя сторона). Передбачити методи введення /
//        виведення, знаходження периметру та площі.
        public static void Main(string[] args)
        {
            TestTriangleArea();
        }

        private static void TestTriangleArea()
        {
            Triangle a = new Triangle(new Point(1,0), new Point(2,2), new Point(0,1));
            double actual = a.GetArea();
            double expected = 1.5;
            if (isEquals(actual, expected))
            {
                Console.WriteLine("TestTriangleArea PASSED");
            }
            else
            {
                Console.WriteLine("TestTriangleArea FAILED");
            }
        }

        private static bool isEquals(double actual, double expected)
        {
            return Math.Abs(actual - expected) < 0.001;
        }
    }
}