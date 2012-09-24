namespace Euler
{
    using System;

    internal class Problem19 : EulerProblem
    {
        public Problem19(Printing printing)
            : base(printing)
        {
        }

        protected override long GetCalculationResult()
        {
            int sundays = 0;
            for (int year = 1901; year < 2001; year++)
            {
                for (int month = 1; month < 13; month++)
                {
                    var date = DateTime.Parse(string.Format("{0}-{1}-01", year, month));
                    if (date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        sundays++;
                    }
                }
            }

            return sundays;
        }
    }
}