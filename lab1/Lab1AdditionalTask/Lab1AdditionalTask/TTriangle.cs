using System;

namespace Additional
{
    public class TTriangle
    {
        private double a;
        private double b;
        private double c;

        public TTriangle(double a, double b, double c)
        {
            ValidateTriangleSides(a, b, c);
            this.a = a;
            this.b = b;
            this.c = c;
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

        public double GetPerimeter()
        {
            return a + b + c;
        }

        public double GetArea()
        {
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        
        private static void ValidateTriangleSides(double a, double b, double c)
        {
            if (a < 0 || b < 0 || c < 0)
            {
                throw new Exception("Side length must be greater than 0");
            }

            if (a > b + c || b > a + c || c > a + b)
            {
                throw new Exception("Triangle with that sides cannot exist");
            }
        }
    }
}