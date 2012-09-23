// VisualTransition.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Media.Filters {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class VisualTransition : VisualFilter {

        private VisualTransition() {
        }

        [ScriptProperty]
        public double Duration {
            get {
                return 0f;
            }
            set {
            }
        }

        [ScriptProperty]
        public int Percent {
            get {
                return 0;
            }
        }

        [ScriptProperty]
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
