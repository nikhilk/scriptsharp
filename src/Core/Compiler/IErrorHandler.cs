// IErrorHandler.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp {

    public interface IErrorHandler {

        void ReportError(string errorMessage, string location);
    }
}
