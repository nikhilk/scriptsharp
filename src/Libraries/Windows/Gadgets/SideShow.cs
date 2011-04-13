// SideShow.cs
// Script#/Libraries/Windows
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Gadgets {

    [IgnoreNamespace]
    [Imported]
    public static class SideShow {

        public static Action ApplicationEvent {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public static bool Enabled {
            get {
                return false;
            }
        }

        public static void AddImage(int id, string fileName) {
        }

        public static void AddText(int id, string text) {
        }

        public static void Remove(int id) {
        }

        public static void RemoveAll() {
        }

        public static void SetFriendlyName(string name) {
        }
    }
}
