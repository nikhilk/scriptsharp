// TouchEvent.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class TouchEvent : ElementEvent {

        internal TouchEvent() {
        }

        [IntrinsicProperty]
        public TouchInfo[] ChangedTouches {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public TouchInfo[] TargetTouches {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public TouchInfo[] Touches {
            get {
                return null;
            }
        }
    }
}
