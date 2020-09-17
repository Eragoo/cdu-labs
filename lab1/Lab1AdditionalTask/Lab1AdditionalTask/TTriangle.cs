using System;

namespace Additional
{
    public class TTriangle
    {
        private int a;
        private int b;
        private int c;

        public TTriangle(int a, int b, int c)
        {
            ValidateTriangleSides(a, b, c);
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public int GetA()
        {
            return a;
        }

        public int GetB()
        {
            return b;
        }
        
        public int GetC()
        {
            return c;
        }

        public void SetA(int a)
        {
            ValidateTriangleSides(a, b, c);
            this.a = a;
        }
        
        public void SetB(int b)
        {
            ValidateTriangleSides(a, b, c);
            this.b = b;
        }
        
        public void SetC(int c)
        {
            ValidateTriangleSides(a, b, c);
            this.c = c;
        }

        public long GetPerimeter()
        {
            return a + b + c;
        }

        public double GetArea()
        {
            long p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        
        private static void ValidateTriangleSides(int a, int b, int c)
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