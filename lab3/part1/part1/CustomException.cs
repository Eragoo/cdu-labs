using System;

namespace part1
{
    public class CustomException : Exception
    {
        public CustomException(string msg): base(msg)
        {}
    }
}