// WidgetObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI {

    /// <summary>
    /// Create stateful jQuery plugins using the same abstraction that all jQuery UI widgets.
    /// </summary>
    /// <remarks>
    /// <para>You can create new widgets from scratch, using just the <code>$.Widget</code> object as base to inherit from, or you can explicitly inherit from existing jQuery UI or third-party widgets. Defining a widget with the same name as you inherit from even allows you to extend widgets in place.</para><para>For now, more details can be found at <a href="https://github.com/scottgonzalez/widget-factory-docs/">github.com/scottgonzalez/widget-factory-docs/</a></para>
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("$.Widget")]
    public abstract class WidgetObject : jQueryUIObject {

        protected WidgetObject() {
        }

        [IntrinsicProperty]
        public static object Prototype {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public jQueryObject Element {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public object Options {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("_setOption")]
        public Function SetOption {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("_setOptions")]
        public Function SetOptions {
            get {
                return null;
            }
        }



        /// <summary>
        /// This is the widget's constructor.
        /// </summary>
        [ScriptName("_create")]
        public void Create() {
        }


        /// <summary>
        /// 
        /// </summary>
        [ScriptName("_createWidget")]
        public void CreateWidget() {
        }


        /// <summary>
        /// 
        /// </summary>
        [ScriptName("_getCreateOptions")]
        public void GetCreateOptions() {
        }


        /// <summary>
        /// Widgets have the concept of initialization that is distinct from creation. Any time the plugin is called with no arguments or with only an option hash, the widget is initialized; this includes when the widget is created.<para>Initialization should only be handled if there is a logical action to perform on successive calls to the widget with no arguments.</para>
        /// </summary>
        [ScriptName("_init")]
        public void Init() {
        }


        /// <summary>
        /// Triggers an event and its associated callback.<para>The option with the name equal to type is invoked as the callback.</para><para>The event name is the widget name + type.</para>
        /// </summary>
        [ScriptName("_trigger")]
        public bool Trigger(string type, jQueryEvent @event, object data) {
                return false;
        }


        /// <summary>
        /// The <code>destroy()</code> method cleans up all common data, events, etc. and then delegates out to <code>_destroy()</code> for custom cleanup.
        /// </summary>
        public void Destroy() {
        }


        /// <summary>
        /// 
        /// </summary>
        public WidgetObject Disable() {
                return null;
        }


        /// <summary>
        /// 
        /// </summary>
        public WidgetObject Enable() {
                return null;
        }


        /// <summary>
        /// 
        /// </summary>
        public WidgetObject Option(string key, object value) {
                return null;
        }


        /// <summary>
        /// 
        /// </summary>
        public WidgetObject Option(params object[] options) {
                return null;
        }


        /// <summary>
        /// 
        /// </summary>
        public WidgetObject Widget() {
                return null;
        }

    }
}
