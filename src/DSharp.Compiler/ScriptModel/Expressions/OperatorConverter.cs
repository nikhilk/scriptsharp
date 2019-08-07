// OperatorConverter.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal static class OperatorConverter
    {
        public static Operator OperatorFromToken(TokenType token)
        {
            switch (token)
            {
                case TokenType.Tilde:

                    return Operator.BitwiseNot;
                case TokenType.Bang:

                    return Operator.LogicalNot;
                case TokenType.Equal:

                    return Operator.Equals;
                case TokenType.PlusEqual:

                    return Operator.PlusEquals;
                case TokenType.MinusEqual:

                    return Operator.MinusEquals;
                case TokenType.StarEqual:

                    return Operator.MultiplyEquals;
                case TokenType.SlashEqual:

                    return Operator.DivideEquals;
                case TokenType.PercentEqual:

                    return Operator.ModEquals;
                case TokenType.AndEqual:

                    return Operator.BitwiseAndEquals;
                case TokenType.HatEqual:

                    return Operator.BitwiseXorEquals;
                case TokenType.BarEqual:

                    return Operator.BitwiseOrEquals;
                case TokenType.ShiftLeftEqual:

                    return Operator.ShiftLeftEquals;
                case TokenType.ShiftRightEqual:

                    return Operator.ShiftRightEquals;
                case TokenType.Bar:

                    return Operator.BitwiseOr;
                case TokenType.Hat:

                    return Operator.BitwiseXor;
                case TokenType.Ampersand:

                    return Operator.BitwiseAnd;
                case TokenType.LogAnd:

                    return Operator.LogicalAnd;
                case TokenType.LogOr:

                    return Operator.LogicalOr;
                case TokenType.EqualEqual:

                    return Operator.EqualEqualEqual;
                case TokenType.NotEqual:

                    return Operator.NotEqualEqual;
                case TokenType.Less:

                    return Operator.Less;
                case TokenType.LessEqual:

                    return Operator.LessEqual;
                case TokenType.Greater:

                    return Operator.Greater;
                case TokenType.GreaterEqual:

                    return Operator.GreaterEqual;
                case TokenType.ShiftLeft:

                    return Operator.ShiftLeft;
                case TokenType.ShiftRight:

                    return Operator.ShiftRight;
                case TokenType.Plus:

                    return Operator.Plus;
                case TokenType.Minus:

                    return Operator.Minus;
                case TokenType.Star:

                    return Operator.Multiply;
                case TokenType.Slash:

                    return Operator.Divide;
                case TokenType.Percent:

                    return Operator.Mod;
                case TokenType.Is:

                    return Operator.Is;
                case TokenType.As:

                    return Operator.As;
                default:
                    Debug.Fail("Unhandled operator token " + token);

                    return Operator.Invalid;
            }
        }

        public static string OperatorToString(Operator operatorType)
        {
            switch (operatorType)
            {
                case Operator.Plus:

                    return " + ";
                case Operator.Minus:

                    return " - ";
                case Operator.Multiply:

                    return " * ";
                case Operator.Divide:

                    return " / ";
                case Operator.Mod:

                    return " % ";
                case Operator.EqualEqualEqual:

                    return " === ";
                case Operator.NotEqualEqual:

                    return " !== ";
                case Operator.Less:

                    return " < ";
                case Operator.LessEqual:

                    return " <= ";
                case Operator.Greater:

                    return " > ";
                case Operator.GreaterEqual:

                    return " >= ";
                case Operator.LogicalOr:

                    return " || ";
                case Operator.LogicalAnd:

                    return " && ";
                case Operator.LogicalNot:

                    return "!";
                case Operator.BitwiseOr:

                    return " | ";
                case Operator.BitwiseAnd:

                    return " & ";
                case Operator.BitwiseXor:

                    return " ^ ";
                case Operator.BitwiseNot:

                    return "~";
                case Operator.ShiftLeft:

                    return " << ";
                case Operator.ShiftRight:

                    return " >> ";
                case Operator.UnsignedShiftRight:

                    return " >>> ";
                case Operator.PreIncrement:
                case Operator.PostIncrement:

                    return "++";
                case Operator.PreDecrement:
                case Operator.PostDecrement:

                    return "--";
                case Operator.Equals:

                    return " = ";
                case Operator.PlusEquals:

                    return " += ";
                case Operator.MinusEquals:

                    return " -= ";
                case Operator.MultiplyEquals:

                    return " *= ";
                case Operator.DivideEquals:

                    return " /= ";
                case Operator.ModEquals:

                    return " %= ";
                case Operator.BitwiseOrEquals:

                    return " |= ";
                case Operator.BitwiseAndEquals:

                    return " &= ";
                case Operator.BitwiseXorEquals:

                    return " ^= ";
                case Operator.ShiftLeftEquals:

                    return " <<= ";
                case Operator.ShiftRightEquals:

                    return " >>= ";
                case Operator.UnsignedShiftRightEquals:

                    return " >>>= ";
                case Operator.Negative:

                    return "-";
                case Operator.Cast:

                    return string.Empty;
                case Operator.EqualEqual:

                    return " == ";
                case Operator.NotEqual:

                    return " != ";
                default:
                    Debug.Fail("Unexpected operator type: " + operatorType);

                    return string.Empty;
            }
        }
    }
}