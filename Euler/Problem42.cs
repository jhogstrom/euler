using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Euler
{
    internal class Problem42 : EulerProblem
    {
        public Problem42(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            var words = File.ReadAllText("p42_words.txt").Split(',').Select(s => s.Substring(1, s.Length - 2)).Select(StringValue);
            var max = words.Max();

            var triangles = new List<int> { 1 };
            var n = 2;
            while (triangles.Max() < max)
            {
                triangles.Add(n * (n + 1) / 2);
                n++;
            }

            return words.Where(triangles.Contains).Count();
        }
    }
}