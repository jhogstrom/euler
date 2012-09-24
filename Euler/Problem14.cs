namespace Euler
{
    internal class Problem14 : EulerProblem
    {
        public Problem14(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            var result = 0;
            var longest = 0;
            var n = 0;

            while (n < 1000000)
            {
                n++;
                var chainLength = GetChainLength(n);
                if (chainLength > longest)
                {
                    result = n;
                    longest = chainLength;
                    Print("* {0} => {1}", n, chainLength);
                }

                if (n % 100 == 0)
                {
                    Print("* {0} => {1}", n, chainLength);
                }                
            }

            return result;
        }

        private static int GetChainLength(long num)
        {
            var tally = 0;

            while (num != 1)
            {
                num = GetNextInChain(num);          
                tally++;
            }

            return tally;
        }

        private static long GetNextInChain(long num)
        {
            // even
            if (num % 2 == 0)
            {
                return num / 2;
            }

            // odd
            return (3 * num) + 1;
        }
    }
}