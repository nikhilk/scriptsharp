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
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class jQueryTemplateInstance {

        private jQueryTemplateInstance() {
        }

        /// <summary>
        /// Gets the data that this instance is based on.
        /// </summary>
        [ScriptField]
        public object Data {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the elements that this template instance represents.
        /// </summary>
        [ScriptField]
        public Element[] Nodes {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets or sets the template that this instance is based on.
        /// </summary>
        [ScriptField]
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
