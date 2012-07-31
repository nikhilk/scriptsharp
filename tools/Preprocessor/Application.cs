// Application.cs
// Script#/Tools/Preprocessor
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ScriptSharp {

    internal sealed class Application : IStreamResolver, IErrorHandler {

        private static readonly string AboutTextFormat = @"
Script# Preprocessor v{0} (Script minimizer/merger)
Written by Nikhil Kothari.
More information at http://projects.nikhilk.net/ScriptSharp.
";

        private static readonly string UsageText =
@"Usage:
sspp [/?] [/nologo] [/noMin] [/debug] [/browser:<browser_name>]
     [/d:define_1,...define_n]
     /input:<jsa file> /output:<js file>

/nologo  - Suppresses the about information.
/noMin   - Suppress the minimizer.
           If minimization is turned on you can add /stripCommentsOnly
           to only minimize comments, and leave spaces intact.
/debug   - Turns on debug mode (defines the DEBUG preprocessor variable)
           (implies /noMin)
/d       - Allows you to define one or more additional preprocessor variables.
/crlf    - Use Windows-style line breaks
/input   - Specifies the input .jsa file (required)
/output  - Specifies the output .js file (required)
/?       - Shows usage information.";

        private CommandLine _commandLine;

        public Application(string[] args) {
            _commandLine = new CommandLine(args);
        }

        public bool Execute() {
            if (_commandLine.ShowHelp) {
                ShowHelp();
                return true;
            }

            List<string> predefinedVariables = new List<string>();
            bool debug = false;
            bool minimize = true;
            bool stripCommentsOnly = false;
            bool useWindowsLineBreaks = false;

            if (_commandLine.Options.Contains("debug")) {
                predefinedVariables.Add("DEBUG");
                debug = true;
            }

            string definesArgument = (string)_commandLine.Options["d"];
            if (definesArgument != null) {
                string[] defines = definesArgument.Split(',');
                predefinedVariables.AddRange(defines);
            }

            if (_commandLine.Options.Contains("noMin")) {
                minimize = false;
            }

            if (minimize) {
                if (_commandLine.Options.Contains("stripCommentsOnly")) {
                    stripCommentsOnly = true;
                }
            }

            if (_commandLine.Options.Contains("crlf")) {
                useWindowsLineBreaks = true;
            }

            string inputFile = (string)_commandLine.Options["input"];
            string outputFile = (string)_commandLine.Options["output"];

            if (String.IsNullOrEmpty(inputFile)) {
                ShowError("Input file was not specified.");
                return false;
            }
            if (File.Exists(inputFile) == false) {
                ShowError("The specified input file does not exist.");
                return false;
            }

            PreprocessorOptions options = new PreprocessorOptions();
            options.SourceFile = new FileInputStreamSource(inputFile);
            options.TargetFile = new FileOutputStreamSource(outputFile);
            options.DebugFlavor = debug;
            options.Minimize = minimize;
            options.StripCommentsOnly = stripCommentsOnly;
            options.UseWindowsLineBreaks = useWindowsLineBreaks;
            options.PreprocessorVariables = predefinedVariables;

            try {
                if (_commandLine.HideAbout == false) {
                    Console.WriteLine(GetAboutString());
                }

                ScriptPreprocessor preprocessor = new ScriptPreprocessor(this, this);
                preprocessor.Preprocess(options);

                return true;
            }
            catch (Exception e) {
                ShowError("Unhandled Exception: " + Environment.NewLine + e.Message);
            }

            return false;
        }

        private string GetAboutString() {
            Version versionInfo = typeof(Application).Assembly.GetName().Version;
            return String.Format(AboutTextFormat, versionInfo);
        }

        [STAThread]
        public static int Main(string[] args) {
            Application app = new Application(args);
            bool success = app.Execute();

            return success ? 0 : 1;
        }

        private void ShowError(string error) {
            if (_commandLine.HideAbout == false) {
                Console.WriteLine(GetAboutString());
                Console.WriteLine();
            }

            Console.WriteLine(error);
        }

        private void ShowHelp() {
            Console.WriteLine(GetAboutString());
            Console.WriteLine(UsageText);
        }

        #region Implementation of IErrorHandler
        void IErrorHandler.ReportError(string errorMessage, string location) {
            ShowError("Error in input at " + location + ": " + errorMessage);
        }
        #endregion

        #region Implementation of IStreamResolver
        IStreamSource IStreamResolver.ResolveInclude(IStreamSource baseStream, string includePath) {
            string resolvedPath = Path.Combine(Path.GetDirectoryName(Path.GetFullPath(baseStream.FullName)), includePath);
            return new FileInputStreamSource(resolvedPath);
        }
        #endregion
    }
}
