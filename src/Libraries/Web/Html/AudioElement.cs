// AudioElement.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [Imported]
    [IgnoreNamespace]
    public sealed class AudioElement : Element {

        private AudioElement() {
        }

        [IntrinsicProperty]
        public double CurrentTime {
            get {
                return 0;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public double Duration {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public bool Ended {
            get {
                return false;
            }
        }

        [IntrinsicProperty]
        public bool Paused {
            get {
                return false;
            }
        }

        [IntrinsicProperty]
        public string Src {
            get {
                return "";
            }
            set {
            }
        }

        [IntrinsicProperty]
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
