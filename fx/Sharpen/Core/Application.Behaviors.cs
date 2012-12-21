// Application.Behaviors.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Html;
using System.Runtime.CompilerServices;
using Sharpen.Html.Utility;

namespace Sharpen.Html {

    public sealed partial class Application {

        /// <summary>
        /// Creates and attaches behaviors specified on the element declaratively.
        /// </summary>
        /// <param name="element">The element whose behaviors should be created and attached.</param>
        private void AttachBehaviors(Element element) {
            string[] behaviorNames = ((string)element.GetAttribute(Application.BehaviorsAttribute)).Split(",");
            int behaviorCount = behaviorNames.Length;

            for (int i = 0; i < behaviorCount; i++) {
                string name = behaviorNames[i].Trim();

                BehaviorRegistration registration = _registeredBehaviors[name];
                Debug.Assert(registration != null, "Unknown behavior '" + name + "'");

                if (registration != null) {
                    Dictionary<string, object> options = OptionsParser.GetOptions(element, name);

                    // Use the Application's IoC capabilities to create behaviors.
                    // This allows satisfying dependencies behaviors have to other services,
                    // and also allows behaviors to provide or register services into the container.

                    Behavior behavior = (Behavior)GetObject(registration.BehaviorType);
                    behavior.Initialize(element, options);

                    if (registration.ServiceType != null) {
                        // Special-case the common case where a behavior represents a single
                        // service type, and auto-register it.
                        // In the case where a behavior is registering multiple service types
                        // (not so common), it can do so manually in its Initialize method.

                        RegisterObject(registration.ServiceType, behavior);
                    }
                }
            }
        }

        /// <summary>
        /// Detaches all behaviors associated with the specified element.
        /// </summary>
        /// <param name="element">The element whose behaviors are to be detached.</param>
        private void DetachBehaviors(Element element) {
            // Detach all behaviors by enumerating the key/value pair list of
            // behaviors being maintained on the element, and disposing them
            // individually.

            Dictionary<string, Behavior> behaviors = Script.GetField<Dictionary<string, Behavior>>(element, Application.BehaviorsKey);
            if (behaviors != null) {
                IEnumerable<string> names = behaviors.Keys;
                foreach (string name in names) {
                    Behavior behavior = behaviors[name];
                    behavior.Dispose();
                }
            }
        }

        /// <summary>
        /// Registers a behavior so it can be used declaratively in markup.
        /// </summary>
        /// <param name="name">The unique name of the behavior.</param>
        /// <param name="behaviorType">The type of the behavior.</param>
        public extern void RegisterBehavior(string name, Type behaviorType);

        /// <summary>
        /// Registers a behavior so it can be used declaratively in markup.
        /// </summary>
        /// <param name="name">The unique name of the behavior.</param>
        /// <param name="behaviorType">The type of the behavior.</param>
        /// <param name="serviceType">An option service type associated with the behavior for auto-registration with the application container.</param>
        public void RegisterBehavior(string name, Type behaviorType, Type serviceType) {
            Debug.Assert(String.IsNullOrEmpty(name) == false);
            Debug.Assert(behaviorType != null);
            Debug.Assert(typeof(Behavior).IsAssignableFrom(behaviorType));
            Debug.Assert(_registeredBehaviors.ContainsKey(name) == false, "A behavior with name '" + name + "' was already registered.");

            BehaviorRegistration registration = new BehaviorRegistration();
            registration.BehaviorType = behaviorType;
            registration.ServiceType = serviceType;

            _registeredBehaviors[name] = registration;
            Script.SetField(behaviorType, Application.BehaviorNameKey, name);
        }
    }
}
