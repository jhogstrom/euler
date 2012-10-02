namespace Euler
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    using Enumerable = System.Linq.Enumerable;

    internal class Problem102 : EulerProblem
    {
        public Problem102(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            var t1 = new Triangle("-340,495,-153,-910,835,-947");
            var t2 = new Triangle("-175,41,-421,-714,574,-645");
            Print("Contains origo: {0} (should be true)", t1.ContainsOrigo); 
            Print("Contains origo: {0} (should be false)", t2.ContainsOrigo);

            var triangles = Enumerable.Select<string, Triangle>(File.ReadAllLines("p102_triangles.txt"), s => new Triangle(s));
            return triangles.Count(t => t.ContainsOrigo);
        }

        class Triangle
        {
            public Triangle(string s)
            {
                var p = s.Split(',');
                var c1 = new Coord(int.Parse(p[0]), int.Parse(p[1]));
                var c2 = new Coord(int.Parse(p[2]), int.Parse(p[3]));
                var c3 = new Coord(int.Parse(p[4]), int.Parse(p[5]));

                var lines = new List<Line> { new Line(c1, c2), new Line(c2, c3), new Line(c3, c1) };
                ContainsOrigo = lines.Count(l => l.CutsNegativeYAxis) == 1
                                && lines.Count(l => l.CutsPositiveYAxis) == 1;
            }

            public bool ContainsOrigo { get; private set; }
        }

        [DebuggerDisplay("({X}, {Y})")]
        class Coord
        {
            public Coord(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; private set; }

            public int Y { get; private set; }
        }

        class Line
        {
            private readonly Coord _c1;
            private readonly Coord _c2;
            private readonly double _b;

            public Line(Coord c1, Coord c2)
            {
                _c1 = c1;
                _c2 = c2;
                var a = (_c1.Y - _c2.Y) / (double)(_c1.X - _c2.X);
                _b = _c1.Y - (a * _c1.X);
            }

            public bool CutsPositiveYAxis
            {
                get { return _b >= 0 && Math.Sign(_c1.X) != Math.Sign(_c2.X); }
            }

            public bool CutsNegativeYAxis
            {
                get { return _b <= 0 && Math.Sign(_c1.X) != Math.Sign(_c2.X); }
            }
        }
    }
}