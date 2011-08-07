// ResXInternalScriptGenerator.cs
// Script#/Tools/VisualStudio
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace ScriptSharp.VisualStudio.Generators {

    [Guid("33FA0BF4-CBBA-4fdd-9300-0F5A6BDE7E33")]
    public sealed class ResXInternalScriptGenerator : ResXScriptGenerator {

        public ResXInternalScriptGenerator()
            : base(/* publicResources */ false) {
        }
    }
}
