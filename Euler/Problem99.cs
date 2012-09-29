namespace Euler
{
    using System;

    using Enumerable = System.Linq.Enumerable;

    internal class Problem99 : EulerProblem
    {
        public Problem99(Printing printing)
            : base(printing)
        {            
        }

        protected override long GetCalculationResult()
        {
            return Enumerable.First<Record>(File.ReadAllLines("p99_base_exp.txt").Select((s, pos) => new Record(s, pos + 1)).OrderByDescending(r => r.Value)).Pos;
        }

        class Record
        {
            public Record(string line, int pos)
            {
                Pos = pos;
                var p = line.Split(',');
                Value = int.Parse(p[1]) * Math.Log(int.Parse(p[0]));
            }

            public int Pos { get; private set; }
            
            public double Value { get; private set; }
        }
    }
}