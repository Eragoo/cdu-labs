using System;
using System.Security.Policy;

namespace part2
{
//    Створити клас-нащадок TRPiramid (прямокутна трикутна піраміда, у якій бічне ребро
//    перпендикулярне до катетів і опускається у прямий кут трикутника) на основі класу
//    TRTriangle. Додати поле висоти піраміди, метод знаходження об’єму піраміди та
//    перевизначити відповідні методи.

    public class TRPiramid : TRTriangle
    {
        protected double h;

        public TRPiramid(double a, double b, double c, double h) : base(a, b, c)
        {
            if (h > 0)
            {
                this.h = h;
            }
            else
            {
                throw new Exception("Height must be greater than 0");
            }
        }

        public new double GetArea()
        {
            double baseS = base.GetArea();
            return 1.0 / 3.0 * baseS * h;
        }

        public override string ToString()
        {
            return "TRPyramid : {a = " + a + "; b = " + b + "; c = " + c + "; h = " + h + "}";
        }

        private static bool IsDoubleEquals(double actual, double expected)
        {
            return Math.Abs(actual - expected) < 0.001;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            TRPiramid p = (TRPiramid) obj;

            if (IsDoubleEquals(a, p.a) &&
                IsDoubleEquals(b, p.b) &&
                IsDoubleEquals(c, p.c) &&
                IsDoubleEquals(h, p.h))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return h.GetHashCode() + a.GetHashCode() + b.GetHashCode() +  c.GetHashCode();
        }
        
        
        
    }
}