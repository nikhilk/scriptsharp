// ResourceModelBuilder.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.IO;
using ScriptSharp.ScriptModel;

namespace ScriptSharp.ResourceModel {

    internal sealed class ResourcesBuilder {

        private SymbolSet _symbols;

        public ResourcesBuilder(SymbolSet symbols) {
            _symbols = symbols;
        }

        public void BuildResources(ICollection<IStreamSource> sources) {
            // Process resources in the order of neutral to most specific locale
            // so that as string values are looked up and stored, the final value
            // contains the most specific locale value.
            // This is a somewhat hacky way to get the ordering right, without
            // have to sort through sets of related resource files, and constructing
            // a hierarchy in the right order.

            // First handle all the locale-neutral resources
            foreach (IStreamSource source in sources) {
                string locale = Utility.GetResourceFileLocale(source.Name);

                if (locale.Length == 0) {
                    BuildResources(source);
                }
            }

            // Next handle all the language-only resource files
            foreach (IStreamSource source in sources) {
                string locale = Utility.GetResourceFileLocale(source.Name);

                if (locale.Length == 2) {
                    BuildResources(source);
                }
            }

            // Finally handle all the language+country resource files
            foreach (IStreamSource source in sources) {
                string locale = Utility.GetResourceFileLocale(source.Name);

                if (locale.Length > 2) {
                    BuildResources(source);
                }
            }
        }

        private void BuildResources(IStreamSource source) {
            string resxMarkup = GetMarkup(source);
            List<ResXItem> resourceItems = ResXParser.ParseResxMarkup(resxMarkup);

            string resourceName = Utility.GetResourceFileName(source.Name);
            Dictionary<string, ResXItem> existingResourceItems = _symbols.GetResources(resourceName);

            foreach (ResXItem item in resourceItems) {
                existingResourceItems[item.Name] = item;
            }
        }

        private string GetMarkup(IStreamSource source) {
            string markup = null;

            Stream stream = source.GetStream();
            try {
                StreamReader reader = new StreamReader(stream);
                markup = reader.ReadToEnd();
            }
            finally {
                if (stream != null) {
                    source.CloseStream(stream);
                    stream = null;
                }
            }
            return markup;
        }
    }
}
