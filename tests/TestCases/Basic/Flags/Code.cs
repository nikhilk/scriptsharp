using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace BasicTests {

    public class App {

        public void Method1(int i) {
#if ABC
		int j = i;
#else
		int j = 10;
#endif

		int x = j++;
        }

        public void Method2(int i) {
#if !ABC
		int j = i;
#else
		int j = 10;
#endif

		int x = j++;
        }
    }
}
