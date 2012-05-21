// jQueryTemplating.cs
// Script#/Libraries/jQuery/Templating
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Html;
using System.Net;
using System.Runtime.CompilerServices;

namespace jQueryApi.Templating {

    /// <summary>
    /// Provides access to jQuery Templating APIs.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public static class jQueryTemplating {

        /// <summary>
        /// Creates a template based on the specified template markup.
        /// </summary>
        /// <param name="template">The template markup.</param>
        /// <returns>A compiled template.</returns>
        [ScriptAlias("$.template")]
        public static jQueryTemplate CreateTemplate(string template) {
            return null;
        }

        /// <summary>
        /// Creates a template based on the specified template markup.
        /// </summary>
        /// <param name="templateName">The name to assign to the template.</param>
        /// <param name="template">The template markup.</param>
        /// <returns>A compiled template.</returns>
        [ScriptAlias("$.template")]
        public static jQueryTemplate CreateTemplate(string templateName, string template) {
            return null;
        }

        /// <summary>
        /// Creates a template based on the content of the specified element.
        /// </summary>
        /// <param name="templateElement">The element containing the template markup.</param>
        /// <returns>A compiled template.</returns>
        [ScriptAlias("$.template")]
        public static jQueryTemplate CreateTemplate(Element templateElement) {
            return null;
        }

        /// <summary>
        /// Creates a template based on the content of the specified element.
        /// </summary>
        /// <param name="templateName">The name to assign to the template.</param>
        /// <param name="templateElement">The element containing the template markup.</param>
        /// <returns>A compiled template.</returns>
        [ScriptAlias("$.template")]
        public static jQueryTemplate CreateTemplate(string templateName, Element templateElement) {
            return null;
        }

        /// <summary>
        /// Creates a template based on the first element of the matched set.
        /// </summary>
        /// <param name="o">The jQueryObject representing the element whose content is to be used as a template.</param>
        /// <returns>A compiled template.</returns>
        [ScriptAlias("$.template")]
        public static jQueryTemplate CreateTemplate(jQueryObject o) {
            return null;
        }

        /// <summary>
        /// Creates a template based on the first element of the matched set.
        /// </summary>
        /// <param name="templateName">The name to assign to the template.</param>
        /// <param name="template">The jQueryObject representing the element whose content is to be used as a template.</param>
        /// <returns>A compiled template.</returns>
        [ScriptAlias("$.template")]
        public static jQueryTemplate CreateTemplate(string templateName, jQueryObject template) {
            return null;
        }

        /// <summary>
        /// Gets the template by name, previously created using CreateTemplate.
        /// </summary>
        /// <param name="templateName">The template name.</param>
        /// <returns>A compiled template.</returns>
        [ScriptAlias("$.template")]
        public static jQueryTemplate GetTemplate(string templateName) {
            return null;
        }

        /// <summary>
        /// Gets the template instance associated with the specified element.
        /// </summary>
        /// <param name="element">The element associated with a template.</param>
        /// <returns>The associated template instance if one exists.</returns>
        [ScriptAlias("$.tmplItem")]
        public static jQueryTemplateInstance GetTemplateInstance(Element element) {
            return null;
        }

        /// <summary>
        /// Gets the template instance associated with the specified jQueryObject.
        /// </summary>
        /// <param name="o">The jQueryObject associated with a template.</param>
        /// <returns>The associated template instance if one exists.</returns>
        [ScriptAlias("$.tmplItem")]
        public static jQueryTemplateInstance GetTemplateInstance(jQueryObject o) {
            return null;
        }

        /// <summary>
        /// Creates a template based on the first element of the matched set
        /// and instantiates it using the specified data.
        /// </summary>
        /// <param name="template">The name of a template or markup to use.</param>
        /// <param name="data">The data associated with the template instance.</param>
        /// <returns>The resulting elements from instantiating the template.</returns>
        [ScriptAlias("$.tmpl")]
        public static jQueryObject RenderTemplate(string template, object data) {
            return null;
        }

        /// <summary>
        /// Creates a template based on the first element of the matched set
        /// and instantiates it using the specified data.
        /// </summary>
        /// <param name="template">The name of a template or markup to use.</param>
        /// <param name="data">The data associated with the template instance.</param>
        /// <param name="item">An object for use inside the template as $item.</param>
        /// <returns>The resulting elements from instantiating the template.</returns>
        [ScriptAlias("$.tmpl")]
        public static jQueryObject RenderTemplate(string template, object data, object item) {
            return null;
        }

        /// <summary>
        /// Creates a template based on the first element of the matched set
        /// and instantiates it using the specified data.
        /// </summary>
        /// <param name="templateElement">The element whose content is to be used as a template.</param>
        /// <param name="data">The data associated with the template instance.</param>
        /// <returns>The resulting elements from instantiating the template.</returns>
        [ScriptAlias("$.tmpl")]
        public static jQueryObject RenderTemplate(Element templateElement, object data) {
            return null;
        }

        /// <summary>
        /// Creates a template based on the first element of the matched set
        /// and instantiates it using the specified data.
        /// </summary>
        /// <param name="templateElement">The element whose content is to be used as a template.</param>
        /// <param name="data">The data associated with the template instance.</param>
        /// <param name="item">An object for use inside the template as $item.</param>
        /// <returns>The resulting elements from instantiating the template.</returns>
        [ScriptAlias("$.tmpl")]
        public static jQueryObject RenderTemplate(Element templateElement, object data, object item) {
            return null;
        }

        /// <summary>
        /// Creates a template based on the first element of the matched set
        /// and instantiates it using the specified data.
        /// </summary>
        /// <param name="template">The jQueryObject representing the element whose content is to be used as a template.</param>
        /// <param name="data">The data associated with the template instance.</param>
        /// <returns>The resulting elements from instantiating the template.</returns>
        [ScriptAlias("$.tmpl")]
        public static jQueryObject RenderTemplate(jQueryObject template, object data) {
            return null;
        }

        /// <summary>
        /// Creates a template based on the first element of the matched set
        /// and instantiates it using the specified data.
        /// </summary>
        /// <param name="template">The jQueryObject representing the element whose content is to be used as a template.</param>
        /// <param name="data">The data associated with the template instance.</param>
        /// <param name="item">An object for use inside the template as $item.</param>
        /// <returns>The resulting elements from instantiating the template.</returns>
        [ScriptAlias("$.tmpl")]
        public static jQueryObject RenderTemplate(jQueryObject template, object data, object item) {
            return null;
        }

        /// <summary>
        /// Creates a template based on the first element of the matched set
        /// and instantiates it using the specified data.
        /// </summary>
        /// <param name="template">The template to use.</param>
        /// <param name="data">The data associated with the template instance.</param>
        /// <returns>The resulting elements from instantiating the template.</returns>
        [ScriptAlias("$.tmpl")]
        public static jQueryObject RenderTemplate(jQueryTemplate template, object data) {
            return null;
        }

        /// <summary>
        /// Creates a template based on the first element of the matched set
        /// and instantiates it using the specified data.
        /// </summary>
        /// <param name="template">The template to use.</param>
        /// <param name="data">The data associated with the template instance.</param>
        /// <param name="item">An object for use inside the template as $item.</param>
        /// <returns>The resulting elements from instantiating the template.</returns>
        [ScriptAlias("$.tmpl")]
        public static jQueryObject RenderTemplate(jQueryTemplate template, object data, object item) {
            return null;
        }
    }
}
