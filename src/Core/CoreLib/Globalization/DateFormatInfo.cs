// DateFormatInfo.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Globalization {

    [IgnoreNamespace]
    [Imported]
    public sealed class DateFormatInfo {

        private DateFormatInfo() {
        }

        [ScriptProperty]
        [ScriptName("am")]
        public string AMDesignator {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("pm")]
        public string PMDesignator {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("ds")]
        public string DateSeparator {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("ts")]
        public string TimeSeparator {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("gmt")]
        public string GMTDateTimePattern {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("uni")]
        public string UniversalDateTimePattern {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("sort")]
        public string SortableDateTimePattern {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("dt")]
        public string DateTimePattern {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("ld")]
        public string LongDatePattern {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("sd")]
        public string ShortDatePattern {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("lt")]
        public string LongTimePattern {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("st")]
        public string ShortTimePattern {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("day0")]
        public int FirstDayOfWeek {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        [ScriptName("day")]
        public string[] DayNames {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("sday")]
        public string[] ShortDayNames {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("mday")]
        public string[] MinimizedDayNames {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("mon")]
        public string[] MonthNames {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("smon")]
        public string[] ShortMonthNames {
            get {
                return null;
            }
        }
    }
}
