// TextRange.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace System.Html.Editing {

    [IgnoreNamespace]
    [Imported]
    public sealed class TextRange : Range {

        private TextRange() {
        }

        [IntrinsicProperty]
        public int BoundingHeight {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public int BoundingLeft {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public int BoundingTop {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public int BoundingWidth {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public string HTMLText {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public int OffsetLeft {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public int OffsetTop {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public string Text {
            get {
                return null;
            }
            set {
            }
        }

        public void Collapse(bool moveInsertionPointToStart) {
        }

        public int CompareEndPoints(string compareType, TextRange range) {
            return 0;
        }

        public TextRange Duplicate() {
            return null;
        }

        public bool Expand(string unit) {
            return false;
        }

        public bool FindText(string text) {
            return false;
        }

        public bool FindText(string text, int searchExtent) {
            return false;
        }

        public bool FindText(string text, int searchExtent, int flags) {
            return false;
        }

        public string GetBookmark() {
            return null;
        }

        public object GetBoundingClientRect() {
            return null;
        }

        public Array GetClientRects() {
            return null;
        }

        public bool InRange(TextRange range) {
            return false;
        }

        public bool IsEqual(TextRange range) {
            return false;
        }

        public int Move(string unit) {
            return 0;
        }

        public int Move(string unit, int count) {
            return 0;
        }

        public int MoveEnd(string unit) {
            return 0;
        }

        public int MoveEnd(string unit, int count) {
            return 0;
        }

        public int MoveStart(string unit) {
            return 0;
        }

        public int MoveStart(string unit, int count) {
            return 0;
        }

        public void MoveToElementText(Element element) {
        }

        public bool MoveToBookmark(string bookmark) {
            return false;
        }

        public void MoveToPoint(int x, int y) {
        }

        public Element ParentElement() {
            return null;
        }

        public void PasteHTML(string html) {
        }
    }
}
