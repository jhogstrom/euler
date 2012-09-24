namespace Euler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class Problem21 : EulerProblem
    {
        private readonly Dictionary<int, int> _divisorSums = new Dictionary<int, int>(10000);

        public Problem21(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            const int MaxValue = 10010;

            for (int i = 1; i < MaxValue; i++)
            {
                var divisors = GetDivisors(i);
                _divisorSums.Add(i, divisors.Sum());
            }

            var count = _divisorSums.Count;

            var result = 0;

            for (int i = 1; i < MaxValue; i++)
            {
                var divisorSum = _divisorSums[i];
                
                if (divisorSum > 0 && divisorSum < count)
                {
                    if (_divisorSums[divisorSum] == i && (_divisorSums[divisorSum] != _divisorSums[i]))
                    {
                        result += i;
                        var s = new StringBuilder();
                        var divisors = GetDivisors(i).ToList();
                        divisors.ForEach(n => s.Append(n).Append(" "));
                        Print("{0}: {1} [{2}]", i, divisors.Sum(), s);
                    }
                }
            }

            return result;
        }
    }
}