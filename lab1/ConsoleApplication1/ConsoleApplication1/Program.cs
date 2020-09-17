using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    //var5
    internal class Program
    {
        public static void Main(string[] args)
        {
            //В матриці C кількість стовпчиків у кожному рядку є
            //випадковим натуральним числом з інтервалу [a; b], але
            //загальна кількість елементів є квадратом натурального числа.
            //Переписати всі елементи з матриці C в одновимірний масив F, відсортувати
            //його за зростанням, після чого переписати його елементи у квадратну матрицю Q по рядках.
            Console.WriteLine("Введіть к-ть елементів в матриці (має бути квадратом натурального числа)");
            int n = Int32.Parse(Console.ReadLine());
            int sqrtFromN = ValidateNumberOfMatrixElements(n);

            Console.WriteLine("Введіть ліву границю інтервалу (має бути більше 0)");
            int a = Int32.Parse(Console.ReadLine());

            if (a < 1)
            {
                throw new Exception("Ліва границя має бути більше 0");
            }
            

            Console.WriteLine("Введіть праву границю інтервалу");
            int b = Int32.Parse(Console.ReadLine());

            if (b > n)
            {
                throw new Exception("Права границя має бути менше ніж загальна к-ть елементів'");
            }

            int[][] c = new int[16][];
            FillJaggedArray(n, a, b, ref c);
            Console.WriteLine("Матриця С:");
            PrintJaggedArray(c);

            int[] f = new int[n];
            PutJuggedArrayIntoArray(c, ref f);

            Console.WriteLine("Масив F:");
            PrintArray(f);

            Array.Sort(f);
            Console.WriteLine("Сортований масив F:");
            PrintArray(f);

            int[,] q = new int[sqrtFromN, sqrtFromN];
            PutArrayIntoMatrix(sqrtFromN, f, ref q);

            Console.WriteLine("Матриця Q:");
            PrintMatrix(sqrtFromN, sqrtFromN, q);
        }

        private static void PutArrayIntoMatrix(int sqrtFromN, int[] f, ref int[,] q)
        {
            int z = 0;
            for (int i = 0; i < sqrtFromN; i++)
            {
                for (int j = 0; j < sqrtFromN; j++)
                {
                    q[i, j] = f[z];
                    z++;
                }
            }
        }

        private static void PrintArray(int[] f)
        {
            foreach (int el in f)
            {
                Console.Write(el + "\t");
            }
            Console.WriteLine();
        }

        private static void PutJuggedArrayIntoArray(int[][] juggedArr, ref int[] arr)
        {
            int writtenEl = 0;
            foreach (int[] t in juggedArr)
            {
                Array.Copy(t, 0, arr, writtenEl, t.Length);
                writtenEl += t.Length;
            }
        }

        private static void PrintMatrix(int rows, int columns, int[,] c)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(c[i, j] + "\t");
                }

                Console.WriteLine();
            }
        }
        
        private static void PrintJaggedArray(int[][] c)
        {
            for (int i = 0; i < c.Length; i++)
            {
                for (int j = 0; j < c[i].Length; j++)
                {
                    Console.Write(c[i][j] + "\t");
                }

                Console.WriteLine();
            }
        }
        
        private static void FillJaggedArray(int totalElements, int leftRandomLimit, int rightRandomLimit, ref int[][] c)
        {
            int writtenEl = 0;
            int writtenRows;
            Random random = new Random();
            for (int i = 0;;i++)
            {
                int n;
                int[] arr;
                if (rightRandomLimit > totalElements - writtenEl)
                {
                    n = totalElements - writtenEl;
                    arr = new int[n];
                    RandomFillArray(leftRandomLimit, rightRandomLimit,ref arr);
                    ResizeIfNeeded(ref c, i);
                    c[i] = arr;
                    writtenRows = i + 1;
                    break;
                }

                n = random.Next(leftRandomLimit, rightRandomLimit);
                arr = new int[n];
                RandomFillArray(leftRandomLimit, rightRandomLimit,ref arr);

                writtenEl += arr.Length;
                ResizeIfNeeded(ref c, i);
                c[i] = arr;
            }

            Array.Resize(ref c, writtenRows);
        }

        private static void ResizeIfNeeded(ref int[][] c, int i)
        {
            if (c.Length <= i)
            {
                Array.Resize(ref c, c.Length * 2);
            }
        }

        private static void RandomFillArray(int leftRandomLimit, int rightRandomLimit, ref int[] arr)
        {
            Random random = new Random();
            for (int j = 0; j < arr.Length; j++)
            {
                arr[j] = random.Next(leftRandomLimit, rightRandomLimit);
            }
        }

        private static int ValidateNumberOfMatrixElements(int n)
        {
            double sqrt = Math.Sqrt(n);
            if (sqrt % 2 != 0 && sqrt % 3 != 0)
            {
                throw new Exception("К-ть елементів в матриці має бути квадратом натурального числа!");
            }

            return (int) sqrt;
        }
    }
}