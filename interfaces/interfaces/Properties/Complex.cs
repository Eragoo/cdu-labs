using System;
using System.Runtime.Remoting.Messaging;

namespace interfaces.Properties
{
    public class Complex : IMyNumber<Complex>
    {
        protected double re;
        protected double im;

        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public Complex Add(Complex that)
        {
            return new Complex(re + that.re, im + that.im);
        }

        public Complex Subtract(Complex that)
        {
            return new Complex(re - that.re, im - that.im);
        }

        public Complex Multiply(Complex that)
        {
            double newRe = re * that.re - im * that.im;
            double newIm = re * that.im + im * that.re;
            return new Complex(newRe, newIm);
        }

        public Complex Divide(Complex that)
        {
            double commonDenom = Math.Pow(that.re, 2) + Math.Pow(that.im, 2);
            if (Math.Abs(commonDenom) < 0.0001)
            {
                throw new DivideByZeroException("Division by zero occured!");
            }
            double newRe = (re * that.re + im * that.im) / commonDenom;
            double newIm = (im * that.re - re * that.im) / commonDenom;
            return new Complex(newRe, newIm);
        }

        public override string ToString()
        {
            return re + "+" + im + "i";
        }
    }
}