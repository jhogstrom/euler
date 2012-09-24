namespace Euler
{
    internal class Problem6 : EulerProblem
    {
        public Problem6(Printing printing) : base(printing)
        {            
        }

        protected override long GetCalculationResult()
        {
            long sumofsquares = 0;
            long squareofsums = 0;
            for (int i = 0; i < 101; i++)
            {
                sumofsquares += i * i;
                squareofsums += i;
            }

            return (squareofsums * squareofsums) - sumofsquares;
        }
    }
}