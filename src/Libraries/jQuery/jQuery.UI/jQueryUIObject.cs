// jQueryUIObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI {

    [Imported]
    [IgnoreNamespace]
    public abstract class jQueryUIObject : jQueryObject {

        protected jQueryUIObject() {
        }

        [ScriptName("ui")]
        public jQueryUIObject jQueryUI() {
            return null;
        }

        [ScriptName("ui")]
        public object jQueryUI(jQueryUIMethod method, params object[] options) {
            return null;
        }

        public jQueryObject DisableSelection() {
                return null;
        }

        public jQueryObject EnableSelection() {
                return null;
        }

        public jQueryObject Focus(int delay) {
                return null;
        }

        public jQueryObject RemoveUniqueId() {
                return null;
        }

        public object ScrollParent() {
                return null;
        }

        public jQueryObject UniqueId() {
                return null;
        }

        public void ZIndex(int zIndex) {
        }
    }
}
