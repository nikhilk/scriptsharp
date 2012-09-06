// IParseNodeValidator.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using ScriptSharp;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Validator {

    /// <summary>
    /// Defines a parse node validator
    /// </summary>
    internal interface IParseNodeValidator {

        bool Validate(ParseNode node, CompilerOptions options, IErrorHandler errorHandler);
    }
}
