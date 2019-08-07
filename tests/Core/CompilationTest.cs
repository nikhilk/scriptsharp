// CompilationTest.cs
// Script#/Tests/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace DSharp.Tests.Core {

    public abstract class CompilationTest {

        private TestContext _context;

        public TestContext TestContext {
            get {
                return _context;
            }
            set {
                _context = value;
            }
        }

        protected Compilation CreateCompilation() {
            return CreateCompilation(avoidStandardReferences: false);
        }

        protected Compilation CreateCompilation(bool avoidStandardReferences) {
            Compilation compilation = new Compilation(this);
            if (avoidStandardReferences == false) {
                compilation.AddReference("mscorlib.dll");
            }

            return compilation;
        }

        public string GetAssemblyFilePath(string fileName) {
            // Get the path to the ScriptSharp build output folder
            string assemblyPath = this.GetType().Assembly.GetModules()[0].FullyQualifiedName;
            string binPath = Path.GetFullPath(Path.Combine(assemblyPath, "..\\Test"));

            return Path.Combine(binPath, fileName);
        }

        public string GetTestFilePath(string fileName) {
            // Get the path to the test cases folder
            string assemblyPath = this.GetType().Assembly.GetModules()[0].FullyQualifiedName;
            string testCasesPath = Path.GetFullPath(Path.Combine(assemblyPath, "..\\TestCases\\"));

            // Files within the test cases folder are organized into a two level folder
            // structure ... group\test
            // where group is mapped to the test class name, and test is mapped to the test name.
            string groupName = this.GetType().Name;
            string testName = _context.TestName;

            if (groupName.EndsWith("Tests")) {
                groupName = groupName.Substring(0, groupName.Length - 5);
            }
            if (testName.StartsWith("Test")) {
                testName = testName.Substring(4);
            }

            return Path.Combine(testCasesPath, groupName, testName, fileName);
        }

        public string GetToolPath(string fileName) {
            // Get the path to the tools folder
            string assemblyPath = this.GetType().Assembly.GetModules()[0].FullyQualifiedName;
            string toolsPath = Path.GetFullPath(Path.Combine(assemblyPath, "..\\tools\\bin"));

            return Path.Combine(toolsPath, fileName);
        }

        protected void RunTest(Action<Compilation> compilationInitializer) {
            RunTest(compilationInitializer, "Baseline.txt", avoidStandardReferences: false);
        }

        protected void RunTest(Action<Compilation> compilationInitializer, string baselineFile) {
            RunTest(compilationInitializer, baselineFile, avoidStandardReferences: false);
        }

        protected void RunTest(Action<Compilation> compilationInitializer, string baselineFile, bool avoidStandardReferences) {
            Compilation compilation = CreateCompilation(avoidStandardReferences);
            compilationInitializer(compilation);

            bool result = compilation.Execute();
            Assert.IsTrue(result, "Compilation failed.");

            string baselinePath = GetTestFilePath(baselineFile);
            string baseline = File.ReadAllText(baselinePath, new UTF8Encoding(false));
            string output = compilation.Output.GeneratedOutput;

            Assert.AreEqual(baseline, output, "Unexpected differences between baseline and result.");
        }

        protected bool ValidateResults(string output, string baselineFile) {
            string baselinePath = GetTestFilePath(baselineFile);
            string baseline = File.ReadAllText(baselinePath);
            
            if (String.CompareOrdinal(baseline, output) != 0) {
                string diff = null;

                string outputFile = Path.GetTempFileName();
                try {
                    File.WriteAllText(outputFile, output);

                    ProcessStartInfo diffInfo = new ProcessStartInfo();
                    diffInfo.FileName = GetToolPath("diff.exe");
                    diffInfo.Arguments = "\"" + baselinePath + "\" \"" + outputFile + "\"";
                    diffInfo.UseShellExecute = false;
                    diffInfo.RedirectStandardOutput = true;

                    Process diffProcess = Process.Start(diffInfo);

                    diff = diffProcess.StandardOutput.ReadToEnd();
                    diffProcess.WaitForExit();

                    if (Debugger.IsAttached) {
                        ProcessStartInfo windiffInfo = new ProcessStartInfo();
                        windiffInfo.FileName = GetToolPath("windiff.exe");
                        windiffInfo.Arguments = "\"" + baselinePath + "\" \"" + outputFile + "\"";
                        windiffInfo.UseShellExecute = true;

                        Process windiffProcess = Process.Start(windiffInfo);
                        windiffProcess.WaitForExit();
                    }
                }
                finally {
                    File.Delete(outputFile);
                }

                Console.WriteLine(diff);
                return false;
            }

            return true;
        }
    }
}
