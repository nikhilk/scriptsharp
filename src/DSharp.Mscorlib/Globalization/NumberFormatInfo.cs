using System.Runtime.CompilerServices;
using DSharp;

namespace System.Globalization
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class NumberFormatInfo
    {
        private NumberFormatInfo() { }

        [ScriptField]
        [ScriptName("nan")]
        public extern string NaNSymbol { get; }

        [ScriptField]
        [ScriptName("neg")]
        public extern string NegativeSign { get; }

        [ScriptField]
        [ScriptName("pos")]
        public extern string PositiveSign { get; }

        [ScriptField]
        [ScriptName("negInf")]
        public extern string NegativeInfinityText { get; }

        [ScriptField]
        [ScriptName("posInf")]
        public extern string PositiveInfinityText { get; }

        [ScriptField]
        [ScriptName("per")]
        public extern string PercentSymbol { get; }

        [ScriptField]
        [ScriptName("perGW")]
        public extern int[] PercentGroupSizes { get; }

        [ScriptField]
        [ScriptName("perDD")]
        public extern int PercentDecimalDigits { get; }

        [ScriptField]
        [ScriptName("perDS")]
        public extern string PercentDecimalSeparator { get; }

        [ScriptField]
        [ScriptName("perGS")]
        public extern string PercentGroupSeparator { get; }

        [ScriptField]
        [ScriptName("perNP")]
        public extern string PercentNegativePattern { get; }

        [ScriptField]
        [ScriptName("perPP")]
        public extern string PercentPositivePattern { get; }

        [ScriptField]
        [ScriptName("cur")]
        public extern string CurrencySymbol { get; }

        [ScriptField]
        [ScriptName("curGW")]
        public extern int[] CurrencyGroupSizes { get; }

        [ScriptField]
        [ScriptName("curDD")]
        public extern int CurrencyDecimalDigits { get; }

        [ScriptField]
        [ScriptName("curDS")]
        public extern string CurrencyDecimalSeparator { get; }

        [ScriptField]
        [ScriptName("curGS")]
        public extern string CurrencyGroupSeparator { get; }

        [ScriptField]
        [ScriptName("curNP")]
        public extern string CurrencyNegativePattern { get; }

        [ScriptField]
        [ScriptName("curPP")]
        public extern string CurrencyPositivePattern { get; }

        [ScriptField]
        [ScriptName("gw")]
        public extern int[] NumberGroupSizes { get; }

        [ScriptField]
        [ScriptName("dd")]
        public extern int NumberDecimalDigits { get; }

        [ScriptField]
        [ScriptName("ds")]
        public extern string NumberDecimalSeparator { get; }

        [ScriptField]
        [ScriptName("gs")]
        public extern string NumberGroupSeparator { get; }
    }
}
