// Template.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace Sharpen {

    /// <summary>
    /// Creates an instance of the markup represented by this template.
    /// </summary>
    /// <param name="data">The data that is associated with the template instance.</param>
    /// <param name="index">The index of the template if the template is being instantiated in a repeated fashion.</param>
    /// <param name="context">Any additional contextual information that should be passed into the template.</param>
    /// <returns>The markup instance.</returns>
    public delegate string Template(object data, int index, object context);
}
