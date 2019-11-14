using System.Collections.Generic;

namespace DSharp.Compiler
{
    public sealed class CompilerOptions
    {
        public CompilerOptions()
        {
            ScriptInfo = new ScriptInfo();
        }

        public ICollection<string> Defines { get; set; }

        public IStreamSource DocCommentFile { get; set; }

        public IStreamSourceResolver IncludeResolver { get; set; }

        public bool Minimize { get; set; }

        public ICollection<string> References { get; set; }

        public ICollection<IStreamSource> Resources { get; set; }

        public IStreamSource ScriptFile { get; set; }

        public ICollection<IStreamSource> Sources { get; set; }

        public string AssemblyName { get; set; }

        public ScriptInfo ScriptInfo { get; }

        public bool EnableDocComments => DocCommentFile != null;

        public bool DebugMode { get; set; } = false;

        //TODO: Remove this mechanism
        public bool Validate(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (References.Count == 0)
            {
                errorMessage = "You must specify a list of valid assembly references.";

                return false;
            }

            if (Sources.Count == 0)
            {
                errorMessage = "You must specify a list of valid source files.";

                return false;
            }

            if (ScriptFile == null)
            {
                errorMessage = "You must specify a valid output script file.";

                return false;
            }

            return true;
        }
    }
}
