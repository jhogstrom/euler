namespace Euler
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    internal abstract class TriangleProblem : EulerProblem
    {
        private readonly List<List<Node>> _nodelist = new List<List<Node>>();

        protected TriangleProblem(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            foreach (var s in GetTriangle())
            {
                _nodelist.Add(s.Split(' ').Select(p => int.Parse(p)).Select(part => new Node(part)).ToList());                
            }

            for (int i = 0; i < _nodelist.Count - 1; i++)
            {
                var list = _nodelist[i];
                var below = _nodelist[i + 1];
                for (int j = 0; j < list.Count; j++)
                {
                    list[j].ConnectLeft(below[j]);
                    list[j].ConnectRight(below[j + 1]);
                }
            }

            for (int i = _nodelist.Count - 2; i >= 0; i--)
            {
                var list = _nodelist[i];
                list.ForEach(n => n.Accumulate());
            }

            return _nodelist[0].First().Value;
        }

        protected abstract IEnumerable<string> GetTriangle();

        [DebuggerDisplay("n: {Value}")]
        internal class Node
        {
            public Node(int value)
            {
                Value = value;
            }

            public int Value { get; private set; }

            public Node NextLeft { get; set; }

            public Node NextRight { get; set; }

            public void ConnectLeft(Node node)
            {
                NextLeft = node;
            }

            public void ConnectRight(Node node)
            {
                NextRight = node;
            }

            public void Accumulate()
            {
                if (NextLeft.Value > NextRight.Value)
                {
                    Value += NextLeft.Value;
                }
                else
                {
                    Value += NextRight.Value;
                }
            }
        }
    }
}