// IStreamResolver.cs
// Script#/Core/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.IO;

namespace ScriptSharp {

    public interface IStreamResolver {

        IStreamSource ResolveInclude(IStreamSource baseStream, string includePath);
    }
}
