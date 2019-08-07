// FileInputStreamSource.cs
// Script#/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;
using System.IO;
using DSharp.Compiler;

namespace DSharp
{
    internal class FileInputStreamSource : IStreamSource
    {
        private readonly string path;

        public FileInputStreamSource(string path)
            : this(path, path)
        {
        }

        public FileInputStreamSource(string path, string name)
        {
            this.path = path;
            Name = name;
        }

        public string FullName => Path.GetFullPath(path);

        public string Name { get; }

        public void CloseStream(Stream stream)
        {
            Debug.Assert(stream != null);
            Debug.Assert(stream is FileStream);

            stream.Close();
        }

        public Stream GetStream()
        {
            try
            {
                return new FileStream(FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch
            {
                return null;
            }
        }
    }
}