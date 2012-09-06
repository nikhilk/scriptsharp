using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]
[assembly: ScriptNamespace("test")]

namespace MemberTests {

    public delegate void Callback();
    
    public abstract class Test {

        [AlternateSignature]
        public extern Test();

        public Test(string name) {
        }

        [AlternateSignature]
        public static extern void DoSomething();

        public static void DoSomething(object o) {
        }

        [AlternateSignature]
        public extern void Invoke(Callback successCallback);

        [AlternateSignature]
        public extern void Invoke(Callback successCallback, Callback errorCallback);

        public void Invoke(Callback successCallback, Callback errorCallback, object context) {
        }
    }

    public class App {

        public App() {
            Test.DoSomething();
            Test.DoSomething(null);

            Test t1 = new Test();
            Test t2 = new Test("test");
            Callback cb1 = null;
            Callback cb2 = null;

            t1.Invoke(cb1);
            t1.Invoke(cb1, cb2);
            t2.Invoke(cb1, cb2, t1);
        }
    }
}
