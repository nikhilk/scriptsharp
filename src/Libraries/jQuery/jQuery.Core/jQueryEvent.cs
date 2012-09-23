// jQueryEvent.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Html;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// Provides information about the current event.
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    public class jQueryEvent {

        protected jQueryEvent() {
        }

        [ScriptProperty]
        public bool AltKey {
            get {
                return false;
            }
        }

        [ScriptProperty]
        public bool Bubbles {
            get {
                return false;
            }
        }

        [ScriptProperty]
        public int Button {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public bool Cancelable {
            get {
                return false;
            }
        }

        [ScriptProperty]
        public bool CtrlKey {
            get {
                return false;
            }
        }

        [ScriptProperty]
        public int ClientX {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public int ClientY {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Gets the current DOM element within the event bubbling phase.
        /// </summary>
        [ScriptProperty]
        public Element CurrentTarget {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the event data that was passed in into the Bind method.
        /// </summary>
        [ScriptProperty]
        public Dictionary Data {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the namespace specified when the event was triggered.
        /// </summary>
        [ScriptProperty]
        public string Namespace {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public int OffsetX {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public int OffsetY {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public Element OriginalTarget {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the mouse position relative to left edge of the document.
        /// </summary>
        [ScriptProperty]
        public int PageX {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Gets the mouse position relative to top edge of the document.
        /// </summary>
        [ScriptProperty]
        public int PageY {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public int ScreenX {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public int ScreenY {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Gets the other DOM element associated with the event if any.
        /// </summary>
        [ScriptProperty]
        public Element RelatedTarget {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the value returned by the last event handler if any.
        /// </summary>
        [ScriptProperty]
        public object Result {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public bool ShiftKey {
            get {
                return false;
            }
        }

        /// <summary>
        /// Gets the DOM element that initiated the event.
        /// </summary>
        [ScriptProperty]
        public Element Target {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the number of milliseconds since Jan 1, 1970, when the event
        /// was triggered.
        /// </summary>
        [ScriptProperty]
        public long TimeStamp {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Gets the type or name of the event.
        /// </summary>
        [ScriptProperty]
        public string Type {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the key or button that was pressed.
        /// </summary>
        [ScriptProperty]
        public int Which {
            get {
                return 0;
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
