// Observable.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.ComponentModel {

    [Imported]
    [ScriptNamespace("ss")]
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
