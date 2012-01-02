// SelectableMethod.cs
// Script#/Libraries/jQuery/jQuery.UI/Selectable
// Auto-generated code!
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace jQueryApi.UI
{
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum SelectableMethod
    {
        /// <summary>
        /// Remove the selectable functionality completely. This will return the element back to its pre-init state.
        /// </summary>
        Destroy,
        /// <summary>
        /// Disable the selectable.
        /// </summary>
        Disable,
        /// <summary>
        /// Enable the selectable.
        /// </summary>
        Enable,
        /// <summary>
        /// Set multiple selectable options at once by providing an options object.Get or set any selectable option. If no value is specified, will act as a getter.
        /// </summary>
        Option,
        /// <summary>
        /// Returns the .ui-selectable element.
        /// </summary>
        Widget,
        /// <summary>
        ///  Refresh the position and size of each selectee element. This method can be used to manually recalculate the position and size of each selectee element. Very useful if autoRefresh is set to false.
        /// </summary>
        Refresh,
    }
}
