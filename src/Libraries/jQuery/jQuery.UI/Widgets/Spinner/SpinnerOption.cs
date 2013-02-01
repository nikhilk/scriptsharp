// SpinnerOption.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Options for use with Spinner.
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptConstants(UseNames = true)]
    public enum SpinnerOption {

        Max,
        Min,
        Step,
        Page,
        Incremental,
        Icons,
        NumberFormat,
        Culture,
        Disabled
    }
}
