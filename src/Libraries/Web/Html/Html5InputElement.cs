// InputElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html
{
    [ScriptImport, ScriptName("HTMLInputElement")]
    [ScriptIgnoreNamespace]
    public class Html5InputElement : InputElement
    {
        [ScriptField]
        public extern int SelectionStart { get; }

        [ScriptField]
        public extern int SelectionEnd { get; }
    }
}
