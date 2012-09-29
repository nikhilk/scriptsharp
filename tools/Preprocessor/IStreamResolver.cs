// IStreamResolver.cs
// Script#/Tools/Preprocessor
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.IO;

namespace ScriptSharp {

    internal interface IStreamResolver {

        IStreamSource ResolveInclude(IStreamSource baseStream, string includePath);
    }
}
