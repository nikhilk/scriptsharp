using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]


namespace ValidationTests {

    public abstract class Test {

        public static extern void DoSomething();

        public extern void Invoke(Action successCallback);

        public extern void Invoke(Action successCallback, Action errorCallback);

        public static void Invoke(Action successCallback, Action errorCallback, object context) {
        }
    }
}
