// Behavior.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Html;

namespace Sharpen.Html {

    /// <summary>
    /// Represents a script objects that can be attached to an Element to
    /// extend its standard functionality.
    /// </summary>
    public abstract class Behavior : IDisposable {

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
        /// Disposes a behavior by detaching itself from its associated element.
        /// When overriding this, be sure to call the base functionality at the after the implementation
        /// in the derived class.
        /// </summary>
        public virtual void Dispose() {
            Debug.Assert(_element != null, "Behavior has already been disposed.");

            // First remove the expando corresponding to this behavior on the element.

            string name = Script.GetField<string>(this.GetType(), Application.BehaviorNameKey);
            Script.DeleteField(_element, name);

            // Next remove this behavior from the key/value pair list of all behaviors
            // being maintained on the element.

            Dictionary<string, Behavior> behaviors = Script.GetField<Dictionary<string, Behavior>>(_element, Application.BehaviorsKey);
            Debug.Assert(behaviors != null);

            behaviors.Remove(name);

            _element = null;
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

            Dictionary<string, Behavior> behaviors = Script.GetField<Dictionary<string, Behavior>>(element, Application.BehaviorsKey);
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

            string name = Script.GetField<string>(this.GetType(), Application.BehaviorNameKey);
            Script.SetField(element, name, this);

            // Add a 'behaviors' expando on the element which is a key/value pair
            // list of behavior name -> behavior instance mapping.

            Dictionary<string, Behavior> behaviors = Script.GetField<Dictionary<string, Behavior>>(element, Application.BehaviorsKey);
            if (behaviors == null) {
                behaviors = new Dictionary<string, Behavior>();
                Script.SetField(element, Application.BehaviorsKey, behaviors);
            }

            behaviors[name] = this;

            // Set data-behavior on the element if it is not already set (i.e. if the behavior
            // is being programmatically constructed), so that if DisposeBehaviors is called,
            // then this element is picked up via the CSS query used to find elements that have
            // behaviors.
            if (element.HasAttribute(Application.BehaviorsAttribute) == false) {
                element.SetAttribute(Application.BehaviorsAttribute, String.Empty);
            }
        }
    }
}
