using System.IO;
using System.Text;

namespace DSharp.Compiler.Preprocessing
{
    internal class StringSource : IStreamSource
    {
        public string FullName { get; set; }
        public string Name { get; set; }
        public string Contents { get; set; }

        public void CloseStream(Stream stream)
        {
            stream.Close();
        }

        public Stream GetStream()
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(Contents ?? ""));
        }
    }
}
