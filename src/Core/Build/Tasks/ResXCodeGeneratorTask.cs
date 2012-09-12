// ResXCodeGeneratorTask.cs
// Script#/Core/Build
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using ScriptSharp.Generators;

namespace ScriptSharp.Tasks {

    public sealed class ResXCodeGeneratorTask : Task {

        private ITaskItem[] _resources;
        private ITaskItem _generatedCode;

        private string _namespace;

        [Required]
        public ITaskItem GeneratedCode {
            get {
                return _generatedCode;
            }
            set {
                _generatedCode = value;
            }
        }

        [Required]
        public string Namespace {
            get {
                return _namespace;
            }
            set {
                _namespace = value;
            }
        }

        [Required]
        public ITaskItem[] Resources {
            get {
                return _resources;
            }
            set {
                _resources = value;
            }
        }

        public override bool Execute() {
            try {
                if ((_resources != null) && (_resources.Length != 0)) {
                    ExecuteCore();
                }
            }
            catch (Exception e) {
                Debug.Fail(e.ToString());

                return false;
            }

            return true;
        }

        private void ExecuteCore() {
            ResXCodeBuilder codeBuilder = new ResXCodeBuilder();

            codeBuilder.Start(_namespace);
            foreach (ITaskItem resourceItem in _resources) {
                string resourceFileName = resourceItem.ItemSpec;
                string resourceGenerator = resourceItem.GetMetadata("Generator");
                string resourceContent = File.ReadAllText(resourceFileName);

                codeBuilder.GenerateCode(resourceFileName, resourceContent, resourceGenerator);
            }

            string code = codeBuilder.End();

            File.WriteAllText(_generatedCode.ItemSpec, code);
        }
    }
}
