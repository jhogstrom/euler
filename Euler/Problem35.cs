namespace Euler
{
    using System.Collections.Generic;

    internal class Problem35 : EulerProblem
    {
        private readonly List<string> _primes = new List<string>(10000);

        public Problem35(Printing printing) : base(printing)
        {
        }

        private List<int> FullCircle(int n)
        {
            var s = n.ToString();
            var result = new List<int>(s.Length);

            for (int i = 0; i < s.Length; i++)
            {
                s = s.Substring(1) + s.Substring(0, 1);
                var c = int.Parse(s);

                if (!result.Contains(c))
                {
                    result.Add(c);
                }
            }

            return result;
        }

        private int AllCirclesPrime(string s)
        {
            int length = s.Length;
            for (int i = 0; i < length; i++)
            {
                string c = s.Substring(i, 1);
                if (int.Parse(c) % 2 == 0)
                {
                    if (length > 1)
                    {
                        return 0;
                    }
                }
            }

            for (int i = 0; i < length; i++)
            {
                s = s.Substring(1) + s.Substring(0, 1);
                if (!_primes.Contains(s))
                {
                    return 0;
                }
            }

            return 1;
        }

        protected override long GetCalculationResult()
        {
            for (var i = 0; i < 1000000; i++)
            {
                if (IsPrime(i))
                {
                    _primes.Add(i.ToString());
                }
            }

            //var circularPrimes = new List<int>();

            var count = 0;
            foreach (var prime in _primes)
            {
                count += AllCirclesPrime(prime);
                //var circle = FullCircle(prime);
                //if (circle[0] != -1 && circle.All(primes.Contains))
                //{
                //    circularPrimes.Add(prime);
                //}
            }

            return count;
        }
    }
}