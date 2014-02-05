using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Ajax.Utilities;
using System.IO;
using System.Xml;

namespace ScriptSharp.Tasks.Obfuscator {
    public class AjaxMinObfuscator {

        private readonly string _obfuscationStyle;
        private ObfuscationStyleEnum ObfuscationStyle {
            get {
                var sstyle = !string.IsNullOrEmpty(_obfuscationStyle)
                    ? _obfuscationStyle
                    : "Full";

                var style = ObfuscationStyleEnum.Full;
                Enum.TryParse<ObfuscationStyleEnum>(value: sstyle, ignoreCase: true, result: out style);
                return style;

            }
        }

        public AjaxMinObfuscator(string obfuscationStyle) {
            _obfuscationStyle = obfuscationStyle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obfuscationStyle">
        /// X : prefix obfuscated symbol with a X (helps with debugging obfuscated code)</param>
        /// Full : fully obfuscate symbols
        /// None : disable obfuscation
        /// </param>
        public void Obfuscate(IEnumerable<string> scripts, string renamefile, string obfuscatedfile) {


            var merged = Merge(scripts);
            var norenames = ReadNoRename(renamefile);
            var renames = ReadRename(renamefile);
            ShuffleRenameKeys(renames);
            var obfuscated = Obfuscate(merged, norenames, renames);

            File.WriteAllText(obfuscatedfile, obfuscated);
        }


        private void ShuffleRenameKeys(List<RenamePair> renames) {

            int count = renames.Count();
            var obfid = Generate(count);
            var permutation = RandomPermutation(count);
            var shuffled = Shuffle(obfid, permutation);

            for (int i = 0; i < count; i++) {

                string rename = shuffled[i];
                switch (ObfuscationStyle) {
                    case ObfuscationStyleEnum.X:
                        rename = "x" + renames[i].From;
                        break;
                    case ObfuscationStyleEnum.Full:
                        rename = shuffled[i];
                        break;
                    default:
                        rename = renames[i].From;
                        break;
                }
                renames[i].To = rename;
            }

        }

        public static int[] RandomPermutation(int length) {

            int[] arr = new int[length];

            for (int i = 0; i < arr.Length - 1; i++) {
                int swapIndex = Random.Next(i + 1, arr.Length);
                arr[i] = swapIndex;
            }

            return arr;
        }

        public static IEnumerable<string> Generate(int length) {
            for (int i = 0; i < length; i++) {
                yield return "x" + i;
            }
        }

        static Random Random = new Random();
        public static T[] Shuffle<T>(IEnumerable<T> sequence, int[] permutation) {

            T[] retArray = sequence.ToArray();
            for (int i = 0; i < retArray.Length - 1; i += 1) {
                int swapIndex = permutation[i];
                T temp = retArray[i];
                retArray[i] = retArray[swapIndex];
                retArray[swapIndex] = temp;
            }

            return retArray;
        }

        string Merge(IEnumerable<string> files) {

            using (var output = new MemoryStream()) {

                foreach (var file in files) {
                    using (var input = File.OpenRead(file)) {
                        input.CopyTo(output);
                    }
                }

                return Encoding.UTF8.GetString(output.ToArray());
            }

        }

        IEnumerable<string> ReadNoRename(string fmap) {

            using (var file = new FileStream(fmap, FileMode.Open, FileAccess.Read, FileShare.Read)) {

                var xml = new XmlDocument();
                xml.Load(file);
                var nodes = xml.SelectNodes("//norename[@id]");
                List<string> norenames = new List<string>();
                foreach (XmlNode node in nodes) {
                    string norename = node.Attributes["id"].Value;
                    norenames.Add(norename);
                }

                return norenames;
            }

        }

        internal class RenamePair {
            internal RenamePair(string from, string to) {
                From = from;
                To = to;
            }
            internal string From;
            internal string To;
        }

        List<RenamePair> ReadRename(string fmap) {

            using (var file = new FileStream(fmap, FileMode.Open, FileAccess.Read, FileShare.Read)) {

                var xml = new XmlDocument();
                xml.Load(file);
                var nodes = xml.SelectNodes("//rename[@from][@to]");
                List<RenamePair> rename = new List<RenamePair>();
                foreach (XmlNode node in nodes) {
                    string from = node.Attributes["from"].Value;
                    string to = node.Attributes["to"].Value;
                    var t = new RenamePair(from, to);
                    rename.Add(t);
                }

                return rename;
            }

        }

        Microsoft.Ajax.Utilities.OutputMode GetOutputMode(ObfuscationStyleEnum style) {
            var dic = new Dictionary<ObfuscationStyleEnum, OutputMode> {
                { ObfuscationStyleEnum.None, OutputMode.MultipleLines },
                { ObfuscationStyleEnum.X, OutputMode.MultipleLines },
                { ObfuscationStyleEnum.Full, OutputMode.SingleLine }
            };

            return dic.ContainsKey(style) ? dic[style] : OutputMode.SingleLine;
        }

        string Obfuscate(string script, IEnumerable<string> norenames, IEnumerable<RenamePair> renames) {

            var minifier = new Minifier();
            var settings = new CodeSettings() {
                StripDebugStatements = true,
                OutputMode = GetOutputMode(ObfuscationStyle),
                IgnorePreprocessorDefines = true,
                IgnoreConditionalCompilation = true,
                MinifyCode = ObfuscationStyle == ObfuscationStyleEnum.None ? false : true
            };

            foreach (var s in norenames) { settings.AddNoAutoRename(s); };
            foreach (var p in renames) { settings.AddRenamePair(p.From, p.To); };

            settings.SetDebugNamespaces(null);

            string obfuscated = minifier.MinifyJavaScript(script, settings);
            return obfuscated;
        }


    }
}
