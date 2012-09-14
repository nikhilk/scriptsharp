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

        [IntrinsicProperty]
        [ScriptName("am")]
        public string AMDesignator {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("pm")]
        public string PMDesignator {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("ds")]
        public string DateSeparator {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("ts")]
        public string TimeSeparator {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("gmt")]
        public string GMTDateTimePattern {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("uni")]
        public string UniversalDateTimePattern {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("sort")]
        public string SortableDateTimePattern {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("dt")]
        public string DateTimePattern {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("ld")]
        public string LongDatePattern {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("sd")]
        public string ShortDatePattern {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("lt")]
        public string LongTimePattern {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("st")]
        public string ShortTimePattern {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("day0")]
        public int FirstDayOfWeek {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        [ScriptName("day")]
        public string[] DayNames {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("sday")]
        public string[] ShortDayNames {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("mday")]
        public string[] MinimizedDayNames {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("mon")]
        public string[] MonthNames {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("smon")]
        public string[] ShortMonthNames {
            get {
                return null;
            }
        }
    }
}
