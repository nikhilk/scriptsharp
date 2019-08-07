// FileErrorEventArgs.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.Parser
{
    internal sealed class FileLexerErrorEventArgs
    {
        internal FileLexerErrorEventArgs(Error error, FilePosition position, params object[] args)
        {
            Error = error;
            Position = position;
            Args = args;
        }

        internal FileLexerErrorEventArgs(ErrorEventArgs e, LineMap lineMap)
            : this(e.Error, lineMap.Map(e.Position), e.Args)
        {
        }

        public object[] Args { get; }

        public Error Error { get; }

        public FilePosition Position { get; }
    }
}
