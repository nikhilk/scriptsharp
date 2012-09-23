// SizeOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Effects {

    /// <summary>
    /// Options used to initialize or customize Size.
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class SizeOptions {

        public SizeOptions() {
        }

        public SizeOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// A callback function, executed when the effect completes
        /// </summary>
        [ScriptProperty]
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
        [ScriptProperty]
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
        [ScriptProperty]
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
        [ScriptProperty]
        public Array Origin {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Which areas of the element will be resized: 'both', 'box', 'content' Box resizes the border and padding of the element Content resizes any content inside of the element.
        /// </summary>
        [ScriptProperty]
        public string Scale {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Height and width to resize to.{ height: .., width: .. }
        /// </summary>
        [ScriptProperty]
        public object To {
            get {
                return null;
            }
            set {
            }
        }
    }
}
