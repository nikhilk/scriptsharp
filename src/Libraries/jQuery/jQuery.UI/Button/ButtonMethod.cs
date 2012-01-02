// ButtonMethod.cs
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
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum ButtonMethod
    {
        /// <summary>
        /// Remove the button functionality completely. This will return the element back to its pre-init state.
        /// </summary>
        Destroy,
        /// <summary>
        /// Disable the button.
        /// </summary>
        Disable,
        /// <summary>
        /// Enable the button.
        /// </summary>
        Enable,
        /// <summary>
        /// Set multiple button options at once by providing an options object.Get or set any button option. If no value is specified, will act as a getter.
        /// </summary>
        Option,
        /// <summary>
        /// Returns the .ui-button element.
        /// </summary>
        Widget,
        /// <summary>
        /// Refreshes the visual state of the button. Useful for updating button state after the native element's checked or disabled state is changed programmatically.
        /// </summary>
        Refresh,
    }
}
