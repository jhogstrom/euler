namespace Euler
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Problem45 : EulerProblem
    {
        public Problem45(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            var tri = new List<double>();
            var pent = new List<double>();
            var hex = new List<double>();
            for (int n = 1; n < 1000000; n++)
            {
                tri.Add((double)n * (n + 1) / 2);
                pent.Add((double)n * ((3 * n) - 1) / 2);
                hex.Add((double)n * ((2 * n) - 1));
            }

            var res = tri.Intersect(pent).Intersect(hex);

            res.ToList().ForEach(n => Print("{0}", n));
            return 0;
        }
    }
}