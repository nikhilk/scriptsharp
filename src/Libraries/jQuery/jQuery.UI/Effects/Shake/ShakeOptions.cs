// ShakeOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Effects {

    /// <summary>
    /// Options used to initialize or customize Shake.
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class ShakeOptions {

        public ShakeOptions() {
        }

        public ShakeOptions(params object[] nameValuePairs) {
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
        /// The direction of the effect. Can be "left", "right", "up", "down".
        /// </summary>
        [ScriptField]
        public string Direction {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Distance to shake.
        /// </summary>
        [ScriptField]
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
        /// Times to shake.
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
