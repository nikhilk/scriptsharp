// SqlError.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    public delegate bool SqlErrorCallback(SqlError error);

    [IgnoreNamespace]
    [Imported]
    public sealed class SqlError {

        private SqlError() {
        }

        [IntrinsicProperty]
        public int Code {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public string Message {
            get {
                return null;
            }
        }
    }
}
