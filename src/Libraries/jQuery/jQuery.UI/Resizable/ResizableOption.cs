// ResizableOption.cs
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
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum ResizableOption
    {
        /// <summary>
        /// Disables (true) or enables (false) the resizable. Can be set when initialising (first creating) the resizable.
        /// </summary>
        Disabled,
        /// <summary>
        /// Resize these elements synchronous when resizing.
        /// </summary>
        AlsoResize,
        /// <summary>
        /// Animates to the final size after resizing.
        /// </summary>
        Animate,
        /// <summary>
        /// Duration time for animating, in milliseconds. Other possible values: 'slow', 'normal', 'fast'.
        /// </summary>
        AnimateDuration,
        /// <summary>
        /// Easing effect for animating.
        /// </summary>
        AnimateEasing,
        /// <summary>
        /// If set to true, resizing is constrained by the original aspect ratio. Otherwise a custom aspect ratio can be specified, such as 9 / 16, or 0.5.
        /// </summary>
        AspectRatio,
        /// <summary>
        /// If set to true, automatically hides the handles except when the mouse hovers over the element.
        /// </summary>
        AutoHide,
        /// <summary>
        /// Prevents resizing if you start on elements matching the selector.
        /// </summary>
        Cancel,
        /// <summary>
        /// Constrains resizing to within the bounds of the specified element. Possible values: 'parent', 'document', a DOMElement, or a Selector.
        /// </summary>
        Containment,
        /// <summary>
        /// Tolerance, in milliseconds, for when resizing should start. If specified, resizing will not start until after mouse is moved beyond duration. This can help prevent unintended resizing when clicking on an element.
        /// </summary>
        Delay,
        /// <summary>
        /// Tolerance, in pixels, for when resizing should start. If specified, resizing will not start until after mouse is moved beyond distance. This can help prevent unintended resizing when clicking on an element.
        /// </summary>
        Distance,
        /// <summary>
        /// If set to true, a semi-transparent helper element is shown for resizing.
        /// </summary>
        Ghost,
        /// <summary>
        /// Snaps the resizing element to a grid, every x and y pixels. Array values: [x, y]
        /// </summary>
        Grid,
        /// <summary>
        /// If specified as a string, should be a comma-split list of any of the following: 'n, e, s, w, ne, se, sw, nw, all'. The necessary handles will be auto-generated by the plugin. If specified as an object, the following keys are supported: { n, e, s, w, ne, se, sw, nw }. The value of any specified should be a jQuery selector matching the child element of the resizable to use as that handle. If the handle is not a child of the resizable, you can pass in the DOMElement or a valid jQuery object directly.
        /// </summary>
        Handles,
        /// <summary>
        /// This is the css class that will be added to a proxy element to outline the resize during the drag of the resize handle. Once the resize is complete, the original element is sized.
        /// </summary>
        Helper,
        /// <summary>
        /// This is the maximum height the resizable should be allowed to resize to.
        /// </summary>
        MaxHeight,
        /// <summary>
        /// This is the maximum width the resizable should be allowed to resize to.
        /// </summary>
        MaxWidth,
        /// <summary>
        /// This is the minimum height the resizable should be allowed to resize to.
        /// </summary>
        MinHeight,
        /// <summary>
        /// This is the minimum width the resizable should be allowed to resize to.
        /// </summary>
        MinWidth,
    }
}
