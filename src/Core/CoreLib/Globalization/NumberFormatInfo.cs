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

        [IntrinsicProperty]
        [ScriptName("nan")]
        public string NaNSymbol {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("neg")]
        public string NegativeSign {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("pos")]
        public string PositiveSign {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("negInf")]
        public string NegativeInfinityText {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("posInf")]
        public string PositiveInfinityText {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("per")]
        public string PercentSymbol {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("perGW")]
        public int[] PercentGroupSizes {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("perDD")]
        public int PercentDecimalDigits {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        [ScriptName("perDS")]
        public string PercentDecimalSeparator {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("perGS")]
        public string PercentGroupSeparator {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("perNP")]
        public string PercentNegativePattern {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("perPP")]
        public string PercentPositivePattern {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("cur")]
        public string CurrencySymbol {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("curGW")]
        public int[] CurrencyGroupSizes {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("curDD")]
        public int CurrencyDecimalDigits {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        [ScriptName("curDS")]
        public string CurrencyDecimalSeparator {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("curGS")]
        public string CurrencyGroupSeparator {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("curNP")]
        public string CurrencyNegativePattern {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("curPP")]
        public string CurrencyPositivePattern {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("gw")]
        public int[] NumberGroupSizes {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("dd")]
        public int NumberDecimalDigits {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        [ScriptName("ds")]
        public string NumberDecimalSeparator {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("gs")]
        public string NumberGroupSeparator {
            get {
                return null;
            }
        }
    }
}
