// FileList.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Html.Data.Files {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class FileList {

        private FileList() {
        }

        [ScriptField]
        public long Length {
            get {
                return 0;
            }
        }

        [ScriptField]
        public File this[int index] {
            get {
                return null;
            }
        }
    }
}
