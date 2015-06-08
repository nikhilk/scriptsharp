// File.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Html.Data.Files {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class File : Blob {

        private File() {
        }

        [ScriptField]
        public Date LastModifiedDate {
            get {
                return Date.Now;
            }
        }

        [ScriptField]
        public String Name {
            get {
                return String.Empty;
            }
        }
    }
}
