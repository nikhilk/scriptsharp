// Application.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Html;
using System.Runtime.CompilerServices;
using Sharpen.Html.Utility;

namespace Sharpen.Html {

    /// <summary>
    /// A page-level singleton representing the current application. It provides core
    /// services like settings, IoC, and pub/sub events-based messaging for decoupled
    /// components.
    /// </summary>
    public sealed partial class Application : IApplication, IContainer, IEventManager {

        internal const string ServicesAttribute = "data-services";

        internal const string BehaviorNameKey = "behaviorName";
        internal const string BehaviorsKey = "behaviors";
        internal const string BehaviorsAttribute = "data-behavior";
        internal const string BehaviorsSelector = "*[data-behavior]";

        internal const string ModelTypeAttribute = "data-model-type";

        internal const string BindingsAttribute = "data-bindings";
        internal const string BindingsSelector = "*[data-bindings]";
        internal static readonly RegExp BindingsRegex =
            new RegExp(@"([a-z\.\-]+)\s*:\s*([a-z]+)\s+([^;]*)\s*\;", "gi");
        internal static readonly RegExp PropertyPathRegex =
            new RegExp(@"[a-z0-9\.]+", "gi");

        internal const string TemplateTypeAttribute = "data-template";
        internal const string TemplateOptionsAttribute = "template-options";

        /// <summary>
        /// The current Application instance.
        /// </summary>
        public static readonly Application Current = new Application();

        private readonly Dictionary<string, ServiceRegistration> _registeredServices;
        private readonly Dictionary<string, BehaviorRegistration> _registeredBehaviors;
        private readonly Dictionary<string, ExpressionFactory> _registeredExpressions;
        private readonly Dictionary<string, BinderFactory> _registeredBinders;
        private readonly Dictionary<string, TemplateEngine> _registeredTemplateEngines;
        private readonly Dictionary<string, Template> _registeredTemplates;

        private Dictionary<string, object> _catalog;
        private Dictionary<string, Dictionary<string, Callback>> _subscriptions;
        private int _subscriptionCount;

        private object _model;

        static Application() {
            Script.SetTimeout(delegate() {
                Application.Current.ActivateFragment(Document.Body, /* contentOnly */ false);
            }, 0);
        }

        private Application() {
            _catalog = new Dictionary<string, object>();
            _subscriptions = new Dictionary<string, Dictionary<string, Callback>>();

            _registeredServices = new Dictionary<string, ServiceRegistration>();
            _registeredBehaviors = new Dictionary<string, BehaviorRegistration>();
            _registeredExpressions = new Dictionary<string, ExpressionFactory>();
            _registeredBinders = new Dictionary<string, BinderFactory>();
            _registeredTemplateEngines = new Dictionary<string, TemplateEngine>();
            _registeredTemplates = new Dictionary<string, Template>();

            RegisterObject(typeof(IApplication), this);
            RegisterObject(typeof(IContainer), this);
            RegisterObject(typeof(IEventManager), this);

            RegisterBehavior(BinderManager.BehaviorName, typeof(BinderManager));
            RegisterExpression("bind", ProcessModelExpression);
            RegisterExpression("init", ProcessModelExpression);
            RegisterExpression("link", ProcessModelExpression);
            RegisterExpression("exec", ProcessModelExpression);
            RegisterBinder("text", BindContent);
            RegisterBinder("html", BindContent);
            RegisterBinder("value", BindValue);
            RegisterBinder("visibility", BindVisibility);
        }

        /// <summary>
        /// The model object associated with the application.
        /// </summary>
        public object Model {
            get {
                return _model;
            }
        }

        /// <summary>
        /// Activates a specified element and its children by instantiating any
        /// declaratively specified behaviors or bindings within the markup.
        /// </summary>
        /// <param name="element">The element to activate.</param>
        /// <param name="contentOnly">Whether the element should be activated, or only its contained content.</param>
        public extern void ActivateFragment(Element element, bool contentOnly);

        /// <summary>
        /// Activates a specified element and its children by instantiating any
        /// declaratively specified behaviors or bindings within the markup.
        /// </summary>
        /// <param name="element">The element to activate.</param>
        /// <param name="contentOnly">Whether the element should be activated, or only its contained content.</param>
        /// <param name="model">The model to bind to.</param>
        public void ActivateFragment(Element element, bool contentOnly, object model) {
            Debug.Assert(element != null);

            if (element == Document.Body) {
                // Perform app-level activation (tied to body initialization)

                // Setup top-level services specified declaratively.
                SetupServices();

                // Create the model declaratively associated with the application.
                if (model == null) {
                    string modelTypeName = (string)Document.Body.GetAttribute(ModelTypeAttribute);
                    if (String.IsNullOrEmpty(modelTypeName) == false) {
                        Type modelType = Type.GetType(modelTypeName);
                        Debug.Assert(modelType != null, "Could not resolve model '" + modelTypeName + "'");

                        model = GetObject(modelType);

                        IInitializable initializableModel = model as IInitializable;
                        if (initializableModel != null) {
                            Dictionary<string, object> modelData = OptionsParser.GetOptions(element, "model");
                            initializableModel.BeginInitialization(modelData);
                            initializableModel.EndInitialization();
                        }
                    }
                }

                _model = model;
            }

            // Create expressions and bindings associated with the specified elements and
            // the contained elements. Do this first, as this allows behaviors to look at
            // values set as a result of bindings when they are attached.
            if ((contentOnly == false) && element.HasAttribute(Application.BindingsAttribute)) {
                SetupBindings(element, model);
            }

            ElementCollection boundElements = element.QuerySelectorAll(Application.BindingsSelector);
            for (int i = 0, boundElementCount = boundElements.Length; i < boundElementCount; i++) {
                SetupBindings(boundElements[i], model);
            }

            // Attach behaviors associated declaratively with the specified element and the
            // contained elements.
            if ((contentOnly == false) && element.HasAttribute(Application.BehaviorsAttribute)) {
                AttachBehaviors(element);
            }

            ElementCollection extendedElements = element.QuerySelectorAll(Application.BehaviorsSelector);
            for (int i = 0, extendedElementCount = extendedElements.Length; i < extendedElementCount; i++) {
                AttachBehaviors(extendedElements[i]);
            }
        }

        /// <summary>
        /// Deactivates the specified element and its children by disposing any
        /// behaviors or binding instances attached to the elements.
        /// </summary>
        /// <param name="element">The element to deactivate.</param>
        /// <param name="contentOnly">Whether the element should be deactivated, or only its contained content.</param>
        public void DeactivateFragment(Element element, bool contentOnly) {
            Debug.Assert(element != null);

            // Detach behaviors associated with the element and the contained elements.
            if ((contentOnly == false) && element.HasAttribute(Application.BehaviorsAttribute)) {
                DetachBehaviors(element);
            }

            ElementCollection elements = element.QuerySelectorAll(Application.BehaviorsSelector);
            int matchingElements = elements.Length;

            if (matchingElements != 0) {
                for (int i = 0; i < matchingElements; i++) {
                    DetachBehaviors(elements[i]);
                }
            }
        }

        private string GetTypeKey(Type type) {
            string key = Script.GetField<string>(type, "$key");
            if (key == null) {
                key = Date.Now.GetTime().ToString();
                Script.SetField(type, "$key", key);
            }

            return key;
        }

        #region Implementation of IApplication

        /// <summary>
        /// Gets the value of the specified setting.
        /// </summary>
        /// <param name="name">The name of the setting.</param>
        /// <returns>The value of the specified setting.</returns>
        public string GetSetting(string name) {
            // TODO: Implement access to query string settings as well as maybe
            //       a few other things like JSON data written out as page-level
            //       metadata, or maybe a JSON block in an embedded script element.
            return null;
        }

        #endregion

        #region Implementation of IContainer

        /// <summary>
        /// Gets an instance of the specified object type. An instance is created
        /// if one has not been registered with the container. A factory method is
        /// called if a factory has been registered or implemented on the object type.
        /// </summary>
        /// <param name="objectType">The type of object to retrieve.</param>
        /// <returns>The object instance.</returns>
        public object GetObject(Type objectType) {
            Debug.Assert(objectType != null, "Expected an object type when creating objects.");

            string catalogKey = GetTypeKey(objectType);
            object catalogItem = _catalog[catalogKey];

            if (catalogItem == null) {
                Function objectFactory = Script.GetField(objectType, "factory") as Function;
                if (objectFactory != null) {
                    catalogItem = objectFactory;
                }
                else {
                    return Script.CreateInstance(objectType);
                }
            }

            if (catalogItem is Function) {
                return ((Function)catalogItem).Call(null, (IContainer)this, objectType);
            }

            return catalogItem;
        }

        /// <summary>
        /// Registers an object factory with the container. The factory is called
        /// when the particular object type is requested. The factory can decide whether to
        /// cache object instances it returns or not, based on its policy.
        /// </summary>
        /// <param name="objectType"></param>
        /// <param name="objectFactory"></param>
        public void RegisterFactory(Type objectType, Func<IContainer, Type, object> objectFactory) {
            Debug.Assert(objectType != null, "Expected an object type when registering object factories.");
            Debug.Assert(objectFactory != null, "Expected an object factory when registering object factories.");

            _catalog[GetTypeKey(objectType)] = objectFactory;
        }

        /// <summary>
        /// Registers an object instance for the specified object type.
        /// </summary>
        /// <param name="objectType">The type that can be used to lookup the specified object instance.</param>
        /// <param name="objectInstance">The object instance to use.</param>
        public void RegisterObject(Type objectType, object objectInstance) {
            Debug.Assert(objectType != null, "Expected an object type when registering objects.");
            Debug.Assert(objectInstance != null, "Expected an object instance when registering objects.");

            _catalog[GetTypeKey(objectType)] = objectInstance;
        }

        #endregion

        #region Implementation of IEventManager

        /// <summary>
        /// Raises the specified event. The type of the event arguments is used to determine
        /// which subscribers the event is routed to.
        /// </summary>
        /// <param name="eventArgs">The event arguments containing event-specific data.</param>
        public void PublishEvent(EventArgs eventArgs) {
            Debug.Assert(eventArgs != null, "Must specify an eventArgs when raising an event.");

            string eventTypeKey = GetTypeKey(eventArgs.GetType());

            Dictionary<string, Callback> eventHandlerMap = _subscriptions[eventTypeKey];
            if (eventHandlerMap != null) {
                // TODO: Handle the case where a subscriber unsubscribes while we're iterating
                //       Should we do it here by copying/cloning the list, or should we handle it
                //       by completing unsubscribe asynchronously?
                foreach (KeyValuePair<string, Callback> eventHandlerEntry in eventHandlerMap) {
                    eventHandlerEntry.Value(eventArgs);
                }
            }
        }

        /// <summary>
        /// Subscribes to the specified type of events. The resulting cookie can be used for
        /// unsubscribing.
        /// </summary>
        /// <param name="eventType">The type of the event.</param>
        /// <param name="eventHandler">The event handler to invoke when the specified event type is raised.</param>
        /// <returns></returns>
        public object SubscribeEvent(Type eventType, Callback eventHandler) {
            Debug.Assert(eventType != null, "Must specify an event type when subscribing to events.");
            Debug.Assert(eventHandler != null, "Must specify an event handler when subscribing to events.");

            string eventTypeKey = GetTypeKey(eventType);

            Dictionary<string, Callback> eventHandlerMap = _subscriptions[eventTypeKey];
            if (eventHandlerMap == null) {
                eventHandlerMap = new Dictionary<string, Callback>();
                _subscriptions[eventTypeKey] = eventHandlerMap;
            }

            string eventHandlerKey = (++_subscriptionCount).ToString();
            eventHandlerMap[eventHandlerKey] = eventHandler;

            // The subscription cookie we use is an object with the two strings
            // identifying the event handler uniquely - the event type key used to index
            // into the top-level event handlers key/value pair list, and the handler key
            // (as generated above) to index into the event-type-specific key/value pair list.
            // Keep these in sync with Unsubscribe...

            return new Dictionary<string, string>("type", eventTypeKey, "handler", eventHandlerKey);
        }

        /// <summary>
        /// Unsubcribes from a previously subscribed-to event type.
        /// </summary>
        /// <param name="subscriptionCookie">The subscription cookie.</param>
        public void UnsubscribeEvent(object subscriptionCookie) {
            Debug.Assert(subscriptionCookie != null, "Must specify the subscription cookie when unsubscribing to events.");
            Debug.Assert(Script.HasField(subscriptionCookie, "type") && Script.HasField(subscriptionCookie, "handler"),
                         "A valid subscription cookie is an object with 'type' and 'handler' fields.");

            Dictionary<string, string> keys = (Dictionary<string, string>)subscriptionCookie;

            Dictionary<string, Callback> eventHandlerMap = _subscriptions[keys["type"]];
            Debug.Assert(eventHandlerMap != null, "Invalid subscription cookie.");
            Debug.Assert(eventHandlerMap.ContainsKey(keys["handler"]), "Invalid subscription cookie.");

            eventHandlerMap.Remove(keys["handler"]);

            if (eventHandlerMap.Count == 0) {
                _subscriptions.Remove(keys["type"]);
            }
        }

        #endregion
    }
}
