// jQueryEvent.cs
// Script#/Libraries/jQuery/jQueryCore
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Collections;
using System.Html;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// Provides information about the current event.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public sealed class jQueryEvent {

        private jQueryEvent() {
        }

        /// <summary>
        /// Gets the current DOM element within the event bubbling phase.
        /// </summary>
        [IntrinsicProperty]
        public Element CurrentTarget {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the event data that was passed in into the Bind method.
        /// </summary>
        [IntrinsicProperty]
        public Dictionary Data {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the namespace specified when the event was triggered.
        /// </summary>
        [IntrinsicProperty]
        public string Namespace {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the mouse position relative to left edge of the document.
        /// </summary>
        [IntrinsicProperty]
        public int PageX {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Gets the mouse position relative to top edge of the document.
        /// </summary>
        [IntrinsicProperty]
        public int PageY {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Gets the other DOM element associated with the event if any.
        /// </summary>
        [IntrinsicProperty]
        public Element RelatedTarget {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the value returned by the last event handler if any.
        /// </summary>
        [IntrinsicProperty]
        public object Result {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the DOM element that initiated the event.
        /// </summary>
        [IntrinsicProperty]
        public Element Target {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the number of milliseconds since Jan 1, 1970, when the event
        /// was triggered.
        /// </summary>
        [IntrinsicProperty]
        public long TimeStamp {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Gets the type or name of the event.
        /// </summary>
        [IntrinsicProperty]
        public string Type {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the key or button that was pressed.
        /// </summary>
        [IntrinsicProperty]
        public string Which {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets whether PreventDefault has been called on this event.
        /// </summary>
        /// <returns>True if PreventDefault was called. False otherwise.</returns>
        public bool IsDefaultPrevented() {
            return false;
        }

        /// <summary>
        /// Gets whether StopImmediatePropagation has been called on this event.
        /// </summary>
        /// <returns>True if StopImmediatePropagation was called. False otherwise.</returns>
        public bool IsImmediatePropagationStopped() {
            return false;
        }

        /// <summary>
        /// Gets whether StopPropagation has been called on this event.
        /// </summary>
        /// <returns>True if StopPropagation was called. False otherwise.</returns>
        public bool IsPropagationStopped() {
            return false;
        }

        /// <summary>
        /// Prevents the default action associated with the event.
        /// </summary>
        public void PreventDefault() {
        }

        /// <summary>
        /// Prevents the rest of the handlers associated with the event from being invoked.
        /// </summary>
        public void StopImmediatePropagation() {
        }

        /// <summary>
        /// Prevents the event from being bubbled up the DOM tree.
        /// </summary>
        public void StopPropagation() {
        }
    }
}
