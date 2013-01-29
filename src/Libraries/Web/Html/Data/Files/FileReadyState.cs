// FileReadyState.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Html.Data.Files {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptConstants]
    public enum FileReadyState {

        Empty = 0,

        Loading = 1,

        Done = 2
    }
}
