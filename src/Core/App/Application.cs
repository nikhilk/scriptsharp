// Application.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace ScriptSharp {

    internal static class Application {

        private static readonly string AboutTextFormat = @"
Script# Compiler v{0} (C# to JavaScript compiler)
Written by Nikhil Kothari.
More information at http://projects.nikhilk.net/ScriptSharp.
";

        private static readonly string UsageText = @"
Usage:
  ssc [/nologo] [/?]
      [/debug]
      [/tests]
      [/minimize]
      [/D:<variable>]
      [/res:<resource file>]
      /ref:<assembly path>
      /out:<script file>
      <C# source files>

/nologo     Hides the about information.
/?          Displays usage information.
/debug      Turns on debug mode. Specifically, it defines the 'DEBUG'
            variable.
/tests      Includes test classes defined in the sources into the
            generated script.
/minimize   Minimizes the whitespace in the generated script file.
            This is only used in non-debug builds.
/D          Defines one or more variables that are used to conditionally
            compile code.
/ref        One or more references to C# assemblies to be used
            to import metadata corresponding to dependency script files.
            (Note you must include a reference to mscorlib.dll)
/res        The set of one or more resources to compile in. These should be
            .resx files. You should pass in both the language-neutral
            resources and the locale specific resources for the locale
            associated with the output script.
/out        The resulting script file. Typically this is a .js file.
";

        private static CompilerOptions CreateCompilerOptions(CommandLine commandLine) {
            List<string> references = new List<string>();
            List<IStreamSource> sources = new List<IStreamSource>();
            List<IStreamSource> resources = new List<IStreamSource>();
            List<string> defines = new List<string>();
            List<string> scripts = new List<string>();
            bool debug = false;
            bool includeTests = false;
            bool minimize = true;
            IStreamSource scriptFile = null;

            foreach (string fileName in commandLine.Arguments) {
                // TODO: This is a hack... something in the .net 4 build system causes
                //       generation of an AssemblyAttributes.cs file with fully-qualified
                //       type names, that we can't handle (this comes from multitargeting),
                //       and there doesn't seem like a way to turn it off.
                if (fileName.EndsWith(".AssemblyAttributes.cs", StringComparison.OrdinalIgnoreCase)) {
                    continue;
                }
                sources.Add(new FileInputStreamSource(fileName));
            }

            object referencesObject = commandLine.Options["ref"];
            if (referencesObject is string) {
                references.Add((string)referencesObject);
            }
            else if (referencesObject is ArrayList) {
                ArrayList referenceList = (ArrayList)referencesObject;

                foreach (string reference in referenceList) {
                    // TODO: This is a hack... something in the .net 4 build system causes
                    //       System.Core.dll to get included [sometimes].
                    //       That shouldn't happen... so filter it out here.
                    if (reference.EndsWith("System.Core.dll", StringComparison.OrdinalIgnoreCase)) {
                        continue;
                    }
                    references.Add(reference);
                }
            }

            object resourcesObject = commandLine.Options["res"];
            if (resourcesObject is string) {
                resources.Add(new FileInputStreamSource((string)resourcesObject));
            }
            else if (resourcesObject is ArrayList) {
                ArrayList resourceList = (ArrayList)resourcesObject;

                foreach (string resource in resourceList) {
                    resources.Add(new FileInputStreamSource(resource));
                }
            }

            object definesObject = commandLine.Options["D"];
            if (definesObject is string) {
                defines.Add((string)definesObject);
            }
            else if (definesObject is ArrayList) {
                ArrayList definesList = (ArrayList)definesObject;

                foreach (string definedVariable in definesList) {
                    defines.Add(definedVariable);
                }
            }

            string scriptFilePath = null;
            if (commandLine.Options.Contains("out")) {
                scriptFilePath = (string)commandLine.Options["out"];
                if (scriptFilePath.IndexOfAny(Path.GetInvalidPathChars()) < 0) {
                    scriptFile = new FileOutputStreamSource(scriptFilePath);
                }
            }

            debug = commandLine.Options.Contains("debug");
            if (debug && !defines.Contains("DEBUG")) {
                defines.Add("DEBUG");
            }

            includeTests = commandLine.Options.Contains("tests");
            minimize = commandLine.Options.Contains("minimize");

            CompilerOptions compilerOptions = new CompilerOptions();
            compilerOptions.IncludeTests = includeTests;
            compilerOptions.Defines = defines;
            compilerOptions.Minimize = minimize;
            compilerOptions.References = references;
            compilerOptions.Sources = sources;
            compilerOptions.Resources = resources;
            compilerOptions.ScriptFile = scriptFile;

            compilerOptions.InternalTestMode = commandLine.Options.Contains("test");
            if (compilerOptions.InternalTestMode) {
                compilerOptions.InternalTestType = (string)commandLine.Options["test"];
            }

            return compilerOptions;
        }

        public static bool Execute(string[] args) {
            CommandLine commandLine = new CommandLine(args);
            if (commandLine.Options.Contains("attach")) {
                Debug.Fail("Attach");
            }

            if (commandLine.ShowHelp) {
                ShowUsage(/* message */ String.Empty);
                return true;
            }

            CompilerOptions compilerOptions = CreateCompilerOptions(commandLine);

            string errorMessage;
            if (compilerOptions.Validate(out errorMessage) == false) {
                ShowUsage(errorMessage);
                return false;
            }

            if (commandLine.HideAbout == false) {
                ShowAbout();
            }

            ScriptCompiler compiler = new ScriptCompiler();
            bool success = compiler.Compile(compilerOptions);
#if DEBUG
            return true;
#else
            return success;
#endif // DEBUG
        }

        private static string GetVersion() {
            string exePath = typeof(Application).Assembly.GetModules()[0].FullyQualifiedName;
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(exePath);

            return versionInfo.FileVersion;
        }

        [STAThread]
        public static int Main(string[] args) {
            bool success = Application.Execute(args);
            return success ? 0 : 1;
        }

        private static void ShowAbout() {
            string version = GetVersion();
            string aboutText = String.Format(AboutTextFormat, version);

            Console.WriteLine(aboutText);
        }

        private static void ShowUsage(string message) {
            if (String.IsNullOrEmpty(message) == false) {
                Console.WriteLine(message);
            }
            Console.WriteLine(UsageText);
        }
    }
}
