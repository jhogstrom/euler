namespace Euler
{
    using System.Collections.Generic;
    using System.Linq;

    public static class QueueExtensions
    {
        public static long Product(this Queue<long> queue)
        {
            long result = 1;
            queue.ToList().ForEach(i => result *= i);
            return result;
        }

        public static Queue<long> Clone(this Queue<long> queue)
        {
            var result = new Queue<long>();
            queue.ToList().ForEach(result.Enqueue);
            return result;
        }
    }
}