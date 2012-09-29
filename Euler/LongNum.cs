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

        public LongNum(long num) : this(num.ToString())
        {
        }

        public LongNum(LongNum num) : this(num.ToString())
        {            
        }

        public int DigitSum
        {
            get { return _number.Sum(); }
        }

        public long SumOfDigits
        {
            get { return _number.Sum(); }
        }

        internal int Length
        {
            get { return _number.Count(); }
        }

        public static LongNum Fact(int n)
        {
            return n == 1 ? new LongNum(1) : Fact(n - 1).Mul(n);
        }

        public static long Raise(long n, int exp)
        {
            if (exp == 0)
            {
                return 1;
            }

            return n * Raise(n, exp - 1);
        }

        public LongNum Pow(int n)
        {
            var result = new LongNum(this);
            var start = this.AsLong();
            for (int i = 1; i < n; i++)
            {
                result = result.Mul((int)start);
            }

            return result;
        }

        public long AsLong()
        {
            var c = _number.Count;
            return _number.Select((n, i) => n * Raise(10, c - i - 1)).Sum();
        }

        public LongNum Mul(int i)
        {
            var result = _number.Select(n => n * i).ToList();

            for (int j = result.Count() - 1; j >= 0; j--)
            {
                if (j == 0)
                {
                    if (result[j] < 9)
                    {
                        break;
                    }

                    result.Insert(0, 0);
                    j++;
                }

                var n = result[j];
                result[j - 1] += n / 10;
                result[j] = n % 10;
            }

            return new LongNum(result);
        }

        public override int GetHashCode()
        {
            return _number.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as LongNum;
            if (other == null)
            {
                return false;
            }

            if (_number.Count != other._number.Count)
            {
                return false;
            }

            return _number.Select((n, i) => n.Equals(other._number[i])).All(b => b);
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