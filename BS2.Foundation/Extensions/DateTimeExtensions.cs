using System;
using System.Collections.Generic;

namespace BS2.Foundation.Extensions
{
    public static class DateTimeExtensions
    {
        public static int LastDayOfMonth(this DateTime date)
        {
            var nextMonth = new DateTime(date.Year, date.Month + 1, 1);
            return nextMonth.AddDays(-1).Day;
        }

        public static DateTime FirstDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static IEnumerable<DateTime> GetAllMonthsUntil(this DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("Data inicial maior que data final.");
            }

            var halfStartDate = new DateTime(startDate.Year, startDate.Month, 15);
            var halfEndDate = new DateTime(endDate.Year, endDate.Month, 15);

            do
            {
                yield return halfStartDate.FirstDayOfMonth();
                halfStartDate = halfStartDate.AddMonths(1);
            } while (halfStartDate <= halfEndDate);
        }

        public static DateTime GetPreviousMonthPeriod(this DateTime value, DateTime startDate, DateTime endDate)
        {
            var monthsDiff = endDate.Subtract(startDate).Days / 30;

            if (monthsDiff == 0)
            {
                monthsDiff = 1;
            }

            return value.AddMonths(-monthsDiff);
        }

        // TODO: verificar as extensões do DateTime
        public static DateTime FirstOfYear(this DateTime dateTime)
            => new DateTime(dateTime.Year, 1, 1, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);

        public static DateTime LastDayOfYear(this DateTime dateTime)
            => new DateTime(dateTime.Year, 12, 31, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
    }
}