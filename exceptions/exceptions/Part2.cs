using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;

namespace exceptions
{
    public class Part2
    {
        public static void ProcessImages()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            foreach (String filename in Directory.GetFiles(currentDirectory))
            {
                try
                {
                    Image image = Image.FromFile(filename);
                    image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    image.Save(filename + "-mirrored", ImageFormat.Gif);
                    image.Dispose();
                }
                catch (Exception e)
                {
                    Regex regexExtForImage = new Regex(@".*((bmp)|(gif)|(tiff?)|(jpe?g)|(png))$", RegexOptions.IgnoreCase);
                    if (regexExtForImage.IsMatch(Path.GetExtension(filename)))
                    {
                        Console.WriteLine("File has image type but something went wrong...");
                    }
                }
            }
        }
    }
}