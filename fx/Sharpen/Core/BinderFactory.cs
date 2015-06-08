// BinderFactory.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Html;

namespace Sharpen {

    /// <summary>
    /// Creates an expression binder given an element, the bound property and
    /// the expression to bind to.
    /// </summary>
    /// <param name="element">The element that is bound.</param>
    /// <param name="property">The property on the element that is bound.</param>
    /// <param name="expression">The expression to bind to.</param>
    /// <returns>The binder that was created. If no binder needs to be created, the return value is null.</returns>
    public delegate Binder BinderFactory(Element element, string property, Expression expression);
}
