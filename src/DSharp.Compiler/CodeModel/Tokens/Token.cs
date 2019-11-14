// Token.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using DSharp.Compiler.Parser;

namespace DSharp.Compiler.CodeModel.Tokens
{
    internal class Token : IComparable
    {
        public const int MAXIMUM_PRECEDENCE = int.MaxValue - 1;

        private static readonly TokenInfo[] Infos;

        private BufferPosition position;

        static Token()
        {
            Infos = new[]
            {
                new TokenInfo("abstract", TokenFlags.None),
                new TokenInfo("as", TokenFlags.None, 4),
                new TokenInfo("base", TokenFlags.None),
                new TokenInfo("bool", TokenFlags.PredefinedType),
                new TokenInfo("break", TokenFlags.None),
                new TokenInfo("byte", TokenFlags.PredefinedType),
                new TokenInfo("case", TokenFlags.None),
                new TokenInfo("catch", TokenFlags.None),
                new TokenInfo("char", TokenFlags.PredefinedType),
                new TokenInfo("checked", TokenFlags.None),
                new TokenInfo("class", TokenFlags.None),
                new TokenInfo("const", TokenFlags.None),
                new TokenInfo("continue", TokenFlags.None),
                new TokenInfo("decimal", TokenFlags.PredefinedType),
                new TokenInfo("default", TokenFlags.None),
                new TokenInfo("delegate", TokenFlags.None),
                new TokenInfo("do", TokenFlags.None),
                new TokenInfo("double", TokenFlags.PredefinedType),
                new TokenInfo("else", TokenFlags.None),
                new TokenInfo("enum", TokenFlags.None),
                new TokenInfo("event", TokenFlags.None),
                new TokenInfo("explicit", TokenFlags.None),
                new TokenInfo("extern", TokenFlags.None),
                new TokenInfo("false", TokenFlags.OverloadableOperator),
                new TokenInfo("finally", TokenFlags.None),
                new TokenInfo("fixed", TokenFlags.None),
                new TokenInfo("float", TokenFlags.PredefinedType),
                new TokenInfo("for", TokenFlags.None),
                new TokenInfo("foreach", TokenFlags.None),
                new TokenInfo("goto", TokenFlags.None),
                new TokenInfo("if", TokenFlags.None),
                new TokenInfo("in", TokenFlags.None),
                new TokenInfo("implicit", TokenFlags.None),
                new TokenInfo("int", TokenFlags.PredefinedType),
                new TokenInfo("interface", TokenFlags.None),
                new TokenInfo("internal", TokenFlags.None),
                new TokenInfo("is", TokenFlags.None, 4),
                new TokenInfo("lock", TokenFlags.None),
                new TokenInfo("long", TokenFlags.PredefinedType),
                new TokenInfo("namespace", TokenFlags.None),
                new TokenInfo("new", TokenFlags.None),
                new TokenInfo("null", TokenFlags.None),
                new TokenInfo("object", TokenFlags.PredefinedType),
                new TokenInfo("operator", TokenFlags.None),
                new TokenInfo("out", TokenFlags.None),
                new TokenInfo("override", TokenFlags.None),
                new TokenInfo("params", TokenFlags.None),
                new TokenInfo("private", TokenFlags.None),
                new TokenInfo("protected", TokenFlags.None),
                new TokenInfo("public", TokenFlags.None),
                new TokenInfo("readonly", TokenFlags.None),
                new TokenInfo("ref", TokenFlags.None),
                new TokenInfo("return", TokenFlags.None),
                new TokenInfo("sbyte", TokenFlags.PredefinedType),
                new TokenInfo("sealed", TokenFlags.None),
                new TokenInfo("short", TokenFlags.PredefinedType),
                new TokenInfo("sizeof", TokenFlags.None),
                new TokenInfo("stackalloc", TokenFlags.None),
                new TokenInfo("static", TokenFlags.None),
                new TokenInfo("string", TokenFlags.PredefinedType),
                new TokenInfo("struct", TokenFlags.None),
                new TokenInfo("switch", TokenFlags.None),
                new TokenInfo("this", TokenFlags.None),
                new TokenInfo("throw", TokenFlags.None),
                new TokenInfo("true", TokenFlags.OverloadableOperator),
                new TokenInfo("try", TokenFlags.None),
                new TokenInfo("typeof", TokenFlags.None),
                new TokenInfo("uint", TokenFlags.PredefinedType),
                new TokenInfo("ulong", TokenFlags.PredefinedType),
                new TokenInfo("unchecked", TokenFlags.None),
                new TokenInfo("unsafe", TokenFlags.None),
                new TokenInfo("ushort", TokenFlags.PredefinedType),
                new TokenInfo("using", TokenFlags.None),
                new TokenInfo("virtual", TokenFlags.None),
                new TokenInfo("void", TokenFlags.PredefinedType),
                new TokenInfo("volatile", TokenFlags.None),
                new TokenInfo("while", TokenFlags.None),
                new TokenInfo("Identifier", TokenFlags.None),
                new TokenInfo("Literal", TokenFlags.None),
                new TokenInfo(";", TokenFlags.None),
                new TokenInfo(")", TokenFlags.None),
                new TokenInfo("]", TokenFlags.None),
                new TokenInfo("{", TokenFlags.None),
                new TokenInfo("}", TokenFlags.None),
                new TokenInfo(",", TokenFlags.None),
                new TokenInfo("=", TokenFlags.AssignmentOperator),
                new TokenInfo("+=", TokenFlags.AssignmentOperator),
                new TokenInfo("-=", TokenFlags.AssignmentOperator),
                new TokenInfo("*=", TokenFlags.AssignmentOperator),
                new TokenInfo("/=", TokenFlags.AssignmentOperator),
                new TokenInfo("%=", TokenFlags.AssignmentOperator),
                new TokenInfo("&=", TokenFlags.AssignmentOperator),
                new TokenInfo("^=", TokenFlags.AssignmentOperator),
                new TokenInfo("|=", TokenFlags.AssignmentOperator),
                new TokenInfo("<<=", TokenFlags.AssignmentOperator),
                new TokenInfo(">>=", TokenFlags.AssignmentOperator),
                new TokenInfo("?", TokenFlags.None),
                new TokenInfo(":", TokenFlags.None),
                new TokenInfo("::", TokenFlags.None),
                new TokenInfo("||", TokenFlags.None, 10),
                new TokenInfo("&&", TokenFlags.None, 9),
                new TokenInfo("|", TokenFlags.OverloadableOperator, 8),
                new TokenInfo("^", TokenFlags.OverloadableOperator, 7),
                new TokenInfo("&", TokenFlags.OverloadableOperator, 6),
                new TokenInfo("==", TokenFlags.OverloadableOperator, 5),
                new TokenInfo("!=", TokenFlags.OverloadableOperator, 5),
                new TokenInfo("<", TokenFlags.OverloadableOperator, 4),
                new TokenInfo("<=", TokenFlags.OverloadableOperator, 4),
                new TokenInfo(">", TokenFlags.OverloadableOperator, 4),
                new TokenInfo(">=", TokenFlags.OverloadableOperator, 4),
                new TokenInfo("??", TokenFlags.OverloadableOperator, 4),
                new TokenInfo("<<", TokenFlags.OverloadableOperator, 3),
                new TokenInfo(">>", TokenFlags.OverloadableOperator, 3),
                new TokenInfo("+", TokenFlags.OverloadableOperator, 2),
                new TokenInfo("-", TokenFlags.OverloadableOperator, 2),
                new TokenInfo("*", TokenFlags.OverloadableOperator, 1),
                new TokenInfo("/", TokenFlags.OverloadableOperator, 1),
                new TokenInfo("%", TokenFlags.OverloadableOperator, 1),
                new TokenInfo("~", TokenFlags.OverloadableOperator),
                new TokenInfo("!", TokenFlags.OverloadableOperator),
                new TokenInfo("++", TokenFlags.OverloadableOperator),
                new TokenInfo("--", TokenFlags.OverloadableOperator),
                new TokenInfo("(", TokenFlags.None),
                new TokenInfo("[", TokenFlags.None),
                new TokenInfo(".", TokenFlags.None),
                new TokenInfo("->", TokenFlags.None),
                new TokenInfo("BOF", TokenFlags.None),
                new TokenInfo("EOF", TokenFlags.None),
                new TokenInfo("Comment", TokenFlags.None),
                new TokenInfo("Error", TokenFlags.None),
                new TokenInfo("Invalid", TokenFlags.None)
            };

            Debug.Assert((int) TokenType.Invalid + 1 == Infos.Length);
        }

        internal Token(TokenType type, string sourcePath, BufferPosition position)
        {
            Type = type;
            SourcePath = sourcePath;
            this.position = position;
        }

        public string Location => SourcePath + position;

        public BufferPosition Position => position;

        public string SourcePath { get; }

        public TokenType Type { get; }

        #region Implementation of IComparable

        int IComparable.CompareTo(object o)
        {
            return CompareTo((Token) o);
        }

        #endregion

        public int CompareTo(Token token)
        {
            return position.CompareTo(token.Position);
        }

        public static string GetString(TokenType type)
        {
            return Infos[(int) type].ToString();
        }

        public static int GetTokenPrecedence(TokenType type)
        {
            return Infos[(int) type].Precedence;
        }

        public bool IsAdjacent(Token right)
        {
            return position.Line == right.Position.Line &&
                   position.Column + ToString().Length == right.Position.Column;
        }

        public static bool IsAssignmentOperator(TokenType type)
        {
            return Infos[(int) type].IsAssignmentOperator;
        }

        public static bool IsBinaryOperator(TokenType type)
        {
            return Infos[(int) type].IsBinaryOperator;
        }

        public static bool IsKeyword(TokenType type)
        {
            return type < TokenType.Identifier;
        }

        public static bool IsOverloadableOperator(TokenType type)
        {
            return Infos[(int) type].IsOverloadableOperator;
        }

        public static bool IsPredefinedType(TokenType type)
        {
            return Infos[(int) type].IsPredefinedType;
        }

        public override string ToString()
        {
            return GetString(Type);
        }

        public T As<T>()
            where T : Token
        {
            return (T)this;
        }
    }
}
