// IEnumerator.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Collections {

    [ScriptImport]
    public interface IEnumerator {

        [ScriptField]
        object Current {
            get;
        }

        bool MoveNext();

        void Reset();
    }
}
