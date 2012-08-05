// IScriptInfo.cs
// Script#/Core/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.IO;

namespace ScriptSharp {

    internal interface IScriptInfo {

        string GetValue(string name);
    }
}
