// Subscribable.cs
//

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace KnockoutApi
{
    [Imported]
    [IgnoreNamespace]
    public class Subscribable<T>: IDisposable
    {
        protected Subscribable() { }

        /// <summary>
        /// Subscribes to change notifications raised when the value changes.
        /// </summary>
        /// <param name="changeCallback">The callback to invoke.</param>
        /// <returns>A subscription cookie that can be disposed to unsubscribe.</returns>
        public IDisposable Subscribe(Action<T> changeCallback) { return null; }

        /// <summary>
        /// Subscribes to change notifications raised when the value changes.
        /// </summary>
        /// <param name="changeCallback">The callback to invoke.</param>
        /// <param name="callBackTarget">callback target</param>
        /// <returns>A subscription cookie that can be disposed to unsubscribe.</returns>
        public IDisposable Subscribe(Action<T> changeCallback, object callBackTarget) { return null; }

        /// <summary>
        /// Subscribes to change notifications raised when the value changes.
        /// </summary>
        /// <param name="changeCallback">The callback to invoke.</param>
        /// <param name="callBackTarget">callback target</param>
        /// <param name="eventName">event registration</param>
        /// <returns>A subscription cookie that can be disposed to unsubscribe.</returns>
        public IDisposable Subscribe(Action<T> changeCallback, object callBackTarget, string eventName) { return null; }

        public void NotifySubscribers(T value) { }

        public void NotifySubscribers(T value, string eventName) { }
        
        public int GetSubscriptionsCount() { return 0; }


        /// <summary>
        /// For dependent observables, we throttle *evaluations* so that, no matter how fast its dependencies        
        /// notify updates, the target doesn't re-evaluate (and hence doesn't notify) faster than a certain rate
        /// For writable targets (observables, or writable dependent observables), we throttle *writes*        
        /// so the target cannot change value synchronously or faster than a certain rate
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Extend is Chainable</returns>
        public Subscribable<T> Extend(Dictionary options) { return null; }

        public void Dispose() { }
    }
}
