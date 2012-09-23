// jQueryTemplateInstance.cs
// Script#/Libraries/jQuery/Templating
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Html;
using System.Net;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace jQueryApi.Templating {

    /// <summary>
    /// Represents an instantiated jQuery template.
    /// </summary>
    [IgnoreNamespace]
    [ScriptImport]
    public sealed class jQueryTemplateInstance {

        private jQueryTemplateInstance() {
        }

        /// <summary>
        /// Gets the data that this instance is based on.
        /// </summary>
        [ScriptProperty]
        public object Data {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the elements that this template instance represents.
        /// </summary>
        [ScriptProperty]
        public Element[] Nodes {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets or sets the template that this instance is based on.
        /// </summary>
        [ScriptProperty]
        public jQueryTemplate Template {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Updates the rendering once an update template has been set.
        /// </summary>
        public void Update() {
        }
    }
}
