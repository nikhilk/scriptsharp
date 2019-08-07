// History.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html
{

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class History
    {

        private History() { }

        /// <summary>
        /// Retrieves the number of elements in the history list.
        /// </summary>
        [ScriptField]
        public extern int Length { get; }

        /// <summary>
        /// Retrieves the current state object.
        /// </summary>
        [ScriptField]
        public extern object State { get; }

        /// <summary>
        /// Scroll restoration behavior on history navigation. Can be either 'auto' or 'manual'.
        /// </summary>
        [ScriptField]
        public extern string ScrollRestoration { get; set; }

        /// <summary>
        /// Navigates to the previous page in history.
        /// </summary>
        public extern void Back();


        /// <summary>
        /// Navigates to the next page in history.
        /// </summary>
        public extern void Forward();

        /// <summary>
        /// Navigates to a page in history relative to the current page.
        /// </summary>
        /// <param name="delta">The number of pages in history to go back (negative) or forward (positive).</param>
        public extern void Go(int delta);

        /// <summary>
        /// Pushes the given data onto the session history stack.
        /// </summary>
        /// <param name="data">The data to serialize into JSON format.</param>
        /// <param name="title">The title to place into history.</param>
        public extern void PushState(object data, string title);

        /// <summary>
        /// Pushes the given data onto the session history stack.
        /// </summary>
        /// <param name="data">The data to serialize into JSON format.</param>
        /// <param name="title">The title to place into history.</param>
        /// <param name="url">The URL to place into history.</param>
        public extern void PushState(object data, string title, string url);

        /// <summary>
        /// Updates the most recent entry on the history stack.
        /// </summary>
        /// <param name="data">The data to serialize into JSON format.</param>
        /// <param name="title">The title to place into history.</param>
        public extern void ReplaceState(object data, string title);

        /// <summary>
        /// Updates the most recent entry on the history stack.
        /// </summary>
        /// <param name="data">The data to serialize into JSON format.</param>
        /// <param name="title">The title to place into history.</param>
        /// <param name="url">The URL to place into history.</param>
        public extern void ReplaceState(object data, string title, string url);
    }
}
