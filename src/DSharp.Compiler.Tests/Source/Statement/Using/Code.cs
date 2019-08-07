using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace StatementTests {

    public class App: IDisposable {

        public void Dispose()
        {

        }

        public void Test() {
            using (IDisposable d = new App())
            {
                int a = 0;
                a++;
            }

            using (IDisposable d1 = new App(), d2 = new App())
            {
                int a = 0;
                a++;
            }
        }
    }
}
