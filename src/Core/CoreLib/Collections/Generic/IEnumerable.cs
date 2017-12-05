// IEnumerable.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Collections.Generic {

    [ScriptImport]
    [ScriptName("IEnumerable")]
    public interface IEnumerable<T> : IEnumerable {

        new IEnumerator<T> GetEnumerator();
    }
}
