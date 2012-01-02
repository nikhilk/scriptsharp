// AutocompleteObject.cs
// Script#/Libraries/jQuery/jQuery.UI/Autocomplete
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
    /// Autocomplete, when added to an input field, enables users to quickly find and select from a pre-populated list of values as they type, leveraging searching and filtering.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public sealed class AutocompleteObject : jQueryObject
    {
        [ScriptName("autocomplete")]
        public extern AutocompleteObject Autocomplete();

        [ScriptName("autocomplete")]
        public extern AutocompleteObject Autocomplete(AutocompleteOptions options);

        [ScriptName("autocomplete")]
        public extern object Autocomplete(AutocompleteMethod method, params object[] options);
    }
}
