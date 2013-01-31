// Globalize.cs
// Script#/Libraries/jQuery/Globalize
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Html;
using System.Net;
using System.Runtime.CompilerServices;

namespace jQueryApi.Globalize {

    /// <summary>
    /// Provides access to jQuery Globalize APIs.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Globalize")]
    public static class Globalize {

        /// <summary>
        /// Formats a number according to the format pattern specified.
        /// </summary>
        /// <param name="value">The number to be formatted.</param>
        /// <param name="format">The format pattern to format the number.</param>
        /// <returns>A string containing the formatted version of the provided number.</returns>
        public static string Format(Number value, string format) {
            return null;
        }

        /// <summary>
        /// Formats a number according to the format pattern specified.
        /// </summary>
        /// <param name="value">The number to be formatted.</param>
        /// <param name="format">The format pattern to format the number.</param>
        /// <param name="culture">The culture for which to apply the format pattern.</param>
        /// <returns>A string containing the formatted version of the provided number.</returns>
        public static string Format(Number value, string format, string culture) {
            return null;
        }

        /// <summary>
        /// Formats a date according to the format pattern specified.
        /// </summary>
        /// <param name="value">The date to be formatted.</param>
        /// <param name="format">The format pattern to format the date.</param>
        /// <returns>A string containing the formatted version of the provided date.</returns>
        public static string Format(Date value, string format) {
            return null;
        }

        /// <summary>
        /// Formats a date according to the format pattern specified.
        /// </summary>
        /// <param name="value">The date to be formatted.</param>
        /// <param name="format">The format pattern to format the date.</param>
        /// <param name="culture">The culture for which to apply the format pattern.</param>
        /// <returns>A string containing the formatted version of the provided date.</returns>
        public static string Format(Date value, string format, string culture) {
            return null;
        }

        /// <summary>
        /// Parses a float value from a given string.
        /// </summary>
        /// <param name="value">The string from which to parse the floating point value.</param>
        /// <returns>The floating point value represented by the given string.</returns>
        public static Number ParseFloat(string value) {
            return null;
        }

        /// <summary>
        /// Parses a float value from a given string.
        /// </summary>
        /// <param name="value">The string from which to parse the floating point value.</param>
        /// <param name="radix">The base in which to interpret the floating point value.</param>
        /// <returns>The floating point value represented by the given string.</returns>
        public static Number ParseFloat(string value, int radix) {
            return null;
        }

        /// <summary>
        /// Parses a float value from a given string.
        /// </summary>
        /// <param name="value">The string from which to parse the floating point value.</param>
        /// <param name="radix">The base in which to interpret the floating point value.</param>
        /// <param name="culture">The culture in which to interpret the floating point value.</param>
        /// <returns>The floating point value represented by the given string.</returns>
        public static Number ParseFloat(string value, int radix, string culture) {
            return null;
        }

        /// <summary>
        /// Parses an integer value from a given string.
        /// </summary>
        /// <param name="value">The string from which to parse the integer value.</param>
        /// <returns>The integer value represented by the given string.</returns>
        public static int ParseInt(string value) {
            return 0;
        }

        /// <summary>
        /// Parses an integer value from a given string.
        /// </summary>
        /// <param name="value">The string from which to parse the integer value.</param>
        /// <param name="radix">The base in which to interpret the integer value.</param>
        /// <returns>The integer value represented by the given string.</returns>
        public static int ParseInt(string value, int radix) {
            return 0;
        }

        /// <summary>
        /// Parses an integer value from a given string.
        /// </summary>
        /// <param name="value">The string from which to parse the integer value.</param>
        /// <param name="radix">The base in which to interpret the integer value.</param>
        /// <param name="culture">The culture in which to interpret the integer value.</param>
        /// <returns>The integer value represented by the given string.</returns>
        public static int ParseInt(string value, int radix, string culture) {
            return 0;
        }

        /// <summary>
        /// Parses an date value from a given string.
        /// </summary>
        /// <param name="value">The string from which to parse the date.</param>
        /// <returns>The date represented by the given string.</returns>
        public static Date ParseDate(string value) {
            return null;
        }

        /// <summary>
        /// Parses an date value from a given string.
        /// </summary>
        /// <param name="value">The string from which to parse the date.</param>
        /// <param name="formats">The set of potential formats in which the date may be formatted.</param>
        /// <returns>The date represented by the given string.</returns>
        public static Date ParseDate(string value, string formats) {
            return null;
        }

        /// <summary>
        /// Parses an date value from a given string.
        /// </summary>
        /// <param name="value">The string from which to parse the date.</param>
        /// <param name="formats">The set of potential formats in which the date may be formatted.</param>
        /// <param name="culture">The culture in which to interpret the date.</param>
        /// <returns>The date represented by the given string.</returns>
        public static Date ParseDate(string value, string[] formats, string culture) {
            return null;
        }
     }
}
