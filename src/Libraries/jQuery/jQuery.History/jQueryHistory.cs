// jQueryHistory.cs
// Script#/Libraries/jQuery/History
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Html;
using System.Net;
using System.Runtime.CompilerServices;

namespace jQueryApi.History {

    /// <summary>
    /// Provides access to jQuery history and back button management APIs.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public static class jQueryHistory {

        /// <summary>
        /// Retrieves the current state from the browser.
        /// </summary>
        /// <returns>An object that contains the current state.</returns>
        [ScriptAlias("$.bbq.getState")]
        public static object GetState() {
            return null;
        }

        /// <summary>
        /// Retrieves the current state for the specified key from the browser.
        /// </summary>
        /// <param name="key">The state key to lookup.</param>
        /// <returns>The state value for the specified key.</returns>
        [ScriptAlias("$.bbq.getState")]
        public static object GetState(string key) {
            return null;
        }

        /// <summary>
        /// Retrieves the current state for the specified key from the browser.
        /// </summary>
        /// <param name="key">The state key to lookup.</param>
        /// <param name="coerce">true if numeric, boolean, undefined values should be coerced from their string representation.</param>
        /// <returns>The state value for the specified key.</returns>
        [ScriptAlias("$.bbq.getState")]
        public static object GetState(string key, bool coerce) {
            return null;
        }

        /// <summary>
        /// Adds state to the browser.
        /// </summary>
        /// <param name="state">The object containing state key/value pairs to be merged.</param>
        [ScriptAlias("$.bbq.pushState")]
        public static void PushState(Dictionary state) {
        }

        /// <summary>
        /// Adds state to the browser.
        /// </summary>
        /// <param name="state">The object containing state key/value pairs to be merged.</param>
        /// <param name="mergeMode">Specifies how the new state should be merged into the current state.</param>
        [ScriptAlias("$.bbq.pushState")]
        public static void PushState(Dictionary state, StateMergeMode mergeMode) {
        }

        /// <summary>
        /// Clears all the state from the browser.
        /// </summary>
        /// <returns></returns>
        [ScriptAlias("$.bbq.removeState")]
        public static void RemoveState() {
        }

        /// <summary>
        /// Removes the specified key(s) from the current state in the browser.
        /// </summary>
        /// <param name="key">The keys to be removed.</param>
        [ScriptAlias("$.bbq.removeState")]
        public static void RemoveState(params string[] key) {
        }
    }
}
