// DateTime.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// Equivalent to the Date type in Javascript.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    [ScriptName("Date")]
    public struct DateTime {

        /// <summary>
        /// Represents a null date.
        /// </summary>
        public static readonly DateTime Empty;

        /// <summary>
        /// Creates a new instance of DateTime initialized from the specified number of milliseconds.
        /// </summary>
        /// <param name="milliseconds">Milliseconds since January 1st, 1970.</param>
        public DateTime(int milliseconds) {
        }

        /// <summary>
        /// Creates a new instance of DateTime initialized from parsing the specified date.
        /// </summary>
        /// <param name="date"></param>
        public DateTime(string date) {
        }

        /// <summary>
        /// Creates a new instance of DateTime.
        /// </summary>
        /// <param name="year">The full year.</param>
        /// <param name="month">The month (0 through 11)</param>
        /// <param name="date">The day of the month (1 through # of days in the specified month)</param>
        public DateTime(int year, int month, int date) {
        }

        /// <summary>
        /// Creates a new instance of DateTime.
        /// </summary>
        /// <param name="year">The full year.</param>
        /// <param name="month">The month (0 through 11)</param>
        /// <param name="date">The day of the month (1 through # of days in the specified month)</param>
        /// <param name="hours">The hours (0 through 23)</param>
        public DateTime(int year, int month, int date, int hours) {
        }

        /// <summary>
        /// Creates a new instance of DateTime.
        /// </summary>
        /// <param name="year">The full year.</param>
        /// <param name="month">The month (0 through 11)</param>
        /// <param name="date">The day of the month (1 through # of days in the specified month)</param>
        /// <param name="hours">The hours (0 through 23)</param>
        /// <param name="minutes">The minutes (0 through 59)</param>
        public DateTime(int year, int month, int date, int hours, int minutes) {
        }

        /// <summary>
        /// Creates a new instance of DateTime.
        /// </summary>
        /// <param name="year">The full year.</param>
        /// <param name="month">The month (0 through 11)</param>
        /// <param name="date">The day of the month (1 through # of days in the specified month)</param>
        /// <param name="hours">The hours (0 through 23)</param>
        /// <param name="minutes">The minutes (0 through 59)</param>
        /// <param name="seconds">The seconds (0 through 59)</param>
        public DateTime(int year, int month, int date, int hours, int minutes, int seconds) {
        }

        /// <summary>
        /// Creates a new instance of DateTime.
        /// </summary>
        /// <param name="year">The full year.</param>
        /// <param name="month">The month (0 through 11)</param>
        /// <param name="date">The day of the month (1 through # of days in the specified month)</param>
        /// <param name="hours">The hours (0 through 23)</param>
        /// <param name="minutes">The minutes (0 through 59)</param>
        /// <param name="seconds">The seconds (0 through 59)</param>
        /// <param name="milliseconds">The milliseconds (0 through 999)</param>
        public DateTime(int year, int month, int date, int hours, int minutes, int seconds, int milliseconds) {
        }

        /// <summary>
        /// Returns the current date and time.
        /// </summary>
        public static DateTime Now {
            get {
                return default(DateTime);
            }
        }

        /// <summary>
        /// Returns the current date with the time part set to 00:00:00.
        /// </summary>
        public static DateTime Today {
            get {
                return default(DateTime);
            }
        }

        public string Format(string format) {
            return null;
        }

        public int GetDate() {
            return 0;
        }

        public int GetDay() {
            return 0;
        }

        public int GetFullYear() {
            return 0;
        }

        public int GetHours() {
            return 0;
        }

        public int GetMilliseconds() {
            return 0;
        }

        public int GetMinutes() {
            return 0;
        }

        public int GetMonth() {
            return 0;
        }

        public int GetSeconds() {
            return 0;
        }

        public int GetTime() {
            return 0;
        }

        public int GetTimezoneOffset() {
            return 0;
        }

        public int GetUTCDate() {
            return 0;
        }

        public int GetUTCDay() {
            return 0;
        }

        public int GetUTCFullYear() {
            return 0;
        }

        public int GetUTCHours() {
            return 0;
        }

        public int GetUTCMilliseconds() {
            return 0;
        }

        public int GetUTCMinutes() {
            return 0;
        }

        public int GetUTCMonth() {
            return 0;
        }

        public int GetUTCSeconds() {
            return 0;
        }

        public static bool IsEmpty(DateTime d) {
            return false;
        }

        public string LocaleFormat(string format) {
            return null;
        }

        [ScriptName("parseDate")]
        public static DateTime Parse(string value) {
            return default(DateTime);
        }

        public void SetDate(int date) {
        }

        public void SetFullYear(int year) {
        }

        public void SetFullYear(int year, int month) {
        }

        public void SetFullYear(int year, int month, int day) {
        }

        public void SetHours(int hours) {
        }

        public void SetMilliseconds(int milliseconds) {
        }

        public void SetMinutes(int minutes) {
        }

        public void SetMonth(int month) {
        }

        public void SetSeconds(int seconds) {
        }

        public void SetTime(int milliseconds) {
        }

        public void SetUTCDate(int date) {
        }

        public void SetUTCFullYear(int year) {
        }

        public void SetUTCHours(int hours) {
        }

        public void SetUTCMilliseconds(int milliseconds) {
        }

        public void SetUTCMinutes(int minutes) {
        }

        public void SetUTCMonth(int month) {
        }

        public void SetUTCSeconds(int seconds) {
        }

        public void SetYear(int year) {
        }

        public string ToDateString() {
            return null;
        }

        public string ToISOString() {
            return null;
        }

        public string ToLocaleDateString() {
            return null;
        }

        public string ToLocaleTimeString() {
            return null;
        }

        public string ToTimeString() {
            return null;
        }

        public string ToUTCString() {
            return null;
        }

        [PreserveCase]
        public static int UTC(int year, int month, int day) {
            return 0;
        }

        [PreserveCase]
        public static int UTC(int year, int month, int day, int hours) {
            return 0;
        }

        [PreserveCase]
        public static int UTC(int year, int month, int day, int hours, int minutes) {
            return 0;
        }

        [PreserveCase]
        public static int UTC(int year, int month, int day, int hours, int minutes, int seconds) {
            return 0;
        }

        [PreserveCase]
        public static int UTC(int year, int month, int day, int hours, int minutes, int seconds, int milliseconds) {
            return 0;
        }

        // NOTE: There is no + operator since in JavaScript that returns the
        //       concatenation of the date strings, which is pretty much useless.

        /// <summary>
        /// Returns the difference in milliseconds between two dates.
        /// </summary>
        public static int operator -(DateTime a, DateTime b) {
            return 0;
        }

        /// <summary>
        /// Compares two dates
        /// </summary>
        public static bool operator ==(DateTime a, DateTime b) {
            return false;
        }

        /// <summary>
        /// Compares two dates
        /// </summary>
        public static bool operator !=(DateTime a, DateTime b) {
            return false;
        }

        /// <summary>
        /// Compares two dates
        /// </summary>
        public static bool operator <(DateTime a, DateTime b) {
            return false;
        }

        /// <summary>
        /// Compares two dates
        /// </summary>
        public static bool operator >(DateTime a, DateTime b) {
            return false;
        }

        /// <summary>
        /// Compares two dates
        /// </summary>
        public static bool operator <=(DateTime a, DateTime b) {
            return false;
        }

        /// <summary>
        /// Compares two dates
        /// </summary>
        public static bool operator >=(DateTime a, DateTime b) {
            return false;
        }
    }
}
