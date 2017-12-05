// NumberFormatInfo.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Globalization {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class NumberFormatInfo {

        private NumberFormatInfo() {
        }

        [ScriptField]
        [ScriptName("nan")]
        public string NaNSymbol {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("neg")]
        public string NegativeSign {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("pos")]
        public string PositiveSign {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("negInf")]
        public string NegativeInfinityText {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("posInf")]
        public string PositiveInfinityText {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("per")]
        public string PercentSymbol {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("perGW")]
        public int[] PercentGroupSizes {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("perDD")]
        public int PercentDecimalDigits {
            get {
                return 0;
            }
        }

        [ScriptField]
        [ScriptName("perDS")]
        public string PercentDecimalSeparator {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("perGS")]
        public string PercentGroupSeparator {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("perNP")]
        public string PercentNegativePattern {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("perPP")]
        public string PercentPositivePattern {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("cur")]
        public string CurrencySymbol {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("curGW")]
        public int[] CurrencyGroupSizes {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("curDD")]
        public int CurrencyDecimalDigits {
            get {
                return 0;
            }
        }

        [ScriptField]
        [ScriptName("curDS")]
        public string CurrencyDecimalSeparator {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("curGS")]
        public string CurrencyGroupSeparator {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("curNP")]
        public string CurrencyNegativePattern {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("curPP")]
        public string CurrencyPositivePattern {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("gw")]
        public int[] NumberGroupSizes {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("dd")]
        public int NumberDecimalDigits {
            get {
                return 0;
            }
        }

        [ScriptField]
        [ScriptName("ds")]
        public string NumberDecimalSeparator {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("gs")]
        public string NumberGroupSeparator {
            get {
                return null;
            }
        }
    }
}
