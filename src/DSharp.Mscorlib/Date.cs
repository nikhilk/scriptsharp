using System.Runtime.CompilerServices;

namespace System
{
    //TODO: Move to javascript library
    /// <summary>
    /// Equivalent to the Date type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class Date
    {
        /// <summary>
        /// Creates a new instance of Date initialized from the current time.
        /// </summary>
        public Date() { }

        /// <summary>
        /// Creates a new instance of Date initialized from the specified number of milliseconds.
        /// </summary>
        /// <param name="milliseconds">Milliseconds since January 1st, 1970.</param>
        public Date(int milliseconds) { }

        /// <summary>
        /// Creates a new instance of Date initialized from parsing the specified date.
        /// </summary>
        /// <param name="date"></param>
        public Date(string date) { }

        /// <summary>
        /// Creates a new instance of Date.
        /// </summary>
        /// <param name="year">The full year.</param>
        /// <param name="month">The month (0 through 11)</param>
        /// <param name="date">The day of the month (1 through # of days in the specified month)</param>
        public Date(int year, int month, int date) { }

        /// <summary>
        /// Creates a new instance of Date.
        /// </summary>
        /// <param name="year">The full year.</param>
        /// <param name="month">The month (0 through 11)</param>
        /// <param name="date">The day of the month (1 through # of days in the specified month)</param>
        /// <param name="hours">The hours (0 through 23)</param>
        public Date(int year, int month, int date, int hours) { }

        /// <summary>
        /// Creates a new instance of Date.
        /// </summary>
        /// <param name="year">The full year.</param>
        /// <param name="month">The month (0 through 11)</param>
        /// <param name="date">The day of the month (1 through # of days in the specified month)</param>
        /// <param name="hours">The hours (0 through 23)</param>
        /// <param name="minutes">The minutes (0 through 59)</param>
        public Date(int year, int month, int date, int hours, int minutes) { }

        /// <summary>
        /// Creates a new instance of Date.
        /// </summary>
        /// <param name="year">The full year.</param>
        /// <param name="month">The month (0 through 11)</param>
        /// <param name="date">The day of the month (1 through # of days in the specified month)</param>
        /// <param name="hours">The hours (0 through 23)</param>
        /// <param name="minutes">The minutes (0 through 59)</param>
        /// <param name="seconds">The seconds (0 through 59)</param>
        public Date(int year, int month, int date, int hours, int minutes, int seconds) { }

        /// <summary>
        /// Creates a new instance of Date.
        /// </summary>
        /// <param name="year">The full year.</param>
        /// <param name="month">The month (0 through 11)</param>
        /// <param name="date">The day of the month (1 through # of days in the specified month)</param>
        /// <param name="hours">The hours (0 through 23)</param>
        /// <param name="minutes">The minutes (0 through 59)</param>
        /// <param name="seconds">The seconds (0 through 59)</param>
        /// <param name="milliseconds">The milliseconds (0 through 999)</param>
        public Date(int year, int month, int date, int hours, int minutes, int seconds, int milliseconds) { }

        /// <summary>
        /// Returns the current date and time.
        /// </summary>
        [ScriptField]
        [DSharpScriptMemberName("now()")]
        public extern static Date Now { get; }

        /// <summary>
        /// Returns the current date with the time part set to 00:00:00.
        /// </summary>
        [ScriptField]
        [DSharpScriptMemberName("today")]
        public static Date Today { get; }

        public extern int GetDate();

        public extern int GetDay();

        public extern int GetFullYear();

        public extern int GetHours();

        public extern int GetMilliseconds();

        public extern int GetMinutes();

        public extern int GetMonth();

        public extern int GetSeconds();

        public extern int GetTime();

        public extern int GetTimezoneOffset();

        public extern int GetUTCDate();

        public extern int GetUTCDay();

        public extern int GetUTCFullYear();

        public extern int GetUTCHours();

        public extern int GetUTCMilliseconds();

        public extern int GetUTCMinutes();

        public extern int GetUTCMonth();

        public extern int GetUTCSeconds();

        [DSharpScriptMemberName("date")]
        public extern static Date Parse(string value);

        public extern void SetDate(int date);

        public extern void SetFullYear(int year);

        public extern void SetFullYear(int year, int month);

        public extern void SetFullYear(int year, int month, int day);

        public extern void SetHours(int hours);

        public extern void SetMilliseconds(int milliseconds);

        public extern void SetMinutes(int minutes);

        public extern void SetMonth(int month);

        public extern void SetSeconds(int seconds);

        public extern void SetTime(int milliseconds);

        public extern void SetUTCDate(int date);

        public extern void SetUTCFullYear(int year);

        public extern void SetUTCHours(int hours);

        public extern void SetUTCMilliseconds(int milliseconds);

        public extern void SetUTCMinutes(int minutes);

        public extern void SetUTCMonth(int month);

        public extern void SetUTCSeconds(int seconds);

        public extern void SetYear(int year);

        public extern string ToDateString();

        public extern string ToISOString();

        public extern string ToLocaleDateString();

        public extern string ToLocaleTimeString();

        public extern string ToTimeString();

        public extern string ToUTCString();

        [ScriptName(PreserveCase = true)]
        public extern static int UTC(int year, int month, int day);

        [ScriptName(PreserveCase = true)]
        public extern static int UTC(int year, int month, int day, int hours);

        [ScriptName(PreserveCase = true)]
        public extern static int UTC(int year, int month, int day, int hours, int minutes);

        [ScriptName(PreserveCase = true)]
        public extern static int UTC(int year, int month, int day, int hours, int minutes, int seconds);

        [ScriptName(PreserveCase = true)]
        public extern static int UTC(int year, int month, int day, int hours, int minutes, int seconds, int milliseconds);

        // NOTE: There is no + operator since in JavaScript that returns the
        //       concatenation of the date strings, which is pretty much useless.

        /// <summary>
        /// Returns the difference in milliseconds between two dates.
        /// </summary>
        [ScriptIgnore]
        public extern static int operator -(Date a, Date b);

        /// <summary>
        /// Compares two dates
        /// </summary>
        [ScriptIgnore]
        public extern static bool operator ==(Date a, Date b);

        /// <summary>
        /// Compares two dates
        /// </summary>
        [ScriptIgnore]
        public extern static bool operator !=(Date a, Date b);

        /// <summary>
        /// Compares two dates
        /// </summary>
        [ScriptIgnore]
        public extern static bool operator <(Date a, Date b);

        /// <summary>
        /// Compares two dates
        /// </summary>
        [ScriptIgnore]
        public extern static bool operator >(Date a, Date b);

        /// <summary>
        /// Compares two dates
        /// </summary>
        [ScriptIgnore]
        public extern static bool operator <=(Date a, Date b);

        /// <summary>
        /// Compares two dates
        /// </summary>
        [ScriptIgnore]
        public extern static bool operator >=(Date a, Date b);
    }
}
