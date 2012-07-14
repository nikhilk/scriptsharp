// BounceOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Effects {

    /// <summary>
    /// Options used to initialize or customize Bounce.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class BounceOptions {

        public BounceOptions() {
        }

        public BounceOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// A callback function, executed when the effect completes
        /// </summary>
        [IntrinsicProperty]
        public Action Complete {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// <para>The direction the blind will be pulled to "hide" the element., or the direction from which the element will be revealed.</para><para>Possible Values</para><dl><dt>up</dt><dt>down</dt><dt>left</dt><dt>right</dt></dl>
        /// </summary>
        [IntrinsicProperty]
        public string Direction {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// The distance of the largest "bounce" in pixels
        /// </summary>
        [IntrinsicProperty]
        public int Distance {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// The number of ms the animation will run for
        /// </summary>
        [IntrinsicProperty]
        public int Duration {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// The easing function to use
        /// </summary>
        [IntrinsicProperty]
        public string Easing {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// <para>UI Effect Mode</para><para>Possible Values: </para><dl><dt>hide</dt><dd>Hides the element by pulling a bouncing out the direction and fading out on the last half bounce</dd><dt>show</dt><dd>Shows the element by pulling a bouncing in from the direction fading in on the the first half bounce.</dd><dt>toggle</dt><dd>Will use <code>hide</code> or <code>show</code> depending on the current visibility of the element</dd><dt>effect</dt><dd>Just bounces the element, doesn't hide or show.</dd></dl>
        /// </summary>
        [IntrinsicProperty]
        public string Mode {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// The number of times the element will bounce.  When used with hide or show, there is an extra "half" bounce for the fade in/out
        /// </summary>
        [IntrinsicProperty]
        public int Times {
            get {
                return 0;
            }
            set {
            }
        }
    }
}
