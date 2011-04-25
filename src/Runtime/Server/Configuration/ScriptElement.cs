// ScriptElement.cs
// Script#/Runtime/Server
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Configuration;
using System.Diagnostics;
using System.Web.Configuration;

namespace ScriptSharp.Web.Configuration {

    public sealed class ScriptElement : ConfigurationElement {

        private static readonly ConfigurationProperty NameProperty =
            new ConfigurationProperty("name", typeof(string), null,
                                      new WhiteSpaceTrimStringConverter(),
                                      new StringValidator(1),
                                      ConfigurationPropertyOptions.IsRequired | ConfigurationPropertyOptions.IsKey);

        private static readonly ConfigurationProperty UrlProperty =
            new ConfigurationProperty("url", typeof(string), null,
                                      new WhiteSpaceTrimStringConverter(),
                                      new StringValidator(1),
                                      ConfigurationPropertyOptions.IsRequired);

        private static readonly ConfigurationProperty DependenciesProperty =
            new ConfigurationProperty("dependencies", typeof(string), null,
                                      new WhiteSpaceTrimStringConverter(),
                                      new StringValidator(1),
                                      ConfigurationPropertyOptions.None);

        private static readonly ConfigurationProperty VersionProperty =
            new ConfigurationProperty("version", typeof(string), null,
                                      new WhiteSpaceTrimStringConverter(),
                                      new StringValidator(1),
                                      ConfigurationPropertyOptions.None);

        private static ConfigurationPropertyCollection AllProperties = BuildProperties();

        [ConfigurationProperty("dependencies", IsRequired = false, DefaultValue = "")]
        public string Dependencies {
            get {
                return (string)base[DependenciesProperty];
            }
            set {
                base[DependenciesProperty] = value;
            }
        }

        [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = "")]
        [StringValidator(MinLength = 1)]
        public string Name {
            get {
                return (string)base[NameProperty];
            }
            set {
                base[NameProperty] = value;
            }
        }

        [ConfigurationProperty("url", IsRequired = true, DefaultValue = "")]
        [StringValidator(MinLength = 1)]
        public string Url {
            get {
                return (string)base[UrlProperty];
            }
            set {
                base[UrlProperty] = value;
            }
        }

        [ConfigurationProperty("version", IsRequired = false, DefaultValue = "")]
        public string Version {
            get {
                return (string)base[VersionProperty];
            }
            set {
                base[VersionProperty] = value;
            }
        }

        protected override ConfigurationPropertyCollection Properties {
            get {
                return AllProperties;
            }
        }

        private static ConfigurationPropertyCollection BuildProperties() {
            ConfigurationPropertyCollection props = new ConfigurationPropertyCollection();
            props.Add(NameProperty);
            props.Add(UrlProperty);
            props.Add(DependenciesProperty);
            props.Add(VersionProperty);

            return props;
        }

        internal string[] GetDependencyList() {
            string dependencies = Dependencies;
            if (String.IsNullOrEmpty(dependencies) == false) {
                return dependencies.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            return null;
        }
    }
}
