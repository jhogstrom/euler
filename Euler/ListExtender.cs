namespace Euler
{
    using System.Collections.Generic;
    using System.Linq;

    public static class ListExtender
    {
        public static IEnumerable<long> Expand(this List<long> me)
        {
            yield return me[0];
            for (int i = 0; i < me.Count - 1; i++)
            {
                yield return me[i] + me[i + 1];
            }

            yield return me.Last();
        }
    }
}