using System;
using System.Html;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

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

    public sealed class MyClassEmpty {

        static MyClassEmpty() {
        }
    }

    public sealed class MyClassSimple {

        static MyClassSimple() {
            Window.Alert("simple static ctor");
        }
    }

    public sealed class MyClassSimpleMulti {

        static MyClassSimpleMulti() {
            Window.Alert("simple static ctor with multiple statements");
            Document.GetElementById("foo").InnerHTML = "...";
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
