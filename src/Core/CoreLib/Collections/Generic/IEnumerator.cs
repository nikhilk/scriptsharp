// IEnumerator.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Collections.Generic {

    [ScriptImport]
    [ScriptName("IEnumerator")]
    public interface IEnumerator<T> {

        [ScriptField]
        T Current {
            get;
        }

        bool MoveNext();

        void Reset();
    }
}
