// MapEntityCollectionEventArgs.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Html;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    // TODO: Make properties

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class MapEntityCollectionEventArgs : MapEventArgs {

        private MapEntityCollectionEventArgs() {
        }

        public MapEntityCollection Collection;
        public MapEntity Entity;
    }
}
