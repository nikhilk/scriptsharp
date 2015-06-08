// WineResults.cs
//

using System;
using System.Runtime.CompilerServices;

namespace Cellar.DataModels {

    [ScriptImport]
    [ScriptObject]
    public sealed class WineResults {

        public int Count;
        public Wine[] Wines;
    }
}
