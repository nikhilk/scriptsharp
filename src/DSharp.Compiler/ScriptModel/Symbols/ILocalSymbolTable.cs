// ILocalSymbolTable.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal interface ILocalSymbolTable : ISymbolTable
    {
        void AddSymbol(LocalSymbol symbol);

        string CreateSymbolName(string nameHint);

        void PopScope();

        void PushScope();
    }
}