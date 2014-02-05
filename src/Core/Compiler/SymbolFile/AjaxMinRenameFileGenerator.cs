using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace ScriptSharp.SymbolFile {
    public class AjaxMinRenameFileGenerator {

        internal const string RootElement = "root";
        internal const string RenameElement = "rename";
        internal const string NorenameElement = "norename";
        internal const string IdAttribute = "id";
        internal const string FromAttribute = "from";
        internal const string ToAttribute = "to";

        /// <summary>
        /// Generate an AjaxMin rename file, based on Exported Symbols
        /// </summary>
        /// <param name="mfs">Merged symbol file</param>
        /// <param name="amrf">AjaxMin rename file</param>
        public void Generate(string symbol, string rename) {

            string renames = @"//Symbol[@GeneratedName][ancestor::Symbol[@HasApplicationTypes='True']]";
            string norenames = @"//Symbol[@GeneratedName][ancestor::Symbol[@HasApplicationTypes='False']] 
                | //Symbol[@GeneratedName][ancestor::Symbol[@IsScriptImported='True']]
                | //Symbol[@GeneratedName][@IsScriptImported='True']
            ";

            var xmsf = new XmlDocument();
            xmsf.Load(symbol);

            var renameNodes = xmsf.SelectNodes(renames);
            var norenameNodes = xmsf.SelectNodes(norenames);

            HashSet<string> norenameHash = new HashSet<string>();
            foreach (XmlNode node in norenameNodes) {
                string name = GetAttribute(node, SymbolFile.GeneratedNameAttribute);
                norenameHash.Add(name);

                // $.bbq.getstate get expanded as getstate
                // otherwise ajaxmin will it
                var names = name.Split(new[] { '.' });
                string trailing = names[names.Length - 1];
                norenameHash.Add(trailing);
            }

            HashSet<string> renameHash = new HashSet<string>();
            foreach (XmlNode node in renameNodes) {
                string name = GetAttribute(node, SymbolFile.GeneratedNameAttribute);
                if (norenameHash.Contains(name)) {
                    continue;
                }
                renameHash.Add(name);
            }

            GenerateFile(rename, norenameHash, renameHash);

        }

        private void GenerateFile(string rename, HashSet<string> norenameHash, HashSet<string> renameHash) {

            using (XmlTextWriter writer = new XmlTextWriter(rename, Encoding.UTF8)) {

                writer.WriteStartDocument();
                writer.WriteStartElement(RootElement);

                var seq = Generate(renameHash.Count);
                var random = RandomPermutation<string>(seq).ToArray();

                int i = 0;
                foreach (string ren in renameHash) {
                    writer.WriteStartElement(RenameElement);
                    writer.WriteAttributeString(FromAttribute, ren);
                    writer.WriteAttributeString(ToAttribute, random[i++]);
                    writer.WriteEndElement();
                }

                foreach (string ren in norenameHash) {
                    writer.WriteStartElement(NorenameElement);
                    writer.WriteAttributeString(IdAttribute, ren);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                writer.Close();

            }

        }

        public static IEnumerable<string> Generate(int length) {
            for (int i = 0; i < length; i++) {
                yield return "x" + i;
            }
        }

        static Random random = new Random();
        public static IEnumerable<T> RandomPermutation<T>(IEnumerable<T> sequence) {
            T[] retArray = sequence.ToArray();


            for (int i = 0; i < retArray.Length - 1; i += 1) {
                int swapIndex = random.Next(i + 1, retArray.Length);
                T temp = retArray[i];
                retArray[i] = retArray[swapIndex];
                retArray[swapIndex] = temp;
            }

            return retArray;
        }

        string GetAttribute(XmlNode node, string attributeName) {
            if (node == null) {
                return null;
            }
            if (node.Attributes[attributeName] == null) {
                return null;
            }
            return node.Attributes[attributeName].Value;
        }
    }
}
