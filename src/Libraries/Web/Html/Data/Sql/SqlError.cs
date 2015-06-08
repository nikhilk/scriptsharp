// SqlError.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.Sql {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class SqlError {

        private SqlError() {
        }

        [ScriptField]
        public int Code {
            get {
                return 0;
            }
        }

        [ScriptField]
        public string Message {
            get {
                return null;
            }
        }
    }

    public delegate bool SqlErrorCallback(SqlError error);
}
