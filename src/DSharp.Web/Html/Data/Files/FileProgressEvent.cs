// FileProgressEvent.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Html.Data.Files {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class FileProgressEvent : ElementEvent {

        private FileProgressEvent() {
        }

        public bool DefaultPrevented;
        public bool LengthComputable;

        public int EventPhase;
        public int Loaded;
        public int Total;

        public object ClipboardData;
    }
}
