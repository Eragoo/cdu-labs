using System;

namespace part1
{
    public class MyMatrixException : Exception
    {
        public MyMatrixException(string msg) : base(msg)
        {}
    }
}