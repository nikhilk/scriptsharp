// TokenInfo.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.CodeModel {

    internal sealed class TokenInfo {

        public const int InvalidPrecedence = Int32.MaxValue;

        private string _tokenString;
        private TokenFlags _flags;
        private int _precedence;

        internal TokenInfo(string tokenString, TokenFlags flags, int precedence)
            : this(tokenString, flags) {
            _precedence = precedence;
        }

        internal TokenInfo(string tokenString, TokenFlags flags) {
            _tokenString = tokenString;
            _flags = flags;
            _precedence = TokenInfo.InvalidPrecedence;
        }

        public bool IsAssignmentOperator {
            get {
                return (_flags & TokenFlags.AssignmentOperator) != 0;
            }
        }

        public bool IsBinaryOperator {
            get {
                return _precedence != InvalidPrecedence;
            }
        }

        public bool IsOverloadableOperator {
            get {
                return (_flags & TokenFlags.OverloadableOperator) != 0;
            }
        }

        public bool IsPredefinedType {
            get {
                return (_flags & TokenFlags.PredefinedType) != 0;
            }
        }

        public int Precedence {
            get {
                return _precedence;
            }
        }

        public override string ToString() {
            return _tokenString;
        }
    }
}
