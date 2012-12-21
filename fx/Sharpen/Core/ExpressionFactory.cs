// ExpressionFactory.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace Sharpen.Html {

    /// <summary>
    /// Creates an expression given a model object and a string representation of the
    /// expression.
    /// </summary>
    /// <param name="model">The model object to be used for binding purposes.</param>
    /// <param name="expressionType">The type of expression.</param>
    /// <param name="value">The string representation of the expression.</param>
    /// <returns>An expression object.</returns>
    public delegate Expression ExpressionFactory(object model, string expressionType, string value);
}
