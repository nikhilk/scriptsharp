// Buffer.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.IO {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptConstants(UseNames = true)]
    public enum FileAccess {

        [ScriptName("r")]
        Read,

        [ScriptName("r+")]
        ReadWrite,

        [ScriptName("rs")]
        ReadSynchronous,

        [ScriptName("rs+")]
        ReadWriteSynchronous,

        [ScriptName("w")]
        Write,

        [ScriptName("wx")]
        WriteExclusive,

        [ScriptName("w+")]
        ReadWriteCreate,

        [ScriptName("wx+")]
        ReadWriteCreateExclusive,

        [ScriptName("a")]
        AppendCreate,

        [ScriptName("ax")]
        AppendCreateExclusive,

        [ScriptName("a+")]
        ReadAppendCreate,

        [ScriptName("ax+")]
        ReadAppendCreateExclusive
    }
}
