// ElementType.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    [NumericValues]
    public enum ElementType {

        Element = 1,

        Attribute = 2,

        Text = 3,

        CharacterData = 4,

        EntityReference = 5,

        Entity = 6,

        ProcessingInstruction = 7,

        Comment = 8,

        Document = 9,

        DocumentType = 10,

        DocumentFragment = 11,

        Notation = 12
    }
}
