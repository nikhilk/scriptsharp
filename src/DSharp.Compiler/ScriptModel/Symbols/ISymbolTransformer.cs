// ISymbolTransformer.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal interface ISymbolTransformer
    {
        string TransformSymbol(Symbol symbol, out bool transformChildren);
    }
}