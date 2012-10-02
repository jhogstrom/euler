namespace Euler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class EulerProblem
    {
        private readonly Printing _printing;

        protected EulerProblem(Printing printing)
        {
            _printing = printing;
            var start = DateTime.UtcNow;
            Calculate();
            var done = DateTime.UtcNow;
            Timing = done - start;
        }

        public TimeSpan Timing { get; private set; }

        public long Answer { get; private set; }

        public void Calculate()
        {
            Answer = GetCalculationResult();
        }

        protected int StringValue(string s)
        {
            System.Text.Encoding ascii = System.Text.Encoding.ASCII;
            var encodedBytes = ascii.GetBytes(s);
            return encodedBytes.Sum(c => c - 64);
        }


        protected abstract long GetCalculationResult();

        protected void Print(string s, params object[] parameters)
        {
            if (_printing == Printing.On)
            {
                Console.WriteLine(s, parameters);
            }
        }

        protected static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        protected static IEnumerable<int> GetDivisors(int number)
        {
            var divisors = new List<int>();                       

            for (int i = 1; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    divisors.Add(i);
                }
            }

            return divisors;
        }

        protected IEnumerable<int> Primes(int max)
        {            
            var numbers = new List<int>(max);            
            
            for (int i = 0; i < max; i++)
            {
                numbers.Add(i);
            }

            numbers[0] = -1;
            numbers[1] = -1;

            var lastPrime = 2;
            var lpSquare = lastPrime * lastPrime;

            while (lpSquare < max)
            {
                for (var i = lpSquare; i < max; i += lastPrime)
                {
                    numbers[i] = -1;
                }

                lastPrime = numbers.SkipWhile(n => n <= lastPrime).SkipWhile(n => n < 0).First();
                lpSquare = lastPrime * lastPrime;
            }


            return numbers.Where(n => n != -1);
        }
    }
}