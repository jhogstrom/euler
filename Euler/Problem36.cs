namespace Euler
{
    internal class Problem36 : EulerProblem
    {
        public Problem36(Printing printing)
            : base(printing)
        {            
        }

        protected override long GetCalculationResult()
        {
            const int Max = 1000000;
            var sum = 0L;
            for (long i = 1; i < Max; i += 2)
            {
                if (i.IsPalindrome() && i.IsPalindrome(2))
                {
                    Print("{0}", i);
                    sum += i;
                }
            }

            return sum;
        }
    }
}