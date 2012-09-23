// jQueryObject.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// Represents the properties that indicate existence of browser features
    /// and bugs.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class jQuerySupport {

        private jQuerySupport() {
        }

        /// <summary>
        /// This is equal to true if the page and browser are rendered according to the
        /// W3C CSS Box Model.
        /// </summary>
        [ScriptProperty]
        public bool BoxModel {
            get {
                return false;
            }
        }

        /// <summary>
        /// True if cssFloat is the name of the float CSS property. False if it is styleFloat.
        /// </summary>
        [ScriptProperty]
        public bool CssFloat {
            get {
                return false;
            }
        }

        /// <summary>
        /// True if the browser leaves URLs returned from getAttribute("href") intact.
        /// </summary>
        [ScriptProperty]
        public bool HrefNormalized {
            get {
                return false;
            }
        }

        /// <summary>
        /// True is the browser properly serializes link elements when innerHTML is used.
        /// </summary>
        [ScriptProperty]
        public bool HtmlSerialize {
            get {
                return false;
            }
        }

        /// <summary>
        /// True if the browser preserves leading whitespace when innerHTML is used.
        /// </summary>
        [ScriptProperty]
        public bool LeadingWhitespace {
            get {
                return false;
            }
        }

        /// <summary>
        /// True if the browser does not copy over the checked expando when elements are cloned.
        /// </summary>
        [ScriptProperty]
        public bool NoCloneChecked {
            get {
                return false;
            }
        }

        /// <summary>
        /// True if the browser does not clone event handlers when elements are cloned.
        /// </summary>
        [ScriptProperty]
        public bool NoCloneEvent {
            get {
                return false;
            }
        }

        /// <summary>
        /// True if doing getElementsByTagName('*') on an object element returns all descendant elements.
        /// </summary>
        [ScriptProperty]
        public bool ObjectAll {
            get {
                return false;
            }
        }

        /// <summary>
        /// True if a browser can properly interpret the opacity style property.
        /// </summary>
        [ScriptProperty]
        public bool Opacity {
            get {
                return false;
            }
        }

        /// <summary>
        /// True if using appendChild/createTextNode to inject inline scripts executes them.
        /// </summary>
        [ScriptProperty]
        public bool ScriptEval {
            get {
                return false;
            }
        }

        /// <summary>
        /// True if getAttribute("style") is able to return the inline style specified by an element.
        /// </summary>
        [ScriptProperty]
        public bool Style {
            get {
                return false;
            }
        }

        /// <summary>
        /// True if the browser allows table elements without tbody elements.
        /// </summary>
        [ScriptProperty]
        public bool Tbody {
            get {
                return false;
            }
        }
    }
}
