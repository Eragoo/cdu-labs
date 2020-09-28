using System;

namespace part2
{
    internal class Program
    {
        //Описати клас, який містять вказані поля і методи.
//        Клас “прямокутний трикутник ” – TRTriangle
//            Поля  для зберігання довжин катетів;
//        Методи  конструктор без параметрів, конструктор з параметрами, конструктор копіювання;
//
//        override public string ToString();
//        введення/виведення даних;
//        визначення площі;
//        визначення периметру;
//        порівняння з іншим трикутником (лише на рівність/нерівність);
//        перевантаження операторів * (множення сторін на деяке число; забезпечити, щоб
//        домноження могло відбуватися хоч як «число*трикутник», хоч як «трикутник*число»).
        public static void Main(string[] args)
        {
            TestInitIncorrectTriangle();
            TestAreaTriangle();
            TestInitCorrectTriangle();
            TestCompareEqualTriangles();
            TestMultiplyTriangles();
        }

        private static void TestInitIncorrectTriangle()
        {
            try
            {
                TRTriangle t = new TRTriangle(10, 2, 3);
            }
            catch (Exception e)
            {
                Console.WriteLine("TestInitIncorrectTriangle PASSED");
                return;
            }

            Console.WriteLine("TestInitIncorrectTriangle FAILED");
        }

        private static void TestInitCorrectTriangle()
        {
            try
            {
                TRTriangle t = new TRTriangle(3, 4, 5);
            }
            catch (Exception e)
            {
                Console.WriteLine("TestInitCorrectTriangle FAILED");
                return;
            }

            Console.WriteLine("TestInitCorrectTriangle PASSED");
        }

        private static void TestAreaTriangle()
        {
            TRTriangle t = new TRTriangle(3, 4, 5);
            double actual = t.GetArea();
            double expected = 6.0;
            if (IsDoubleEquals(actual, expected))
            {
                Console.WriteLine("TestAreaTriangle PASSED");
            }
            else
            {
                Console.WriteLine("TestAreaTriangle FAILED");
            }
        }

        private static bool IsDoubleEquals(double actual, double expected)
        {
            return Math.Abs(actual - expected) < 0.001;
        }

        private static void TestCompareEqualTriangles()
        {
            TRTriangle t1 = new TRTriangle(3, 4, 5);
            TRTriangle t2 = new TRTriangle(4, 3, 5);
            int comp = t1.CompareTo(t2);
            if (comp == 0)
            {
                Console.WriteLine("IsDoubleEquals PASSED");
            }
            else
            {
                Console.WriteLine("IsDoubleEquals FAILED");
            }
        }
        
        private static void TestMultiplyTriangles()
        {
            TRTriangle t1 = new TRTriangle(3, 4, 5);
            TRTriangle expected = new TRTriangle(6, 8, 10);
            TRTriangle actual = t1 * 2;
            if (IsDoubleEquals(actual.GetA(), expected.GetA()) &&
                IsDoubleEquals(actual.GetB(), expected.GetB()) &&
                IsDoubleEquals(actual.GetC(), expected.GetC()))
            {
                Console.WriteLine("TestMultiplyTriangles PASSED");
            }
            else
            {
                Console.WriteLine("TestMultiplyTriangles FAILED");
            }
        }    
    }
}