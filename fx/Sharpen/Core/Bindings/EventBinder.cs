// EventBinder.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Html;

namespace Sharpen.Bindings {

    /// <summary>
    /// Binds an event of an element to the value of an expression.
    /// </summary>
    internal sealed class EventBinder : Binder {

        private Element _source;
        private string _eventName;

        private ElementEventListener _eventHandler;

        public EventBinder(Element source, string eventName, ElementEventListener eventHandler) {
            _source = source;
            _eventName = eventName;
            _eventHandler = eventHandler;
        }

        public override void Dispose() {
            _source.RemoveEventListener(_eventName, _eventHandler, false);
        }

        internal override void Update() {
            _source.AddEventListener(_eventName, _eventHandler, false);
        }
    }
}
