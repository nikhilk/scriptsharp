// Enum.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System {

    [ScriptImport]
    public abstract class Enum : ValueType {
        
        [ScriptAlias("ss.enumgetname")]
        public static string GetName(Type enumType, object value) {
            return null;
        }
    }
}
