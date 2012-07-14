// ScaleOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Effects {

    /// <summary>
    /// Options used to initialize or customize Scale.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class ScaleOptions {

        public ScaleOptions() {
        }

        public ScaleOptions(params object[] nameValuePairs) {
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
        /// The direction of the effect. Can be "both", "vertical" or "horizontal".
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
        /// The vanishing point, default for show/hide.
        /// </summary>
        [IntrinsicProperty]
        public Array Origin {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// The percentage to scale to.
        /// </summary>
        [IntrinsicProperty]
        public int Percent {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// Which areas of the element will be resized: 'both', 'box', 'content' Box resizes the border and padding of the element Content resizes any content inside of the element
        /// </summary>
        [IntrinsicProperty]
        public string Scale {
            get {
                return null;
            }
            set {
            }
        }
    }
}
