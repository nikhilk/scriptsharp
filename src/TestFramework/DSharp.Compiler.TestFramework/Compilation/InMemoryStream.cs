using System;
using System.IO;
using System.Text;

namespace DSharp.Compiler.TestFramework.Compilation
{
    public sealed class InMemoryStream : IStreamSource
    {
        private readonly string name;

        public string GeneratedOutput { get; private set; }

        string IStreamSource.FullName
        {
            get { return name; }
        }

        string IStreamSource.Name
        {
            get { return name; }
        }

        public InMemoryStream() => name = Guid.NewGuid().ToString();

        void IStreamSource.CloseStream(Stream stream)
        {
            MemoryStream memoryStream = (MemoryStream)stream;
            byte[] buffer = memoryStream.GetBuffer();

            GeneratedOutput = Encoding.UTF8.GetString(buffer, 0, (int)memoryStream.Length);
            memoryStream.Close();
        }

        Stream IStreamSource.GetStream()
        {
            return new MemoryStream();
        }
    }
}
