namespace Euler
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Problem23 : EulerProblem
    {
        public Problem23(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            const int MaxValue = 28123;
            var abundantSums = new List<int>(1000);
            for (int i = 1; i < MaxValue; i++)
            {
                var divisors = GetDivisors(i);
                var sum = divisors.Sum();
                if (sum > i)
                {
                    abundantSums.Add(i);
                }
            }

            var s = new HashSet<int>();
            foreach (var t in abundantSums)
            {
                foreach (var i in abundantSums)
                {
                    s.Add(t + i);
                }
            }

            var nonsum = new List<int>();
            for (var i = 1; i < MaxValue; i++)
            {
                if (!s.Contains(i))
                {
                    nonsum.Add(i);
                }
            }

            return nonsum.Sum();
        }
    }
}