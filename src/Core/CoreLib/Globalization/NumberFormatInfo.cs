// NumberFormatInfo.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Globalization {

    [IgnoreNamespace]
    [Imported]
    public sealed class NumberFormatInfo {

        private NumberFormatInfo() {
        }

        [ScriptProperty]
        [ScriptName("nan")]
        public string NaNSymbol {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("neg")]
        public string NegativeSign {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("pos")]
        public string PositiveSign {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("negInf")]
        public string NegativeInfinityText {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("posInf")]
        public string PositiveInfinityText {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("per")]
        public string PercentSymbol {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("perGW")]
        public int[] PercentGroupSizes {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("perDD")]
        public int PercentDecimalDigits {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        [ScriptName("perDS")]
        public string PercentDecimalSeparator {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("perGS")]
        public string PercentGroupSeparator {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("perNP")]
        public string PercentNegativePattern {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("perPP")]
        public string PercentPositivePattern {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("cur")]
        public string CurrencySymbol {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("curGW")]
        public int[] CurrencyGroupSizes {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("curDD")]
        public int CurrencyDecimalDigits {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        [ScriptName("curDS")]
        public string CurrencyDecimalSeparator {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("curGS")]
        public string CurrencyGroupSeparator {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("curNP")]
        public string CurrencyNegativePattern {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("curPP")]
        public string CurrencyPositivePattern {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("gw")]
        public int[] NumberGroupSizes {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("dd")]
        public int NumberDecimalDigits {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        [ScriptName("ds")]
        public string NumberDecimalSeparator {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("gs")]
        public string NumberGroupSeparator {
            get {
                return null;
            }
        }
    }
}
