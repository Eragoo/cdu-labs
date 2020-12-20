using System;
using System.IO;

namespace exceptions
{
    public class MyFileWriteException : IOException
    {
        public MyFileWriteException(string message) : base(message)
        {
        }
    }
}