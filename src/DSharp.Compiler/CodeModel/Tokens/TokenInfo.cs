// TokenInfo.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.CodeModel.Tokens
{
    internal sealed class TokenInfo
    {
        public const int INVALID_PRECEDENCE = int.MaxValue;
        private readonly TokenFlags flags;

        private readonly string tokenString;

        internal TokenInfo(string tokenString, TokenFlags flags, int precedence)
            : this(tokenString, flags)
        {
            Precedence = precedence;
        }

        internal TokenInfo(string tokenString, TokenFlags flags)
        {
            this.tokenString = tokenString;
            this.flags = flags;
            Precedence = INVALID_PRECEDENCE;
        }

        public bool IsAssignmentOperator => (flags & TokenFlags.AssignmentOperator) != 0;

        public bool IsBinaryOperator => Precedence != INVALID_PRECEDENCE;

        public bool IsOverloadableOperator => (flags & TokenFlags.OverloadableOperator) != 0;

        public bool IsPredefinedType => (flags & TokenFlags.PredefinedType) != 0;

        public int Precedence { get; }

        public override string ToString()
        {
            return tokenString;
        }
    }
}