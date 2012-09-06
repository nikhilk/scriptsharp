// IParseNodeHandler.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.CodeModel {

    internal interface IParseNodeHandler {

        bool RequiresChildrenGrouping {
            get;
        }

        bool HandleNode(ParseNode node, object context);

        void StartChildren(string identifier);

        void EndChildren();
    }
}
