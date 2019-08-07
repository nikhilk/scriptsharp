// CommandLine.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;

namespace DSharp.Shell
{
    internal sealed class CommandLine
    {
        private IDictionary options;

        public string[] Arguments { get; }

        public bool HideAbout { get; }

        public bool ShowHelp { get; }

        public CommandLine(string[] args)
        {
            if (args == null) throw new ArgumentNullException("args");

            args = ExpandResponseFileArguments(args);

            ArrayList argList = new ArrayList();

            for (int i = 0; i < args.Length; i++)
            {
                char c = args[i][0];

                if (c != '/' && c != '-')
                {
                    argList.Add(args[i]);
                }
                else
                {
                    int index = args[i].IndexOf(':');

                    if (index == -1)
                    {
                        string option = args[i].Substring(1);

                        if (string.Compare(option, "help", StringComparison.OrdinalIgnoreCase) == 0 ||
                            string.Compare(option, "?", StringComparison.Ordinal) == 0)
                            ShowHelp = true;
                        else if (string.Compare(option, "nologo", StringComparison.OrdinalIgnoreCase) == 0)
                            HideAbout = true;
                        else
                            Options[option] = string.Empty;
                    }
                    else
                    {
                        string optionName = args[i].Substring(1, index - 1);
                        string optionValue = args[i].Substring(index + 1);

                        if (Options.Contains(optionName))
                        {
                            object existingValue = Options[optionName];

                            if (existingValue is string)
                            {
                                ArrayList valueList = new ArrayList();
                                valueList.Add(existingValue);
                                valueList.Add(optionValue);

                                Options[optionName] = valueList;
                            }
                            else
                            {
                                Debug.Assert(existingValue is ArrayList);

                                ArrayList valueList = (ArrayList) existingValue;
                                valueList.Add(optionValue);
                            }
                        }
                        else
                        {
                            Options[optionName] = optionValue;
                        }
                    }
                }
            }

            Arguments = (string[]) argList.ToArray(typeof(string));
        }

        public IDictionary Options
        {
            get
            {
                if (options == null) options = new HybridDictionary(true);

                return options;
            }
        }

        private static string[] ExpandResponseFileArguments(IReadOnlyList<string> args)
        {
            List<string> expandedArgs = new List<string>();

            for (int i = 0; i < args.Count; i++)
                if (args[i].Length > 1 && args[i].StartsWith("@"))
                {
                    string responseFile = args[i].Substring(1);

                    if (File.Exists(responseFile))
                        using (TextReader reader = File.OpenText(responseFile))
                        {
                            string line;

                            while ((line = reader.ReadLine()) != null)
                            {
                                line = line.Trim();

                                if (line.Length > 0) expandedArgs.Add(line);
                            }
                        }
                }
                else
                {
                    expandedArgs.Add(args[i]);
                }

            return expandedArgs.ToArray();
        }
    }
}