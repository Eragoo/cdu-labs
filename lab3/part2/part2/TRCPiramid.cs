using System;

namespace part2
{
    public class TRCPiramid : TRPiramid
    {
        protected String color;
        
        public TRCPiramid(double a, double b, double c, double h, String color) : base(a, b, c, h)
        {
            this.color = color;
        }

        public void SetColor(String color)
        {
            this.color = color;
        }

        public String GetColor()
        {
            return color;
        }
    }
}