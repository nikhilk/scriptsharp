// SqlError.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
