namespace Euler
{
    using System;

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
}