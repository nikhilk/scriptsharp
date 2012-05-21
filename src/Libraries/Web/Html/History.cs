// History.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class History {

        private History() {
        }

        /// <summary>
        /// Retrieves the number of elements in the history list.
        /// </summary>
        [IntrinsicProperty]
        public int Length {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Retrieves the current state object.
        /// </summary>
        [IntrinsicProperty]
        public object State {
            get {
                return null;
            }
        }

        /// <summary>
        /// Navigates to the previous page in history.
        /// </summary>
        public void Back() {
        }

        /// <summary>
        /// Navigates to the next page in history.
        /// </summary>
        public void Forward() {
        }

        /// <summary>
        /// Navigates to a page in history relative to the current page.
        /// </summary>
        /// <param name="delta">The number of pages in history to go back (negative) or forward (positive).</param>
        public void Go(int delta) {
        }

        /// <summary>
        /// Pushes the given data onto the session history stack.
        /// </summary>
        /// <param name="data">The data to serialize into JSON format.</param>
        /// <param name="title">The title to place into history.</param>
        public void PushState(object data, string title) {
        }

        /// <summary>
        /// Pushes the given data onto the session history stack.
        /// </summary>
        /// <param name="data">The data to serialize into JSON format.</param>
        /// <param name="title">The title to place into history.</param>
        /// <param name="url">The URL to place into history.</param>
        public void PushState(object data, string title, string url) {
        }

        /// <summary>
        /// Updates the most recent entry on the history stack.
        /// </summary>
        /// <param name="data">The data to serialize into JSON format.</param>
        /// <param name="title">The title to place into history.</param>
        public void ReplaceState(object data, string title) {
        }

        /// <summary>
        /// Updates the most recent entry on the history stack.
        /// </summary>
        /// <param name="data">The data to serialize into JSON format.</param>
        /// <param name="title">The title to place into history.</param>
        /// <param name="url">The URL to place into history.</param>
        public void ReplaceState(object data, string title, string url) {
        }
    }
}
