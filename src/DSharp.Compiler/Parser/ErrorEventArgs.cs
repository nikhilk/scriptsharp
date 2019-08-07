// ErrorEventArgs.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.Parser
{
    internal sealed class ErrorEventArgs
    {
        public ErrorEventArgs(Error error, BufferPosition position, params object[] args)
        {
            Error = error;
            Position = position;
            Args = args;
        }

        public object[] Args { get; }

        public Error Error { get; }

        public BufferPosition Position { get; }
    }
}