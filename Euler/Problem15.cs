namespace Euler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Problem15 : EulerProblem
    {
        public Problem15(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            var l = new List<long> { 1, 1 };
            var c = 1;
            while (c < 42)
            {
                l = l.Expand().ToList();
                c++;
                if (c % 2 == 0)
                {
                    Console.Write("{0} - ", c / 2);
                    //l.ForEach(i => Console.Write("{0} ", i));
                    Console.Write(" -- {0}", l.Max());
                    Console.WriteLine();
                }
            }
            return 0;
        }
    }
}