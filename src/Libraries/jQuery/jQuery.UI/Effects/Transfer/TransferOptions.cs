// TransferOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Effects {

    /// <summary>
    /// Options used to initialize or customize Transfer.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class TransferOptions {

        public TransferOptions() {
        }

        public TransferOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// Optional class name the transfer element will receive.
        /// </summary>
        [IntrinsicProperty]
        public string ClassName {
            get {
                return null;
            }
            set {
            }
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
        /// jQuery selector, the element to transfer to.
        /// </summary>
        [IntrinsicProperty]
        public string To {
            get {
                return null;
            }
            set {
            }
        }
    }
}
