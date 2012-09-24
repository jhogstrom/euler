namespace Euler
{
    using System;
    using System.Linq;
    using System.Text;

    public class Problem17 : EulerProblem
    {
        public Problem17(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            int answer = 0;
            for (int i = 1; i <= 1000; i++)
            {
                var s = DigitAsString(i);
                var charCount = CountChars(s);
                answer += charCount;
                Print("{0} - {1} ({2})", i, s, charCount);
            }

            return answer;
        }

        private static int CountChars(string s)
        {
            return s.ToCharArray().ToList().Count(c => c != ' ');
        }

        private static string DigitAsString(int i)
        {
            var th = i / 1000;
            var hds = (i - (th * 1000)) / 100;
            var tens = (i - (th * 1000) - (hds * 100)) / 10;
            var ones = i % 10;

            var s = new StringBuilder(40);
            s.Append(tens == 1 ? TeenString(ones) : SingleDigitString(ones));

            s.Insert(0, TenString(tens));
            s.Insert(0, HundredString(hds, (10 * tens) + ones));
            s.Insert(0, ThousandString(th));

            return s.ToString();
        }

        private static string ThousandString(int th)
        {
            if (th == 0)
            {
                return string.Empty;
            }

            return string.Format("{0} thousand ", SingleDigitString(th));
        }

        private static string HundredString(int hds, int rest)
        {
            if (hds == 0)
            {
                return string.Empty;
            }

            return string.Format("{0} hundred {1}", SingleDigitString(hds), rest == 0 ? string.Empty : " and ");
        }

        private static string TenString(int tens)
        {
            switch (tens)
            {
                case 0:
                    return string.Empty;
                case 1:
                    return string.Empty;
                case 2:
                    return "twenty";

                case 3:
                    return "thirty";

                case 4:
                    return "forty";

                case 5:
                    return "fifty";

                case 6:
                    return "sixty";

                case 7:
                    return "seventy";

                case 8:
                    return "eighty";

                case 9:
                    return "ninety";

                default:
                    throw new Exception();
            }
        }

        private static string TeenString(int ones)
        {
            switch (ones)
            {
                case 0:
                    return "ten";

                case 1:
                    return "eleven";
                case 2:
                    return "twelve";

                case 3:
                    return "thirteen";

                case 4:
                    return "fourteen";

                case 5:
                    return "fifteen";

                case 6:
                    return "sixteen";

                case 7:
                    return "seventeen";

                case 8:
                    return "eighteen";

                case 9:
                    return "nineteen";

                default:
                    throw new Exception();
            }
        }

        private static string SingleDigitString(int ones)
        {
            switch (ones)
            {
                case 0:
                    return string.Empty;

                case 1:
                    return "one";
                case 2:
                    return "two";

                case 3:
                    return "three";

                case 4:
                    return "four";

                case 5:
                    return "five";

                case 6:
                    return "six";

                case 7:
                    return "seven";

                case 8:
                    return "eight";

                case 9:
                    return "nine";

                default:
                    throw new Exception();
            }
        }
    }
}