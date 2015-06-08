// PulsateOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Effects {

    /// <summary>
    /// Options used to initialize or customize Pulsate.
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class PulsateOptions {

        public PulsateOptions() {
        }

        public PulsateOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// A callback function, executed when the effect completes
        /// </summary>
        [ScriptField]
        public Action Complete {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// The number of ms the animation will run for
        /// </summary>
        [ScriptField]
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
        [ScriptField]
        public string Easing {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// <para>UI Effect Mode</para><para>Possible Values: </para><dl><dt>hide</dt><dd>Hides the element.</dd><dt>show</dt><dd>Shows the element.</dd><dt>toggle</dt><dd>Will use <code>hide</code> or <code>show</code> depending on the current visibility of the element</dd><dt>effect</dt><dd>Just pulsates.</dd></dl>
        /// </summary>
        [ScriptField]
        public string Mode {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// The number of times the element should pulse.  An extra half pulse is added for hide/show
        /// </summary>
        [ScriptField]
        public int Times {
            get {
                return 0;
            }
            set {
            }
        }
    }
}
