using System.Runtime.CompilerServices;
using DSharp;

namespace System.Globalization
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class DateFormatInfo
    {
        private DateFormatInfo() { }

        [ScriptField]
        [ScriptName("am")]
        public string AMDesignator { get; }

        [ScriptField]
        [ScriptName("pm")]
        public extern string PMDesignator { get; }

        [ScriptField]
        [ScriptName(DSharpStringResources.ASSEMBLY_NAME)]
        public extern string DateSeparator { get; }

        [ScriptField]
        [ScriptName("ts")]
        public extern string TimeSeparator { get; }

        [ScriptField]
        [ScriptName("gmt")]
        public extern string GMTDateTimePattern { get; }

        [ScriptField]
        [ScriptName("uni")]
        public extern string UniversalDateTimePattern { get; }

        [ScriptField]
        [ScriptName("sort")]
        public extern string SortableDateTimePattern { get; }

        [ScriptField]
        [ScriptName("dt")]
        public extern string DateTimePattern { get; }

        [ScriptField]
        [ScriptName("ld")]
        public extern string LongDatePattern { get; }

        [ScriptField]
        [ScriptName("sd")]
        public extern string ShortDatePattern { get; }

        [ScriptField]
        [ScriptName("lt")]
        public extern string LongTimePattern { get; }

        [ScriptField]
        [ScriptName("st")]
        public extern string ShortTimePattern { get; }

        [ScriptField]
        [ScriptName("day0")]
        public extern int FirstDayOfWeek { get; }

        [ScriptField]
        [ScriptName("day")]
        public extern string[] DayNames { get; }

        [ScriptField]
        [ScriptName("sday")]
        public extern string[] ShortDayNames { get; }

        [ScriptField]
        [ScriptName("mday")]
        public extern string[] MinimizedDayNames { get; }

        [ScriptField]
        [ScriptName("mon")]
        public extern string[] MonthNames { get; }

        [ScriptField]
        [ScriptName("smon")]
        public extern string[] ShortMonthNames { get; }
    }
}
