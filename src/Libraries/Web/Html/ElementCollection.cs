// ElementCollection.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [ScriptImport]
    public sealed class ElementCollection {

        internal ElementCollection() {
        }

        [ScriptProperty]
        public int Length {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public Element this[int index] {
            get {
                return null;
            }
        }
    }
}
