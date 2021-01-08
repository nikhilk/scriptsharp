using System.Collections.Generic;

namespace DSharp.Compiler
{
    public interface IMetadataCompilerOptions
    {
        string AssemblyName { get; set; }
        bool DebugMode { get; set; }
        string Assembly { get; set; }
        IStreamSource MetadataFile { get; set; }
        ICollection<string> References { get; set; }
    }
}
