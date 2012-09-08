// TodoItem.cs
//

using System;
using System.Runtime.CompilerServices;

namespace Todo {

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    internal sealed class TodoItem {

        public bool Completed;

        [ScriptName("id")]
        public string ID;

        public string Title;
    }
}
