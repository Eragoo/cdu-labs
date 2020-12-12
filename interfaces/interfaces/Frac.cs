using System;
using System.Numerics;

namespace interfaces
{
    public class Frac : IMyNumber<Frac>
    {
        protected BigInteger nom;
        protected BigInteger denom;

        public Frac(BigInteger nom, BigInteger denom)
        {
            if (denom.IsZero)
            {
                throw new DivideByZeroException("Frac denom must be non zero"); 
            }

            BigInteger gcd = Util.GCD(nom, denom);
            this.nom = nom / gcd;
            this.denom = denom / gcd;
        }

        public Frac Add(Frac b)
        {
            BigInteger newFracNom = nom * b.denom + denom * b.nom;
            BigInteger newFracDenom = denom * b.denom;
            Frac newFrac = new Frac(newFracNom, newFracDenom);
            ValidateFrac(newFrac);
            return newFrac;
        }

        public Frac Subtract(Frac b)
        {
            BigInteger newFracNom = nom * b.denom - denom * b.nom;  
            BigInteger newFracDenom = denom * b.nom;                
            Frac newFrac = new Frac(newFracNom, newFracDenom);     
            ValidateFrac(newFrac);                                 
            return newFrac;                                        
        }

        public Frac Multiply(Frac b)
        {
            BigInteger newFracNom = nom * b.nom;  
            BigInteger newFracDenom = denom * b.denom;                
            Frac newFrac = new Frac(newFracNom, newFracDenom);     
            ValidateFrac(newFrac);                                 
            return newFrac;                                                      
        }

        public Frac Divide(Frac b)
        {
            BigInteger newFracNom = nom * b.denom;              
            BigInteger newFracDenom = denom * b.nom;        
            Frac newFrac = new Frac(newFracNom, newFracDenom);
            ValidateFrac(newFrac);                            
            return newFrac;                                   
        }

        private void ValidateFrac(Frac frac)
        {
            if (frac.denom.IsZero)
            {
                throw new DivideByZeroException("Frac denom must be non zero");
            }
        }

        public override string ToString()
        {
            String sign = nom / denom >= 0 ? "" : "-";
            return sign + BigInteger.Abs(nom) + "/" + BigInteger.Abs(denom);
        }
    }
}