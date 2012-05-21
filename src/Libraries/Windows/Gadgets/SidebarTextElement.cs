// SidebarTextElement.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace System.Gadgets {

    [IgnoreNamespace]
    [Imported]
    public sealed class SidebarTextElement : Element {

        private SidebarTextElement() {
        }

        [IntrinsicProperty]
        public SidebarTextAlignment Align {
            get {
                return SidebarTextAlignment.Left;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public new int Blur {
            get {
                return 0;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public int Brightness {
            get {
                return 0;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public string Color {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public string Font {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public int FontSize {
            get {
                return 0;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public int Height {
            get {
                return 0;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public int Left {
            get {
                return 0;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public int Opacity {
            get {
                return 0;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public int Rotation {
            get {
                return 0;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public int SoftEdge {
            get {
                return 0;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public string Src {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public int Top {
            get {
                return 0;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public string Value {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public int Width {
            get {
                return 0;
            }
            set {
            }
        }

        public void AddGlow(string color, int radius, int alpha) {
        }

        public void AddShadow(string color, int radius, int alpha, int xOffset, int yOffset) {
        }
    }
}
