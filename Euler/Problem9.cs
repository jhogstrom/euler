namespace Euler
{
    using System;

    internal class Problem9 : EulerProblem
    {
        public Problem9(Printing printing) : base(printing)
        {           
        }

        protected override long GetCalculationResult()
        {
            for (var i = 1; i < 1000; i++)
            {
                for (var j = 1; j < 1000; j++)
                {
                    if (i + j > 1000)
                    {
                        continue;
                    }

                    for (var k = 1; k < 1000; k++)
                    {
                        if (i + j + k != 1000)
                        {
                            continue;
                        }

                        var k2 = k * k;
                        var j2 = j * j;
                        var i2 = i * i;
                        if (i2 + j2 == k2)
                        {
                            this.Print("{0}, {1}, {2}", i, j, k);
                            return i * j * k;
                        }                        
                    }
                }
            }

            throw new Exception();
        }
    }
}