// $safeitemrootname$.cs
//

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Html;
using System.Testing;

namespace $rootnamespace$
{
    [SuppressMessage("Microsoft.Performance", "CA1812",
                     Justification = "Tests don't have internal consumers. They're only compiled into .test.js scripts.")]
    internal sealed class $safeitemrootname$ : TestClass
    {
        public void TestMethod1()
        {
            // TODO: Uncomment and specify n to indicate the number of
            //       asserts that will be invoked.
            // Assert.ExpectAsserts(n);
        }

        public void TestMethod2()
        {
            // TODO: Uncomment and specify n to indicate the number of
            //       asserts that will be invoked.
            // Assert.ExpectAsserts(n);

            // TODO: Start async work

            TestEngine.WaitForAsyncCompletion();

            // TODO: From within the async callback
            // TestEngine.ResumeOnAsyncCompleted();
        }
    }
}
