// MutableEvent.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class MutableEvent {

        internal MutableEvent() {
        }

        public void InitCustomEvent(string eventType, bool canBubble, bool canCancel, string detail) {
        }

        public void InitEvent(string eventType, bool canBubble, bool canCancel) {
        }

        public void InitFocusEvent(string eventType, bool canBubble, bool canCancel, WindowInstance view, string detail) {
        }

        public void InitKeyboardEvent(string eventType, bool canBubble, bool canCancel, WindowInstance view, string detail, string key, string location, string modifiers, int repeat, string locale) {
        }

        public void InitMouseEvent(string eventType, bool canBubble, bool canCancel, WindowInstance view, string detail, int screenX, int screenY, int clientX, int clientY, bool ctrlKey, bool altKey, bool shiftKey, bool metaKey, string button, Element relatedTarget) {
        }

        public void InitMouseWheelEvent(string eventType, bool canBubble, bool canCancel, WindowInstance view, string detail, int screenX, int screenY, int clientX, int clientY, bool ctrlKey, bool altKey, bool shiftKey, bool metaKey, string button, Element relatedTarget, string modifiers, int wheelDelta) {
        }

        public void InitUIEvent(string eventType, bool canBubble, bool canCancel, WindowInstance view, string detail) {
        }

        public void InitWheelEvent(string eventType, bool canBubble, bool canCancel, WindowInstance view, string detail, int screenX, int screenY, int clientX, int clientY, bool ctrlKey, bool altKey, bool shiftKey, bool metaKey, string button, Element relatedTarget, string modifiers, int deltaX, int deltaY, int deltaZ, int deltaMode) {
        }
    }
}
