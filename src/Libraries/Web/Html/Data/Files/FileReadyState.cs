// FileReadyState.cs
// Script#/Libraries/Web/
// This source code is subject to terms and conditions of the Apache License, Version 2.0.

using System.Runtime.CompilerServices;

namespace System.Html.Data.Files {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public enum FileReadyState {

        EMPTY = 0,

        LOADING = 1,

        DONE = 2
    }
}
