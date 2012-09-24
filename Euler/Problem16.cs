namespace Euler
{
    internal class Problem16 : EulerProblem
    {
        public Problem16(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            var num = new LongNum("1");
            for (int i = 0; i <= 1000 - 1; i++)
            {
                num = num.Add(num);
            }
            this.Print("{0}", num);
            return num.DigitSum;
        }
    }
}