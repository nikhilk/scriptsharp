// ScriptInfo.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System {

    [IgnoreNamespace]
    [Imported]
    [ScriptName("Object")]
    public sealed class ScriptInfo {

        [IntrinsicProperty]
        [ScriptName("requires")]
        public string[] Dependencies {
            get;
            set;
        }

        [IntrinsicProperty]
        public string Name {
            get;
            set;
        }

        [IntrinsicProperty]
        [ScriptName("src")]
        public string Source {
            get;
            set;
        }
    }
}
