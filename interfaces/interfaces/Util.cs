using System.Numerics;

namespace interfaces
{
    public class Util
    {
        public static BigInteger GCD(BigInteger a, BigInteger b)
        {
            while (!b.IsZero)
            {
                //BigInteger overrides % operator so we can use it there
                b = a % (a = b);
            }
            return a;
        }
    }
}