using System.Collections.Generic;
using DSharp.Compiler;

namespace DSharp.ImportedMetadataGenerator
{
    public class Options : IMetadataCompilerOptions
    {
        public ICollection<string> References { get; set; }
        public string AssemblyName { get; set; }
        public string OutputPath
        {
            set { MetadataFile = new FileOutputStreamSource(value); }
        }
        public string Assembly { get; set; }
        public bool DebugMode { get; set; }
        public string ProjectPath { get; set; }

        public IStreamSource MetadataFile { get; set; }
    }
}
