// SqlError.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    public delegate bool SqlErrorCallback(SqlError error);

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class SqlError {

        private SqlError() {
        }

        [ScriptProperty]
        public int Code {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public string Message {
            get {
                return null;
            }
        }
    }
}
