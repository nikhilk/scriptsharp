// ParserError.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.Parser
{
    internal sealed class ParseError
    {
        public static readonly Error UnexpectedEndOfFile = new Error(300, 0, "Unexpected end of file found");
        public static readonly Error TokenExpected = new Error(301, 0, "Syntax error: '{0}' expected");

        public static readonly Error TypeQualifierExpected =
            new Error(302, 0, "'class', 'struct', 'interface' or 'delegate' expected");

        public static readonly Error DuplicateModifier = new Error(303, 0, "Duplicate '{0}' flags");
        public static readonly Error DuplicateParameterModifier = new Error(304, 0, "More than one parameter flags");
        public static readonly Error TokenUnexpected = new Error(305, 0, "Syntax error: '{0}' unexpected");
        public static readonly Error OverloadableOperatorExpected = new Error(306, 0, "Overloadable operator expected");
        public static readonly Error DuplicateAccessor = new Error(307, 0, "Duplicate '{0}' accessor");
        public static readonly Error GetOrSetExpected = new Error(308, 0, "'get' or 'set' expected");
        public static readonly Error AddOrRemoveExpected = new Error(309, 0, "'add' or 'remove' expected");

        public static readonly Error NeedAtLeastOneAccessor =
            new Error(310, 0, "Property or indexer declaration must contain at least one accessor");

        public static readonly Error CaseOrDefaultExpected = new Error(311, 0, "'case' or 'default' expected");
        public static readonly Error StatementExpected = new Error(312, 0, "statement expected");
        public static readonly Error ExpressionExpected = new Error(313, 0, "expression expected");

        public static readonly Error BadEnumBase =
            new Error(314, 0, "Type byte, short, int, long, sbyte, ushort, uint or ulong expected");

        public static readonly Error ArrayOfVoidType = new Error(315, 0, "'void' is not a valid array element type");

        public static readonly Error InvalidModifier =
            new Error(316, 0, "The flags '{0}' is not valid on this declaration");

        public static readonly Error InvalidAttributeTarget =
            new Error(317, 0, "'{0}' is not a valid attribute target");

        public static readonly Error FixedVariablesMustBeOfPointerType =
            new Error(318, 0, "Variables declared in a fixed statement must be of pointer type");

        public static readonly Error FixedDeclaratorsMustHaveValue =
            new Error(319, 0, "Variables declared in a fixed statement must be initialized");

        public static readonly Error UsingDeclaratorsMustHaveValue =
            new Error(320, 0, "Variables declared in a using statement must be initialized");

        public static readonly Error ExpressionStatementMustDoWork =
            new Error(321, 0, "Expression statement must do work");

        public static readonly Error VariableCannotBeInterfaceImpl =
            new Error(322, 0, "A variable may not be an explicit interface implementation");

        public static readonly Error EventMissingAcessor =
            new Error(323, 0, "An event must have both an 'add' and a remove 'accessor'");

        public static readonly Error ConversionMustHaveOneParam =
            new Error(324, 0, "A conversion operator must have exactly 1 formal parameter");

        public static readonly Error WrongNumberOfArgsToUnaryOperator =
            new Error(325, 0, "Operator must have exactly 1 formal parameter");

        public static readonly Error WrongNumberOfArgsToBinnaryOperator =
            new Error(326, 0, "Operator must have exactly 2 formal parameter");

        public static readonly Error WrongNumberOfArgsToOperator =
            new Error(327, 0, "Operator must have exactly 1 or 2 formal parameter");

        public static readonly Error BadBaseExpression = new Error(328, 0,
            "A 'base' expression must be the first element in either a member access expression or an element access expression");

        public static readonly Error PartialMustBeLastModifier = new Error(329, 0,
            "'partial' must appear immediately before the 'class', 'struct' or 'interface' keyword.");

        public static readonly Error DuplicateConstructorConstraint =
            new Error(330, 0, "Duplicate constructor constraint");

        public static readonly Error ConstructorConstraintMustBeLast =
            new Error(331, 0, "Constructor constraint must be last");

        public static readonly Error UseDotInsteadOfColonColon =
            new Error(332, 0, "Use '.' instead of '::' for member access");

        public static readonly Error EventCannotBeGeneric = new Error(333, 0, "Event declarations cannot be generic");
        public static readonly Error VoidNotType = new Error(334, 0, "'void' is not a valid type");

        private ParseError()
        {
        }
    }
}