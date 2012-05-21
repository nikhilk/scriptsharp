// HttpVerb.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using System.Xml;

namespace System.Net {

    [IgnoreNamespace]
    [Imported]
    [NamedValues]
    public enum HttpVerb {

        [ScriptName("GET")]
        Get = 0,

        [ScriptName("POST")]
        Post = 1,

        [ScriptName("PUT")]
        Put = 2,

        [ScriptName("DELETE")]
        Delete = 3,

        [ScriptName("HEAD")]
        Head = 4
    }
}
