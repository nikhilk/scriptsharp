// Export.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class Export : IDisposable {

        private Export() {
        }

        [ScriptField]
        public string Name {
            get {
                return null;
            }
        }

        public void Detach() {
        }

        public void Dispose() {
        }
    }
}
