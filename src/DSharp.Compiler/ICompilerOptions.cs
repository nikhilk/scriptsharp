using System.Collections.Generic;

namespace DSharp.Compiler
{
    public interface ICompilerOptions
    {
        string AssemblyName { get; set; }
        bool DebugMode { get; set; }
        ICollection<string> Defines { get; set; }
        IStreamSource DocCommentFile { get; set; }
        bool EnableDocComments { get; }
        IStreamSourceResolver IncludeResolver { get; set; }
        string Assembly { get; set; }
        string IntermediarySourceFolder { get; set; }
        IStreamSource MetadataFile { get; set; }
        bool Minimize { get; set; }
        ICollection<string> References { get; set; }
        ICollection<IStreamSource> Resources { get; set; }
        IStreamSource ScriptFile { get; set; }
        ScriptInfo ScriptInfo { get; }
        ICollection<IStreamSource> Sources { get; set; }

        bool Validate(out string errorMessage);
    }
}