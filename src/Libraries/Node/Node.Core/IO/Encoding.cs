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
    public enum Encoding {

        [ScriptName("ascii")]
        Ascii,

        [ScriptName("base64")]
        Base64,

        [ScriptName("hex")]
        Hex,

        [ScriptName("utf16le")]
        UTF16,

        [ScriptName("utf8")]
        UTF8
    }
}
