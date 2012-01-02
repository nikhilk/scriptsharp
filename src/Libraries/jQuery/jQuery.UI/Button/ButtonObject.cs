// ButtonObject.cs
// Script#/Libraries/jQuery/jQuery.UI/Button
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
    /// Button enhances standard form elements like button, input of type submit or reset or anchors to themable buttons with appropiate mouseover and active styles.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public sealed class ButtonObject : jQueryObject
    {
        [ScriptName("button")]
        public extern ButtonObject Button();

        [ScriptName("button")]
        public extern ButtonObject Button(ButtonOptions options);

        [ScriptName("button")]
        public extern object Button(ButtonMethod method, params object[] options);
    }
}
