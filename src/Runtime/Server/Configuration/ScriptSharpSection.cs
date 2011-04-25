// ScriptSharpSection.cs
// Script#/Runtime/Server
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Web.Configuration;

namespace ScriptSharp.Web.Configuration {

    public sealed class ScriptSharpSection : ConfigurationSection {

        private static readonly ConfigurationProperty ScriptsProperty =
            new ConfigurationProperty("", typeof(ScriptCollection), null,
                                      ConfigurationPropertyOptions.IsDefaultCollection);

        private static readonly ConfigurationProperty ClientScriptStorageCookieProperty =
            new ConfigurationProperty("clientScriptStorageCookie", typeof(string), "",
                                      new WhiteSpaceTrimStringConverter(),
                                      null,
                                      ConfigurationPropertyOptions.None);

        private static ConfigurationPropertyCollection AllProperties = BuildProperties();

        private static ScriptSharpSection SectionInstance;

        [ConfigurationProperty("clientScriptStorageCookie", DefaultValue = "")]
        public string ClientScriptStorageCookie {
            get {
                return (string)base[ClientScriptStorageCookieProperty];
            }
            set {
                base[ClientScriptStorageCookieProperty] = value;
            }
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public ScriptCollection Scripts {
            get {
                return (ScriptCollection)base[ScriptsProperty];
            }
        }

        protected override ConfigurationPropertyCollection Properties {
            get {
                return AllProperties;
            }
        }

        private static ConfigurationPropertyCollection BuildProperties() {
            ConfigurationPropertyCollection props = new ConfigurationPropertyCollection();
            props.Add(ScriptsProperty);
            props.Add(ClientScriptStorageCookieProperty);

            return props;
        }

        private static void EnsureSection() {
            if (SectionInstance == null) {
                SectionInstance = (ScriptSharpSection)WebConfigurationManager.GetSection("scriptSharp");
                if (SectionInstance == null) {
                    SectionInstance = new ScriptSharpSection();
                }
            }
        }

        internal static ScriptSharpSection GetSettings() {
            EnsureSection();
            return SectionInstance;
        }
    }
}
