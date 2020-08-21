using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Testing;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace DateTimeTest
{
    public class TestClass
    {
        public TestClass()
        {
            Date jsDate = new Date();
            DateTime dateTime;

            // Implicitly convertible
            dateTime = jsDate;
            jsDate = dateTime;

            // DateTime constructors
            dateTime = new DateTime(2019, 12, 24);
            dateTime = new DateTime(2019, 12, 24, 23, 45, 0);
            dateTime = new DateTime(2019, 12, 24, 23, 45, 0, 2);

            // DayOfWeek
            DayOfWeek dayOfWeek = dateTime.DayOfWeek;
            bool enumComparison = dayOfWeek == DayOfWeek.Saturday;

            // Year
            int year = dateTime.Year;

            // Month
            int month = dateTime.Month;

            // Day
            int day = dateTime.Day;

            // Hour
            int hour = dateTime.Hour;

            // Minute
            int minute = dateTime.Minute;

            // Second
            int second = dateTime.Second;

            // Millisecond
            int millisecond = dateTime.Millisecond;

            // Now
            dateTime = DateTime.Now;

            // Today
            dateTime = DateTime.Today;

            // AddMilliseconds
            dateTime = dateTime.AddMilliseconds(123);

            // AddSeconds
            dateTime = dateTime.AddSeconds(4);

            // AddMinutes
            dateTime = dateTime.AddMinutes(10);

            // AddHours
            dateTime = dateTime.AddHours(1);

            // AddDays
            dateTime = dateTime.AddDays(2);

            // ToLongDateString
            string longDate = dateTime.ToLongDateString();

            // ToLongTimeString
            string longTime = dateTime.ToLongTimeString();

            // ToShortDateString
            string shortDate = dateTime.ToShortDateString();

            // ToShortTimeString
            string shortTime = dateTime.ToShortTimeString();

            // ToString
            string toString = dateTime.ToString();

            // ToFormattedString
            string formattedString = dateTime.ToString("");

            // Parse
            DateTime parsedDate = DateTime.Parse("");

            // Not equal
            bool notEqual = dateTime != parsedDate;

            // Greater than
            bool greaterThan = dateTime > parsedDate;

            // Greater or equal
            bool greaterOrEqual = dateTime >= parsedDate;

            // Lesser than
            bool lesserThan = dateTime < parsedDate;

            // Lesser or equal
            bool lesserOrEqual = dateTime < parsedDate;

            // IEquatable
            bool isEqual = dateTime.Equals(dateTime);

            // IComparable
            int comparison = dateTime.CompareTo(dateTime);
        }
    }
}
