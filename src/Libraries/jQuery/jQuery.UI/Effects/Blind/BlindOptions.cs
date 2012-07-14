// BlindOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Effects {

    /// <summary>
    /// Options used to initialize or customize Blind.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class BlindOptions {

        public BlindOptions() {
        }

        public BlindOptions(params object[] nameValuePairs) {
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
        /// <para>The direction the blind will be pulled to "hide" the element., or the direction from which the element will be revealed.</para><para>Possible Values</para><dl><dt>up</dt><dt>down</dt><dt>left</dt><dt>right</dt><dt>vertical</dt><dt>horizontal</dt></dl>
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
        /// <para>UI Effect Mode</para><para>Possible Values: </para><dl><dt>hide</dt><dd>Hides the element by pulling a blind in the direction</dd><dt>show</dt><dd>Shows the element by pulling a blind from the direction. This seems inverted from the hide.</dd><dt>toggle</dt><dd>Will use <code>hide</code> or <code>show</code> depending on the current visibility of the element</dd></dl>
        /// </summary>
        [IntrinsicProperty]
        public string Mode {
            get {
                return null;
            }
            set {
            }
        }
    }
}
