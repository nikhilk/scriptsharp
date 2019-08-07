using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class EventArgs {
    }

    public delegate void Foo();

    public delegate void EventHandler(object sender, EventArgs e);

    public class SomeClass {

        public SomeClass(EventHandler handler) {
        }
    }

    public class Test {

        private EventHandler _handler;

        public Test() {
            _handler = OnEvent;
            _handler = new EventHandler(OnEvent);
            _handler = new EventHandler(this.OnEvent);
            _handler = new EventHandler(Test2.OnGlobalEvent);

            SomeClass s1 = new SomeClass(OnEvent);
            SomeClass s2 = new SomeClass(_handler);
        }

        public void DoStuff() {
            if (_handler != null) {
                _handler(this, null);
            }
        }

        public void OnEvent(object sender, EventArgs e) {
        }
    }

    public class Test2 {

        public static void OnGlobalEvent(object sender, EventArgs e) {
        }
    }
}
