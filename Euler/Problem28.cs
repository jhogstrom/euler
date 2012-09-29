namespace Euler
{
    internal class Problem28 : EulerProblem
    {
        public Problem28(Printing printing)
            : base(printing)
        {            
        }

        protected override long GetCalculationResult()
        {
            const int size = 1001;
            long sum = 1;

            for (int i = 2; i <= (size / 2) + 1; i++)
            {
                var cornerSum = CornerSum(i);
                sum += cornerSum;
            }

            return sum;
        }

        private static long CornerSum(int i)
        {
            return (16 * i * i) - (28 * i) + 16;
        }
    }
}