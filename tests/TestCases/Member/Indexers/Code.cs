using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace MemberTests {

    public class Normal {

        private int n;

        public Normal() {
            int i = this["name"];
            this["name"] = i + 1;
        }

        private int this[string name] {
            get { return n; }
            set { n = value; }
        }
    }

    public class GetterOnly {

        private int n;

        public GetterOnly() {
            int i = this["name"];
        }

        private int this[string name] {
            get { return n; }
        }
    }

    public class VirtualIndexer {

        private int n;

        public VirtualIndexer() {
            int i = this["name"];
            this["name"] = i + 1;
        }

        protected virtual int this[string name] {
            get { return n; }
            set { n = value; }
        }
    }

    public class OverriddenIndexer : VirtualIndexer {

        public OverriddenIndexer() {
            int i = this["name"];
            this["name"] = i + 1;

            int j = base["name"];
            base["name"] = 43;
        }

        protected override int this[string name] {
            get { return base[name] + 1; }
            set { base[name] = value - 1; }
        }
    }

    public abstract class AbstractIndexer {

        private int n;

        public AbstractIndexer() {
            int i = this["name"];
            this["name"] = i + 1;
        }

        public abstract int this[string name] {
            get;
        }
    }

    public sealed class ImplementedIndexer : AbstractIndexer {

        private int n;

        public ImplementedIndexer() {
            int i = this["name"];
            this["name"] = i + 1;
        }

        public abstract int this[string name] {
            get {
                return n / 4;
            }
        }
    }

    public class MultipleArgs {

        private int n;

        public MultipleArgs() {
            int i = this["name", "name2", "name3"];
            this["name", "name2","name3"] = i + 1;
        }

        public int this[string first, string middle, string last] {
            get { string value = first + middle + last; return value.Length; }
            set { n = value; }
        }
    }

    public interface IIndexable {

        public object this[int index] {
            get;
        }
    }

    public class ImplementedIndexer2 : IIndexable {

        public object this[int index] {
            get { return 0; }
        }
    }

    public class Test {

        public Test() {

            MultipleArgs ma = new MultipleArgs();
            ma["1", "2", "3"] = ma["3", "2", "1"];

            ImplementedIndexer ii = new ImplementedIndexer();
            ii["big"] = ii["small"];

            AbstractIndexer ai = ii;
            ai["small"] = ai["big"];

            IIndexable indexable = new ImplementedIndexer2();
            object o = indexable[0];
        }
    }

    public class A {

        public virtual string this[string name] {
            get {
                return name;
            }
        }
    }

    public class B : A {
    }

    public class C : B {

        public static void Main() {
            C c = new C();
            c["a"] = c["b"];

            A a = c;
            a["b"] = a["c"];
        }

        public override string this[string name] {
            get {
                return name;
            }
        }
    }
}
