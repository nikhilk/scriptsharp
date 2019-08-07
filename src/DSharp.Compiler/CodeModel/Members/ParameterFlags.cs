// ParameterFlags.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.CodeModel.Members
{
    /// <summary>
    ///     Modifiers on a formal parameter.
    /// </summary>
    internal enum ParameterFlags
    {
        None,

        Ref,

        Out,

        Params
    }
}