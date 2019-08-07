// IStreamSourceResolver.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler
{
    public interface IStreamSourceResolver
    {
        IStreamSource Resolve(string name);
    }
}