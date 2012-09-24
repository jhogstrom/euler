namespace Euler
{
    internal class Problem10 : EulerProblem
    {
        public Problem10(Printing printing) : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            long result = 0;
            for (int i = 2; i < 2000000; i++)
            {
                if (IsPrime(i))
                {
                    result += i;
                }
            }

            return result;
        }
    }
}