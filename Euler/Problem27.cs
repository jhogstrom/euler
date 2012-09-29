namespace Euler
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Problem27 : EulerProblem
    {
        private List<int> _primes;

        public Problem27(Printing printing)
            : base(printing)
        {            
        }

        protected override long GetCalculationResult()
        {
            var max = 999;
            var longest = 0;
            _primes = Primes(1000000).ToList();
            Print("{0}", CheckPrimes(1, 41));
            Print("{0}", CheckPrimes(-79, 1601));
            Print("{0}", CheckPrimes(-996, 167));

            var longA = 0;
            var longB = 0;
            for (int a = -max; a <= max; a += 2)
            {
                for (int b = 0; _primes[b] <= max; b++)
                {
                    var primeCount = CheckPrimes(a, _primes[b]);
                    
                    if (primeCount > longest)
                    {
                        longest = primeCount;
                        longA = a;
                        longB = _primes[b];
                        Print("n^2 + {0}n  + {1} => {2}", a, _primes[b], longest);
                    }
                }                
            }

            return longA * longB;
        }

        private int CheckPrimes(int a, int b)
        {
            var n = 0;
            var f = (n * n) + (a * n) + b;            
            
            while (_primes.Contains(f))
            {
                n++;
                f = (n * n) + (a * n) + b;
            }

            return n;
        }
    }
}