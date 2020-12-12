using System;

namespace part1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TestMatrixCorrectInit();
            TestMatrixInitWithEmptyArray();
            TestMatrixInitWithAnotherMatrix();
            TestMatrixInitWithIncorrectJuggedArray();
            TestMatrixInitWithCorrectJuggedArray();
            TestMatrixInitWithIncorrectStringArray();
            TestMatrixInitWithCorrectStringArray();
            TestMatrixInitWithIncorrectString();
            TestMatrixInitWithCorrectString();
            TestMatrixInitWithAnotherMatrixToStringMethod();
            TestAddMatrix();
            TestMultiplyMatrix();
            TestTransposeMe();
        }

        private static void TestMatrixCorrectInit()
        {
            try
            {
                double[,] arr = {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
                MyMatrix matrix = new MyMatrix(arr);
            }
            catch (MyMatrixException ex)
            {
                Console.WriteLine("TestMatrixCorrectInit FAILED");
                return;
            }

            Console.WriteLine("TestMatrixCorrectInit PASSED");
        }

        private static void TestMatrixInitWithEmptyArray()
        {
            try
            {
                double[,] arr = { };
                MyMatrix matrix = new MyMatrix(arr);
            }
            catch (MyMatrixException ex)
            {
                Console.WriteLine("TestMatrixInitWithEmptyArray PASSED");
                return;
            }

            Console.WriteLine("TestMatrixInitWithEmptyArray FAILED");
        }

        private static void TestMatrixInitWithAnotherMatrix()
        {
            double[,] arr = {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
            MyMatrix matrix = new MyMatrix(arr);
            MyMatrix newMatrix = new MyMatrix(matrix);

            matrix[1, 1] = 13;
            
            Console.WriteLine(newMatrix);


            if (matrix.GetHeight() == newMatrix.GetHeight() && matrix.GetWidth() == newMatrix.GetWidth())
            {
                Console.WriteLine("TestMatrixInitWithAnotherMatrix PASSED");
            }
            else
            {
                Console.WriteLine("TestMatrixInitWithAnotherMatrix FAILED");
            }
        }

        private static void TestMatrixInitWithIncorrectJuggedArray()
        {
            try
            {
                double[][] arr = new double[2][];
                arr[0] = new[] {1.2, 2, 34};
                arr[1] = new[] {1.2, 2, 2, 2, 4, 3, 2};
                MyMatrix matrix = new MyMatrix(arr);
            }
            catch (MyMatrixException ex)
            {
                Console.WriteLine("TestMatrixInitWithIncorrectJuggedArray PASSED");
                return;
            }

            Console.WriteLine("TestMatrixInitWithIncorrectJuggedArray FAILED");
        }

        private static void TestMatrixInitWithCorrectJuggedArray()
        {
            try
            {
                double[][] arr = new double[2][];
                arr[0] = new[] {1.2, 2, 34};
                arr[1] = new[] {1.2, 2, 2};
                MyMatrix matrix = new MyMatrix(arr);
            }
            catch (MyMatrixException ex)
            {
                Console.WriteLine("TestMatrixInitWithCorrectJuggedArray FAILED");
                return;
            }

            Console.WriteLine("TestMatrixInitWithCorrectJuggedArray PASSED");
        }

        private static void TestMatrixInitWithIncorrectStringArray()
        {
            try
            {
                String[] arr = new[] {"1\t2\t3\t4", "5\t6\t7\t8,0\t3"};
                MyMatrix matrix = new MyMatrix(arr);
            }
            catch (MyMatrixException ex)
            {
                Console.WriteLine("TestMatrixInitWithIncorrectStringArray PASSED");
                return;
            }

            Console.WriteLine("TestMatrixInitWithIncorrectStringArray FAILED");
        }

        private static void TestMatrixInitWithCorrectStringArray()
        {
            try
            {
                String[] arr = new[] {"1\t2\t3\t4,12\t-20", "5\t6\t7\t8,0\t3"};
                MyMatrix matrix = new MyMatrix(arr);
            }
            catch (MyMatrixException ex)
            {
                Console.WriteLine("TestMatrixInitWithCorrectStringArray FAILED");
                return;
            }

            Console.WriteLine("TestMatrixInitWithCorrectStringArray PASSED");
        }

        private static void TestMatrixInitWithIncorrectString()
        {
            try
            {
                String str = "3\t4\t5\n3\t4\t5\t6";
                MyMatrix matrix = new MyMatrix(str);
            }
            catch (MyMatrixException ex)
            {
                Console.WriteLine("TestMatrixInitWithIncorrectString PASSED");
                return;
            }

            Console.WriteLine("TestMatrixInitWithIncorrectString FAILED");
        }

        private static void TestMatrixInitWithCorrectString()
        {
            try
            {
                String str = "3\t4\t5\n3\t4\t5";
                MyMatrix matrix = new MyMatrix(str);
            }
            catch (MyMatrixException ex)
            {
                Console.WriteLine("TestMatrixInitWithCorrectString FAILED");
                return;
            }

            Console.WriteLine("TestMatrixInitWithCorrectString PASSED");
        }

        private static void TestMatrixInitWithAnotherMatrixToStringMethod()
        {
            try
            {
                MyMatrix matrix = new MyMatrix(new double[,] {{4, 2, 3}, {4, 5, 6}});
                MyMatrix newMatrix = new MyMatrix(matrix.ToString());
                if (newMatrix.ToString().Equals(matrix.ToString()))
                {
                    Console.WriteLine("TestMatrixInitWithAnotherMatrixToStringMethod PASSED");
                }
                else
                {
                    Console.WriteLine("TestMatrixInitWithAnotherMatrixToStringMethod FAILED");
                }
            }
            catch (MyMatrixException ex)
            {
                Console.WriteLine("TestMatrixInitWithAnotherMatrixToStringMethod FAILED");
            }
        }

        private static void TestAddMatrix()
        {
            MyMatrix matrix1 = new MyMatrix(new double[,] {{4, 2, 3}, {4, 5, 6}});
            MyMatrix matrix2 = new MyMatrix(new double[,] {{1, 3, 5}, {2, 7, 10}});
            MyMatrix matrix3 = matrix1 + matrix2;
            bool isFailed = false;

            for (int i = 0; i < matrix1.GetHeight(); i++)
            {
                if (isFailed)
                {
                    break;
                }

                for (int j = 0; j < matrix1.GetWidth(); j++)
                {
                    if (!IsTwoDoubleEqual(matrix3[i, j], matrix1[i, j] + matrix2[i, j]))
                    {
                        isFailed = true;
                        break;
                    }
                }
            }

            if (isFailed)
            {
                Console.WriteLine("TestAddSameMatrix FAILED");
            }
            else
            {
                Console.WriteLine("TestAddSameMatrix PASSED");
            }
        }
        
        private static void TestMultiplyMatrix()
        {
            MyMatrix matrix1 = new MyMatrix(new double[,] {{4, 2}, {4, 5}});
            MyMatrix matrix2 = new MyMatrix(new double[,] {{1, 3, 5}, {2, 7, 10}});
            MyMatrix matrix3 = matrix1 * matrix2;
            MyMatrix result = new MyMatrix(new double[,]{{8,26,40},{14,47,70}});
            if (matrix3.ToString().Equals(result.ToString()))
            {
                Console.WriteLine("TestMultiplyMatrix PASSED");
            }
            else
            {
                Console.WriteLine("TestMultiplyMatrix FAILED");
            }
        }

        private static void TestTransposeMe()
        {
            MyMatrix actual = new MyMatrix(new double[,]{{1,2},{3,4}}).TransposeMe();
            MyMatrix expected = new MyMatrix(new double[,]{{1,3},{2,4}});

            if (actual.ToString().Equals(expected.ToString()))
            {
                Console.WriteLine("TestTransposeMe PASSED");
            }
            else
            {
                Console.WriteLine("TestTransposeMe FAILED");
            }
        }

        private static bool IsTwoDoubleEqual(double a, double b)
        {
            return Math.Abs(a - b) < 0.001;
        }
    }
}