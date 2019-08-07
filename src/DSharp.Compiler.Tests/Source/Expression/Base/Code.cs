using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class Foo {

        public Foo(int i, int j) {
        }

        public override string ToString() {
            return "Foo";
        }

        public virtual int Sum(int i) {
            return 0;
        }
    }

    public class Bar : Foo {

        public Bar(int i, int j, Foo f) : base(i, j) {
        }

        public override int Sum() {
            return base.Sum(1) + 1;
        }

        public override string ToString() {
            return base.ToString() + " -> Bar";
        }
    }
}
