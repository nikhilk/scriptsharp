// Application.Services.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Html;
using Sharpen.Html.Utility;

namespace Sharpen.Html {

    public sealed partial class Application {

        /// <summary>
        /// Registers a service type.
        /// </summary>
        /// <param name="name">The name of the service.</param>
        /// <param name="serviceImplementationType">The type providing the implementation of the service.</param>
        /// <param name="serviceType">The type of the service.</param>
        public void RegisterService(string name, Type serviceImplementationType, Type serviceType) {
            Debug.Assert(String.IsNullOrEmpty(name) == false);
            Debug.Assert(serviceImplementationType != null);
            Debug.Assert(serviceType != null);
            Debug.Assert(_registeredServices.ContainsKey(name) == false, "A service with name '" + name + "' was already registered.");

            ServiceRegistration registration = new ServiceRegistration();
            registration.ServiceImplementationType = serviceImplementationType;
            registration.ServiceType = serviceType;

            _registeredServices[name] = registration;
        }

        private void SetupServices() {
            string servicesAttribute = (string)Document.Body.GetAttribute(ServicesAttribute);
            if (String.IsNullOrEmpty(servicesAttribute)) {
                return;
            }

            string[] serviceNames = servicesAttribute.Split(",");
            int serviceCount = serviceNames.Length;

            for (int i = 0; i < serviceCount; i++) {
                string name = serviceNames[i];

                ServiceRegistration registration = _registeredServices[name];
                Debug.Assert(registration != null, "Unknown service '" + name + "'");

                // TODO: Add support for deferred loading of service implementation, where
                //       the service gets included later, even though it is declared at the
                //       page level.

                object service = GetObject(registration.ServiceImplementationType);

                IInitializable initializableService = service as IInitializable;
                if (initializableService != null) {
                    Dictionary<string, object> options = OptionsParser.GetOptions(Document.Body, name);
                    initializableService.BeginInitialization(options);
                    initializableService.EndInitialization();
                }

                RegisterObject(registration.ServiceType, service);
            }
        }
    }
}
