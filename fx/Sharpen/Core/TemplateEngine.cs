// TemplateEngine.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Html;

namespace Sharpen {

    /// <summary>
    /// Creates an instance of a template from the specified content.
    /// </summary>
    /// <param name="content">The content representing the template.</param>
    /// <param name="options">Any options associated with the template.</param>
    /// <returns>The template instance.</returns>
    public delegate Template TemplateEngine(string content, Dictionary<string, object> options);
}
