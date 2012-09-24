namespace Euler
{
    internal class Problem7 : EulerProblem
    {
        public Problem7(Printing printing) : base(printing)
        {            
        }

        protected override long GetCalculationResult()
        {
            var count = 1;
            var i = 1;
            while (count < 100001)
            {
                i += 2;
                if (IsPrime(i))
                {
                    count++;
                    Print("{0} - {1}", count, i);
                }
            }

            return i;
        }
    }
}