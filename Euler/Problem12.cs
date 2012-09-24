namespace Euler
{
    using System;

    internal class Problem12 : EulerProblem
    {
        public Problem12(Printing printing)
            : base(printing)
        {            
        }

        protected override long GetCalculationResult()
        {
            //Print("Triangle: {0}", TriangleNumber(8));
            //var r = Divisors(TriangleNumber(8));
            //for (int i = 0; i < r.Count; i++)
            //{
            //    this.Print("{0}", r[i]);
            //}
            //return 0;

            var n = 1;
            var divisors = 0;
            var triangleNumber = 0L;
            while (divisors < 500)
            {
                n++;

                triangleNumber = TriangleNumber(n);
                var r = DivisorCount(triangleNumber);
                if (r > divisors)
                {
                    divisors = r;
                    Print("* {0}: {1} => {2}", n, triangleNumber, divisors);
                }

                if (n % 100 == 0)
                {
                    Print("{0}: {1} => {2}", n, triangleNumber, r);
                }
            }

            return triangleNumber;
        }

        private static int DivisorCount(long number)
        {
            var result = 2;

            for (int i = 1; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    result += 2;
                }
            }
            
            return result;
        }

        private static long TriangleNumber(int number)
        {
            return (1 + number) * number / 2;
        }
    }
}