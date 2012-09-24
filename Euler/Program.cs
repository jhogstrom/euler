using System;

namespace Euler
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            EulerProblem p = new Problem23(Printing.On);
            Console.WriteLine("Answer: {0}", p.Answer);
            Console.WriteLine("Time: {0}", p.Timing);
            Console.WriteLine("The answer is in the clipboard!");
            Clipboard.SetText(p.Answer.ToString());
            Console.ReadLine();
        }
    }

    internal class Problem23 : EulerProblem
    {
        public Problem23(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            const int MaxValue = 28123;
            var abundantSums = new List<int>(1000);
            for (int i = 1; i < MaxValue; i++)
            {
                var divisors = GetDivisors(i);
                var sum = divisors.Sum();
                if (sum > i)
                {
                    abundantSums.Add(i);
                }
            }

            var s = new HashSet<int>();
            foreach (var t in abundantSums)
            {
                foreach (var i in abundantSums)
                {
                    s.Add(t + i);
                }
            }

            var nonsum = new List<int>();
            for (int i = 1; i < MaxValue; i++)
            {
                if (!s.Contains(i))
                {
                    
                    nonsum.Add(i);
                }
            }

            return nonsum.Sum();
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

    [DebuggerDisplay("v = {NextValue}")]
    internal class Vertex
    {
        public Vertex(Node node)
        {
            Next = node;
        }

        public Node Next { get; set; }

        public int NextValue
        {
            get { return Next.Value; }
        }
    }

    internal class Problem18 : EulerProblem
    {
        private readonly List<string> _triangle = new List<string>
            {
                   "3",
                  "7 4",
                 "2 4 6",
                "8 5 9 3"
            };

        private readonly List<Node> _nodes = new List<Node>();
        private readonly List<List<Node>> _nodelist = new List<List<Node>>();

        public Problem18(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            foreach (var s in _triangle)
            {
                var parts = s.Split(' ').Select(p => int.Parse(p));

                var l = parts.Select(part => new Node(part)).ToList();

                _nodelist.Add(l);
                _nodes.AddRange(l);
            }

            for (int i = _nodelist.Count - 1; i > 0; i--)
            {
                var list = _nodelist[i];
                var above = _nodelist[i - 1];
                for (int p = 0; p < list.Count; p++)
                {
                    if (p > 0)
                    {
                        list[p].ConnectLeft(above[p - 1]);
                    }

                    if (p < above.Count)
                    {
                        list[p].ConnectRight(above[p]);
                    }
                }
            }

            var endLine = _nodelist.Last().OrderByDescending(n => n.MaxNextValue).ToList();
            var best = endLine.First();
            while (best.HasNext)
            {
                endLine.Add(best.ConsumeMax());
                if (!best.HasNext)
                {
                    endLine.Remove(best);
                }

                best = endLine.OrderByDescending(n => n.MaxNextValue).First();
            }

            return best.Value;
        }
    }

    [DebuggerDisplay("n: {Value}")]
    internal class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; private set; }

        public Vertex NextLeft { get; set; }

        public Vertex NextRight { get; set; }

        public bool Used { get; set; }

        public bool HasNext
        {
            get { return NextLeft != null || NextRight != null; }
        }

        public void ConnectLeft(Node node)
        {
            NextLeft = new Vertex(node);
        }

        public void ConnectRight(Node node)
        {
            NextRight = new Vertex(node);
        }

        public int MaxNextValue
        {
            get { return Value + MaxNextNode.NextValue; }
        }

        public Vertex MaxNextNode
        {
            get
            {
                var left = NextLeft != null ? Value + NextLeft.NextValue : Value;
                var right = NextRight != null ? Value + NextRight.NextValue : Value;
                return left > right ? NextLeft : NextRight;
            }
        }

        public Node ConsumeMax()
        {
            var left = NextLeft != null ? Value + NextLeft.NextValue : Value;
            var right = NextRight != null ? Value + NextRight.NextValue : Value;
            Node result;
            if (left > right)
            {
                result = NextLeft.Next;                
                NextLeft = null;
            }
            else
            {
                result = NextRight.Next;                
                NextRight = null;
            }
            result.Value += Value;
            return result;
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