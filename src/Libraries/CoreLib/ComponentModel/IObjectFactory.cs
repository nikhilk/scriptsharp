// IObjectFactory.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.ComponentModel {

    /// <summary>
    /// Represents a factory that can create object instances as needed.
    /// </summary>
    [Imported]
    [ScriptNamespace("ss")]
    public interface IObjectFactory {

        /// <summary>
        /// Creates an instance of the component as needed.
        /// </summary>
        /// <param name="objectType">The type of component to be created.</param>
        /// <param name="container">The container that is requesting the creation of the object.</param>
        /// <returns>The instance created by this factory.</returns>
        object CreateInstance(Type objectType, IContainer container);
    }
}
