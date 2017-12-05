// IEventManager.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.ComponentModel {

    /// <summary>
    /// Provides a simple pub/sub mechanism to allow objects to broadcast and
    /// listen to messages or events without being coupled to each other.
    /// </summary>
    [ScriptImport]
    public interface IEventManager {

        /// <summary>
        /// Broadcasts an event. The event is sequentially handled by all subscribers.
        /// Any errors that occur are ignored.
        /// </summary>
        /// <param name="eventArgs">The data associated with the event.</param>
        void PublishEvent(EventArgs eventArgs);

        /// <summary>
        /// Subscribes the specified handler to listen to events of the specified type.
        /// </summary>
        /// <param name="eventType">The type of the event to listen to.</param>
        /// <param name="eventHandler">The event handler to be invoked when the event occurs.</param>
        /// <returns>An opaque cookie that can be used to unsubscribe subsequently.</returns>
        object SubscribeEvent(Type eventType, Callback eventHandler);

        /// <summary>
        /// Unsubscribes a previous event handler from subsequent events.
        /// </summary>
        /// <param name="subscriptionCookie">The cookie that represents the subscription.</param>
        void UnsubscribeEvent(object subscriptionCookie);
    }
}
