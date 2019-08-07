using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Equivalent to the Math object in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public static class Math
    {
        [ScriptName(PreserveCase = true)]
        public static double E;

        [ScriptName(PreserveCase = true)]
        public static double LN2;

        [ScriptName(PreserveCase = true)]
        public static double LN10;

        [ScriptName(PreserveCase = true)]
        public static double LOG2E;

        [ScriptName(PreserveCase = true)]
        public static double LOG10E;

        [ScriptName(PreserveCase = true)]
        public static double PI;

        [ScriptName(PreserveCase = true)]
        public static double SQRT1_2;

        [ScriptName(PreserveCase = true)]
        public static double SQRT2;

        public extern static Number Abs(Number n);

        public extern static Number Acos(Number n);

        public extern static Number Asin(Number n);

        public extern static Number Atan(Number n);

        public extern static Number Atan2(Number x, Number y);

        public extern static Number Ceil(Number n);

        public extern static Number Cos(Number n);

        public extern static Number Exp(Number n);

        public extern static Number Floor(Number n);

        public extern static Number Log(Number n);

        public extern static Number Max(params Number[] numbers);

        public extern static Number Min(params Number[] numbers);

        public extern static Number Pow(Number baseNumber, Number exponent);

        public extern static Number Random();

        public extern static Number Round(Number n);

        public extern static Number Sin(Number n);

        public extern static Number Sqrt(Number n);

        public extern static Number Tan(Number n);

        [DSharpScriptMemberName("truncate")]
        public extern static int Truncate(Number n);

        [DSharpScriptMemberName("truncate")]
        public extern static int Truncate(double n);

        [DSharpScriptMemberName("truncate")]
        public extern static int Truncate(float n);
    }
}
