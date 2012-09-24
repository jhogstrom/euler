using System;

namespace Euler
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            EulerProblem p = new Problem21(Printing.On);
            Console.WriteLine("Answer: {0}", p.Answer);
            Console.WriteLine("Time: {0}", p.Timing);
            Console.WriteLine("The answer is in the clipboard!");
            Clipboard.SetText(p.Answer.ToString());
            Console.ReadLine();
        }
    }

    internal class Problem21 : EulerProblem
    {
        private List<int> _divisors = new List<int>(10000);
        private readonly Dictionary<int, int> _divisorSums = new Dictionary<int, int>(10000);

        public Problem21(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            const int MaxValue = 10010;

            for (int i = 1; i < MaxValue; i++)
            {
                var divisors = GetDivisors(i);
                _divisorSums.Add(i, divisors.Sum());
            }
            var count = _divisorSums.Count;

            var result = 0;

            for (int i = 1; i < MaxValue; i++)
            {
                var divisorSum = _divisorSums[i];
                
                if (divisorSum > 0 && divisorSum < count)
                {
                    if (_divisorSums[divisorSum] == i && (_divisorSums[divisorSum] != _divisorSums[i]))
                    {
                        result += i;
                        var s = new StringBuilder();
                        var divisors = GetDivisors(i).ToList();
                        divisors.ForEach(n => s.Append(n).Append(" "));
                        Print("{0}: {1} [{2}]", i, divisors.Sum(), s);
                    }
                }
            }

            return result;
        }

        private static IEnumerable<int> GetDivisors(int number)
        {
            var primeDivisors = new List<int>();                       

            for (int i = 1; i <= number / 2 /*Math.Sqrt(number)*/; i++)
            {
                if (number % i == 0 /*&& IsPrime(i)*/)
                {
                    primeDivisors.Add(i);
                }
            }

            //if (number != 1)
            //{
            //    primeDivisors.Add(number);
            //}

            //var result = Permute(primeDivisors);

            return primeDivisors;
        }

        private static List<int> Permute(List<int> list)
        {
            throw new NotImplementedException();
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