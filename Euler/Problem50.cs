namespace Euler
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Problem50 : EulerProblem
    {
        public Problem50(Printing printing)
            : base(printing)
        {            
        }

        protected override long GetCalculationResult()
        {
            const int max = 1000000;
            var primes = Primes(max).ToList();
            var terms = primes.TakeWhile(n => n < max / 2).Reverse().ToList();

            var start = 0;
            var highest = 0;
            var longest = 1;

            while (start < primes.Count && primes[start] < max / longest)
            {
                var end = start;
                var sum = 0;
                while (sum <= max)
                {
                    sum += primes[end++];
                    if (sum > highest && primes.Contains(sum) && end - start > longest)
                    {
                        longest = end - start;
                        highest = sum;
                        Print("{0} - {1}", highest, longest);
                    }
                }

                start++;
            }

            return highest;
        }
    }
}