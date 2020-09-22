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
                i++;
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
    }
}