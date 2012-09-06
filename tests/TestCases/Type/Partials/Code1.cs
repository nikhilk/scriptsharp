using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]
[assembly: ScriptNamespace("test")]

namespace TypeTests {

    public partial class EmptyClass {
    }

    partial class EmptyClass {
    }

    partial class SingleMemberClass {
    }

    internal partial class SingleMemberClass {
        public bool Run() {
        }
    }

    public class DerivedMemberClass : SingleMemberClass {
    }

    public partial class MergedMembersClass {
        public bool Foo;
    }

    public partial class MergedMembersClass {
        public string Bar;

        public virtual string TestMethod() { return null; }
    }

    public partial class DerivedMergedMembersClass : MergedMembersClass {
        public string Name;
    }

    public partial class DerivedMergedMembersClass {
        public string Value;

        public override string TestMethod() { return null; }

        public string TestMethod2() {
            return this["foo"];
        }
    }

    public interface IMyInterface {
        void Start();
        [PreserveCase]
        void Stop();
        void Resume();
    }

    public partial class MyClass : IMyInterface {
        public void Start() {
        }

        public void Stop() {
        }
    }

    partial class ImportedClass {
        public void Run() {
        }
    }


    public partial class MyClass {
        [PreserveCase]
        public void Resume() {
        }
    }

    [Imported]
    internal partial class ImportedClass {
    }

    partial class SomeClass {
        public bool Close() {
	}

        private void Cancel() {
        }
    }

    internal partial class SomeClass {
        public bool Run() {
        }
    }

    public class App {

        public App() {
            SingleMemberClass s;
            s.Run();

            DerivedMergedMembersClass d;
            d.Bar = d.Name;
            d.Value = d.Foo;

            MyClass mc;
            mc.Start();
            mc.Stop();
            mc.Resume();
        }
    }
}
