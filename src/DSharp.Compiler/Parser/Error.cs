// Error.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.Diagnostics;

namespace DSharp.Compiler.Parser
{
    internal sealed class Error
    {
#if DEBUG
        private static readonly Hashtable ErrorTable = new Hashtable();
#endif

        public Error(int id, int level, string message)
        {
            Id = id;
            Level = level;
            Message = message;

#if DEBUG
            // ensure that _errorTable are unique
            Debug.Assert(ErrorTable[id] == null);
            ErrorTable[id] = this;
#endif
        }

        /// <summary>
        ///     Error number. Should be unique for a given component.
        /// </summary>
        public int Id { get; }

        /// <summary>
        ///     Warning Level of the _message. 0 means its an Error.
        /// </summary>
        public int Level { get; }

        /// <summary>
        ///     Message template.
        /// </summary>
        public string Message { get; }

        /// <summary>
        ///     Is this error fatal.
        /// </summary>
        public bool IsFatal => Level < 0;

        /// <summary>
        ///     Is this an error as opposed to a warning.
        /// </summary>
        public bool IsError => Level <= 0;

        /// <summary>
        ///     Is this a warning as opposed to an error.
        /// </summary>
        public bool IsWarning => !IsError;
    }
}