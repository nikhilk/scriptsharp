// IContainer.cs
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
    /// Encapsulates the functionality of a container that defines a scope of
    /// composition where objects can be registered and dependencies can be resolved.
    /// </summary>
    [Imported]
    [ScriptNamespace("ss")]
    public interface IContainer {

        /// <summary>
        /// Gets an instance of an object for the specified object type.
        /// </summary>
        /// <param name="objectType">The type of object to retrieve.</param>
        /// <returns>The resulting object; null if the object could not be retrieved.</returns>
        object GetObject(Type objectType);

        /// <summary>
        /// Registers an object instance for the specified type with the container.
        /// </summary>
        /// <param name="objectType">The type of object this instance corresponds to.</param>
        /// <param name="objectInstance">The object to register.</param>
        void RegisterObject(Type objectType, object objectInstance);

        /// <summary>
        /// Registers an object factory for the specified type with the container.
        /// </summary>
        /// <param name="objectType">The type of object this factory corresponds to.</param>
        /// <param name="objectFactory">The factory to register.</param>
        void RegisterFactory(Type objectType, IObjectFactory objectFactory);
    }
}
