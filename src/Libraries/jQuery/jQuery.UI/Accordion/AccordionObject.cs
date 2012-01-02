// AccordionObject.cs
// Script#/Libraries/jQuery/jQuery.UI/Accordion
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
    /// Make the selected elements Accordion widgets.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public sealed class AccordionObject : jQueryObject
    {
        [ScriptName("accordion")]
        public extern AccordionObject Accordion();

        [ScriptName("accordion")]
        public extern AccordionObject Accordion(AccordionOptions options);

        [ScriptName("accordion")]
        public extern object Accordion(AccordionMethod method, params object[] options);
    }
}
