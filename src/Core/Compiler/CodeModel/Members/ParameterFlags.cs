// ParameterFlags.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.CodeModel {

    /// <summary>
    /// Modifiers on a formal parameter.
    /// </summary>
    internal enum ParameterFlags {

        None,

        Ref,

        Out,

        Params
    }
}
