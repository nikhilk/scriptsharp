using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        private int Foo { get { return 0; } }

        public void Test(object x) {
            Type t = x.GetType();
            Type t2 = x.ToString().GetType();
            Type t3 = Foo.GetType();

            Type t4 = Type.GetType("String");
            Type t5 = Type.GetType("test.Foo");

            bool b1 = typeof(Object).IsAssignableFrom(typeof(App));
            bool b2 = typeof(IDisposable).IsAssignableFrom(typeof(App));
            bool b3 = t.IsAssignableFrom(typeof(App));

            bool b4 = typeof(App).IsInstanceOfType(new App());
            bool b5 = typeof(IDisposable).IsInstanceOfType(new App());
            bool b6 = t.IsInstanceOfType(new App());

            bool b7 = Type.IsInterface(t) || Type.IsClass(t);

            string n = t.Name;
        }
    }
}
