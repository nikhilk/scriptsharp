// jQueryTemplateObject.cs
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
    /// Represents a jQuery result that wraps a set of elements, with templating
    /// APIs added.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public sealed class jQueryTemplateObject : jQueryObject {

        private jQueryTemplateObject() {
        }

        /// <summary>
        /// Creates a template based on the first element of the matched set.
        /// </summary>
        /// <returns>A compiled template.</returns>
        [ScriptName("template")]
        public jQueryTemplate CreateTemplate() {
            return null;
        }

        /// <summary>
        /// Creates a named template based on the first element of the matched set.
        /// </summary>
        /// <param name="name">The name of the template.</param>
        /// <returns>A compiled template.</returns>
        [ScriptName("template")]
        public jQueryTemplate CreateTemplate(string name) {
            return null;
        }

        /// <summary>
        /// Gets the template instance that the matched element is based on.
        /// </summary>
        /// <returns>The template instance.</returns>
        [ScriptName("tmplItem")]
        public jQueryTemplateInstance GetTemplateInstance() {
            return null;
        }

        /// <summary>
        /// Creates a template based on the first element of the matched set
        /// and instantiates it using the specified data.
        /// </summary>
        /// <param name="data">The data associated with the template instance.</param>
        /// <returns>The resulting elements from instantiating the template.</returns>
        [ScriptName("tmpl")]
        public jQueryObject RenderTemplate(object data) {
            return null;
        }

        /// <summary>
        /// Creates a template based on the first element of the matched set
        /// and instantiates it using the specified data.
        /// </summary>
        /// <param name="data">The data associated with the template instance.</param>
        /// <param name="item">An object for use inside the template as $item.</param>
        /// <returns>The resulting elements from instantiating the template.</returns>
        [ScriptName("tmpl")]
        public jQueryObject RenderTemplate(object data, object item) {
            return null;
        }
    }
}
