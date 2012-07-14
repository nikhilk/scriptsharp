// WidgetMethod.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI {

    /// <summary>
    /// Operations supported by Widget.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum WidgetMethod {

        /// <summary>
        /// This is the widget's constructor.
        /// </summary>
        [ScriptName("_create")]
        Create,

        [ScriptName("_createWidget")]
        CreateWidget,

        [ScriptName("_getCreateOptions")]
        GetCreateOptions,

        /// <summary>
        /// Widgets have the concept of initialization that is distinct from creation. Any time the plugin is called with no arguments or with only an option hash, the widget is initialized; this includes when the widget is created.<para>Initialization should only be handled if there is a logical action to perform on successive calls to the widget with no arguments.</para>
        /// </summary>
        [ScriptName("_init")]
        Init,

        /// <summary>
        /// Called from <code>_setOptions()</code> for each individual option.<para>Widget state should be updated based on changes.</para>
        /// </summary>
        [ScriptName("_setOption")]
        SetOption,

        /// <summary>
        /// Called with a hash of key/value pairs to set whenever the <code>option()</code> method is called, regardless of the form in which option() was called.<para>Overriding this is useful if you can defer processor-intensive changes for multiple option changes.</para>
        /// </summary>
        [ScriptName("_setOptions")]
        SetOptions,

        /// <summary>
        /// Triggers an event and its associated callback.<para>The option with the name equal to type is invoked as the callback.</para><para>The event name is the widget name + type.</para>
        /// </summary>
        [ScriptName("_trigger")]
        Trigger,

        /// <summary>
        /// The <code>destroy()</code> method cleans up all common data, events, etc. and then delegates out to <code>_destroy()</code> for custom cleanup.
        /// </summary>
        Destroy,

        Disable,

        DisableSelection,

        Enable,

        EnableSelection,

        Focus,

        Option,

        RemoveUniqueId,

        ScrollParent,

        UniqueId,

        Widget,

        ZIndex
    }
}
