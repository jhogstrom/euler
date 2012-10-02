using System;

namespace Euler
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            EulerProblem p = new Problem45(Printing.On);
            Console.WriteLine("Answer: {0}", p.Answer);
            Console.WriteLine("Time: {0}", p.Timing);
            Console.WriteLine("The answer is in the clipboard!");
            Clipboard.SetText(p.Answer.ToString());
            Console.ReadLine();
        }
    }

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
            Print("Contains origo: {0}", t1.ContainsOrigo); 
            Print("Contains origo: {0}", t2.ContainsOrigo);
            return 0;

            var triangles = File.ReadAllLines("p102_triangles.txt").Select(s => new Triangle(s));
            // 81 - is wrong
            // 181 - is wrong
            return triangles.Count(t => t.ContainsOrigo);
        }

        class Triangle
        {
            public Triangle(string s)
            {
                var p = s.Split(',');
                C1 = new Coord(int.Parse(p[0]), int.Parse(p[1]));
                C2 = new Coord(int.Parse(p[2]), int.Parse(p[3]));
                C3 = new Coord(int.Parse(p[4]), int.Parse(p[5]));

                var m1 = (C1.Y - C2.Y) / (double)(C1.X - C2.X);
                var m2 = (C2.Y - C3.Y) / (double)(C2.X - C3.X);
                var m3 = (C3.Y - C1.Y) / (double)(C3.X - C1.X);

                var b1 = C1.Y - m1 * C1.X;
                var b2 = C2.Y - m2 * C2.X;
                var b3 = C3.Y - m3 * C3.X;

                var x1 = -b1 / m1;
                var x2 = -b2 / m2;
                var x3 = -b3 / m3;

                var positiveY = PosCount(b1, b2, b3);
                var positiveX = PosCount(x1, x2, x3);
                //ContainsOrigo = (positiveY == 1 && positiveX == 1) || (positiveX == 2 && positiveY == 2);
                ContainsOrigo = PosCount(b1, b2, b3, x1, x2, x3) == 4;
            }

            private int PosCount(params double[] numbers)
            {
                return numbers.Count(d => d >= 0);
            }

            public bool ContainsOrigo { get; private set; }
            //{
            //    get
            //    {
            //        if (Math.Sign(C1.X) == Math.Sign(C2.X) && Math.Sign(C2.X) == Math.Sign(C3.X))
            //        {
            //            return false;
            //        }

            //        if (Math.Sign(C1.Y) == Math.Sign(C2.Y) && Math.Sign(C2.Y) == Math.Sign(C3.Y))
            //        {
            //            return false;
            //        }

            //        return true;
            //    }
            //}

            protected Coord C3 { get; set; }

            protected Coord C2 { get; set; }

            protected Coord C1 { get; set; }


        }

        [DebuggerDisplay("({X}, {Y})")]
        class Coord
        {
            public int X { get; set; }

            public int Y { get; set; }

            public Coord(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }

    internal class Problem125 : EulerProblem
    {
        private const long max = 1000;

        private List<long> _squares = new List<long>();
        public Problem125(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            GetSquares();
            var result = 0L;
            for (var i = 1L; i < 1e8; i++)
            {
                if (!i.IsPalindrome())
                {
                    continue;
                }

                if (HasSquareSum(i))
                {
                    Print("{0}", i);
                    result += i;
                }
            }

            return result;
        }

        private void GetSquares()
        {
            for (int i = 1; i < (max); i++)
            {
                _squares.Add(i * i);
            }
        }

        private bool HasSquareSum(long l)
        {
            var start = 0;
            var end = 0;
            var sum = 0L;
            
            while (sum < l && _squares[end] < l / 2)
            {
                sum += _squares[end++];
                if (sum == l)
                {
                    return true;
                }

                while (sum > l && end > start)
                {
                    sum -= _squares[start++];
                }

                if (start == end)
                {
                    return false;
                }
            }

            return false;
        }
    }

    internal class Problem32 : EulerProblem
    {
        public Problem32(Printing printing)
            : base(printing)
        {            
        }

        protected override long GetCalculationResult()
        {
            var p = Permute("ABC");
            foreach (var s in p)
            {
                Print("{0}", s);
            }

            return 0;
        }

        private IEnumerable<string> Permute(string s)
        {
            if (s.Length == 1)
            {
                return new[] { s };
            }

            var c = s[0];
            var result = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {
                foreach (var permutation in Permute(s.Substring(1)))
                {
                    var sb = new StringBuilder(s.Length);
                    sb.Append(permutation.Substring(i, 1));
                    sb.Append(c);
                    if (i < permutation.Length - 1)
                    {
                        sb.Append(permutation.Substring(i + 1));
                    }

                    result.Add(sb.ToString());
                }                
            }

            return result;
        }
    }

    internal class Problem22 : EulerProblem
    {
        public Problem22(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            var lines = File.ReadAllText("p22_names.txt").Split(',').Select(s => s.Substring(1, s.Length - 2));
            //var lines = new List<string> { "A", "AA", "ABC", "JESPER" };
            lines = lines.OrderBy(s => s).ToList();
            var values = lines.Select(StringValue);
            var posValues = values.Select(PositionValue);
            return posValues.Sum();

        }

        private long PositionValue(int value, int i)
        {
            return value * (i + 1);
        }

        private int StringValue(string s)
        {
            System.Text.Encoding ascii = System.Text.Encoding.ASCII;
            var encodedBytes = ascii.GetBytes(s);
            return encodedBytes.Sum(c => c - 64);
        }
    }

    internal class Problem74 : EulerProblem
    {
        private readonly Dictionary<int, int> _factor = new Dictionary<int, int>(10);

        public Problem74(Printing printing)
            : base(printing)
        {
        }

        private int Factor(int i)
        {
            if (!_factor.ContainsKey(i))
            {
                _factor.Add(i, Factorial(i));
            }

            return _factor[i];
        }

        private int Factorial(int i)
        {
            if (i == 1)
            {
                return 1;
            }

            return i * Factorial(i - 1);
        }

        protected override long GetCalculationResult()
        {
            throw new NotImplementedException();
        }
    }
}