using System.Runtime.CompilerServices;

namespace System
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Date")]
    public struct DateTime
    {
        public extern static implicit operator Date(DateTime d);

        public extern static implicit operator DateTime(Date d);

        [ScriptField]
        [ScriptAlias("ss.DateTime.Now")]
        public extern static DateTime Now { get; }

        [ScriptField]
        [ScriptAlias("ss.DateTime.Today")]
        public extern static DateTime Today { get; }

        [ScriptAlias("ss.DateTime.Equals")]
        public extern static bool Equals(DateTime d1, DateTime d2);

        public DateTime(int year, int month, int day) { }

        public DateTime(int year, int month, int day, int hour, int minute, int second) { }

        public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond) { }

        public extern DayOfWeek DayOfWeek
        {
            [ScriptAlias("ss.DateTime.DayOfWeek")]
            get;
        }

        [ScriptAlias("ss.DateTime.AddMilliseconds")]
        public extern DateTime AddMilliseconds(double value);

        [ScriptAlias("ss.DateTime.AddSeconds")]
        public extern DateTime AddSeconds(double value);

        [ScriptAlias("ss.DateTime.AddMinutes")]
        public extern DateTime AddMinutes(double value);

        [ScriptAlias("ss.DateTime.AddHours")]
        public extern DateTime AddHours(double value);

        [ScriptAlias("ss.DateTime.AddDays")]
        public extern DateTime AddDays(double value);

        [ScriptAlias("ss.DateTime.ToLongDateString")]
        public extern string ToLongDateString();

        [ScriptAlias("ss.DateTime.ToLongTimeString")]
        public extern string ToLongTimeString();

        [ScriptAlias("ss.DateTime.ToShortDateString")]
        public extern string ToShortDateString();

        [ScriptAlias("ss.DateTime.ToShortTimeString")]
        public extern string ToShortTimeString();

        [ScriptAlias("ss.DateTime.ToStringFormatted")]
        public override extern string ToString();

        [ScriptAlias("ss.DateTime.ToStringFormatted")]
        public extern string ToString(string format);
    }
}
