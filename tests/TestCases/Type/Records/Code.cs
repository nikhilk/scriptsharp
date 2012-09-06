using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]
[assembly: ScriptNamespace("test")]

namespace TypeTests {

    public sealed class Point : Record {
         public int x;
         public int y;

         public Point(int x, int y) {
             this.x = x;
             this.y = y;
         }
    }

    public sealed class Pair : Record {
        public object first;
        public object second;
    }
}
