// BindingHandler.cs
// Script#/Libraries/Knockout
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Html;
using System.Runtime.CompilerServices;

namespace KnockoutApi {

    /// <summary>
    /// Represents a custom binding handler in Knockout.
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public abstract class BindingHandler {

        /// <summary>
        /// Performs one time initialization for a binding.
        /// </summary>
        /// <param name="element">The element involved in this binding.</param>
        /// <param name="valueAccessor">A function which returns the model property that is involved in this binding.</param>
        /// <param name="allBindingsAccessor">A function which returns all the model properties bound to this element.</param>
        /// <param name="viewModel">The view model instance involved in this binding.</param>
        /// <param name="context">The binding context involved in this binding.</param>
        public virtual void Init(Element element, Func<object> valueAccessor, Func<Dictionary> allBindingsAccessor, object viewModel, object context) {
        }

        /// <summary>
        /// Invoked whenever an observable associated with this binding changes.
        /// </summary>
        /// <param name="element">The element involved in this binding.</param>
        /// <param name="valueAccessor">A function which returns the model property that is involved in this binding.</param>
        /// <param name="allBindingsAccessor">A function which returns all the model properties bound to this element.</param>
        /// <param name="viewModel">The view model instance involved in this binding.</param>
        /// <param name="context">The binding context involved in this binding.</param>
        public virtual void Update(Element element, Func<object> valueAccessor, Func<Dictionary> allBindingsAccessor, object viewModel, object context) {
        }
    }
}
