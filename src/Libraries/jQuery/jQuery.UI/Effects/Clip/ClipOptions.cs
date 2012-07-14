// ClipOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Effects {

    /// <summary>
    /// Options used to initialize or customize Clip.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class ClipOptions {

        public ClipOptions() {
        }

        public ClipOptions(params object[] nameValuePairs) {
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
        /// <para>The plane in which the clip effect will hide or show its element</para><para>Possible Values</para><dl><dt>vertical</dt><dd>Uses top &amp; bottom edges</dd><dt>horizontal</dt><dd>Uses left &amp; right edges</dd></dl>
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
        /// <para>UI Effect Mode</para><para>Possible Values: </para><dl><dt>hide</dt><dd>Hides the element</dd><dt>show</dt><dd>Shows the element.</dd><dt>toggle</dt><dd>Will use <code>hide</code> or <code>show</code> depending on the current visibility of the element</dd></dl>
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
