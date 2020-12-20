using System;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace exceptions
{
    public class Part1
    {
        private const String NO_FILE = "no_file.txt";
        private const String BAD_DATA = "bad_data.txt";
        private const String OVERFLOW = "overflow.txt";
        public static void ProcessFiles()
        {
            for (int i = 10; i < 30; i++)
            {
                string filename = i + ".txt";
                //string filename = "/home/ykukhol/Documents/"+"11" + ".txt";
                try
                {
                    FileStream fs = new FileStream(filename, FileMode.Open);
                    StreamReader sr = new StreamReader(fs);
                    Tuple<int, int> values = ReadValues(sr);
                    sr.Close();
                    Int32 sum = values.Item1 + values.Item2;
                    Console.WriteLine(filename + ":  " + sum);
                }
                //File read exceptions
                catch (FileNotFoundException e)
                {
                    IOUtils.AppendLineToFile(NO_FILE, filename);
                }
                //Int32.Parse exceptions
                catch (ArgumentNullException e)
                {
                        IOUtils.AppendLineToFile(BAD_DATA, filename);
                }
                catch (ArgumentException argumentException)
                {
                    IOUtils.AppendLineToFile(BAD_DATA, filename);
                }
                catch (FormatException formatException)
                {
                    IOUtils.AppendLineToFile(BAD_DATA, filename);
                }
                catch (OverflowException overflowException)
                {
                    IOUtils.AppendLineToFile(OVERFLOW, filename);
                }
            }
        }
        private static Tuple<Int32, Int32> ReadValues(StreamReader streamReader)
        {
            Int32 num1 = Int32.Parse(streamReader.ReadLine());
            Int32 num2 = Int32.Parse(streamReader.ReadLine());
            return new Tuple<int, int>(num1, num2);
        }
    }
}