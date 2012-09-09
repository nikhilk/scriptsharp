using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("")]

namespace Library3 {

    [Imported]
    [ScriptDependency("comp3")]
    public class Component3 {

        public Component3() {
        }
    }

    [Imported]
    [ScriptDependency("comp4")]
    [IgnoreNamespace]
    public class Component4 {

        public Component4() {
        }
    }
}
