using System.IO;
using Microsoft.CodeAnalysis;

namespace DSharp.Compiler.Preprocessing
{
    internal class SyntaxTreeSource : IStreamSource
    {
        private readonly SyntaxTree syntaxTree;

        public string FullName => syntaxTree.FilePath;

        public string Name { get; }

        public SyntaxTreeSource(string name, SyntaxTree syntaxTree)
        {
            Name = name;
            this.syntaxTree = syntaxTree;
        }

        public void CloseStream(Stream stream)
        {
            stream.Close();
        }

        public Stream GetStream()
        {
            var stream = new MemoryStream();

            using (var writer = new StreamWriter(stream, System.Text.Encoding.UTF8, 1024, leaveOpen: true))
            {
                syntaxTree.GetText().Write(writer);
                writer.Flush();
                stream.Position = 0;
                return stream;
            }
        }
    }
}
