namespace Euler
{
    using System.Collections.Generic;
    using System.IO;

    internal class Problem67 : TriangleProblem
    {
        public Problem67(Printing printing)
            : base(printing)
        {
        }

        protected override IEnumerable<string> GetTriangle()
        {
            return File.ReadAllLines("p67_triangle.txt");
        }
    }
}