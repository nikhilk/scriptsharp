using System.IO;
using System.Linq;
using DSharp;
using DSharp.Compiler.TestFramework.Compilation.Sources;

namespace DSharp.Compiler.TestFramework
{
    internal class LocalTestContextStreamResolver : IStreamSourceResolver
    {
        private readonly DirectoryInfo testDirectory;

        public LocalTestContextStreamResolver(DirectoryInfo testDirectory)
        {
            this.testDirectory = testDirectory;
        }

        public IStreamSource Resolve(string name)
        {
            var file = testDirectory.GetFiles(name, SearchOption.AllDirectories)
                .FirstOrDefault();

            if (file == null || !file.Exists)
            {
                return null;
            }

            return new FileInputSource(file.FullName);
        }
    }
}