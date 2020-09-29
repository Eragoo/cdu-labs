using System;

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
    }
}