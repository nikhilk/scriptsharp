// DatepickerObject.cs
// Script#/Libraries/jQuery/jQuery.UI/Datepicker
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
    /// The jQuery UI Datepicker is a highly configurable plugin that adds datepicker functionality to your pages. You can customize the date format and language, restrict the selectable date ranges and add in buttons and other navigation options easily.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public sealed class DatepickerObject : jQueryObject
    {
        [ScriptName("datepicker")]
        public extern DatepickerObject Datepicker();

        [ScriptName("datepicker")]
        public extern DatepickerObject Datepicker(DatepickerOptions options);

        [ScriptName("datepicker")]
        public extern object Datepicker(DatepickerMethod method, params object[] options);
    }
}
