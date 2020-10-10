namespace part2
{
    public class TRCEPiramid : TRCPiramid
    {
        public TRCEPiramid(double a, double b, double c, double h, string color) : base(a, b, c, h, color)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (this == obj)
            {
                return true;
            }

            TRCEPiramid p = (TRCEPiramid) obj;
            
            bool baseCompare = base.Equals(obj);
            if (baseCompare && color.Equals(p.color))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + c.GetHashCode();
        }
    }
}