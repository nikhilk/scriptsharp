// ProgressbarObject.cs
// Script#/Libraries/jQuery/jQuery.UI/Progressbar
// Auto-generated code!
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace jQueryApi.UI
{
    /// <summary>
    /// The progress bar is designed to simply display the current % complete for a process. The bar is coded to be flexibly sized through CSS and will scale to fit inside it's parent container by default.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public sealed class ProgressbarObject : jQueryObject
    {
        [ScriptName("progressbar")]
        public extern ProgressbarObject Progressbar();

        [ScriptName("progressbar")]
        public extern ProgressbarObject Progressbar(ProgressbarOptions options);

        [ScriptName("progressbar")]
        public extern object Progressbar(ProgressbarMethod method, params object[] options);
    }
}
