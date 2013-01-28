// FileInputElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.

using System.Html.Data.FileAccess;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("InputElement")]
    public class FileInputElement : InputElement {

        protected internal FileInputElement() {
        }
   
        [ScriptField]
        public FileList Files {
            get {
                return null;
            }
        }
    }
}