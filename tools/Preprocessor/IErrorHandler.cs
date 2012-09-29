// IErrorHandler.cs
// Script#/Tools/Preprocessor
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp {

    internal interface IErrorHandler {

        void ReportError(string errorMessage, string location);
    }
}
