using System;

namespace part2
{
    //    Описати клас, який містять вказані поля і методи.
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
    public class TRTriangle : IComparable
    {
        protected double a;
        protected double b;
        protected double c;

        public TRTriangle()
        {
        }

        public TRTriangle(TRTriangle triangle)
        {
            a = triangle.a;
            b = triangle.b;
            c = triangle.c;
        }

        public TRTriangle(double a, double b, double c)
        {
            ValidateTriangleSides(a, b, c);
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double GetBasePerimeter()
        {
            return a + b + c;
        }

        public double GetArea()
        {
            double p = GetBasePerimeter() / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        private static void ValidateTriangleSides(double a, double b, double c)
        {
            if (a < 0 || b < 0 || c < 0)
            {
                throw new Exception("Side length must be greater than 0");
            }

            if (!IsDoubleEquals(Math.Pow(a, 2), Math.Pow(b, 2) + Math.Pow(c, 2)) &&
                !IsDoubleEquals(Math.Pow(b, 2), Math.Pow(a, 2) + Math.Pow(c, 2)) &&
                !IsDoubleEquals(Math.Pow(c, 2), Math.Pow(a, 2) + Math.Pow(b, 2))
            )
            {
                throw new Exception("Triangle with that sides cannot exist");
            }
        }

        public double GetA()
        {
            return a;
        }

        public double GetB()
        {
            return b;
        }

        public double GetC()
        {
            return c;
        }

        public void SetA(double a)
        {
            ValidateTriangleSides(a, b, c);
            this.a = a;
        }

        public void SetB(double b)
        {
            ValidateTriangleSides(a, b, c);
            this.b = b;
        }

        public void SetC(double c)
        {
            ValidateTriangleSides(a, b, c);
            this.c = c;
        }

        private static bool IsDoubleEquals(double a, double b)
        {
            return Math.Abs(a - b) < 0.001;
        }

        public override string ToString()
        {
            return "Triangle : a = " + a + " b = " + b + " c = " + c;
        }

        public int CompareTo(object obj)
        {
            TRTriangle a1 = (TRTriangle) obj;
            if (this == obj || IsDoubleEquals(a1.GetArea(), GetArea()))
            {
                return 0;
            }

            return a1.GetArea() > GetArea() ? -1 : 1;
        }

        public static TRTriangle operator *(TRTriangle triangle, double num)
        {
            return new TRTriangle(triangle.a * num,
                triangle.b * num,
                triangle.c * num);
        }

        public static TRTriangle operator *(double num, TRTriangle triangle)
        {
            return new TRTriangle(triangle.a * num,
                triangle.b * num,
                triangle.c * num);
        }
    }
}