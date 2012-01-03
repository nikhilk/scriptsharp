// ButtonOption.cs
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
    public enum ButtonOption
    {
        /// <summary>
        /// Disables (true) or enables (false) the button. Can be set when initialising (first creating) the button.
        /// </summary>
        Disabled,
        /// <summary>
        /// Whether to show any text - when set to false (display no text), icons (see icons option) must be enabled, otherwise it'll be ignored.
        /// </summary>
        Text,
        /// <summary>
        /// Icons to display, with or without text (see text option). The primary icon is displayed by default on the left of the label text, the secondary by default is on the right. Value for the primary and secondary properties must be a classname (String), eg. "ui-icon-gear". For using only one icon: <c>icons: {primary:'ui-icon-locked'}</c>. For using two icons: <c>icons: {primary:'ui-icon-gear',secondary:'ui-icon-triangle-1-s'}</c>
        /// </summary>
        Icons,
        /// <summary>
        /// Text to show on the button. When not specified (null), the element's html content is used, or its value attribute when it's an input element of type submit or reset; or the html content of the associated label element if its an input of type radio or checkbox
        /// </summary>
        Label,
    }
}
