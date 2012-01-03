// SliderObject.cs
// Script#/Libraries/jQuery/jQuery.UI/Slider
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
    /// The jQuery UI Slider plugin makes selected elements into sliders. There are various options such as multiple handles, and ranges. The handle can be moved with the mouse or the arrow keys.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public sealed class SliderObject : jQueryObject
    {
        [ScriptName("slider")]
        public extern SliderObject Slider();

        [ScriptName("slider")]
        public extern SliderObject Slider(SliderOptions options);

        [ScriptName("slider")]
        public extern object Slider(SliderMethod method, params object[] options);
    }
}
