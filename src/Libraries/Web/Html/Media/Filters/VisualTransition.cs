// VisualTransition.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Media.Filters {

    [IgnoreNamespace]
    [Imported]
    public sealed class VisualTransition : VisualFilter {

        private VisualTransition() {
        }

        [IntrinsicProperty]
        public double Duration {
            get {
                return 0f;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public int Percent {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public VisualTransitionState Status {
            get {
                return VisualTransitionState.Stopped;
            }
        }

        public void Apply() {
        }

        public void Play() {
        }

        public void Stop() {
        }
    }
}
