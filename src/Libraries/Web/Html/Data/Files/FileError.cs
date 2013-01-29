// FileError.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Html.Data.Files {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class FileError {

        private FileError() {
        }

        [ScriptField]
        public string Name {
            get {
                return String.Empty;
            }
        }
    }
}
