using System;

namespace Euler
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            EulerProblem p = new Problem50(Printing.On);
            Console.WriteLine("Answer: {0}", p.Answer);
            Console.WriteLine("Time: {0}", p.Timing);
            Console.WriteLine("The answer is in the clipboard!");
            Clipboard.SetText(p.Answer.ToString());
            Console.ReadLine();
        }
    }

    internal static class LongExtender
    {
        public static bool IsPalindrome(this long i)
        {
            return IsPalindrome(i.ToString());
        }

        private static bool IsPalindrome(string s)
        {
            var l = s.Length;
            for (int i = 0; i < l / 2; i++)
            {
                if (s[i] != s[l - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsPalindrome(this long i, int b)
        {
            return IsPalindrome(Convert.ToString(i, b));
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