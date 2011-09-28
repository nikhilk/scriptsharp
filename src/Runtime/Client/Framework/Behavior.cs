// Behavior.cs
// Script#/Runtime/Client/Framework
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Html;
using System.Runtime.CompilerServices;

namespace Sharpen {

    /// <summary>
    /// Represents a script objects that can be attached to an Element to
    /// extend its standard functionality.
    /// </summary>
    public abstract class Behavior : IDisposable {

        private static readonly Dictionary<string, BehaviorRegistration> _registeredBehaviors = new Dictionary<string, BehaviorRegistration>();

        private const string BehaviorNameKey = "behaviorName";
        private const string BehaviorsKey = "behaviors";
        private const string BehaviorsAttribute = "data-behavior";
        private const string BehaviorsSelector = "*[data-behavior]";

        private Element _element;

        /// <summary>
        /// Gets the element that this behavior is attached to.
        /// </summary>
        protected Element Element {
            get {
                Debug.Assert(_element != null, "Element is being accessed after this behavior has been disposed.");
                return _element;
            }
        }

        /// <summary>
        /// Creates and attaches behaviors specified on the element declaratively.
        /// </summary>
        /// <param name="element">The element whose behaviors should be created and attached.</param>
        private static void AttachBehaviors(Element element) {
            string[] behaviorNames = ((string)element.GetAttribute(Behavior.BehaviorsAttribute)).Split(",");
            int behaviorCount = behaviorNames.Length;

            if (behaviorCount != 0) {
                for (int i = 0; i < behaviorCount; i++) {
                    string name = behaviorNames[i].Trim();

                    BehaviorRegistration registration = _registeredBehaviors[name];
                    Debug.Assert(registration != null, "Unknown behavior '" + name + "'");

                    if (registration != null) {
                        Dictionary<string, object> options = OptionsParser.GetOptions(element, name);

                        // Use the Application's IoC capabilities to create behaviors.
                        // This allows satisfying dependencies behaviors have to other services,
                        // and also allows behaviors to provide or register services into the container.

                        Behavior behavior = (Behavior)Application.Current.GetObject(registration.BehaviorType);
                        behavior.Initialize(element, options);

                        if (registration.ServiceType != null) {
                            // Special-case the common case where a behavior represents a single
                            // service type, and auto-register it.
                            // In the case where a behavior is registering multiple service types
                            // (not so common), it can do so manually in its Initialize method.

                            Application.Current.RegisterObject(registration.ServiceType, behavior);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Detaches all behaviors associated with the specified element.
        /// </summary>
        /// <param name="element">The element whose behaviors are to be detached.</param>
        private static void DetachBehaviors(Element element) {
            // Detach all behaviors by enumerating the key/value pair list of
            // behaviors being maintained on the element, and disposing them
            // individually.

            Dictionary<string, Behavior> behaviors = (Dictionary<string, Behavior>)Type.GetField(element, Behavior.BehaviorsKey);
            if (behaviors != null) {
                IEnumerable<string> names = behaviors.Keys;
                foreach (string name in names) {
                    Behavior behavior = behaviors[name];
                    behavior.Dispose();
                }
            }
        }

        /// <summary>
        /// Disposes a behavior by detaching itself from its associated element.
        /// When overriding this, be sure to call the base functionality at the after the implementation
        /// in the derived class.
        /// </summary>
        public virtual void Dispose() {
            Debug.Assert(_element != null, "Behavior has already been disposed.");

            // First remove the expando corresponding to this behavior on the element.

            string name = (string)Type.GetField(this.GetType(), BehaviorNameKey);
            Type.DeleteField(_element, name);

            // Next remove this behavior from the key/value pair list of all behaviors
            // being maintained on the element.

            Dictionary<string, Behavior> behaviors = (Dictionary<string, Behavior>)Type.GetField(_element, BehaviorsKey);
            Debug.Assert(behaviors != null);

            behaviors.Remove(name);

            _element = null;
        }

        /// <summary>
        /// Disposes and detaches behaviors attached to the specified element and optionally
        /// to contained elements.
        /// </summary>
        /// <param name="element">The element to detach behaviors from.</param>
        /// <param name="recursive">Whether to recursively detach behaviors from contained elements.</param>
        public static void DisposeBehaviors(Element element, bool recursive) {
            Debug.Assert(element != null);

            // TODO: Fix Script.Web
            if ((bool)Type.InvokeMethod(element, "hasAttribute", Behavior.BehaviorsAttribute)) {
                DetachBehaviors(element);
            }

            if (recursive) {
                ElementCollection elements = element.QuerySelectorAll(Behavior.BehaviorsSelector);
                int matchingElements = elements.Length;

                if (matchingElements != 0) {
                    for (int i = 0; i < matchingElements; i++) {
                        DetachBehaviors(elements[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Gets a behavior instance attached to the specified element if one exists.
        /// </summary>
        /// <param name="element">The element to lookup.</param>
        /// <param name="behaviorType">The type of the behavior to lookup.</param>
        /// <returns></returns>
        public static Behavior GetBehavior(Element element, Type behaviorType) {
            Debug.Assert(element != null, "Must specify the element to inspect for a behavior instance.");
            Debug.Assert(behaviorType != null, "Must specify a behavior type to lookup.");

            // Find the first matching behavior by enumerating the key/value pair
            // list of behaviors on the element.

            Dictionary<string, Behavior> behaviors = (Dictionary<string, Behavior>)Type.GetField(element, BehaviorsKey);
            if (behaviors != null) {
                foreach (KeyValuePair<string, Behavior> behaviorEntry in behaviors) {
                    if (behaviorType.IsInstanceOfType(behaviorEntry.Value)) {
                        return behaviorEntry.Value;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Initializes a behavior by attaching it to the specified element.
        /// When overriding this, be sure to call the base functionality before the implementation
        /// in the derived class.
        /// </summary>
        /// <param name="element">The element to attach the behavior to.</param>
        /// <param name="options">Any initialization options that the behavior should consume.</param>
        public virtual void Initialize(Element element, Dictionary<string, object> options) {
            Debug.Assert(_element == null, "A behavior should be initialized only once.");
            Debug.Assert(element != null, "Expected a valid element to initialize a behavior.");

            _element = element;

            // Automatically expose the behavior on the DOM element as an expando using
            // the name of the behavior as the key.

            string name = (string)Type.GetField(this.GetType(), BehaviorNameKey);
            Type.SetField(element, name, this);

            // Add a 'behaviors' expando on the element which is a key/value pair
            // list of behavior name -> behavior instance mapping.

            Dictionary<string, Behavior> behaviors = (Dictionary<string, Behavior>)Type.GetField(element, BehaviorsKey);
            if (behaviors == null) {
                behaviors = new Dictionary<string, Behavior>();
                Type.SetField(element, BehaviorsKey, behaviors);
            }

            behaviors[name] = this;

            // Set data-behavior on the element if it is not already set (i.e. if the behavior
            // is being programmatically constructed), so that if DisposeBehaviors is called,
            // then this element is picked up via the CSS query used to find elements that have
            // behaviors.
            // TODO: Fix Script.Web
            if ((bool)Type.InvokeMethod(element, "hasAttribute", BehaviorsAttribute) == false) {
                element.SetAttribute(BehaviorsAttribute, String.Empty);
            }
        }

        /// <summary>
        /// Registers a behavior so it can be used declaratively in markup.
        /// </summary>
        /// <param name="name">The unique name of the behavior.</param>
        /// <param name="behaviorType">The type of the behavior.</param>
        [AlternateSignature]
        public static extern void RegisterBehavior(string name, Type behaviorType);

        /// <summary>
        /// Registers a behavior so it can be used declaratively in markup.
        /// </summary>
        /// <param name="name">The unique name of the behavior.</param>
        /// <param name="behaviorType">The type of the behavior.</param>
        /// <param name="serviceType">An option service type associated with the behavior for auto-registration with the application container.</param>
        public static void RegisterBehavior(string name, Type behaviorType, Type serviceType) {
            Debug.Assert(String.IsNullOrEmpty(name) == false);
            Debug.Assert(behaviorType != null);
            Debug.Assert(typeof(Behavior).IsAssignableFrom(behaviorType));
            Debug.Assert(_registeredBehaviors.ContainsKey(name) == false, "A behavior with name '" + name + "' was already registered.");

            BehaviorRegistration registration = new BehaviorRegistration();
            registration.BehaviorType = behaviorType;
            registration.ServiceType = serviceType;

            _registeredBehaviors[name] = registration;
            Type.SetField(behaviorType, Behavior.BehaviorNameKey, name);
        }

        /// <summary>
        /// Attaches behaviors associated declaratively with the specified element and optionally
        /// to contained elements.
        /// </summary>
        /// <param name="element">The element to attach behaviors to.</param>
        /// <param name="recursive">Whether to recursively attach behaviors from contained elements.</param>
        public static void SetupBehaviors(Element element, bool recursive) {
            Debug.Assert(element != null);

            if (element.HasAttribute(Behavior.BehaviorsAttribute)) {
                AttachBehaviors(element);
            }

            if (recursive) {
                ElementCollection elements = element.QuerySelectorAll(Behavior.BehaviorsSelector);
                int matchingElements = elements.Length;

                if (matchingElements != 0) {
                    for (int i = 0; i < matchingElements; i++) {
                        AttachBehaviors(elements[i]);
                    }
                }
            }
        }
    }
}
