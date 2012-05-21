// CompositeOperation.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Media.Graphics {

    [IgnoreNamespace]
    [Imported]
    [NamedValues]
    public enum CompositeOperation {

        /// <summary>
        /// A (B is ignored). Display the source image instead of the destination image.
        /// </summary>
        Copy = 0,

        /// <summary>
        /// B atop A. Display the destination image wherever both images are opaque.
        /// Display the source image wherever the source image is opaque but the
        /// destination image is transparent. Display transparency elsewhere.
        /// </summary>
        [ScriptName("destination-atop")]
        DestinationAtop = 1,

        /// <summary>
        /// B in A. Display the destination image wherever both the destination image and
        /// source image are opaque. Display transparency elsewhere.
        /// </summary>
        [ScriptName("destination-in")]
        DestinationIn = 2,

        /// <summary>
        /// B out A. Display the destination image wherever the destination image is opaque
        /// and the source image is transparent. Display transparency elsewhere.
        /// </summary>
        [ScriptName("destination-out")]
        DestinationOut = 3,

        /// <summary>
        /// B over A. Display the destination image wherever the destination image is opaque.
        /// Display the source image elsewhere. 
        /// </summary>
        [ScriptName("destination-over")]
        DestinationOver = 4,

        /// <summary>
        /// A plus B. Display the sum of the source image and destination image, with color
        /// values approaching 1 as a limit.
        /// </summary>
        Lighter = 5,

        /// <summary>
        /// A atop B. Display the source image wherever both images are opaque. Display the
        /// destination image wherever the destination image is opaque but the source image
        /// is transparent. Display transparency elsewhere.
        /// </summary>
        [ScriptName("source-atop")]
        SourceAtop = 6,

        /// <summary>
        /// A in B. Display the source image wherever both the source image and destination
        /// image are opaque. Display transparency elsewhere.
        /// </summary>
        [ScriptName("source-in")]
        SourceIn = 7,

        /// <summary>
        /// A out B. Display the source image wherever the source image is opaque and the
        /// destination image is transparent. Display transparency elsewhere.
        /// </summary>
        [ScriptName("source-out")]
        SourceOut = 8,

        /// <summary>
        /// A over B. Display the source image wherever the source image is opaque. Display the
        /// destination image elsewhere. This is the default option.
        /// </summary>
        [ScriptName("source-over")]
        SourceOver = 9,

        /// <summary>
        /// A xor B. Exclusive OR of the source image and destination image.
        /// </summary>
        Xor = 10
    }
}
