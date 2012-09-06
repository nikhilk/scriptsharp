// Error.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.Parser {

    internal sealed class Error {

#if DEBUG
        private static readonly Hashtable _errorTable = new Hashtable();
#endif

        private int _id;
        private int _level;
        private string _message;

        public Error(int id, int level, string message) {
            _id = id;
            _level = level;
            _message = message;

#if DEBUG
            // ensure that _errorTable are unique
            Debug.Assert(_errorTable[id] == null);
            _errorTable[id] = this;
#endif
        }

        /// <summary>
        /// Error number. Should be unique for a given component.
        /// </summary>
        public int ID {
            get {
                return _id;
            }
        }

        /// <summary>
        /// Warning Level of the _message. 0 means its an Error.
        /// </summary>
        public int Level {
            get {
                return _level;
            }
        }

        /// <summary>
        /// Message template.
        /// </summary>
        public string Message {
            get {
                return _message;
            }
        }

        /// <summary>
        /// Is this error fatal.
        /// </summary>
        public bool IsFatal {
            get {
                return _level < 0;
            }
        }

        /// <summary>
        /// Is this an error as opposed to a warning.
        /// </summary>
        public bool IsError {
            get {
                return _level <= 0;
            }
        }

        /// <summary>
        /// Is this a warning as opposed to an error.
        /// </summary>
        public bool IsWarning {
            get {
                return !IsError;
            }
        }
    }
}
