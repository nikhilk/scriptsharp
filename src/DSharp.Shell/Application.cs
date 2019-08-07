// Application.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using DSharp.Compiler;

namespace DSharp.Shell
{
    internal static class Application
    {
        private const string ABOUT_TEXT_FORMAT = "DSharp Compiler v{0} (C# to JavaScript compiler)";

        private const string USAGE_TEXT = @"
Usage:
  ssc [/nologo] [/?]
      [/debug]
      [/tests]
      [/minimize]
      [/D:<variable>]
      [/res:<resource file>]
      /ref:<assembly path>
      /out:<script file>
      [/inc:<include base path>]
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
/inc        The base path against which includes are resolved.
";

        private static CompilerOptions CreateCompilerOptions(CommandLine commandLine)
        {
            List<string> references = new List<string>();
            List<IStreamSource> sources = new List<IStreamSource>();
            List<IStreamSource> resources = new List<IStreamSource>();
            List<string> defines = new List<string>();
            IStreamSource scriptFile = null;
            IStreamSourceResolver includeResolver = null;

            foreach (string fileName in commandLine.Arguments)
            {
                // TODO: This is a hack... something in the .net 4 build system causes
                //       generation of an AssemblyAttributes.cs file with fully-qualified
                //       type names, that we can't handle (this comes from multitargeting),
                //       and there doesn't seem like a way to turn it off.
                if (fileName.EndsWith(".AssemblyAttributes.cs", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                sources.Add(new FileInputStreamSource(fileName));
            }

            object referencesObject = commandLine.Options["ref"];

            if (referencesObject is string s)
            {
                references.Add(s);
            }
            else if (referencesObject is ArrayList referenceList)
            {
                foreach (string reference in referenceList)
                {
                    // TODO: This is a hack... something in the .net 4 build system causes
                    //       System.Core.dll to get included [sometimes].
                    //       That shouldn't happen... so filter it out here.
                    if (reference.EndsWith("System.Core.dll", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    references.Add(reference);
                }
            }

            object resourcesObject = commandLine.Options["res"];

            if (resourcesObject is string s1)
            {
                resources.Add(new FileInputStreamSource(s1));
            }
            else if (resourcesObject is ArrayList resourceList)
            {
                foreach (string resource in resourceList)
                {
                    resources.Add(new FileInputStreamSource(resource));
                }
            }

            object definesObject = commandLine.Options["D"];

            if (definesObject is string s2)
            {
                defines.Add(s2);
            }
            else if (definesObject is ArrayList definesList)
            {
                foreach (string definedVariable in definesList)
                {
                    defines.Add(definedVariable);
                }
            }

            if (commandLine.Options.Contains("out"))
            {
                string scriptFilePath = (string)commandLine.Options["out"];

                if (scriptFilePath.IndexOfAny(Path.GetInvalidPathChars()) < 0)
                {
                    scriptFile = new FileOutputStreamSource(scriptFilePath);
                }
            }

            bool debug = commandLine.Options.Contains("debug");

            if (debug && !defines.Contains("DEBUG"))
            {
                defines.Add("DEBUG");
            }

            bool includeTests = commandLine.Options.Contains("tests");
            bool minimize = commandLine.Options.Contains("minimize");

            if (commandLine.Options.Contains("inc"))
            {
                string basePath = (string)commandLine.Options["inc"];
                includeResolver = new IncludeResolver(basePath);
            }

            CompilerOptions compilerOptions = new CompilerOptions
            {
                Defines = defines,
                Minimize = minimize,
                References = references,
                Sources = sources,
                Resources = resources,
                ScriptFile = scriptFile,
                IncludeResolver = includeResolver,
            };

            if (string.IsNullOrWhiteSpace(compilerOptions.AssemblyName))
            {
                compilerOptions.AssemblyName = CreateGeneratedAssemblyName();
            }

            return compilerOptions;
        }

        private static string CreateGeneratedAssemblyName()
        {
            return "g_" + Guid.NewGuid().ToString().Replace("-", "");
        }

        private static bool Execute(string[] args)
        {
            CommandLine commandLine = new CommandLine(args);

            if (commandLine.Options.Contains("attach"))
            {
                Debug.Fail("Attach");
            }

            if (commandLine.ShowHelp)
            {
                ShowUsage(string.Empty);

                return true;
            }

            CompilerOptions compilerOptions = CreateCompilerOptions(commandLine);

            if (compilerOptions.Validate(out string errorMessage) == false)
            {
                ShowUsage(errorMessage);

                return false;
            }

            if (commandLine.HideAbout == false)
            {
                ShowAbout();
            }

            ScriptCompiler compiler = new ScriptCompiler();
            bool success = compiler.Compile(compilerOptions);
#if DEBUG
            return true;
#else
            return success;
#endif
        }

        private static string GetVersion()
        {
            string exePath = typeof(Application).Assembly.GetModules()[0].FullyQualifiedName;
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(exePath);

            return versionInfo.FileVersion;
        }

        [STAThread]
        public static int Main(string[] args)
        {
            bool success = Execute(args);

            return success ? 0 : 1;
        }

        private static void ShowAbout()
        {
            string version = GetVersion();
            string aboutText = string.Format(ABOUT_TEXT_FORMAT, version);

            Console.WriteLine(aboutText);
        }

        private static void ShowUsage(string message)
        {
            if (string.IsNullOrEmpty(message) == false)
            {
                Console.WriteLine(message);
            }

            Console.WriteLine(USAGE_TEXT);
        }

        private sealed class IncludeResolver : IStreamSourceResolver
        {
            private readonly string basePath;

            public IncludeResolver(string basePath)
            {
                this.basePath = basePath;
            }

            public IStreamSource Resolve(string name)
            {
                string path = Path.Combine(basePath, name);

                if (File.Exists(path))
                {
                    return new FileInputStreamSource(path, name);
                }

                return null;
            }
        }
    }
}
