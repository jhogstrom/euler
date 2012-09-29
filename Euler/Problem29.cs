namespace Euler
{
    using System.Collections.Generic;

    internal class Problem29 : EulerProblem
    {
        public Problem29(Printing printing)
            : base(printing)
        {            
        }

        protected override long GetCalculationResult()
        {
            var maxA = 100;
            var maxB = 100;

            var result = new HashSet<string>();
            for (var a = 2; a <= maxA; a++)
            {
                for (var b = 2; b <= maxB; b++)
                {
                    var num = new LongNum(a).Pow(b).ToString();
                    result.Add(num);
                }
                //Print("{0}", a);
            }

            //HashSet<int>


            return result.Count;
        }
    }
}