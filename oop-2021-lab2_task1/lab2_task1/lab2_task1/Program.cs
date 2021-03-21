using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_task1
{
    class Program
    {
        public delegate void NumOperation(int i);

        private static Dictionary<string, NumOperation> d = new Dictionary<string, NumOperation>
        {
            {"0", (num) => Console.WriteLine(Math.Sqrt(num))},
            {"1", (num) => Console.WriteLine(Math.Pow(num, 3))},
            {"2", (num) => Console.WriteLine(num + 3.5)}
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Input data format: <0 x> or <1 x> or <2 x>");
            Console.WriteLine("Supported opetations: \n\t 0 - sqrt(abs(x)) \n\t 1 - x^3 \n\t 2 - x + 3,5 \n\t");
            
            while (true) {
                try {
                    string[] input = Console.ReadLine().Split(' ');
                    string opKey = input[0].Trim();
                    int value = Int32.Parse(input[1]);

                    d[opKey](value);
                } catch (Exception e) {
                    Console.WriteLine("Sorry, can't process input data :(");
                }
            }
        }
    }
}
