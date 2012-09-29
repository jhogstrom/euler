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
            EulerProblem p = new Problem99(Printing.On);
            Console.WriteLine("Answer: {0}", p.Answer);
            Console.WriteLine("Time: {0}", p.Timing);
            Console.WriteLine("The answer is in the clipboard!");
            Clipboard.SetText(p.Answer.ToString());
            Console.ReadLine();
        }
    }

    internal class Problem99 : EulerProblem
    {
        public Problem99(Printing printing)
            : base(printing)
        {            
        }

        protected override long GetCalculationResult()
        {
            return File.ReadAllLines("p99_base_exp.txt").ToList().Select((s, pos) => new Record(s, pos + 1)).OrderByDescending(r => r.Value).First().Pos;
        }

        class Record
        {
            public Record(string line, int pos)
            {
                Pos = pos;
                var p = line.Split(',');
                var num = int.Parse(p[0]);
                var exp = int.Parse(p[1]);
                Value = exp * Math.Log(num);
            }

            public int Pos { get; private set; }

            public double Value { get; private set; }
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