// Node.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using NodeApi.Compute;

namespace NodeApi {

    /// <summary>
    /// The global Node object.
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    public static class Node {

        [ScriptField]
        [ScriptAlias("process")]
        public static Process Process {
            get {
                return null;
            }
        }

        /// <summary>
        /// Stops an interval from triggering.
        /// </summary>
        /// <param name="intervalId">Interval Id that was returned by <seealso cref="SetInterval"/></param>
        [ScriptAlias("clearInterval")]
        public static void ClearInterval(int intervalId) {
        }

        /// <summary>
        /// Prevents a timeout from triggering.
        /// </summary>
        /// <param name="timeoutId">"Timeout Id that was returned by <seealso cref="SetTimeout"/></param>
        [ScriptAlias("clearTimeout")]
        public static void ClearTimeout(int timeoutId) {
        }

        /// <summary>
        /// To schedule the repeated execution of <paramref name="callback"/> every <paramref name="delay"/> milliseconds.
        /// Returns an Interval Id for possible use with <seealso cref="ClearInterval"/>.
        /// Optionally you can also pass <paramref name="arguments"/> to the callback.
        /// </summary>
        /// <param name="callback">Callback that is called when the interval delay has elapsed</param>
        /// <param name="delay">Delay in milliseconds</param>
        /// <param name="arguments">Optional arguments for the callback</param>
        /// <returns>Interval Id</returns>
        [ScriptAlias("setInterval")]
        public static int SetInterval(Action<object[]> callback, int delay, params object[] arguments) {
            return 0;
        }

        /// <summary>
        /// To schedule execution of a one-time <paramref name="callback"/> after <paramref name="delay"/> milliseconds.
        /// Returns a Timeout Id for possible use with <seealso cref="ClearTimeout"/>.
        /// Optionally you can also pass <paramref name="arguments"/> to the callback.
        /// </summary>
        /// <param name="callback">Callback that is called when timeout delay has elapsed</param>
        /// <param name="delay">Delay in milliseconds</param>
        /// <param name="arguments">Optional arguments for the callback</param>
        /// <returns>Timeout Id</returns>
        [ScriptAlias("setTimeout")]
        public static int SetTimeout(Action<object[]> callback, int delay, params object[] arguments) {
            return 0;
        }
    }
}
