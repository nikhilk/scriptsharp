// SidebarBackgroundElement.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace System.Gadgets {

    [IgnoreNamespace]
    [Imported]
    public sealed class SidebarBackgroundElement : Element {

        private SidebarBackgroundElement() {
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
        public int Width {
            get {
                return 0;
            }
            set {
            }
        }

        public void AddGlow(string color, int radius, int alpha) {
        }

        public SidebarImageElement AddImageObject(string source, int xOffset, int yOffset) {
            return null;
        }

        public void AddShadow(string color, int radius, int alpha, int xOffset, int yOffset) {
        }

        public SidebarTextElement AddTextObject(string text, string font, int fontSize, string color, int xOffset, int yOffset) {
            return null;
        }

        public void Move(int x, int y) {
        }

        public void RemoveObjects() {
        }
    }
}
