// Export.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System {

    [Imported]
    [IgnoreNamespace]
    public sealed class Export : IDisposable {

        private Export() {
        }

        [IntrinsicProperty]
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
