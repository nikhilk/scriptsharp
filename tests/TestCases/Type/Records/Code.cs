using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace TypeTests {

    [ScriptObject]
    public sealed class Point {
         public int x;
         public int y;

         public Point(int x, int y) {
             this.x = x;
             this.y = y;
         }
    }

    [ScriptObject]
    public sealed class Pair {
        public object first;
        public object second;
    }
}
