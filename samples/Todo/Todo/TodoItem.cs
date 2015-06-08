// TodoItem.cs
//

using System;
using System.Runtime.CompilerServices;

namespace Todo {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    internal sealed class TodoItem {

        public bool Completed;

        [ScriptName("id")]
        public string ID;

        public string Title;
    }
}
