// Blob.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Html.Data.Files {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class Blob {

        public Blob() {
        }

        public Blob(object blobParts) {
        }

        public Blob(object blobParts, object options) {
        }
        
        [CLSCompliant(false)]
        [ScriptField]
        public ulong Size {
            get {
                return 0;
            }
        }

        [ScriptField]
        public string Type {
            get {
                return String.Empty;
            }
        }

        public Blob Slice() {
            return null;
        }

        public Blob Slice(long start) {
            return null;
        }

        public Blob Slice(long start, long end) {
            return null;
        }

        public Blob Slice(long start, long end, string contentType) {
            return null;
        }
    }
}
