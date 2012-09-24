namespace Euler
{
    internal class Problem25 : EulerProblem
    {
        public Problem25(Printing printing) : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            var c = 2;
            var fib = new LongNum("1");
            var prevFib = new LongNum("1");
            LongNum ppFib;
            while (fib.Length < 1000)
            {
                c++;
                ppFib = prevFib;
                prevFib = fib;
                fib = fib.Add(ppFib);
                Print("{0,3} - {1,50}", c, fib);
            }

            return c;
        }
    }
}