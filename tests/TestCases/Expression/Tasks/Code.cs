using System;
using System.Runtime.CompilerServices;
using System.Threading;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class Test {

        private EventHandler _handler;

        public Test() {
            Deferred deferredObject = Deferred.Create();
            Deferred<int> deferredNumber = Deferred.Create<int>();
            Deferred<int> availabledNumber = Deferred.Create<int>(10);

            deferredNumber.Reject();
        }
    }
}
