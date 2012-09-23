// AudioElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class AudioElement : Element {

        private AudioElement() {
        }

        [ScriptProperty]
        public double CurrentTime {
            get {
                return 0;
            }
            set {
            }
        }

        [ScriptProperty]
        public double Duration {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public bool Ended {
            get {
                return false;
            }
        }

        [ScriptProperty]
        public bool Paused {
            get {
                return false;
            }
        }

        [ScriptProperty]
        public string Src {
            get {
                return "";
            }
            set {
            }
        }

        [ScriptProperty]
        public float Volume {
            get {
                return 0;
            }
            set {
            }
        }

        public void Load() {
        }

        public void Pause() {
        }

        public void Play() {
        }
    }
}
