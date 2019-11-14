// Parser.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;
using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Attributes;
using DSharp.Compiler.CodeModel.Expressions;
using DSharp.Compiler.CodeModel.Members;
using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Statements;
using DSharp.Compiler.CodeModel.Tokens;
using DSharp.Compiler.CodeModel.Types;

namespace DSharp.Compiler.Parser
{
    internal sealed class Parser
    {
        // UNDONE use an array of TID's here instead
        private static readonly string[] ModifierNames =
        {
            "abstract",
            "sealed",

            "public",
            "internal",
            "private",
            "protected",

            "new",
            "virtual",
            "static",
            "readonly",
            "extern",
            "override",
            "unsafe"
        };

        private readonly Name addName;
        private readonly Name aliasName;

        //
        // some handy predefined names
        //
        private readonly Name assemblyName;
        private readonly Name getName;
        private readonly Name moduleName;
        private readonly Name partialName;
        private readonly string path;
        private readonly Name removeName;
        private readonly Name setName;
        private readonly Name unknownName;
        private readonly Name whereName;
        private readonly Name yieldName;
        private int iToken;
        private BufferPosition lastErrorPosition;
        private NameTable symbolTable;
        private Token[] tokens;

        public Parser(NameTable symbolTable, string path)
        {
            this.symbolTable = symbolTable;
            this.path = path;

            assemblyName = symbolTable.Add("assembly");
            moduleName = symbolTable.Add("module");
            unknownName = symbolTable.Add("__unknown");
            getName = symbolTable.Add("get");
            setName = symbolTable.Add("set");
            addName = symbolTable.Add("add");
            removeName = symbolTable.Add("remove");
            partialName = symbolTable.Add("partial");
            yieldName = symbolTable.Add("yield");
            whereName = symbolTable.Add("where");
            aliasName = symbolTable.Add("alias");
        }

        /// <summary>
        ///     Parses an array of C# tokens. Subscribe to the OnError event before
        ///     calling Parse to receive errors while Parsing.
        /// </summary>
        public CompilationUnitNode Parse(Token[] tokens)
        {
            this.tokens = tokens;

            iToken = 0;
            lastErrorPosition.Column = -1;

            return ParseCompilationUnit();
        }

        public event ErrorEventHandler OnError;

        private void ReportError(Error error, Token token, params object[] args)
        {
            BufferPosition newPosition = token.Position;

            if (OnError != null && lastErrorPosition != newPosition)
            {
                OnError(this, new ErrorEventArgs(error, newPosition, args));
            }

            lastErrorPosition = newPosition;
        }

        private void ReportError(Error error, params object[] args)
        {
            ReportError(error, PeekToken(), args);
        }

        private void ReportTokenExpectedError(TokenType type)
        {
            ReportError(ParseError.TokenExpected, Token.GetString(type));
        }

        private void ReportUnexpectedError(TokenType type)
        {
            ReportError(ParseError.TokenUnexpected, Token.GetString(type));
        }

        private bool CheckType(TokenType type)
        {
            if (PeekType() == type)
            {
                return true;
            }

            ReportTokenExpectedError(type);

            return false;
        }

        private Token Eat(TokenType type)
        {
            if (PeekType() == type)
            {
                return NextToken();
            }

            ReportTokenExpectedError(type);

            return ErrorToken();
        }

        private Token EatOpt(TokenType type)
        {
            if (PeekType() == type)
            {
                return NextToken();
            }

            return null;
        }

        private Token ErrorToken()
        {
            return new Token(TokenType.Error, path, PeekToken().Position);
        }

        private Token PeekToken()
        {
            return PeekToken(0);
        }

        private Token PeekToken(int index)
        {
            int skippedTokens = 0;
            int i = 0;

            while (skippedTokens < index)
            {
                Debug.Assert(tokens[iToken + i].Type != TokenType.Comment);
                i += 1;

                while (tokens[iToken + i].Type == TokenType.Comment) i += 1;

                skippedTokens += 1;
            }

            Debug.Assert(tokens[iToken + i].Type != TokenType.Comment);

            return tokens[iToken + i];
        }

        private TokenType PeekType()
        {
            return PeekToken().Type;
        }

        private TokenType PeekType(int index)
        {
            return PeekToken(index).Type;
        }

        private Token NextToken()
        {
            Token token = tokens[iToken++];
            Debug.Assert(token.Type != TokenType.Comment);

            while (iToken < tokens.Length && tokens[iToken].Type == TokenType.Comment) iToken++;

            return token;
        }

        private int Mark()
        {
            return iToken;
        }

        private void Rewind(int mark)
        {
            iToken = mark;
        }

        private CompilationUnitNode ParseCompilationUnit()
        {
            CompilationUnitNode tree
                = new CompilationUnitNode(
                    Eat(TokenType.Bof),
                    ParseExternAliases(),
                    ParseUsingClauses(),
                    ParseGlobalAttributes(),
                    ParseNamespaceMembers()
                );
            Eat(TokenType.Eof);

            return tree;
        }

        private ParseNodeList ParseExternAliases()
        {
            ParseNodeList list = new ParseNodeList();
            Token token;

            while (null != (token = EatOpt(TokenType.Extern)))
            {
                EatContextualKeyword(aliasName);
                list.Append(
                    new ExternAliasNode(
                        token,
                        ParseIdentifier()));
                Eat(TokenType.Semicolon);
            }

            return list;
        }

        // using-directives
        private ParseNodeList ParseUsingClauses()
        {
            ParseNodeList list = new ParseNodeList();

            while (PeekType() == TokenType.Using)
            {
                Token token = Eat(TokenType.Using);

                if (PeekType() == TokenType.Identifier && PeekType(1) == TokenType.Equal)
                {
                    // using-alias-directive
                    AtomicNameNode name = ParseIdentifier();
                    Eat(TokenType.Equal);
                    list.Append(
                        new UsingAliasNode(
                            token,
                            name,
                            ParseNamespaceOrTypeName()));
                }
                else
                {
                    // using-namespace-directive
                    list.Append(
                        new UsingNamespaceNode(
                            token,
                            ParseNamespaceOrTypeName()));
                }

                Eat(TokenType.Semicolon);
            }

            return list;
        }

        // identifier
        private AtomicNameNode ParseIdentifier()
        {
            if (CheckType(TokenType.Identifier))
            {
                return new AtomicNameNode((IdentifierToken) Eat(TokenType.Identifier));
            }

            return new AtomicNameNode(new IdentifierToken(unknownName, false, path, PeekToken().Position));
        }

        private NameNode ParseSimpleName(bool inExpression)
        {
            if (CheckType(TokenType.Identifier))
            {
                IdentifierToken name = (IdentifierToken) Eat(TokenType.Identifier);

                int mark = Mark();
                TypeArgumentListScan scan = ScanTypeArgumentListOpt();

                if (scan == TypeArgumentListScan.MayBeTypeArgumentList)
                {
                    if (inExpression)
                    {
                        switch (PeekType())
                        {
                            case TokenType.OpenParen:
                            case TokenType.CloseParen:
                            case TokenType.CloseSquare:
                            case TokenType.CloseAngle:
                            case TokenType.Colon:
                            case TokenType.Comma:
                            case TokenType.Semicolon:
                            case TokenType.Dot:
                            case TokenType.Question:
                                scan = TypeArgumentListScan.MustBeTypeArgumentList;

                                break;
                            default:
                                scan = TypeArgumentListScan.NotTypeArgumentList;

                                break;
                        }
                    }
                    else
                    {
                        scan = TypeArgumentListScan.MustBeTypeArgumentList;
                    }
                }

                Rewind(mark);

                if (scan == TypeArgumentListScan.MustBeTypeArgumentList)
                {
                    return new GenericNameNode(name, ParseTypeArgumentList());
                }

                return new AtomicNameNode(name);
            }

            return new AtomicNameNode(new IdentifierToken(unknownName, false, path, PeekToken().Position));
        }

        private ParseNodeList ParseTypeArgumentList()
        {
            ParseNodeList returnValue = new ParseNodeList();
            Eat(TokenType.OpenAngle);

            do
            {
                returnValue.Append(ParseType());
            } while (null != EatOpt(TokenType.Comma));

            Eat(TokenType.CloseAngle);

            return returnValue;
        }

        private TypeArgumentListScan ScanTypeArgumentListOpt()
        {
            if (PeekType() != TokenType.OpenAngle)
            {
                return TypeArgumentListScan.NotTypeArgumentList;
            }

            NextToken();

            bool couldBeParamList = true;

            do
            {
                if (PeekType() == TokenType.OpenSquare)
                {
                    return TypeArgumentListScan.TypeParameterList;
                }

                if (PeekType() != TokenType.Identifier ||
                    PeekType(1) != TokenType.Comma && PeekType(1) != TokenType.CloseAngle)
                {
                    couldBeParamList = false;
                }

                switch (ScanType())
                {
                    case Scan.CouldBeType:
                    case Scan.Type:

                        break;
                    case Scan.Nottype:
                    case Scan.PointerOrMult:

                        return TypeArgumentListScan.NotTypeArgumentList;
                    default:
                        Debug.Fail("bad scan result");

                        return TypeArgumentListScan.NotTypeArgumentList;
                }
            } while (null != (EatOpt(TokenType.Comma)));

            if (PeekType() != TokenType.CloseAngle)
            {
                return TypeArgumentListScan.NotTypeArgumentList;
            }

            NextToken();

            return couldBeParamList
                ? TypeArgumentListScan.MayBeTypeArgumentList
                : TypeArgumentListScan.MustBeTypeArgumentList;
        }

        // qualified-name
        private NameNode ParseMultiPartName()
        {
            Token token = PeekToken();
            NameNode name = ParseIdentifier();

            if (PeekType() == TokenType.Dot && PeekType(1) == TokenType.Identifier)
            {
                ParseNodeList list = new ParseNodeList(name);

                do
                {
                    Eat(TokenType.Dot);
                    list.Append(ParseIdentifier());
                } while (PeekType() == TokenType.Dot && PeekType(1) == TokenType.Identifier);

                return new MultiPartNameNode(token, list);
            }

            return name;
        }

        // alias-qualified-name
        private NameNode ParseAliasQualifiedName(bool inExpression)
        {
            NameNode name = ParseSimpleName(inExpression);

            if (name.NodeType == ParseNodeType.Name && PeekType() == TokenType.ColonColon)
            {
                NextToken();
                name = new AliasQualifiedNameNode((AtomicNameNode) name, ParseSimpleName(inExpression));
            }

            return name;
        }

        private void EatDotOrColonColon()
        {
            if (PeekType() == TokenType.ColonColon)
            {
                ReportError(ParseError.UseDotInsteadOfColonColon);
            }

            Eat(TokenType.Dot);
        }

        // namespace-or-type-name
        private NameNode ParseNamespaceOrTypeName()
        {
            Token token = PeekToken();
            NameNode name = ParseAliasQualifiedName(false);

            if ((PeekType() == TokenType.Dot || PeekType() == TokenType.ColonColon) &&
                PeekType(1) == TokenType.Identifier)
            {
                ParseNodeList list = new ParseNodeList(name);

                do
                {
                    EatDotOrColonColon();
                    list.Append(ParseSimpleName(false));
                } while (PeekType() == TokenType.Dot && PeekType(1) == TokenType.Identifier);

                return new MultiPartNameNode(token, list);
            }

            return name;
        }

        // namespace-member-declarations
        private ParseNodeList ParseNamespaceMembers()
        {
            ParseNodeList list = new ParseNodeList();

            while (true)
            {
                TokenType type = PeekType();

                switch (type)
                {
                    case TokenType.Namespace:
                        list.Append(ParseNamespace());

                        break;

                    case TokenType.Class:
                    case TokenType.Interface:
                    case TokenType.Enum:
                    case TokenType.Delegate:
                    case TokenType.Struct:

                    case TokenType.Abstract:
                    case TokenType.Sealed:

                    case TokenType.Public:
                    case TokenType.Internal:
                    case TokenType.Private:
                    case TokenType.Protected:

                    case TokenType.New:
                    case TokenType.Virtual:
                    case TokenType.Static:
                    case TokenType.Readonly:
                    case TokenType.Extern:
                    case TokenType.Override:
                    case TokenType.Unsafe:

                    case TokenType.OpenSquare:
                        list.Append(ParseTypeDeclaration());

                        break;

                    case TokenType.Identifier:

                        if (PeekPartial())
                        {
                            goto case TokenType.Class;
                        }

                        goto default;

                    default:

                        return list;
                }
            }
        }

        // namespace-declaration
        private NamespaceNode ParseNamespace()
        {
            Token token = Eat(TokenType.Namespace);
            NameNode name = ParseMultiPartName();

            // namespace-body
            Eat(TokenType.OpenCurly);
            ParseNodeList externAliases = ParseExternAliases();
            ParseNodeList usingClauses = ParseUsingClauses();
            ParseNodeList members = ParseNamespaceMembers();
            Eat(TokenType.CloseCurly);

            EatOpt(TokenType.Semicolon);

            return new NamespaceNode(token, name, externAliases, usingClauses, members);
        }

        // type-declaration
        private TypeNode ParseTypeDeclaration()
        {
            Token token = PeekToken();
            ParseNodeList attributes = ParseAttributes();
            Modifiers modifiers = ParseTypeModifiers();

            switch (PeekType())
            {
                case TokenType.Class:

                    return ParseTypeDeclaration(token, attributes, CheckModifiers(Modifiers.ClassModifiers, modifiers));
                case TokenType.Struct:

                    return ParseTypeDeclaration(token, attributes,
                        CheckModifiers(Modifiers.StructModifiers, modifiers));
                case TokenType.Interface:

                    return ParseTypeDeclaration(token, attributes,
                        CheckModifiers(Modifiers.InterfaceModifiers, modifiers));
                case TokenType.Enum:

                    return ParseTypeDeclaration(token, attributes, CheckModifiers(Modifiers.EnumModifiers, modifiers));

                case TokenType.Delegate:
                    NextToken();

                    return ParseDelegate(token, attributes, CheckModifiers(Modifiers.DelegateModifiers, modifiers));
            }

            ReportError(ParseError.TypeQualifierExpected);

            return null;
        }

        private TypeNode ParseTypeDeclaration(Token token, ParseNodeList attributes, Modifiers modifiers, bool isNestedType = false)
        {
            TokenType type = PeekType();
            NextToken();

            if (type == TokenType.Enum)
            {
                return new CustomTypeNode(
                    token,
                    type,
                    attributes,
                    modifiers,
                    ParseIdentifier(),
                    new ParseNodeList(),
                    ParseBaseList(true),
                    new ParseNodeList(),
                    ParseEnumBody(),
                    isNestedType);
            }

            return new CustomTypeNode(
                token,
                type,
                attributes,
                modifiers,
                ParseIdentifier(),
                ParseTypeParametersOpt(),
                ParseBaseList(false),
                ParseConstraintClauses(),
                ParseClassOrStructBody(),
                isNestedType);
        }

        private ParseNodeList ParseTypeParametersOpt()
        {
            ParseNodeList returnValue = new ParseNodeList();

            if (PeekType() == TokenType.OpenAngle)
            {
                Eat(TokenType.OpenAngle);

                do
                {
                    returnValue.Append(ParseTypeParameter());
                } while (null != EatOpt(TokenType.Comma));

                Eat(TokenType.CloseAngle);
            }

            return returnValue;
        }

        private TypeParameterNode ParseTypeParameter()
        {
            return new TypeParameterNode(ParseAttributes(), ParseIdentifier());
        }

        private TypeParameterConstraintNode ParseConstraintClause()
        {
            EatWhere();
            AtomicNameNode name = ParseIdentifier();
            Eat(TokenType.Colon);

            bool hasConstructorConstraint = false;
            ParseNodeList typeConstraints = new ParseNodeList();

            do
            {
                if (PeekType() == TokenType.New)
                {
                    if (hasConstructorConstraint)
                    {
                        ReportError(ParseError.DuplicateConstructorConstraint);
                    }

                    hasConstructorConstraint = true;

                    Eat(TokenType.New);
                    if(PeekType() == TokenType.OpenParen)
                    {
                        Eat(TokenType.OpenParen);
                        Eat(TokenType.CloseParen);
                    }
                }
                else if (PeekType() == TokenType.Class)
                {
                    Eat(TokenType.Class);
                }
                else if(PeekType() == TokenType.Struct)
                {
                    Eat(TokenType.Struct);
                }
                else
                {
                    if (hasConstructorConstraint)
                    {
                        ReportError(ParseError.ConstructorConstraintMustBeLast);
                    }

                    typeConstraints.Append(ParseNamespaceOrTypeName());
                }
            } while (null != EatOpt(TokenType.Comma));

            return new TypeParameterConstraintNode(name, typeConstraints, hasConstructorConstraint);
        }

        private ParseNodeList ParseConstraintClauses()
        {
            ParseNodeList returnValue = new ParseNodeList();

            while (PeekWhere()) returnValue.Append(ParseConstraintClause());

            return returnValue;
        }

        private Modifiers CheckModifiers(Modifiers validModifiers, Modifiers modifiers)
        {
            // check for invalidModifiers
            Modifiers invalidModifiers = modifiers & ~validModifiers;

            if (invalidModifiers != 0)
            {
                for (int index = 0;
                    invalidModifiers != 0;
                    index += 1, invalidModifiers = (Modifiers) ((int) invalidModifiers >> 1))
                    if ((1 & (int) invalidModifiers) != 0)
                    {
                        ReportError(ParseError.InvalidModifier, ModifierNames[index]);
                    }

                modifiers &= validModifiers;
            }

            return modifiers;
        }

        private AttributeTargets CheckAttributeTargets(Token token)
        {
            switch (token.ToString())
            {
                case "assembly": return AttributeTargets.Assembly;
                case "field":    return AttributeTargets.Field;
                case "event":    return AttributeTargets.Event;
                case "method":   return AttributeTargets.Method;
                case "module":   return AttributeTargets.Module;
                case "param":    return AttributeTargets.Param;
                case "property": return AttributeTargets.Property;
                case "return":   return AttributeTargets.Return;
                case "type":     return AttributeTargets.Type;
                default:
                    ReportError(ParseError.InvalidAttributeTarget, token, token.ToString());

                    return 0;
            }
        }

        private bool PeekModifier(out Modifiers modifier)
        {
            modifier = ToModifier(PeekType());

            return modifier != Modifiers.None;
        }

        private bool PeekModifier()
        {
            return PeekModifier(out Modifiers _);
        }

        private Modifiers ParseModifiers()
        {
            Modifiers modifiers = 0;

            while (PeekModifier(out Modifiers newModifier))
            {
                if ((newModifier & modifiers) != 0)
                {
                    ReportError(ParseError.DuplicateModifier, Token.GetString(PeekType()));
                }
                else
                {
                    modifiers |= newModifier;
                }

                NextToken();
            }

            return modifiers;
        }

        private bool PeekPostPartial()
        {
            switch (PeekType(1))
            {
                case TokenType.Class:
                case TokenType.Struct:
                case TokenType.Interface:

                    return true;
                default:

                    return false;
            }
        }

        private bool PeekPartial()
        {
            return PeekContextualKeyword(partialName) && PeekPostPartial();
        }

        private bool PeekWhere()
        {
            return PeekContextualKeyword(whereName);
        }

        private bool PeekYield()
        {
            return PeekContextualKeyword(yieldName);
        }

        private IdentifierToken EatYield()
        {
            return EatContextualKeyword(yieldName);
        }

        private bool PeekContextualKeyword(Name contextualKeyword)
        {
            return PeekType() == TokenType.Identifier && ((IdentifierToken) PeekToken()).Symbol == contextualKeyword;
        }

        private IdentifierToken EatWhere()
        {
            return EatContextualKeyword(whereName);
        }

        private IdentifierToken EatPartial()
        {
            return EatContextualKeyword(partialName);
        }

        private IdentifierToken EatContextualKeyword(Name contextualKeyword)
        {
            IdentifierToken token = (IdentifierToken) Eat(TokenType.Identifier);
            Debug.Assert(token.Symbol == contextualKeyword);

            return token;
        }

        private Modifiers ParseTypeModifiers()
        {
            Modifiers modifiers = ParseModifiers();

            if (PeekPartial())
            {
                EatPartial();
                modifiers |= Modifiers.Partial;
            }

            return modifiers;
        }

        private static Modifiers ToModifier(TokenType type)
        {
            switch (type)
            {
                case TokenType.Abstract: return Modifiers.Abstract;
                case TokenType.Sealed:   return Modifiers.Sealed;

                case TokenType.Public:    return Modifiers.Public;
                case TokenType.Internal:  return Modifiers.Internal;
                case TokenType.Private:   return Modifiers.Private;
                case TokenType.Protected: return Modifiers.Protected;

                case TokenType.New:      return Modifiers.New;
                case TokenType.Virtual:  return Modifiers.Virtual;
                case TokenType.Static:   return Modifiers.Static;
                case TokenType.Readonly: return Modifiers.Readonly;
                case TokenType.Extern:   return Modifiers.Extern;
                case TokenType.Override: return Modifiers.Override;
                case TokenType.Unsafe:   return Modifiers.Unsafe;
                case TokenType.Volatile: return Modifiers.Volatile;

                default: return Modifiers.None;
            }
        }

        private ParseNodeList ParseBaseList(bool isEnum)
        {
            ParseNodeList list = new ParseNodeList();

            if (PeekType() == TokenType.Colon)
            {
                NextToken();

                if (isEnum)
                {
                    switch (PeekType())
                    {
                        case TokenType.SByte:
                        case TokenType.Short:
                        case TokenType.Int:
                        case TokenType.Long:
                        case TokenType.Byte:
                        case TokenType.UShort:
                        case TokenType.UInt:
                        case TokenType.ULong:
                            list = new ParseNodeList(ParsePredefinedType());

                            break;
                        default:
                            ReportError(ParseError.BadEnumBase);

                            break;
                    }
                }
                else
                {
                    switch (PeekType())
                    {
                        case TokenType.Object:
                        case TokenType.String:
                            list.Append(ParsePredefinedType());

                            if (null == EatOpt(TokenType.Comma))
                            {
                                return list;
                            }

                            break;
                        default:

                            break;
                    }

                    do
                    {
                        list.Append(ParseNamespaceOrTypeName());
                    } while (null != EatOpt(TokenType.Comma));
                }
            }

            return list;
        }

        private ParseNode ParseBaseType()
        {
            ParseNode tree = ParsePredefinedType();

            if (tree == null)
            {
                tree = ParseNamespaceOrTypeName();
            }

            return tree;
        }

        private ParseNode ParsePredefinedType()
        {
            if (Token.IsPredefinedType(PeekType()))
            {
                IntrinsicTypeNode typeNode = new IntrinsicTypeNode(NextToken());

                // NOTE: We aren't supporting Nullable<T> for arbitrary T types
                //       since users can't create their own value types...
                //       So handling here for predefined types takes care of
                //       Nullable<T> scenarios

                Token t = PeekToken();

                if (t.Type == TokenType.Question)
                {
                    NextToken();
                    typeNode.AddNullability();
                }

                return typeNode;
            }

            return null;
        }

        private ParseNodeList ParseGlobalAttributes()
        {
            ParseNodeList list = new ParseNodeList();

            while (PeekType() == TokenType.OpenSquare &&
                   PeekType(1) == TokenType.Identifier &&
                   PeekType(2) == TokenType.Colon &&
                   (((IdentifierToken) PeekToken(1)).Symbol == assemblyName ||
                    ((IdentifierToken) PeekToken(1)).Symbol == moduleName))
                list.Append(ParseAttributeBlock());

            return list;
        }

        private ParseNodeList ParseAttributes()
        {
            ParseNodeList list = new ParseNodeList();

            while (PeekType() == TokenType.OpenSquare) list.Append(ParseAttributeBlock());

            return list;
        }

        private ParseNode ParseAttributeBlock()
        {
            Token token = Eat(TokenType.OpenSquare);
            AttributeTargets location;

            if (PeekType() <= TokenType.Identifier && PeekType(1) == TokenType.Colon)
            {
                location = CheckAttributeTargets(NextToken());
                Eat(TokenType.Colon);
            }
            else
            {
                location = 0;
            }

            ParseNodeList list = new ParseNodeList();

            do
            {
                list.Append(ParseAttribute());
            } while (null != EatOpt(TokenType.Comma) && PeekType() != TokenType.CloseSquare);

            Eat(TokenType.CloseSquare);

            return new AttributeBlockNode(
                token,
                list);
        }

        private ParseNode ParseAttribute()
        {
            NameNode name = ParseNamespaceOrTypeName();
            ParseNode arguments;

            if (PeekType() == TokenType.OpenParen)
            {
                Eat(TokenType.OpenParen);
                arguments = ParseExpressionList(TokenType.CloseParen);
                Eat(TokenType.CloseParen);
            }
            else
            {
                arguments = null;
            }

            return new AttributeNode(name, arguments);
        }

        private ParseNodeList ParseClassOrStructMembers()
        {
            ParseNodeList list = new ParseNodeList();
            TokenType type = PeekType();

            while (type != TokenType.CloseCurly && type != TokenType.Eof)
            {
                int mark = Mark();
                list.Append(ParseClassOrStructMember());

                if (mark == Mark())
                {
                    // didn't consume any tokens!
                    // ensure we make some progress
                    NextToken();
                }

                type = PeekType();
            }

            return list;
        }

        private ParseNodeList ParseClassOrStructBody()
        {
            Eat(TokenType.OpenCurly);
            ParseNodeList members = ParseClassOrStructMembers();
            Eat(TokenType.CloseCurly);
            EatOpt(TokenType.Semicolon);

            return members;
        }

        private TypeNode ParseNestedType(Token token, ParseNodeList attributes, Modifiers modifiers)
        {
            switch (PeekType())
            {
                case TokenType.Delegate:
                    NextToken();

                    return ParseDelegate(token, attributes, CheckModifiers(Modifiers.DelegateModifiers, modifiers), true);
                case TokenType.Class:

                    return ParseTypeDeclaration(token, attributes, CheckModifiers(Modifiers.ClassModifiers, modifiers), true);
                case TokenType.Struct:

                    return ParseTypeDeclaration(token, attributes,
                        CheckModifiers(Modifiers.StructModifiers, modifiers), true);
                case TokenType.Enum:

                    return ParseTypeDeclaration(token, attributes, CheckModifiers(Modifiers.EnumModifiers, modifiers), true);
                case TokenType.Interface:

                    return ParseTypeDeclaration(token, attributes,
                        CheckModifiers(Modifiers.InterfaceModifiers, modifiers), true);
                default:
                    Debug.Fail("Bad token type");

                    return null;
            }
        }

        private ParseNode ParseClassOrStructMember()
        {
            Token token = PeekToken();
            ParseNodeList attributes = ParseAttributes();
            Modifiers modifiers = ParseModifiers();

            switch (PeekType())
            {
                case TokenType.Const:
                    NextToken();

                    return new ConstantFieldDeclarationNode(
                        token,
                        attributes,
                        CheckModifiers(Modifiers.ConstantModifiers, modifiers),
                        ParseType(),
                        ParseFieldInitializersStatement(false));

                case TokenType.Delegate:
                case TokenType.Class:
                case TokenType.Struct:
                case TokenType.Enum:
                case TokenType.Interface:

                    return ParseNestedType(token, attributes, modifiers);

                case TokenType.Event:

                    return ParseEvent(token, attributes, CheckModifiers(Modifiers.EventModifiers, modifiers));

                case TokenType.Tilde:

                    return ParseDestructor(token, attributes, CheckModifiers(Modifiers.DestructorModifiers, modifiers));

                case TokenType.Implicit:
                case TokenType.Explicit:

                    return ParseConversionOperator(token, attributes,
                        CheckModifiers(Modifiers.OperatorModifiers, modifiers));

                case TokenType.Identifier:

                    if (PeekType(1) == TokenType.OpenParen)
                    {
                        return ParseConstructor(token, attributes,
                            CheckModifiers(
                                0 != (modifiers & Modifiers.Static)
                                    ? Modifiers.StaticConstructorModifiers
                                    : Modifiers.ConstructorModifiers, modifiers));
                    }
                    else if (PeekPartial())
                    {
                        EatPartial();
                        modifiers |= Modifiers.Partial;
                        goto case TokenType.Class;
                    }

                    goto default;

                case TokenType.Fixed:
                    Eat(TokenType.Fixed);

                    return new FieldDeclarationNode(
                        token,
                        attributes,
                        CheckModifiers(Modifiers.FieldModifiers, modifiers),
                        CheckIsType(ParseReturnType(), false),
                        ParseFieldInitializersStatement(true),
                        true);

                default:
                {
                    ParseNode type = ParseReturnType();

                    switch (ParseMemberName(out NameNode interfaceType))
                    {
                        case ScanMemberNameKind.Operator:

                            return ParseOperator(token, attributes,
                                CheckModifiers(Modifiers.OperatorModifiers, modifiers), CheckIsType(type, false));

                        case ScanMemberNameKind.Indexer:

                            return ParseIndexer(token, attributes,
                                CheckModifiers(Modifiers.IndexerModifiers, modifiers), CheckIsType(type, false),
                                interfaceType);

                        case ScanMemberNameKind.Field:
                            ReportInterfaceVariable(interfaceType);

                            return new FieldDeclarationNode(
                                token,
                                attributes,
                                CheckModifiers(Modifiers.FieldModifiers, modifiers),
                                CheckIsType(type, false),
                                ParseFieldInitializersStatement(false),
                                false);
                        case ScanMemberNameKind.Method:

                            return ParseMethod(token, attributes, CheckModifiers(Modifiers.MethodModifiers, modifiers),
                                type, interfaceType);
                        case ScanMemberNameKind.Property:

                            return ParseProperty(token, attributes,
                                CheckModifiers(Modifiers.PropertyModifiers, modifiers), CheckIsType(type, false),
                                interfaceType, false);
                        default:
                            Debug.Fail("Invalid Member name kind");

                            return null;
                    }
                }
            }
        }

        private void ReportInterfaceVariable(NameNode interfaceType)
        {
            if (interfaceType != null)
            {
                ReportError(ParseError.VariableCannotBeInterfaceImpl, interfaceType.Token);
            }
        }

        // this
        // type-name.this
        // methodName (
        // methodName<T> (
        // typename.methodName (
        // propertyName {
        // typename.propertyName {
        // typename.methodName<[Attr]T> (
        // fieldName
        private ScanMemberNameKind ParseMemberName(out NameNode interfaceType)
        {
            if (PeekType() == TokenType.Operator)
            {
                interfaceType = null;

                return ScanMemberNameKind.Operator;
            }

            Token token = PeekToken();
            ParseNodeList list = new ParseNodeList();

            if (PeekType() == TokenType.Identifier && PeekType(1) == TokenType.ColonColon)
            {
                interfaceType = ParseAliasQualifiedName(false);
                list.Append(interfaceType);
                EatDotOrColonColon();
            }
            else
            {
                interfaceType = null;
            }

            ScanMemberNameKind result = ScanMemberNameKind.Invalid;

            do
            {
                if (PeekType() == TokenType.This)
                {
                    result = ScanMemberNameKind.Indexer;
                }
                else if (PeekType() != TokenType.Identifier)
                {
                    result = ScanMemberNameKind.Field;
                }
                else
                {
                    switch (PeekType(1))
                    {
                        case TokenType.OpenCurly:
                            result = ScanMemberNameKind.Property;

                            break;
                        case TokenType.OpenParen:
                            result = ScanMemberNameKind.Method;

                            break;
                        case TokenType.OpenAngle:
                            int mark = Mark();
                            NextToken(); // _id
                            TypeArgumentListScan scan = ScanTypeArgumentListOpt();

                            if (scan == TypeArgumentListScan.MayBeTypeArgumentList)
                            {
                                switch (PeekType())
                                {
                                    case TokenType.Dot:
                                    case TokenType.ColonColon:
                                        scan = TypeArgumentListScan.MustBeTypeArgumentList;

                                        break;
                                    default:
                                        scan = TypeArgumentListScan.TypeParameterList;

                                        break;
                                }
                            }

                            Rewind(mark);

                            if (scan == TypeArgumentListScan.TypeParameterList ||
                                scan == TypeArgumentListScan.NotTypeArgumentList)
                            {
                                result = ScanMemberNameKind.Method;

                                break;
                            }

                            list.Append(ParseSimpleName(false));
                            EatDotOrColonColon();

                            break;
                        case TokenType.ColonColon:
                        case TokenType.Dot:
                            list.Append(ParseSimpleName(false));
                            EatDotOrColonColon();

                            break;
                        default:
                            result = ScanMemberNameKind.Field;

                            break;
                    }
                }
            } while (ScanMemberNameKind.Invalid == result);

            if (list.Count > 1)
            {
                interfaceType = new MultiPartNameNode(token, list);
            }

            return result;
        }

        private DestructorDeclarationNode ParseDestructor(Token token, ParseNodeList attributes, Modifiers modifiers)
        {
            NextToken(); // ~
            AtomicNameNode name = ParseIdentifier();
            Eat(TokenType.OpenParen);
            Eat(TokenType.CloseParen);

            return new DestructorDeclarationNode(
                token,
                attributes,
                modifiers,
                name,
                ParseBlockOpt());
        }

        private ConstructorDeclarationNode ParseConstructor(Token token, ParseNodeList attributes, Modifiers modifiers)
        {
            AtomicNameNode name = ParseIdentifier();
            ParseNodeList formals = ParseParensFormalParameterList();
            ParseNode initializer;
            bool thisCall;

            if (PeekType() == TokenType.Colon)
            {
                Eat(TokenType.Colon);

                if (PeekType() == TokenType.This)
                {
                    thisCall = true;
                    Eat(TokenType.This);
                }
                else
                {
                    thisCall = false;
                    Eat(TokenType.Base);
                }

                initializer = ParseParenArgumentList();
            }
            else
            {
                thisCall = false;
                initializer = null;
            }

            BlockStatementNode body = ParseBlockOpt();

            return new ConstructorDeclarationNode(
                token,
                attributes,
                modifiers,
                name,
                formals,
                thisCall,
                initializer,
                body);
        }

        private OperatorDeclarationNode ParseConversionOperator(Token token, ParseNodeList attributes,
                                                                Modifiers modifiers)
        {
            TokenType implicitExplicit = NextToken().Type; // implicit/explicit
            Eat(TokenType.Operator);
            OperatorDeclarationNode tree = new OperatorDeclarationNode(
                token,
                attributes,
                modifiers,
                implicitExplicit,
                ParseType(),
                ParseParensFormalParameterList(),
                ParseBlockOpt());

            if (tree.Parameters.Count != 1)
            {
                ReportError(ParseError.ConversionMustHaveOneParam, tree.Token);
            }

            return tree;
        }

        private OperatorDeclarationNode ParseOperator(Token token, ParseNodeList attributes, Modifiers modifiers,
                                                      ParseNode type)
        {
            NextToken(); // operator
            TokenType operatorKind = EatOverloadableOperator();

            OperatorDeclarationNode tree = new OperatorDeclarationNode(
                token,
                attributes,
                modifiers,
                operatorKind,
                type,
                ParseParensFormalParameterList(),
                ParseBlockOpt());

            switch (tree.OperatorTokenType)
            {
                // unary or binary operators
                case TokenType.Plus:
                case TokenType.Minus:

                    if (tree.Parameters.Count != 1 && tree.Parameters.Count != 2)
                    {
                        ReportError(ParseError.WrongNumberOfArgsToOperator, tree.Token);
                    }

                    break;

                // unary operators
                case TokenType.Bang:
                case TokenType.Tilde:
                case TokenType.PlusPlus:
                case TokenType.MinusMinus:
                case TokenType.True:
                case TokenType.False:

                    if (tree.Parameters.Count != 1)
                    {
                        ReportError(ParseError.WrongNumberOfArgsToUnaryOperator, tree.Token);
                    }

                    break;

                // binary operators
                case TokenType.Star:
                case TokenType.Slash:
                case TokenType.Percent:
                case TokenType.Ampersand:
                case TokenType.Bar:
                case TokenType.Hat:
                case TokenType.ShiftLeft:
                case TokenType.ShiftRight:
                case TokenType.EqualEqual:
                case TokenType.NotEqual:
                case TokenType.Greater:
                case TokenType.GreaterEqual:
                case TokenType.Less:
                case TokenType.LessEqual:

                    if (tree.Parameters.Count != 2)
                    {
                        ReportError(ParseError.WrongNumberOfArgsToBinnaryOperator, tree.Token);
                    }

                    break;

                default:

                    break;
            }

            return tree;
        }

        private MethodDeclarationNode ParseMethod(
            Token token,
            ParseNodeList attributes,
            Modifiers modifiers,
            ParseNode type,
            NameNode interfaceType)
        {
            return new MethodDeclarationNode(
                token,
                attributes,
                modifiers,
                type,
                interfaceType,
                ParseIdentifier(),
                ParseTypeParametersOpt(),
                ParseParensFormalParameterList(),
                ParseConstraintClauses(),
                ParseBlockOpt());
        }

        private IndexerDeclarationNode ParseIndexer(
            Token token,
            ParseNodeList attributes,
            Modifiers modifiers,
            ParseNode type,
            NameNode interfaceType)
        {
            Eat(TokenType.This);
            Eat(TokenType.OpenSquare);
            ParseNodeList formals = ParseFormalParameterList(TokenType.CloseSquare);
            Eat(TokenType.CloseSquare);

            ParseAccessors(false, out AccessorNode get, out AccessorNode set);

            return new IndexerDeclarationNode(
                token,
                attributes,
                modifiers,
                type,
                interfaceType,
                formals,
                get,
                set);
        }

        private PropertyDeclarationNode ParseProperty(
            Token token,
            ParseNodeList attributes,
            Modifiers modifiers,
            ParseNode type,
            NameNode interfaceType,
            bool isEvent)
        {
            AtomicNameNode name = ParseIdentifier();

            ParseAccessors(isEvent, out AccessorNode get, out AccessorNode set);

            return new PropertyDeclarationNode(
                token,
                attributes,
                modifiers,
                type,
                interfaceType,
                name,
                get,
                set);
        }

        private void ParseAccessors(bool isEvent, out AccessorNode get, out AccessorNode set)
        {
            get = null;
            set = null;

            Eat(TokenType.OpenCurly);

            // first accessor
            Token token = PeekToken();
            ParseNodeList attributes = ParseAttributes();

            while (attributes.Count != 0 || PeekType() == TokenType.Identifier || !isEvent && PeekModifier())
            {
                Modifiers modifiers = 0;

                if (!isEvent)
                {
                    modifiers = ParseModifiers();
                }

                AtomicNameNode name = ParseIdentifier();
                BlockStatementNode body = ParseBlockOpt();

                if (name.Identifier.Symbol == getName && !isEvent ||
                    name.Identifier.Symbol == removeName && isEvent)
                {
                    if (get != null)
                    {
                        ReportError(ParseError.DuplicateAccessor, name.Identifier.Symbol);
                    }
                    else
                    {
                        get = new AccessorNode(token, attributes, name, body, modifiers);
                    }
                }
                else if (name.Identifier.Symbol == setName && !isEvent ||
                         name.Identifier.Symbol == addName && isEvent)
                {
                    if (set != null)
                    {
                        ReportError(ParseError.DuplicateAccessor, name.Identifier.Symbol, modifiers);
                    }
                    else
                    {
                        set = new AccessorNode(token, attributes, name, body, modifiers);
                    }
                }
                else
                {
                    if (!isEvent)
                    {
                        ReportError(ParseError.GetOrSetExpected);
                    }
                    else
                    {
                        ReportError(ParseError.AddOrRemoveExpected);
                    }
                }

                // next accessor
                token = PeekToken();
                attributes = ParseAttributes();
            }

            if (get == null && set == null)
            {
                ReportError(ParseError.NeedAtLeastOneAccessor);
            }
            else if (isEvent && (get == null || set == null))
            {
                ReportError(ParseError.EventMissingAcessor);
            }

            Eat(TokenType.CloseCurly);
        }

        private ParseNode ParseEvent(Token token, ParseNodeList attributes, Modifiers modifiers)
        {
            ParseNode backingMember;
            NextToken(); // event
            ParseNode type = ParseType();

            switch (ParseMemberName(out NameNode interfaceType))
            {
                case ScanMemberNameKind.Property:

                    backingMember = ParseProperty(token, new ParseNodeList(), modifiers, type, interfaceType, true);

                    break;
                case ScanMemberNameKind.Field:
                default:
                    ReportInterfaceVariable(interfaceType);
                    backingMember = new VariableDeclarationNode(
                        token,
                        new ParseNodeList(),
                        modifiers,
                        type,
                        ParseFieldInitializersStatement(false),
                        false);

                    break;
            }

            return new EventDeclarationNode(
                token,
                attributes,
                backingMember);
        }

        private ParseNodeList ParseFieldInitializers(bool isFixed)
        {
            ParseNodeList list = new ParseNodeList();

            do
            {
                if (!isFixed)
                {
                    list.Append(new VariableInitializerNode(ParseIdentifier(), ParseVariableInitializer()));
                }
                else
                {
                    list.Append(new VariableInitializerNode(ParseIdentifier(), ParseFixedArrayDimension()));
                }
            } while (EatOpt(TokenType.Comma) != null);

            return list;
        }

        private ParseNode ParseFixedArrayDimension()
        {
            Eat(TokenType.OpenSquare);
            ParseNode returnValue = ParseExpression();
            Eat(TokenType.CloseSquare);

            return returnValue;
        }

        private ParseNodeList ParseFieldInitializersStatement(bool isFixed)
        {
            ParseNodeList returnValue = ParseFieldInitializers(isFixed);
            if(PeekType() == TokenType.Semicolon)
                Eat(TokenType.Semicolon);

            return returnValue;
        }

        private ParseNodeList ParseEnumMembers()
        {
            ParseNodeList list = new ParseNodeList();

            while (PeekType() == TokenType.Identifier || PeekType() == TokenType.OpenSquare)
            {
                list.Append(ParseEnumerationField());

                if (null == EatOpt(TokenType.Comma))
                {
                    break;
                }
            }

            return list;
        }

        private ParseNodeList ParseEnumBody()
        {
            Eat(TokenType.OpenCurly);
            ParseNodeList members = ParseEnumMembers();
            Eat(TokenType.CloseCurly);
            EatOpt(TokenType.Semicolon);

            return members;
        }

        private ParseNode ParseEnumerationField()
        {
            return new EnumerationFieldNode(
                ParseAttributes(),
                ParseIdentifier(),
                ParseVariableInitializer());
        }

        private ParseNode ParseVariableInitializer()
        {
            if (PeekType() == TokenType.Equal)
            {
                NextToken();

                if (PeekType() == TokenType.OpenCurly)
                {
                    return ParseArrayInitializer();
                }

                if (PeekType() == TokenType.Stackalloc)
                {
                    return ParseStackAlloc();
                }

                return ParseExpression();
            }

            return null;
        }

        private StackAllocNode ParseStackAlloc()
        {
            Token token = Eat(TokenType.Stackalloc);
            ParseNode type = ParseType();
            Eat(TokenType.OpenSquare);
            ParseNode numberOfElements = ParseExpression();
            Eat(TokenType.CloseSquare);

            return new StackAllocNode(token, type, numberOfElements);
        }

        private DelegateTypeNode ParseDelegate(Token token, ParseNodeList attributes, Modifiers modifiers, bool isNestedType = false)
        {
            ParseNode returnType = ParseReturnType();
            AtomicNameNode name = ParseIdentifier();
            ParseNodeList typeParameters = ParseTypeParametersOpt();
            ParseNodeList formals = ParseParensFormalParameterList();
            ParseNodeList constraints = ParseConstraintClauses();
            Eat(TokenType.Semicolon);

            return new DelegateTypeNode(
                token,
                attributes,
                modifiers,
                returnType,
                name,
                typeParameters,
                formals,
                constraints,
                isNestedType);
        }

        private ParseNode ParseNonArrayType()
        {
            ParseNode type = ParseBaseType();

            while (PeekType() == TokenType.Star)
            {
                NextToken();
                type = new PointerTypeNode(type);
            }

            return type;
        }

        private ParseNode ParseArrayRanks(ParseNode type)
        {
            if (PeekType() == TokenType.OpenSquare &&
                (PeekType(1) == TokenType.Comma || PeekType(1) == TokenType.CloseSquare))
            {
                CheckIsType(type, true);

                do
                {
                    NextToken();
                    int rank = 1;

                    while (null != EatOpt(TokenType.Comma)) rank += 1;

                    type = new ArrayTypeNode(type, rank);
                    Eat(TokenType.CloseSquare);
                } while (PeekType() == TokenType.OpenSquare &&
                         (PeekType(1) == TokenType.Comma || PeekType(1) == TokenType.CloseSquare));
            }

            return type;
        }

        private ParseNode ParseReturnType()
        {
            return ParseArrayRanks(ParseNonArrayType());
        }

        private ParseNode CheckIsType(ParseNode type, bool isArray)
        {
            if (type.NodeType == ParseNodeType.PredefinedType &&
                ((IntrinsicTypeNode) type).Token.Type == TokenType.Void)
            {
                ReportError(isArray ? ParseError.ArrayOfVoidType : ParseError.VoidNotType);
            }

            return type;
        }

        private ParseNode ParseType()
        {
            return CheckIsType(ParseReturnType(), false);
        }

        private ParseNodeList ParseParensFormalParameterList()
        {
            return ParseParensFormalParameterList(true);
        }

        private ParseNodeList ParseParensFormalParameterList(bool allowAttributes)
        {
            Eat(TokenType.OpenParen);
            ParseNodeList tree = ParseFormalParameterList(TokenType.CloseParen, allowAttributes);
            Eat(TokenType.CloseParen);

            return tree;
        }

        private ParseNodeList ParseFormalParameterList(TokenType endType)
        {
            return ParseFormalParameterList(endType, true);
        }

        private ParseNodeList ParseFormalParameterList(TokenType endType, bool allowAttributes)
        {
            ParseNodeList list = new ParseNodeList();

            if (PeekType() != endType)
            {
                ParameterNode lastParam;

                do
                {
                    lastParam = ParseFormalParameter(allowAttributes);
                    if(list.Count >= 1 && lastParam.IsExtensionMethodTarget)
                    {
                        throw new System.InvalidOperationException("Only the first parameter of a method can be an extension parameter");
                    }
                    list.Append(lastParam);
                } while (null != EatOpt(TokenType.Comma) && lastParam.Flags != ParameterFlags.Params);
            }

            return list;
        }

        private ParameterNode ParseFormalParameter()
        {
            return ParseFormalParameter(true);
        }

        private ParameterNode ParseFormalParameter(bool allowAttributes)
        {
            bool containsThis = false;
            if(PeekType() == TokenType.This)
            {
                Eat(TokenType.This);
                containsThis = true;
            }
            
            return new ParameterNode(
                PeekToken(),
                allowAttributes ? ParseAttributes() : new ParseNodeList(),
                ParseParameterFlags(),
                ParseType(),
                ParseIdentifier(),
                containsThis);
        }

        private ParameterFlags ParseParameterFlags()
        {
            ParameterFlags flags = ParameterFlags.None;
            TokenType type = PeekType();

            while (type == TokenType.Ref || type == TokenType.Out || type == TokenType.Params)
            {
                if (flags != ParameterFlags.None)
                {
                    ReportError(ParseError.DuplicateParameterModifier);
                }
                else
                {
                    if (type == TokenType.Ref)
                    {
                        flags = ParameterFlags.Ref;
                    }
                    else if (type == TokenType.Out)
                    {
                        flags = ParameterFlags.Out;
                    }
                    else
                    {
                        flags = ParameterFlags.Params;
                    }
                }

                NextToken();
                type = PeekType();
            }

            return flags;
        }

        private BlockStatementNode ParseBlockOpt()
        {
            if (PeekType() == TokenType.Semicolon)
            {
                Eat(TokenType.Semicolon);

                return null;
            }

            return ParseBlock();
        }

        private BlockStatementNode ParseBlock()
        {
            Token token = PeekToken();

            ParseNodeList statements = new ParseNodeList();
            Eat(TokenType.OpenCurly);

            TokenType type = PeekType();

            while (type != TokenType.CloseCurly && type != TokenType.Eof)
            {
                int mark = Mark();
                statements.Append(ParseStatement());

                // ensure we make progress in an error case
                if (mark == Mark())
                {
                    NextToken();
                }

                type = PeekType();
            }

            Eat(TokenType.CloseCurly);

            return new BlockStatementNode(token, statements);
        }

        private StatementNode ParseStatement()
        {
            return ParseStatement(false);
        }

        private StatementNode ParseEmbeddedStatement()
        {
            return ParseStatement(true);
        }

        private StatementNode ParseStatement(bool embeddedOnly)
        {
            switch (PeekType())
            {
                // block
                case TokenType.OpenCurly: return ParseBlock();

                // empty
                case TokenType.Semicolon: return ParseEmptyStatement();

                // local const
                case TokenType.Const:

                    if (!embeddedOnly)
                    {
                        return new ConstantDeclarationNode(
                            NextToken(),
                            new ParseNodeList(),
                            Modifiers.None,
                            ParseType(),
                            ParseFieldInitializersStatement(false));
                    }

                    goto default;

                // selection statements
                case TokenType.If:     return ParseIf();
                case TokenType.Switch: return ParseSwitch();

                // iteration statements
                case TokenType.While:   return ParseWhile();
                case TokenType.For:     return ParseFor();
                case TokenType.Do:      return ParseDo();
                case TokenType.Foreach: return ParseForeach();

                // labelled statement
                case TokenType.Identifier:
                {
                    TokenType peek = PeekType(1);

                    if (peek == TokenType.Colon && !embeddedOnly)
                    {
                        return ParseLabeledStatement();
                    }

                    if (PeekYield() && peek == TokenType.Break)
                    {
                        return ParseYieldBreak();
                    }

                    if (PeekYield() && peek == TokenType.Return)
                    {
                        return ParseYieldReturn();
                    }

                    goto default;
                }

                // jump statements
                case TokenType.Break:    return ParseBreak();
                case TokenType.Continue: return ParseContinue();
                case TokenType.Goto:     return ParseGoto();
                case TokenType.Return:   return ParseReturn();
                case TokenType.Throw:    return ParseThrow();

                // try
                case TokenType.Try: return ParseTry();

                // checked
                case TokenType.Checked:   return ParseChecked();
                case TokenType.Unchecked: return ParseUnchecked();
                case TokenType.Using:     return ParseUsing();

                // lock
                case TokenType.Lock: return ParseLock();

                // fixed
                case TokenType.Fixed: return ParseFixed();

                case TokenType.Unsafe: return ParseUnsafeStatement();

                default:
                {
                    if (!embeddedOnly && ScanLocalVariableDeclaration())
                    {
                        return ParseDeclarationStatement();
                    }

                    return ParseExpressionStatement();
                }
            }
        }

        private EmptyStatementNode ParseEmptyStatement()
        {
            return new EmptyStatementNode(Eat(TokenType.Semicolon));
        }

        private IfElseNode ParseIf()
        {
            Token token = Eat(TokenType.If);
            ParseNode condition = ParseParenExpression();
            ParseNode ifBlock = ParseEmbeddedStatement();
            ParseNode elseBlock;

            if (PeekType() == TokenType.Else)
            {
                NextToken();
                elseBlock = ParseEmbeddedStatement();
            }
            else
            {
                elseBlock = null;
            }

            return new IfElseNode(token, condition, ifBlock, elseBlock);
        }

        private ParseNode ParseParenExpression()
        {
            Eat(TokenType.OpenParen);
            ParseNode expr = ParseExpression();
            Eat(TokenType.CloseParen);

            return expr;
        }

        private SwitchNode ParseSwitch()
        {
            Token token = Eat(TokenType.Switch);
            ParseNode condition = ParseParenExpression();
            ParseNodeList cases = new ParseNodeList();
            Eat(TokenType.OpenCurly);

            TokenType type = PeekType();

            while (type != TokenType.CloseCurly && type != TokenType.Eof)
            {
                Token sectionToken = PeekToken();

                // parse case labels
                ParseNodeList labels = new ParseNodeList();
                ParseNode label;

                while ((label = ParseSwitchLabel()) != null)
                {
                    Eat(TokenType.Colon);
                    labels.Append(label);
                }

                if (labels.Count == 0)
                {
                    ReportError(ParseError.CaseOrDefaultExpected);
                }

                // parse statements
                ParseNodeList statements = new ParseNodeList();
                type = PeekType();

                while (type != TokenType.Case && type != TokenType.Default && type != TokenType.CloseCurly &&
                       type != TokenType.Eof)
                {
                    int mark = Mark();

                    statements.Append(ParseStatement());

                    // ensure we make progress in an error case
                    if (mark == Mark())
                    {
                        NextToken();
                    }

                    type = PeekType();
                }

                if (statements.Count == 0)
                {
                    ReportError(ParseError.StatementExpected);
                }

                cases.Append(new SwitchSectionNode(
                    sectionToken,
                    labels,
                    statements));
            }

            Eat(TokenType.CloseCurly);

            return new SwitchNode(token, condition, cases);
        }

        private ParseNode ParseSwitchLabel()
        {
            ParseNode tree;

            if (PeekType() == TokenType.Case)
            {
                tree = new CaseLabelNode(Eat(TokenType.Case), ParseExpression());
            }
            else if (PeekType() == TokenType.Default)
            {
                tree = new DefaultLabelNode(Eat(TokenType.Default));
            }
            else
            {
                return null;
            }

            return tree;
        }

        private WhileNode ParseWhile()
        {
            return new WhileNode(
                Eat(TokenType.While),
                ParseParenExpression(),
                ParseEmbeddedStatement());
        }

        private DoWhileNode ParseDo()
        {
            Token token = Eat(TokenType.Do);
            ParseNode body = ParseEmbeddedStatement();
            Eat(TokenType.While);
            ParseNode condition = ParseParenExpression();
            Eat(TokenType.Semicolon);

            return new DoWhileNode(token, body, condition);
        }

        private ForNode ParseFor()
        {
            Token token = Eat(TokenType.For);
            Eat(TokenType.OpenParen);

            // local vardecl or statement list
            ParseNode initializer;

            if (ScanLocalVariableDeclaration())
            {
                initializer = ParseDeclarationStatement();
            }
            else
            {
                initializer = ParseStatementExpressionList(TokenType.Semicolon);
                Eat(TokenType.Semicolon);
            }

            ParseNode condition;

            if (PeekType() == TokenType.Semicolon)
            {
                condition = null;
            }
            else
            {
                condition = ParseExpression();
            }

            Eat(TokenType.Semicolon);

            ParseNode increment;

            if (PeekType() == TokenType.CloseParen)
            {
                increment = null;
            }
            else
            {
                increment = ParseStatementExpressionList(TokenType.CloseParen);
            }

            Eat(TokenType.CloseParen);

            return new ForNode(
                token,
                initializer,
                condition,
                increment,
                ParseEmbeddedStatement());
        }

        private ExpressionListNode ParseStatementExpressionList(TokenType terminator)
        {
            Token token = PeekToken();
            ParseNodeList list = new ParseNodeList();

            if (PeekType() != terminator)
            {
                do
                {
                    list.Append(ParseStatementExpression());
                } while (null != EatOpt(TokenType.Comma));
            }

            return new ExpressionListNode(token, list);
        }

        private ExpressionListNode ParseExpressionList(TokenType terminator)
        {
            Token token = PeekToken();
            ParseNodeList list = new ParseNodeList();

            if (PeekType() != terminator)
            {
                do
                {
                    list.Append(ParseExpression());
                } while (null != EatOpt(TokenType.Comma));
            }

            return new ExpressionListNode(token, list);
        }

        private ForeachNode ParseForeach()
        {
            Token token = Eat(TokenType.Foreach);
            Eat(TokenType.OpenParen);
            ParseNode type = ParseType();
            AtomicNameNode identifier = ParseIdentifier();
            Eat(TokenType.In);
            ParseNode container = ParseExpression();
            Eat(TokenType.CloseParen);

            return new ForeachNode(
                token,
                type,
                identifier,
                container,
                ParseEmbeddedStatement());
        }

        private BreakNode ParseBreak()
        {
            Token token = Eat(TokenType.Break);
            Eat(TokenType.Semicolon);

            return new BreakNode(token);
        }

        private ContinueNode ParseContinue()
        {
            Token token = Eat(TokenType.Continue);
            Eat(TokenType.Semicolon);

            return new ContinueNode(token);
        }

        private GotoNode ParseGoto()
        {
            Token token = Eat(TokenType.Goto);
            ParseNode destination;
            destination = ParseSwitchLabel();

            if (null == destination)
            {
                destination = ParseIdentifier();
            }

            Eat(TokenType.Semicolon);

            return new GotoNode(token, destination);
        }

        private ThrowNode ParseThrow()
        {
            Token token = Eat(TokenType.Throw);

            ParseNode value;

            if (PeekType() != TokenType.Semicolon)
            {
                value = ParseExpression();
            }
            else
            {
                value = null;
            }

            Eat(TokenType.Semicolon);

            return new ThrowNode(token, value);
        }

        private ReturnNode ParseReturn()
        {
            Token token = Eat(TokenType.Return);

            ParseNode value;

            if (PeekType() != TokenType.Semicolon)
            {
                value = ParseExpression();
            }
            else
            {
                value = null;
            }

            Eat(TokenType.Semicolon);

            return new ReturnNode(token, value);
        }

        private YieldReturnNode ParseYieldReturn()
        {
            IdentifierToken token = EatYield();
            Eat(TokenType.Return);

            ParseNode value = ParseExpression();
            Eat(TokenType.Semicolon);

            return new YieldReturnNode(token, value);
        }

        private YieldBreakNode ParseYieldBreak()
        {
            IdentifierToken token = EatYield();
            Eat(TokenType.Break);
            Eat(TokenType.Semicolon);

            return new YieldBreakNode(token);
        }

        private TryNode ParseTry()
        {
            Token token = Eat(TokenType.Try);
            ParseNode body = ParseBlock();

            ParseNodeList catchClauses = new ParseNodeList();

            while (PeekType() == TokenType.Catch)
            {
                Token catchToken = Eat(TokenType.Catch);
                ParseNode type;
                AtomicNameNode name;

                if (PeekType() == TokenType.OpenParen)
                {
                    Eat(TokenType.OpenParen);
                    type = ParseType();

                    if (PeekType() == TokenType.Identifier)
                    {
                        name = ParseIdentifier();
                    }
                    else
                    {
                        name = null;
                    }

                    Eat(TokenType.CloseParen);
                }
                else
                {
                    type = null;
                    name = null;
                }

                catchClauses.Append(new CatchNode(
                    catchToken,
                    type,
                    name,
                    ParseBlock()));
            }

            ParseNode finallyClause;

            if (PeekType() == TokenType.Finally)
            {
                Eat(TokenType.Finally);
                finallyClause = ParseBlock();
            }
            else
            {
                finallyClause = null;
            }

            return new TryNode(
                token,
                body,
                catchClauses,
                finallyClause);
        }

        private CheckedNode ParseChecked()
        {
            return new CheckedNode(Eat(TokenType.Checked), ParseBlock());
        }

        private UncheckedNode ParseUnchecked()
        {
            return new UncheckedNode(Eat(TokenType.Unchecked), ParseBlock());
        }

        private UsingNode ParseUsing()
        {
            Token token = Eat(TokenType.Using);
            Eat(TokenType.OpenParen);
            ParseNode guard;

            if (ScanLocalVariableDeclaration())
            {
                guard = ParseDeclaration();

                foreach (VariableInitializerNode i in ((VariableDeclarationNode) guard).Initializers)
                    if (i.Value == null)
                    {
                        ReportError(ParseError.UsingDeclaratorsMustHaveValue, i.Token);
                    }
            }
            else
            {
                guard = ParseExpression();
            }

            Eat(TokenType.CloseParen);

            return new UsingNode(token, guard, ParseEmbeddedStatement());
        }

        private LockNode ParseLock()
        {
            return new LockNode(
                Eat(TokenType.Lock),
                ParseParenExpression(),
                ParseEmbeddedStatement());
        }

        private FixedNode ParseFixed()
        {
            Token token = Eat(TokenType.Fixed);
            Eat(TokenType.OpenParen);
            VariableDeclarationNode declaration = ParseDeclaration();

            if (declaration.Type.NodeType != ParseNodeType.PointerType)
            {
                ReportError(ParseError.FixedVariablesMustBeOfPointerType, token);
            }

            foreach (VariableInitializerNode i in declaration.Initializers)
                if (i.Value == null)
                {
                    ReportError(ParseError.FixedDeclaratorsMustHaveValue, i.Token);
                }

            Eat(TokenType.CloseParen);

            return new FixedNode(token, declaration, ParseEmbeddedStatement());
        }

        private UnsafeNode ParseUnsafeStatement()
        {
            return new UnsafeNode(Eat(TokenType.Unsafe), ParseBlock());
        }

        private ExpressionStatementNode ParseExpressionStatement()
        {
            ParseNode expression = ParseStatementExpression();
            Eat(TokenType.Semicolon);

            return new ExpressionStatementNode(expression);
        }

        private ParseNode ParseStatementExpression()
        {
            ParseNode expression = ParseExpression();

            if (expression != null)
            {
                switch (expression.NodeType)
                {
                    case ParseNodeType.BinaryExpression:

                        // postincrment, postdecrement
                        // method call
                        // assignment
                        switch (((BinaryExpressionNode) expression).Operator)
                        {
                            case TokenType.PlusPlus:
                            case TokenType.MinusMinus:
                            case TokenType.OpenParen:

                                break;
                            default:

                                if (Token.IsAssignmentOperator(((BinaryExpressionNode) expression).Operator))
                                {
                                    break;
                                }

                                ReportError(ParseError.ExpressionStatementMustDoWork, expression.Token);

                                break;
                        }

                        break;
                    case ParseNodeType.New:
                    case ParseNodeType.ArrayNew:

                        break;
                    case ParseNodeType.UnaryExpression:

                        // preincrement, predecrement
                        switch (((UnaryExpressionNode) expression).Token.Type)
                        {
                            case TokenType.PlusPlus:
                            case TokenType.MinusMinus:

                                break;
                            default:
                                ReportError(ParseError.ExpressionStatementMustDoWork, expression.Token);

                                break;
                        }

                        break;
                    default:
                        ReportError(ParseError.ExpressionStatementMustDoWork, expression.Token);

                        break;
                }
            }

            return expression;
        }

        private LabeledStatementNode ParseLabeledStatement()
        {
            AtomicNameNode label = ParseIdentifier();
            Eat(TokenType.Colon);

            return new LabeledStatementNode(label, ParseStatement());
        }

        private bool ScanLocalVariableDeclaration()
        {
            int mark = Mark();
            bool returnValue = ScanType() != Scan.Nottype && PeekType() == TokenType.Identifier;
            Rewind(mark);

            return returnValue;
        }

        private Scan ScanTypeNamePart()
        {
            if (PeekType() == TokenType.Identifier)
            {
                NextToken();

                if (PeekType() == TokenType.OpenAngle)
                {
                    switch (ScanTypeArgumentListOpt())
                    {
                        case TypeArgumentListScan.TypeParameterList:
                        case TypeArgumentListScan.NotTypeArgumentList:

                            return Scan.Nottype;
                        case TypeArgumentListScan.MustBeTypeArgumentList:
                        case TypeArgumentListScan.MayBeTypeArgumentList:

                            return Scan.CouldBeType;
                        default:
                            Debug.Fail("Invalid scan result");

                            break;
                    }

                    return Scan.Nottype;
                }

                return Scan.CouldBeType;
            }

            return Scan.Nottype;
        }

        private Scan ScanBaseType()
        {
            // scan a base type
            if (PeekType() == TokenType.Identifier)
            {
                do
                {
                    Scan result = Scan.CouldBeType;

                    switch (ScanTypeNamePart())
                    {
                        case Scan.Nottype:

                            return Scan.Nottype;
                        case Scan.CouldBeType:

                            break;
                        case Scan.Type:
                            result = Scan.Type;

                            break;
                        default:
                            Debug.Fail("Invalid scan result");

                            break;
                    }

                    TokenType peek = PeekType();

                    if ((peek = PeekType()) == TokenType.Dot || peek == TokenType.ColonColon)
                    {
                        if (peek == TokenType.Dot)
                        {
                            result = Scan.CouldBeType;
                        }
                        else
                        {
                            result = Scan.Type;
                        }

                        NextToken();

                        if (PeekType() != TokenType.Identifier)
                        {
                            return Scan.Nottype;
                        }
                    }
                    else
                    {
                        return result;
                    }
                } while (true);
            }

            if (Token.IsPredefinedType(PeekType()))
            {
                NextToken();

                return Scan.Type;
            }

            return Scan.Nottype;
        }

        private Scan ScanType()
        {
            Scan result = ScanBaseType();

            if (result == Scan.Nottype)
            {
                return Scan.Nottype;
            }

            // scan pointer flags
            int numberOfStars = 0;

            while (null != EatOpt(TokenType.Star))
            {
                numberOfStars += 1;

                if (result == Scan.CouldBeType && numberOfStars == 1)
                {
                    result = Scan.PointerOrMult;
                }
                else if (result == Scan.PointerOrMult && numberOfStars > 1)
                {
                    result = Scan.Type;
                }
            }

            // scan nullable flags
            while (null != EatOpt(TokenType.Question)) result = Scan.Type;

            // scan array flags
            while (null != EatOpt(TokenType.OpenSquare))
            {
                while (null != EatOpt(TokenType.Comma))
                {
                }

                if (null == EatOpt(TokenType.CloseSquare))
                {
                    return Scan.Nottype;
                }

                result = Scan.Type;
            }

            return result;
        }

        private VariableDeclarationNode ParseDeclaration()
        {
            return new VariableDeclarationNode(
                PeekToken(),
                new ParseNodeList(), // _attributes
                Modifiers.None,
                ParseType(),
                ParseFieldInitializers(false),
                false);
        }

        private VariableDeclarationNode ParseDeclarationStatement()
        {
            return new VariableDeclarationNode(
                PeekToken(),
                new ParseNodeList(), // _attributes
                Modifiers.None,
                ParseType(),
                ParseFieldInitializersStatement(false),
                false);
        }

        private ParseNode ParseExpression()
        {
            return ParseAssignment();
        }

        private ParseNode ParseConditional()
        {
            ParseNode condition = ParseBinaryExpression();

            if (null != EatOpt(TokenType.Question))
            {
                ParseNode left = ParseExpression();
                Eat(TokenType.Colon);
                ParseNode right = ParseExpression();

                return new ConditionalNode(condition, left, right);
            }

            return condition;
        }

        private TokenType PeekAssignmentOperator()
        {
            if (Token.IsAssignmentOperator(PeekType()))
            {
                return PeekType();
            }

            if (PeekType() == TokenType.Greater &&
                PeekType(1) == TokenType.GreaterEqual &&
                PeekToken().IsAdjacent(PeekToken(1)))
            {
                return TokenType.ShiftRightEqual;
            }

            return TokenType.Invalid;
        }

        private TokenType EatAssignmentOperator()
        {
            if (Token.IsAssignmentOperator(PeekType()))
            {
                return NextToken().Type;
            }

            Debug.Assert(PeekType() == TokenType.Greater &&
                         PeekType(1) == TokenType.GreaterEqual &&
                         PeekToken().IsAdjacent(PeekToken(1)));

            Eat(TokenType.Greater);
            Eat(TokenType.GreaterEqual);

            return TokenType.ShiftRightEqual;
        }

        private ParseNode ParseAssignment()
        {
            ParseNode left = ParseConditional();

            if (PeekAssignmentOperator() != TokenType.Invalid)
            {
                left = new BinaryExpressionNode(left, EatAssignmentOperator(), ParseAssignment());
            }

            return left;
        }

        private TokenType PeekOverloadableOperator()
        {
            TokenType result = PeekBinaryOperator();

            if (result == TokenType.Invalid)
            {
                if (Token.IsOverloadableOperator(PeekType()))
                {
                    result = PeekType();
                }
            }

            return result;
        }

        private TokenType EatOverloadableOperator()
        {
            TokenType operatorKind = PeekType();

            if (operatorKind == TokenType.Greater)
            {
                operatorKind = EatBinaryOperator();
            }
            else
            {
                if (Token.IsOverloadableOperator(operatorKind))
                {
                    NextToken();
                }
                else
                {
                    ReportError(ParseError.OverloadableOperatorExpected);

                    switch (operatorKind)
                    {
                        case TokenType.OpenParen:
                        case TokenType.OpenCurly:

                            break;

                        default:
                            NextToken();

                            break;
                    }
                }
            }

            return operatorKind;
        }

        private TokenType PeekBinaryOperator()
        {
            if (Token.IsBinaryOperator(PeekType()))
            {
                if (PeekType() == TokenType.Greater &&
                    PeekType(1) == TokenType.Greater &&
                    PeekToken().IsAdjacent(PeekToken(1)))
                {
                    return TokenType.ShiftRight;
                }

                if (PeekType() == TokenType.Greater &&
                    PeekType(1) == TokenType.GreaterEqual &&
                    PeekToken().IsAdjacent(PeekToken(1)))
                {
                    return TokenType.ShiftRightEqual;
                }

                return PeekType();
            }

            return TokenType.Invalid;
        }

        private int PeekBinaryOperatorPrecedence()
        {
            return Token.GetTokenPrecedence(PeekBinaryOperator());
        }

        private TokenType EatBinaryOperator()
        {
            Debug.Assert(Token.IsBinaryOperator(PeekType()));

            if (PeekType() == TokenType.Greater &&
                PeekType(1) == TokenType.Greater &&
                PeekToken().IsAdjacent(PeekToken(1)))
            {
                Eat(TokenType.Greater);
                Eat(TokenType.Greater);

                return TokenType.ShiftRight;
            }

            if (PeekType() == TokenType.Greater &&
                PeekType(1) == TokenType.GreaterEqual &&
                PeekToken().IsAdjacent(PeekToken(1)))
            {
                Eat(TokenType.Greater);
                Eat(TokenType.GreaterEqual);

                return TokenType.ShiftRightEqual;
            }

            return NextToken().Type;
        }

        private ParseNode ParseBinaryExpression()
        {
            return ParseBinaryExpression(int.MaxValue - 1);
        }

        private ParseNode ParseBinaryExpression(int precedence)
        {
            return ParseBinaryExpression(precedence, ParseUnaryExpression());
        }

        private ParseNode ParseBinaryExpression(int precedence, ParseNode left)
        {
            int newPrecedence;

            while ((newPrecedence = PeekBinaryOperatorPrecedence()) <= precedence)
            {
                TokenType op = EatBinaryOperator();
                ParseNode right;

                if (op == TokenType.Is || op == TokenType.As)
                {
                    right = ParseType();
                }
                else
                {
                    right = ParseBinaryExpression(newPrecedence - 1);
                }

                left = new BinaryExpressionNode(
                    left,
                    op,
                    right);
            }

            return left;
        }

        private ParseNode ParseUnaryExpression()
        {
            switch (PeekType())
            {
                case TokenType.Plus:
                case TokenType.Minus:
                case TokenType.Bang:
                case TokenType.Tilde:
                case TokenType.PlusPlus:
                case TokenType.MinusMinus:
                case TokenType.Star:
                case TokenType.Ampersand:

                    return new UnaryExpressionNode(NextToken(), ParseUnaryExpression());

                case TokenType.OpenParen:

                    // check for cast expression
                    if (ScanCast())
                    {
                        return ParseCastExpression();
                    }

                    break;
            }

            // must be a primary expression
            return ParsePrimaryExpression();
        }

        private bool ScanCast()
        {
            int mark = Mark();
            bool returnValue;

            NextToken();
            Scan scan = ScanType();

            if (scan == Scan.Nottype)
            {
                returnValue = false;
            }
            else if (PeekType() != TokenType.CloseParen)
            {
                returnValue = false;
            }
            else
            {
                switch (scan)
                {
                    case Scan.Type:
                    case Scan.PointerOrMult:
                        returnValue = true;

                        break;

                    case Scan.CouldBeType:
                    default:
                        TokenType type = PeekType(1);

                        switch (type)
                        {
                            case TokenType.Tilde:
                            case TokenType.Bang:
                            case TokenType.OpenParen:
                            case TokenType.Identifier:
                            case TokenType.Literal:
                                returnValue = true;

                                break;

                            case TokenType.Is:
                            case TokenType.As:
                                returnValue = false;

                                break;

                            default:
                                returnValue = Token.IsKeyword(type);

                                break;
                        }

                        break;
                }
            }

            Rewind(mark);

            return returnValue;
        }

        private ParseNode ParseCastExpression()
        {
            Token token = Eat(TokenType.OpenParen);
            ParseNode type = ParseType();
            Eat(TokenType.CloseParen);

            return new CastNode(token, type, ParseUnaryExpression());
        }

        private ParseNode ParsePrimaryExpression()
        {
            ParseNode expr;

            switch (PeekType())
            {
                case TokenType.Null:
                case TokenType.True:
                case TokenType.False:
                case TokenType.Literal:
                case TokenType.Default:
                    expr = new LiteralNode(NextToken());

                    break;

                case TokenType.OpenParen:
                    Eat(TokenType.OpenParen);
                    expr = ParseExpression();

                    if (expr is ExpressionNode)
                    {
                        ((ExpressionNode) expr).AddParenthesisHint();
                    }

                    Eat(TokenType.CloseParen);

                    break;

                case TokenType.New:
                    expr = ParseNew();

                    break;

                case TokenType.Typeof:
                {
                    Token token = NextToken();
                    Eat(TokenType.OpenParen);
                    expr = new TypeofNode(token, ParseReturnType());
                    Eat(TokenType.CloseParen);

                    break;
                }

                case TokenType.Sizeof:
                {
                    Token token = NextToken();
                    Eat(TokenType.OpenParen);
                    expr = new SizeofNode(token, ParseType());
                    Eat(TokenType.CloseParen);

                    break;
                }

                case TokenType.Checked:
                case TokenType.Unchecked:
                {
                    Token token = NextToken();
                    Eat(TokenType.OpenParen);
                    expr = new UnaryExpressionNode(token, ParseExpression());
                    Eat(TokenType.CloseParen);

                    break;
                }

                case TokenType.This:
                    expr = new ThisNode(NextToken());

                    break;

                case TokenType.Base:
                    expr = new BaseNode(NextToken());

                    if (PeekType() != TokenType.Dot && PeekType() != TokenType.OpenSquare)
                    {
                        ReportError(ParseError.BadBaseExpression);
                    }

                    break;

                case TokenType.Identifier:
                    expr = ParseAliasQualifiedName(true);

                    break;

                case TokenType.Delegate:
                    expr = ParseAnonymousMethod();

                    break;

                default:

                    if (Token.IsPredefinedType(PeekType()) && PeekType() != TokenType.Void)
                    {
                        expr = ParsePredefinedType();
                        CheckType(TokenType.Dot);
                    }
                    else
                    {
                        ReportError(ParseError.ExpressionExpected);
                        expr = ParseIdentifier();
                    }

                    break;
            }

            // postfix operators
            bool foundPostfix = true;

            do
            {
                Token token = PeekToken();

                switch (PeekType())
                {
                    case TokenType.Dot:

                        if (PeekType(1) == TokenType.Default)
                        {
                            expr = new DefaultValueNode(expr);
                            Eat(TokenType.Dot);
                            Eat(TokenType.Default);
                        }
                        else
                        {
                            expr = new BinaryExpressionNode(expr, NextToken().Type, ParseSimpleName(true));
                        }

                        break;

                    case TokenType.OpenParen:
                        expr = new BinaryExpressionNode(expr, token.Type, ParseParenArgumentList());

                        break;

                    case TokenType.PlusPlus:
                    case TokenType.MinusMinus:
                        expr = new BinaryExpressionNode(expr, NextToken().Type, null);

                        break;

                    case TokenType.OpenSquare:
                        expr = new BinaryExpressionNode(expr, NextToken().Type,
                            ParseExpressionList(TokenType.CloseSquare));
                        Eat(TokenType.CloseSquare);

                        break;

                    case TokenType.Arrow:
                        expr = new BinaryExpressionNode(expr, NextToken().Type, ParseIdentifier());

                        break;

                    default:
                        foundPostfix = false;

                        break;
                }
            } while (foundPostfix);

            return expr;
        }

        private ParseNode ParseNew()
        {
            Token token = Eat(TokenType.New);
            ParseNode type = ParseNonArrayType();

            if (TokenType.OpenSquare == PeekType())
            {
                bool needArrayInit;
                ParseNode exprList;

                if (PeekType(1) == TokenType.CloseSquare || PeekType(1) == TokenType.Comma)
                {
                    type = ParseArrayRanks(type);
                    needArrayInit = true;
                    exprList = null;
                }
                else
                {
                    Eat(TokenType.OpenSquare);
                    exprList = ParseExpressionList(TokenType.CloseSquare);
                    Eat(TokenType.CloseSquare);

                    if (TokenType.OpenSquare == PeekType() &&
                        (PeekType(1) == TokenType.CloseSquare || PeekType(1) == TokenType.Comma))
                    {
                        type = ParseArrayRanks(type);
                    }

                    needArrayInit = false;
                }

                ParseNode initExpr;

                if (needArrayInit || PeekType() == TokenType.OpenCurly)
                {
                    initExpr = ParseArrayInitializer();
                }
                else
                {
                    initExpr = null;
                }

                return new ArrayNewNode(token, type, exprList, initExpr);
            }

            var typeInitialiser = new NewNode(token, type, ParseParenArgumentList());
            if(PeekType() == TokenType.OpenCurly)
            {
                NextToken();

                ParseNodeList objectAssignmentExpressions = new ParseNodeList();
                while (PeekType() != TokenType.CloseCurly && PeekType() != TokenType.Eof)
                {
                    objectAssignmentExpressions.Append(ParseExpression());

                    if (null == EatOpt(TokenType.Comma))
                    {
                        break;
                    }
                }

                Eat(TokenType.CloseCurly);
                return new ObjectInitializerNode(token, typeInitialiser, objectAssignmentExpressions);
            }

            return typeInitialiser;
        }

        private ArrayInitializerNode ParseArrayInitializer()
        {
            Token token = Eat(TokenType.OpenCurly);

            ParseNodeList list = new ParseNodeList();

            while (PeekType() != TokenType.CloseCurly && PeekType() != TokenType.Eof)
            {
                if (PeekType() == TokenType.OpenCurly)
                {
                    list.Append(ParseArrayInitializer());
                }
                else
                {
                    list.Append(ParseExpression());
                }

                if (null == EatOpt(TokenType.Comma))
                {
                    break;
                }
            }

            Eat(TokenType.CloseCurly);

            return new ArrayInitializerNode(token, list);
        }

        private ExpressionListNode ParseParenArgumentList()
        {
            Token token = PeekToken();

            ParseNodeList list = new ParseNodeList();
            if(PeekType() == TokenType.OpenParen)
            {
                Eat(TokenType.OpenParen);

                while (PeekType() != TokenType.CloseParen)
                {
                    list.Append(ParseArgument());

                    if (null == EatOpt(TokenType.Comma))
                    {
                        break;
                    }
                }

                Eat(TokenType.CloseParen);
            }

            return new ExpressionListNode(token, list);
        }

        private ParseNode ParseArgument()
        {
            if (PeekType() == TokenType.Ref || PeekType() == TokenType.Out)
            {
                return new UnaryExpressionNode(NextToken(), ParseExpression());
            }

            return ParseExpression();
        }

        private AnonymousMethodNode ParseAnonymousMethod()
        {
            return new AnonymousMethodNode(
                Eat(TokenType.Delegate),
                PeekType() == TokenType.OpenParen ? ParseParensFormalParameterList(false) : new ParseNodeList(),
                ParseBlock());
        }

        private enum TypeArgumentListScan
        {
            MustBeTypeArgumentList,
            MayBeTypeArgumentList,
            TypeParameterList,
            NotTypeArgumentList
        }

        private enum ScanMemberNameKind
        {
            Invalid,
            Method,
            Property,
            Indexer,
            Field,
            Operator
        }

        private enum Scan
        {
            Type,
            CouldBeType,
            PointerOrMult,
            Nottype
        }
    }
}
