// PositionOption.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI {

    /// <summary>
    /// Options for use with Position.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum PositionOption {

        /// <summary>
        /// Defines which position <strong>on the target element</strong> to align the positioned element against: "horizontal vertical" alignment. A single value such as "right" will default to "right center", "top" will default to "center top" (following CSS convention). Acceptable values: "top", "center", "bottom", "left", "right". Example: "left top" or "center center". Each dimension can also contains offsets, in pixels or percent, e.g. `right+10 top-25%`. A perecentage is relative to the target element.
        /// </summary>
        At,

        /// <summary>
        /// <para>When the positioned element overflows the window in some direction, move it to an alternative position. Similar to my and at, this accepts a single value or a pair for horizontal/vertical, eg. "flip", "fit", "fit flip", "fit none".</para><ul><li><b>flip</b>: to the opposite side and the collision detection is run again to see if it will fit. Whichever side allows more of the element to be visible will be used.</li><li><b>fit</b>: so the element keeps in the desired direction, but is re-positioned so it fits.</li><li><b>flipfit</b>: apply both flip and fit. If flip works out, fit won't do anything, if flip gives up, fit should help.</li><li><b>none</b>: no collision detection.</li></ul>
        /// </summary>
        Collision,

        /// <summary>
        /// Defines which position <strong>on the element being positioned</strong> to align with the target element: "horizontal vertical" alignment. A single value such as "right" will default to "right center", "top" will default to "center top" (following CSS convention). Acceptable values: "top", "center", "bottom", "left", "right". Example: "left top" or "center center". Each dimension can also contains offsets, in pixels or percent, e.g. `right+10 top-25%`. A perecentage is relative to the element being positioned.
        /// </summary>
        My,

        /// <summary>
        /// Element to position against. If you provide a selector or jQuery object, the first matching element will be used. If you provide an event object, the pageX and pageY properties will be used. Example: "#top-menu"
        /// </summary>
        Of,

        /// <summary>
        /// Add these left-top values to the calculated position, eg. "50 50" (left top) A single value such as "50" will apply to both.
        /// </summary>
        Offset,

        /// <summary>
        /// When specified the actual property setting is delegated to this callback. Receives two parameters: The first is a hash of top and left values for the position that should be set and can be forwarded to offset() or animate() calls.<para>The second provides feedback about the position and dimensions of both elements, as well as calculations to their relative position. Both `target` and `element` have these properties: element, left, top, width, height. In addition, there's `horizontal`, `vertical` and `important`, giving you twelve potential directions like { horizontal: "center", vertical: "left", important: "horizontal" }.</para>
        /// </summary>
        Using
    }
}
