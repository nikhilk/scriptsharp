// DateFormatInfo.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Globalization {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class DateFormatInfo {

        private DateFormatInfo() {
        }

        [ScriptField]
        [ScriptName("am")]
        public string AMDesignator {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("pm")]
        public string PMDesignator {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("ds")]
        public string DateSeparator {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("ts")]
        public string TimeSeparator {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("gmt")]
        public string GMTDateTimePattern {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("uni")]
        public string UniversalDateTimePattern {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("sort")]
        public string SortableDateTimePattern {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("dt")]
        public string DateTimePattern {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("ld")]
        public string LongDatePattern {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("sd")]
        public string ShortDatePattern {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("lt")]
        public string LongTimePattern {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("st")]
        public string ShortTimePattern {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("day0")]
        public int FirstDayOfWeek {
            get {
                return 0;
            }
        }

        [ScriptField]
        [ScriptName("day")]
        public string[] DayNames {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("sday")]
        public string[] ShortDayNames {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("mday")]
        public string[] MinimizedDayNames {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("mon")]
        public string[] MonthNames {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("smon")]
        public string[] ShortMonthNames {
            get {
                return null;
            }
        }
    }
}
