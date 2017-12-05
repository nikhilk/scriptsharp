// WindowInstance.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    /// <summary>
    /// The window object represents the current browser window, and is the top-level
    /// scripting object.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class WindowInstance {

        private WindowInstance() {
        }

        [ScriptField]
        public bool Closed {
            get {
                return false;
            }
        }

        [ScriptField]
        public string DefaultStatus {
            get { 
                return null; 
            }
            set { 
            }
        }

        [ScriptField]
        public DocumentInstance Document {
            get {
                return null;
            }
        }

        [ScriptField]
        public IFrameElement FrameElement {
            get {
                return null;
            }
        }

        [ScriptField]
        public int InnerHeight {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int InnerWidth {
            get {
                return 0;
            }
        }

        [ScriptField]
        public Location Location {
            get {
                return null;
            }
        }

        [ScriptField]
        public WindowInstance Parent {
            get {
                return null;
            }
        }

        [ScriptField]
        public WindowInstance Opener {
            get {
                return null;
            }
        }

        [ScriptField]
        public static int OuterHeight {
            get {
                return 0;
            }
        }

        [ScriptField]
        public static int OuterWidth {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int PageXOffset {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int PageYOffset {
            get {
                return 0;
            }
        }

        [ScriptField]
        public WindowInstance Self {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Status {
            get { 
                return null; 
            }
            set { 
            }
        }

        [ScriptField]
        public WindowInstance Top {
            get {
                return null;
            }
        }

        [ScriptField]
        public WindowInstance[] Frames {
            get {
                return null;
            }
        }

        /// <summary>
        /// Adds a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="listener">The listener to be invoked in response to the event.</param>
        public void AddEventListener(string eventName, ElementEventListener listener) {
        }

        /// <summary>
        /// Adds a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="listener">The listener to be invoked in response to the event.</param>
        /// <param name="useCapture">Whether the listener wants to initiate capturing the event.</param>
        public void AddEventListener(string eventName, ElementEventListener listener, bool useCapture) {
        }

        public void AttachEvent(string eventName, ElementEventHandler handler) {
        }

        public void Close() {
        }

        public void DetachEvent(string eventName, ElementEventHandler handler) {
        }

        public bool DispatchEvent(MutableEvent eventObject) {
            return false;
        }

        public void Navigate(string url) {
        }

        public void Print() {
        }

        /// <summary>
        /// Removes a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="listener">The listener to be invoked in response to the event.</param>
        public void RemoveEventListener(string eventName, ElementEventListener listener) {
        }

        /// <summary>
        /// Removes a listener for the specified event.
        /// </summary>
        /// <param name="eventName">The name of the event such as 'load'.</param>
        /// <param name="listener">The listener to be invoked in response to the event.</param>
        /// <param name="useCapture">Whether the listener wants to initiate capturing the event.</param>
        public void RemoveEventListener(string eventName, ElementEventListener listener, bool useCapture) {
        }

        public void Scroll(int x, int y) {
        }

        public void ScrollBy(int x, int y) {
        }

        public void ScrollTo(int x, int y) {
        }

        public void PostMessage(string message, string targetOrigin) {
        }
    }
}
