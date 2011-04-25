// ScriptCollection.cs
// Script#/Runtime/Server
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Collections;
using System.Configuration;
using System.Diagnostics;
using System.Web.Configuration;

namespace ScriptSharp.Web.Configuration {

    [ConfigurationCollection(typeof(ScriptElement), AddItemName = "script", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class ScriptCollection : ConfigurationElementCollection {

        private static readonly ConfigurationPropertyCollection AllProperties =
            new ConfigurationPropertyCollection();

        public ScriptCollection()
            : base(StringComparer.OrdinalIgnoreCase) {
        }

        public override ConfigurationElementCollectionType CollectionType {
            get {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override string ElementName {
            get {
                return "script";
            }
        }

        protected override ConfigurationPropertyCollection Properties {
            get {
                return AllProperties;
            }
        }

        public ScriptElement this[int index] {
            get {
                return (ScriptElement)BaseGet(index);
            }
            set {
                if (BaseGet(index) != null) {
                    BaseRemoveAt(index);
                }

                BaseAdd(index, value);
            }
        }

        public new ScriptElement this[string name] {
            get {
                return (ScriptElement)BaseGet(name);
            }
        }

        public void Add(ScriptElement script) {
            BaseAdd(script);
        }

        public void Remove(ScriptElement script) {
            BaseRemove(GetElementKey(script));
        }

        public void Clear() {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement() {
            return new ScriptElement();
        }

        protected override object GetElementKey(ConfigurationElement element) {
            return ((ScriptElement)element).Name;
        }

        internal ScriptElement GetElement(string scriptName, string flavor) {
            Debug.Assert(String.IsNullOrEmpty(scriptName) == false);

            ScriptElement scriptElement = null;

            if (String.IsNullOrEmpty(flavor) == false) {
                string flavorName = scriptName + "." + flavor;
                scriptElement = this[flavorName];
            }

            if (scriptElement == null) {
                scriptElement = this[scriptName];
            }

            if (scriptElement == null) {
                throw new ArgumentException("The referenced script named '" + scriptName + "' was not registered in configuration as a script.", "scriptName");
            }

            return scriptElement;
        }
    }
}
