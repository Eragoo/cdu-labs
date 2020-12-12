using System;
using System.Numerics;
using Complex = interfaces.Properties.Complex;

namespace interfaces
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            testAPlusBSquare(new Frac(1, 3), new Frac(1, 6));
            testAPlusBSquare(new Complex(1, 3), new Complex(1, 6));
            Console.WriteLine("########################################################");
            testSquaresDifference(new Frac(1, 3), new Frac(1, 6));
            testSquaresDifference(new Complex(1, 3), new Complex(1, 6));
            Console.WriteLine("########################################################");
            ComparatorTest();
        }

        static void ComparatorTest()
        {
            int num = 5;
            Frac[] fracs = new Frac[num];
            for (int i = 0; i < num; i++)
            {
                Random random = new Random();
                BigInteger nom = BigInteger.Parse(random.Next(-10, 10).ToString());
                BigInteger denom = BigInteger.Parse(random.Next(-10, 10).ToString());
                fracs[i] = new Frac(nom, denom);
            }
            
            Array.Sort(fracs);
            foreach (var frac in fracs)
            {
                Console.WriteLine(frac);
            }
        }
        static void testAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aPlusB = a.Add(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a + b) = " + aPlusB);
            Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
            Console.WriteLine(" = = = ");
            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = a.Multiply(b); // ab
            curr = curr.Add(curr); // ab + ab = 2ab
            // I’m not sure how to create constant factor "2" in more elegant way,
            // without knowing how IMyNumber is implemented
            Console.WriteLine("2*a*b = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        }

        static void testSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a-b)=(a^2-b^2)/a+b with a = " + a + ", b = " + b + " ===");
            T aSubB = a.Subtract(b);// a - b
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a - b) = " + aSubB);
            Console.WriteLine(" = = = ");
            T aPow = a.Multiply(a); // a^2
            T bPow = b.Multiply(b); // b^2
            T difAPowBPow = aPow.Subtract(bPow);
            Console.WriteLine("a^2-b^2 = " + difAPowBPow);
            T denom = a.Add(b);
            T total = difAPowBPow.Divide(denom);
            Console.WriteLine("(a^2-b^2)/a+b = " + total);
            Console.WriteLine("=== Finishing testing (a-b)=(a^2-b^2)/a+b with a = " + a + ", b = " + b + " ===");
        }
    }
}