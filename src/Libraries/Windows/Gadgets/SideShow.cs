// SideShow.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
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
