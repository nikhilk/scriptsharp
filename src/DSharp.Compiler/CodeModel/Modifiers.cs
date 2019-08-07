// Modifiers.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace DSharp.Compiler.CodeModel
{
    /// <summary>
    ///     Modifiers for types and their _members.
    /// </summary>
    [Flags]
    internal enum Modifiers
    {
        None = 0x0000,

        Abstract = 0x0001,
        Sealed = 0x0002,

        Public = 0x0004,
        Internal = 0x0008,
        Private = 0x0010,
        Protected = 0x0020,
        AccessMask = Public | Internal | Protected | Private,

        New = 0x0040,
        Virtual = 0x0080,
        Static = 0x0100,
        Readonly = 0x0200,
        Extern = 0x0400,
        Override = 0x0800,
        Unsafe = 0x1000,
        Volatile = 0x2000,
        Partial = 0x4000,

        // valid flags by member type
        ClassModifiers = New | AccessMask | Abstract | Sealed | Static | Unsafe | Partial,
        ConstantModifiers = New | AccessMask | Unsafe,
        FieldModifiers = New | AccessMask | Static | Readonly | Unsafe | Volatile,
        MethodModifiers = New | AccessMask | Static | Virtual | Sealed | Override | Abstract | Extern | Unsafe,
        PropertyModifiers = New | AccessMask | Static | Virtual | Sealed | Override | Abstract | Extern | Unsafe,
        EventModifiers = New | AccessMask | Static | Virtual | Sealed | Override | Abstract | Extern | Unsafe,
        IndexerModifiers = New | AccessMask | Static | Virtual | Sealed | Override | Abstract | Extern | Unsafe,
        OperatorModifiers = Public | Static | Extern | Unsafe,
        ConstructorModifiers = AccessMask | Extern | Unsafe,
        StaticConstructorModifiers = Static | Extern | Unsafe,
        DestructorModifiers = Extern | Unsafe,
        StructModifiers = New | AccessMask | Unsafe | Partial,
        InterfaceModifiers = New | AccessMask | Unsafe | Partial,
        EnumModifiers = New | AccessMask,
        DelegateModifiers = New | AccessMask | Unsafe,
        PartialModifiers = AccessMask | Abstract | Sealed | Static
    }
}