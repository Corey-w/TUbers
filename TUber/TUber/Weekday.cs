using System;
using System.Collections.Generic;
using System.Text;

namespace TUber
{
    public enum Weekday
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4
    }

    public static class WeekdayMethods
    {
        public static Weekday StringtoWeekday(string day)
        {
            switch (day)
            {
                case "monday":
                    return Weekday.Monday;

                case "tuesday":
                    return Weekday.Tuesday;

                case "wednesday":
                    return Weekday.Wednesday;

                case "thursday":
                    return Weekday.Thursday;

                case "friday":
                    return Weekday.Friday;

                default:
                    return Weekday.Monday;
            }
        }
    }
}
