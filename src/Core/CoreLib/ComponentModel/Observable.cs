// Observable.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.ComponentModel {

    [ScriptImport]
    [ScriptName("Observable")]
    public sealed class Observable<T> {

        public Observable() {
        }

        public Observable(T value) {
        }

        public T GetValue() {
            return default(T);
        }

        public void SetValue(T value) {
        }
    }
}
