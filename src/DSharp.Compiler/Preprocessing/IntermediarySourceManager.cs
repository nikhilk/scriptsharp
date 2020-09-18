using System;
using System.Collections.Generic;
using System.IO;
using DSharp.Compiler.Errors;
using Microsoft.CodeAnalysis.CSharp;

namespace DSharp.Compiler.Preprocessing
{
    public class IntermediarySourceManager
    {
        private readonly HashSet<string> paths;
        private readonly string intermediarySourceFolder;
        private readonly IErrorHandler errorHandler;

        public IntermediarySourceManager(string intermediarySourceFolder, IErrorHandler errorHandler)
        {
            this.paths = new HashSet<string>();
            this.intermediarySourceFolder = intermediarySourceFolder;
            this.errorHandler = errorHandler;
        }

        public void Write(CSharpCompilation compilation)
        {
            if (string.IsNullOrEmpty(intermediarySourceFolder))
            {
                return;
            }

            Directory.CreateDirectory(intermediarySourceFolder);

            foreach (var syntaxTree in compilation.SyntaxTrees)
            {
                var filePath = syntaxTree.FilePath;
                var extension = $".g{Path.GetExtension(filePath)}";
                var fileName = Path.GetFileNameWithoutExtension(filePath);
                fileName = GetAvailableFileName(fileName, extension);
                var path = Path.Combine(intermediarySourceFolder, fileName);

                try
                {
                    using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        syntaxTree.GetText().Write(writer);
                    }
                }
                catch (Exception e)
                {
                    errorHandler.ReportWarning(
                        new CompilerError(
                            (int)CompilerErrorCode.LowererError,
                            $"Unable to write intermediary file '{fileName}'.{Environment.NewLine}Message:{e.Message},{Environment.NewLine}Stack:{e.StackTrace}",
                            filePath));
                }
            }
        }

        private string GetAvailableFileName(string fileName, string extension, int increment = 0)
        {
            var updatedName = increment > 0
                ? fileName + $"_{increment}{extension}"
                : fileName + extension;

            if (paths.Add(updatedName))
            {
                return updatedName;
            }

            return GetAvailableFileName(fileName, extension, increment + 1);
        }
    }
}
