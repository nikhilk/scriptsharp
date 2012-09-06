// ISymbolTransformer.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.ScriptModel {

    interface ISymbolTransformer {

        string TransformSymbol(Symbol symbol, out bool transformChildren);
    }
}
