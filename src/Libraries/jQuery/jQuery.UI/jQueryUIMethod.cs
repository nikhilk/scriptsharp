// jQueryUIMethod.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI {

    /// <summary>
    /// Operations supported by jQueryUI.
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptConstants(UseNames = true)]
    public enum jQueryUIMethod {

        DisableSelection,

        EnableSelection,

        Focus,

        RemoveUniqueId,

        ScrollParent,

        UniqueId,

        ZIndex
    }
}
