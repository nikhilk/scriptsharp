using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]
[assembly: ScriptNamespace("test")]

namespace ValidationTests {

    public class Foo {

        public Foo(int i, int j) {
        }
    }

    public class Bar {

        public Bar() {
        }
    }

    public class Test {
    
        private static Type GetObjectType() {
            return typeof(Foo);
        }

        private static Type OtherObjectType {
            get {
                return typeof(Bar);
            }
        }

        public static void Main() {
            object o1 = Type.CreateInstance(typeof(Bar));
            object o2 = Type.CreateInstance(typeof(Foo), 0, 0);

            object o3 = Type.CreateInstance(GetObjectType(), 1, 1);
            object o4 = Type.CreateInstance(OtherObjectType);
        }
    }
}
