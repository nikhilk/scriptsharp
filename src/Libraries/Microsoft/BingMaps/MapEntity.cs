// MapEntity.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    [Imported]
    public abstract class MapEntity {

        public object Data;

        public bool GetVisible() {
            return false;
        }
    }
}
