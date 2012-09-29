namespace Euler
{
    using System.Collections.Generic;

    internal class Problem41 : EulerProblem
    {
        public Problem41(Printing printing)
            : base(printing)
        {            
        }

        protected override long GetCalculationResult()
        {
            var sets = new List<HashSet<char>>
                {
                    new HashSet<char> { '1' },
                    new HashSet<char> { '1', '2' },
                    new HashSet<char> { '1', '2', '3' },
                    new HashSet<char> { '1', '2', '3', '4' },
                    new HashSet<char> { '1', '2', '3', '4', '5' },
                    new HashSet<char> { '1', '2', '3', '4', '5', '6' },
                    new HashSet<char> { '1', '2', '3', '4', '5', '6', '7' },
                    new HashSet<char> { '1', '2', '3', '4', '5', '6', '7', '8' },
                    new HashSet<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' }
                };
            var max = 10000000;
            var primes = Primes(max);

            int largest = 0;
            foreach (var prime in primes)
            {
                if (new HashSet<char>(prime.ToString().ToCharArray()).SetEquals(sets[prime.ToString().ToCharArray().Length - 1]))
                {
                    largest = prime;
                    //Print("{0}", prime);
                }
            }

            return largest;
        }
    }
}