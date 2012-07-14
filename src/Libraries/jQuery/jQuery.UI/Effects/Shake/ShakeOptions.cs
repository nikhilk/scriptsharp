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
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class ShakeOptions {

        public ShakeOptions() {
        }

        public ShakeOptions(params object[] nameValuePairs) {
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
        /// The direction of the effect. Can be "left", "right", "up", "down".
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
        /// Distance to shake.
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
        /// Times to shake.
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
