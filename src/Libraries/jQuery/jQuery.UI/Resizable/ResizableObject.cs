// ResizableObject.cs
// Script#/Libraries/jQuery/jQuery.UI/Resizable
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
    /// The jQuery UI Resizable plugin makes selected elements resizable (meaning they have draggable resize handles). You can specify one or more handles as well as min and max width and height.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public sealed class ResizableObject : jQueryObject
    {
        [ScriptName("resizable")]
        public extern ResizableObject Resizable();

        [ScriptName("resizable")]
        public extern ResizableObject Resizable(ResizableOptions options);

        [ScriptName("resizable")]
        public extern object Resizable(ResizableMethod method, params object[] options);
    }
}
