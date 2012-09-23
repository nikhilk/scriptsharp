// StringReplaceCallback.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System {

    // TODO: The actual signature needs to be
    //       string callback(match, m1, m2... mN, offset, fullString)
    //       but there isn't a way to express the varying number of parameters in the
    //       middle of the signature!

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate string StringReplaceCallback(string matchedValue);
}
