// EffectObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Effects {

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    public abstract class EffectObject : jQueryUIObject {

        protected EffectObject() {
        }

        [ScriptName("effect")]
        public EffectObject Effect() {
            return null;
        }

        [ScriptName("effect")]
        public object Effect(EffectMethod method, params object[] options) {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddClass(string classNames, object speed, object easing, Action callback) {
        }


        /// <summary>
        /// 
        /// </summary>
        public void CreateWrapper(object element) {
        }


        /// <summary>
        /// 
        /// </summary>
        public void CssUnit(string key) {
        }


        /// <summary>
        /// 
        /// </summary>
        public void Effect(string effect, object options, object speed, Action callback) {
        }


        /// <summary>
        /// 
        /// </summary>
        public void GetBaseline(object origin, object original) {
        }


        /// <summary>
        /// 
        /// </summary>
        public void RemoveClass(string classNames, object speed, object easing, Action callback) {
        }


        /// <summary>
        /// 
        /// </summary>
        public void RemoveWrapper(object element) {
        }


        /// <summary>
        /// 
        /// </summary>
        public void Restore(object element, object set) {
        }


        /// <summary>
        /// 
        /// </summary>
        public void Save(object element, object set) {
        }


        /// <summary>
        /// 
        /// </summary>
        public void SetMode(object el, object mode) {
        }


        /// <summary>
        /// 
        /// </summary>
        public void SetTransition(object element, object list, object factor, object value) {
        }


        /// <summary>
        /// 
        /// </summary>
        public void SwitchClass(string remove, string add, object speed, object easing, Action callback) {
        }


        /// <summary>
        /// 
        /// </summary>
        public void Toggle(object speed) {
        }


        /// <summary>
        /// 
        /// </summary>
        public void ToggleClass(string classNames, bool force, object speed, object easing, Action callback) {
        }

    }
}
