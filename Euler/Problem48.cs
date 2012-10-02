namespace Euler
{
    internal class Problem48 : EulerProblem
    {
        public Problem48(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            const int max = 1000;
            var res = new LongNum(0);

            for (int i = 1; i <= max; i++)
            {
                res = res.Add(new LongNum(new LongNum(i).Pow(i).Last(10)));
            }

            var last = res.Last(10);
            Print("Digits: {0}", last);
            return long.Parse(last);
        }
    }
}