namespace Euler
{
    internal class Problem20 : EulerProblem
    {
        public Problem20(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            var sumOfDigits = LongNum.Fact(100).SumOfDigits;
            return sumOfDigits;
        }
    }
}