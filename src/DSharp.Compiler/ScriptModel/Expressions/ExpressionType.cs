// ExpressionType.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.ScriptModel.Expressions
{
    internal enum ExpressionType
    {
        Literal = 0,
        Local = 1,
        Member = 2,
        Field = 3,
        EnumerationField = 4,
        PropertyGet = 5,
        PropertySet = 6,
        MethodInvoke = 7,
        DelegateInvoke = 8,
        BaseInitializer = 9,
        EventAdd = 10,
        EventRemove = 11,
        Indexer = 12,
        This = 13,
        Base = 14,
        New = 15,
        Unary = 16,
        Binary = 17,
        Conditional = 18,
        Type = 19,
        Delegate = 20,
        LateBound = 21,
        InlineScript = 22,
        NewDelegate = 23,
        Object = 24,
        ObjectInitializer = 25
    }
}
