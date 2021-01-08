// FileOutputStreamSource.cs
// Script#/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;
using System.IO;
using DSharp;
using DSharp.Compiler;

namespace DSharp
{
    public class FileOutputStreamSource : IStreamSource
    {
        private readonly string pathTest;

        public FileOutputStreamSource(string pathTest)
            : this(pathTest, pathTest)
        {
        }

        protected FileOutputStreamSource(string pathTest, string name)
        {
            this.pathTest = pathTest;
            Name = name;
        }

        public string FullName => Path.GetFullPath(pathTest);

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
                string file = FullName;

                string directory = Path.GetDirectoryName(file);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                return new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None);
            }
            catch
            {
                return null;
            }
        }
    }
}
