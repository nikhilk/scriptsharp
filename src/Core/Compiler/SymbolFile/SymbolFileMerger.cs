using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace ScriptSharp.SymbolFile {

    /// <summary>
    /// Merges multiple symbol files into a single one
    /// </summary>
    public class SymbolFileMerger {

        public bool Merge(string[] symbols, string mergefile, out string error) {

            bool success = false;
            try {
                TryMerge(symbols, mergefile);
                success = true;
                error = null;
            } catch (Exception e) {
                error = e.ToString();
            }
            return success;
        }

        private void TryMerge(string[] symbols, string mergefile) {

            var merged = new XmlDocument();
            XmlElement root = merged.CreateElement(SymbolFile.RootElement);
            merged.AppendChild(root);

            foreach (var symbol in symbols) {
                var xml = new XmlDocument();
                xml.Load(symbol);

                string namespaces = string.Format("/{0}/{1}[@{2}='Namespace']", SymbolFile.RootElement, SymbolFile.SymbolElement, SymbolFile.TypeAttribute);
                foreach (XmlNode node in xml.SelectNodes(namespaces)) {
                    MergeNamespace(merged, root, node);
                }
            }

            merged.Save(mergefile);
        }

        private void MergeNamespace(XmlDocument merged, XmlElement root, XmlNode node) {

            string name = node.Attributes["Name"] == null ? null : node.Attributes["Name"].Value;
            string ns = string.Format("/{0}/{1}[@{2}='Namespace'][@{3}='{4}']", SymbolFile.RootElement, SymbolFile.SymbolElement, SymbolFile.TypeAttribute, SymbolFile.NameAttribute, name);

            var exists = merged.SelectSingleNode(ns);
            bool existsHasApplicationType = HasApplicationAttribue(exists);
            bool nodeHasApplicationType = HasApplicationAttribue(node);

            if (exists == null) {
                var imported = merged.ImportNode(node, true);
                root.AppendChild(imported);
            } else if (exists != null
                  && !existsHasApplicationType
                  && nodeHasApplicationType) {
                root.RemoveChild(exists);
                var imported = merged.ImportNode(node, true);
                root.AppendChild(imported);
            }
        }

        private bool HasApplicationAttribue(XmlNode node) {
            if (node == null) {
                return false;
            }
            if (node.Attributes[SymbolFile.HasApplicationTypesAttribute] == null) {
                return false;
            }
            bool value = false;
            bool.TryParse(node.Attributes[SymbolFile.HasApplicationTypesAttribute].Value, out value);
            return value;
        }
    }
}
