// ResXCodeGeneratorTask.cs
// Script#/Core/Build
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.IO;
using DSharp.Build.Generators;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace DSharp.Build.Tasks
{
    public sealed class ResXCodeGeneratorTask : Task
    {
        [Required]
        public ITaskItem GeneratedCode { get; set; }

        [Required]
        public string Namespace { get; set; }

        [Required]
        public ITaskItem[] Resources { get; set; }

        public override bool Execute()
        {
            try
            {
                if ((Resources != null) && (Resources.Length != 0))
                {
                    ExecuteCore();
                }
            }
            catch (Exception e)
            {
                Debug.Fail(e.ToString());

                return false;
            }

            return true;
        }

        private void ExecuteCore()
        {
            ResXCodeBuilder codeBuilder = new ResXCodeBuilder();

            codeBuilder.Start(Namespace);
            foreach (ITaskItem resourceItem in Resources)
            {
                string resourceFileName = resourceItem.ItemSpec;
                string resourceGenerator = resourceItem.GetMetadata("Generator");
                string resourceContent = File.ReadAllText(resourceFileName);

                codeBuilder.GenerateCode(resourceFileName, resourceContent, resourceGenerator);
            }

            string code = codeBuilder.End();

            File.WriteAllText(GeneratedCode.ItemSpec, code);
        }
    }
}