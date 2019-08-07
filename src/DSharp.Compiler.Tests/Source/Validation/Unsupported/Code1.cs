using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]


namespace ValidationTests {

    public class Test : IDisposable {

        public Test() {
        }

        ~Test() {
        }

        public void Foo() {
            using (new Test()) {
            }
        }
    }

    public interface IBase {
    }

    public interface IFoo : IBase {
    }
}
