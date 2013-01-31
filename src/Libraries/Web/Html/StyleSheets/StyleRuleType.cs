// StyleRule.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.StyleSheets {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptConstants]
    public enum StyleRuleType {

        Unknown = 0,

        Style = 1,

        Charset = 2,

        Import = 3,

        Media = 4,

        FontFace = 5,

        Page = 6,

    }
}
