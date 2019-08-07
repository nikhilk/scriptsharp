using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("")]

namespace Library3 {

    [ScriptImport]
    [ScriptDependency("comp3")]
    public class Component3 {

        public Component3() {
        }
    }

    [ScriptImport]
    [ScriptDependency("comp4")]
    [ScriptIgnoreNamespace]
    public class Component4 {

        public Component4() {
        }
    }
}
