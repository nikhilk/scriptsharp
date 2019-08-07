// FilePosition.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.Parser
{
    /// <summary>
    ///     A position in a source file.
    /// </summary>
    internal struct FilePosition
    {
        public FilePosition(BufferPosition position, string fileName)
        {
            Position = position;
            FileName = fileName;
        }

        public BufferPosition Position { get; set; }

        public string FileName { get; set; }

        /// <summary>
        ///     Returns a string suitable for display in an error _message.
        /// </summary>
        public override string ToString()
        {
            return FileName + Position;
        }
    }
}