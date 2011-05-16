// ScriptInfo.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
