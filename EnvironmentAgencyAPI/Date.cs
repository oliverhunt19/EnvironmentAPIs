using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentAgencyAPI
{
    public struct Date
    {
        DateTime date;

        public Date(DateTime date)
        {
            this.date = date.Date;
        }

        public Date(int year, int month, int day)
        {
            date = new DateTime(year, month, day);
        }

        public DateTime ToDateTime()
        {
            return date;
        }

        public Date AddDays(double days)
        {
            return new Date( date.AddDays(days));
        }

        public Date AddMonths(int months)
        {
            return new Date(date.AddMonths(months));
        }

        public Date AddYears(int years)
        {
            return new Date(date.AddYears(years));
        }

        public Date Add(int years, int month, double day)
        {
            return new Date(date.AddYears(years).AddMonths(month).AddDays(day));
        }
    }

    public struct Days
    {
        TimeSpan days;

        public Days()
        {
            days = TimeSpan.Zero;
        }

        public TimeSpan ToTimeSpan()
        {
            return days;
        }
    }
}
