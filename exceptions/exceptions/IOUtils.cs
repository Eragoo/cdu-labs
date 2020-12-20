using System;
using System.Drawing;
using System.IO;

namespace exceptions
{
    public class IOUtils
    {
        public static void AppendLineToFile(String filename, String line)
        {
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(line);
                sw.Flush();
                sw.Close();
            }
            catch (Exception e)
            {
                throw new MyFileWriteException("Error during writing to " + filename);
            }
        }
    }
}