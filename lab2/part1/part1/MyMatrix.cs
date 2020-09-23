using System;
using System.Text;

namespace part1
{
    public class MyMatrix
    {
        private double[,] elements;
        private int height;
        private int width;

        public MyMatrix(double[,] elements)
        {
            if (elements.Length > 0)
            {
                width = elements.GetLength(1);
                height = elements.Length / width;
                this.elements = elements;
            }
            else
            {
                throw new MyMatrixException("You cannot initialize matrix with empty array");
            }
        }

        public MyMatrix(string elements)
        {
            InitMatrixFromString(elements);
        }

        private void InitMatrixFromString(string elements)
        {
            String[] stringArr = elements.Split('\n');
            InitMatrixFromStringArray(stringArr);
        }

        public MyMatrix(double[][] elements)
        {
            InitMatrixFromJaggedArray(elements);
        }

        public MyMatrix(MyMatrix matrix)
        {
            elements = matrix.elements;
            width = matrix.width;
            height = matrix.height;
        }

        public MyMatrix(string[] elements)
        {
            InitMatrixFromStringArray(elements);
        }

        private void InitMatrixFromStringArray(string[] strings)
        {
            height = strings.Length;
            if (strings.Length > 0)
            {
                width = strings[0].Split('\t').Length;
                elements = new double[height, width];
            }
            else
            {
                throw new MyMatrixException("You cannot initialize matrix with empty array");
            }

            int prevLength = 0;
            for (int i = 0; i < strings.Length; i++)
            {
                string str = strings[i];
                double[] arr = Array.ConvertAll(str.Split('\t'), input => double.Parse(input.Trim()));
                int currLength = arr.Length;
                if (i > 0 && prevLength != currLength)
                {
                    elements = null;
                    width = 0;
                    height = 0;
                    throw new MyMatrixException("String array must contain equal number of elements in each line");
                }

                for (int j = 0; j < arr.Length; j++)
                {
                    elements[i, j] = arr[j];
                }

                prevLength = currLength;
            }
        }

        private void InitMatrixFromJaggedArray(double[][] elements)
        {
            height = elements.Length;
            width = elements.Length > 0 ? elements[0].Length : 0;
            this.elements = new double[height, width];

            for (int i = 0; i < elements.Length; i++)
            {
                double[] element = elements[i];
                int currLength = element.Length;
                int nextLength = i < elements.Length - 1 ? elements[i + 1].Length : currLength;

                if (i < elements.Length - 1 && currLength != nextLength)
                {
                    this.elements = null;
                    height = 0;
                    width = 0;
                    throw new MyMatrixException("Provided jagged array is not square");
                }

                for (int j = 0; j < element.Length; j++)
                {
                    this.elements[i, j] = element[j];
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    sb.Append(elements[i, j]);
                    if (j < width - 1)
                    {
                        sb.Append("\t");
                    }
                }

                if (i < height - 1)
                {
                    sb.Append("\n");
                }
            }

            return sb.ToString();
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }

        public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
        {
            AssertMatrixHaveSameSize(matrix1, matrix2);

            double[,] arr = new double[matrix1.height, matrix1.width];
            for (int i = 0; i < matrix2.height; i++)
            {
                for (int j = 0; j < matrix2.width; j++)
                {
                    arr[i, j] = matrix1.elements[i, j] + matrix2.elements[i, j];
                }
            }

            return new MyMatrix(arr);
        }

        private static void AssertMatrixHaveSameSize(MyMatrix matrix1, MyMatrix matrix2)
        {
            if (matrix1.height != matrix2.height && matrix1.width != matrix2.width)
            {
                throw new MyMatrixException("Matrix must have same size");
            }
        }

        public double[,] Elements => elements;

        public double GetElement(int i, int j)
        {
            return elements[i, j];
        }
        
        public void SetElement(int i, int j, double el)
        {
            elements[i, j] = el;
        }

        public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
        {
            if (matrix1.width != matrix2.height)
            {
                throw new MyMatrixException("Matrix1 height must be equal matrix2 width");
            }

            double[,] arr = new double[matrix1.height, matrix2.width];
            for (var i = 0; i < matrix1.height; i++)
            {
                for (var j = 0; j < matrix2.width; j++)
                {
                    arr[i, j] = 0;

                    for (var k = 0; k < matrix1.width; k++)
                    {
                        arr[i, j] += matrix1.elements[i, k] * matrix2.elements[k, j];
                    }
                }
            }
            return new MyMatrix(arr);
        }

        private double[,] GetTransposedArray()
        {
            double[,] arr = new double[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    arr[i, j] = elements[j, i];
                }
            }

            return arr;
        }

        public MyMatrix TransposeMe()
        {
            return new MyMatrix(GetTransposedArray());
        }
    }
}