// jQueryUIObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI {

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
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

        /// <summary>
        /// 
        /// </summary>
        public jQueryObject DisableSelection() {
                return null;
        }


        /// <summary>
        /// 
        /// </summary>
        public jQueryObject EnableSelection() {
                return null;
        }


        /// <summary>
        /// 
        /// </summary>
        public jQueryObject Focus(int delay) {
                return null;
        }


        /// <summary>
        /// 
        /// </summary>
        public jQueryObject RemoveUniqueId() {
                return null;
        }


        /// <summary>
        /// 
        /// </summary>
        public object ScrollParent() {
                return null;
        }


        /// <summary>
        /// 
        /// </summary>
        public jQueryObject UniqueId() {
                return null;
        }


        /// <summary>
        /// 
        /// </summary>
        public void ZIndex(int zIndex) {
        }

    }
}
