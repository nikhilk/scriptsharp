// Binder.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace Sharpen {

    /// <summary>
    /// A binder is an object that performs the work of binding an expression value
    /// with the associated DOM element.
    /// </summary>
    public abstract class Binder : IDisposable {

        public abstract void Dispose();

        internal virtual void Update() {
        }
    }
}
