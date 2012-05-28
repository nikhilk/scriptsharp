using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]
[assembly: ScriptNamespace("test")]

namespace ValidationTests {

    public abstract class Test {

        [AlternateSignature]
        public static extern void DoSomething();

        [AlternateSignature]
        public extern void Invoke(Action successCallback);

        [AlternateSignature]
        public extern void Invoke(Action successCallback, Action errorCallback);

        public static void Invoke(Action successCallback, Action errorCallback, object context) {
        }
    }
}
