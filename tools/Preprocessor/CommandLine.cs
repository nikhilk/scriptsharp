// CommandLine.cs
// Script#/Common
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace ScriptSharp {

    internal sealed class CommandLine {

        private string[] _arguments;
        private IDictionary _options;
        private bool _showHelp;
        private bool _hideAbout;

        public CommandLine(string[] args) {
            if (args == null) {
                throw new ArgumentNullException("args");
            }
            args = ExpandResponseFileArguments(args);

            ArrayList argList = new ArrayList();

            for (int i = 0; i < args.Length; i++) {
                char c = args[i][0];
                if ((c != '/') && (c != '-')) {
                    argList.Add(args[i]);
                }
                else {
                    int index = args[i].IndexOf(':');
                    if (index == -1) {
                        string option = args[i].Substring(1);
                        if ((String.Compare(option, "help", StringComparison.OrdinalIgnoreCase) == 0) ||
                            (String.Compare(option, "?", StringComparison.Ordinal) == 0)) {
                            _showHelp = true;
                        }
                        else if (String.Compare(option, "nologo", StringComparison.OrdinalIgnoreCase) == 0) {
                            _hideAbout = true;
                        }
                        else {
                            Options[option] = String.Empty;
                        }
                    }
                    else {
                        string optionName = args[i].Substring(1, index - 1);
                        string optionValue = args[i].Substring(index + 1);

                        if (Options.Contains(optionName)) {
                            object existingValue = Options[optionName];
                            if (existingValue is string) {
                                ArrayList valueList = new ArrayList();
                                valueList.Add(existingValue);
                                valueList.Add(optionValue);

                                Options[optionName] = valueList;
                            }
                            else {
                                Debug.Assert(existingValue is ArrayList);

                                ArrayList valueList = (ArrayList)existingValue;
                                valueList.Add(optionValue);
                            }
                        }
                        else {
                            Options[optionName] = optionValue;
                        }
                    }
                }
            }
            _arguments = (string[])argList.ToArray(typeof(string));
        }

        public string[] Arguments {
            get {
                return _arguments;
            }
        }

        public bool HideAbout {
            get {
                return _hideAbout;
            }
        }

        public IDictionary Options {
            get {
                if (_options == null) {
                    _options = new HybridDictionary(true);
                }
                return _options;
            }
        }

        public bool ShowHelp {
            get {
                return _showHelp;
            }
        }

        private string[] ExpandResponseFileArguments(string[] args) {
            List<string> expandedArgs = new List<string>();

            for (int i = 0; i < args.Length; i++) {
                if ((args[i].Length > 1) && args[i].StartsWith("@")) {
                    string responseFile = args[i].Substring(1);

                    if (File.Exists(responseFile)) {
                        using (TextReader reader = File.OpenText(responseFile)) {
                            string line;
                            while ((line = reader.ReadLine()) != null) {
                                line = line.Trim();
                                if (line.Length > 0) {
                                    expandedArgs.Add(line);
                                }
                            }
                        }
                    }
                }
                else {
                    expandedArgs.Add(args[i]);
                }
            }

            return expandedArgs.ToArray();
        }
    }
}
