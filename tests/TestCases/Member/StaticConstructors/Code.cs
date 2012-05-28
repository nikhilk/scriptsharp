using System;
using System.Html;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]
[assembly: ScriptNamespace("test")]

namespace MemberTests {

    public abstract class Behavior {
    
        protected Behavior(Element e, string name) {
        }
    }

    public sealed class MyClass {

        public static readonly MyClass Instance;

        static MyClass() {
            Instance = new MyClass(Date.Now);
        }

        private MyClass(Date d) {
        }
    }

    public sealed class MyBehavior : Behavior {

        static MyBehavior() {
            Element e = Document.Body;

            bool b = true;

            if (!b) {
                return;
            }

            new MyBehavior(e);
        }

        private MyBehavior(Element element) : base(element, "myBehavior") {
        }
    }
}
