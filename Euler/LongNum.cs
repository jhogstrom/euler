using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public class LongNum
    {
        private readonly List<int> _number;
        
        public LongNum(IEnumerable<char> num)
        {
            _number = num.ToArray().ToList().Select(c => int.Parse(c.ToString())).ToList();
        }

        public LongNum(IEnumerable<int> num)
        {
            _number = num.ToList();
        }

        public int DigitSum
        {
            get { return _number.Sum(); }
        }

        internal int Length
        {
            get { return _number.Count(); }
        }

        public LongNum Add(LongNum num)
        {
            while (Length < num.Length)
            {
                _number.Insert(0, 0);
            }

            while (num.Length < Length)
            {
                num._number.Insert(0, 0);
            }

            var result = _number.Select((v, pos) => v + num._number.ElementAtOrDefault(pos)).ToList();
            result.Insert(0, 0);
            for (int i = result.Count - 1; i >= 0; i--)
            {
                while (result[i] >= 10)
                {
                    result[i - 1] += 1;
                    result[i] -= 10;
                }
            }

            while (result[0] == 0)
            {
                result.RemoveAt(0);
            }

            return new LongNum(result);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            _number.ForEach(i => sb.Append(i));
            return sb.ToString();
        }
    }
}