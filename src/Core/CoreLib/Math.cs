// Math.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// Equivalent to the Math object in Javascript.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public static class Math {

        [PreserveCase]
        public static double E;

        [PreserveCase]
        public static double LN2;

        [PreserveCase]
        public static double LN10;

        [PreserveCase]
        public static double LOG2E;

        [PreserveCase]
        public static double LOG10E;

        [PreserveCase]
        public static double PI;

        [PreserveCase]
        public static double SQRT1_2;

        [PreserveCase]
        public static double SQRT2;

        public static Number Abs(Number n) {
            return 0;
        }

        public static Number Acos(Number n) {
            return 0;
        }

        public static Number Asin(Number n) {
            return 0;
        }

        public static Number Atan(Number n) {
            return 0;
        }

        public static Number Atan2(Number x, Number y) {
            return 0;
        }

        public static Number Ceil(Number n) {
            return 0;
        }

        public static Number Cos(Number n) {
            return 0;
        }

        public static Number Exp(Number n) {
            return 0;
        }

        public static Number Floor(Number n) {
            return 0;
        }

        public static Number Log(Number n) {
            return 0;
        }

        public static Number Max(params Number[] numbers) {
            return 0;
        }

        public static Number Min(params Number[] numbers) {
            return 0;
        }

        public static Number Pow(Number baseNumber, Number exponent) {
            return 0;
        }

        public static Number Random() {
            return 0;
        }

        public static Number Round(Number n) {
            return 0;
        }

        public static Number Sin(Number n) {
            return 0;
        }

        public static Number Sqrt(Number n) {
            return 0;
        }

        public static Number Tan(Number n) {
            return 0;
        }

        [ScriptAlias("ss.truncate")]
        public static int Truncate(Number n) {
            return 0;
        }

        [ScriptAlias("ss.truncate")]
        public static int Truncate(double n) {
            return 0;
        }

        [ScriptAlias("ss.truncate")]
        public static int Truncate(float n) {
            return 0;
        }
    }
}
