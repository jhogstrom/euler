using System;

namespace Euler
{
    using System.Collections;
    using System.Collections.Generic;
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
            EulerProblem p = new Problem42(Printing.On);
            Console.WriteLine("Answer: {0}", p.Answer);
            Console.WriteLine("Time: {0}", p.Timing);
            Console.WriteLine("The answer is in the clipboard!");
            Clipboard.SetText(p.Answer.ToString());
            Console.ReadLine();
        }
    }

    internal class Problem75 : EulerProblem
    {
        public Problem75(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            const int max = 100000;
            const int halfmax = max / 2;

            var squares = new List<long>(halfmax) { 0 };

            for (int i = 1; i < halfmax; i++)
            {
                squares.Add(i * i);
            }

            var result = new HashSet<long>();

            for (int i = 1; i < squares.Count; i++)
            {
                for (int j = 1; j < squares.Count; j++)
                {
                    long res = squares[i] + squares[j];                    
                    if (squares.Contains(res))
                    {
                        long l = i + j + (int)Math.Sqrt(res);
                        if (!result.Contains(l))
                        {
                            //Print(
                            //    "{6} - {0}^2 + {1}^2 == {2} ({3} + {4} == {5})",
                            //    i,
                            //    j,
                            //    Math.Sqrt(res),
                            //    squares[i],
                            //    squares[j],
                            //    res,
                            //    l);
                            result.Add(l);
                        }
                    }
                    if (res > halfmax)
                    {
                        break;
                        Print("{0}", i);
                    }
                }
            }

            return result.Sum();
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