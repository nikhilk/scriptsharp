using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]


namespace ValidationTests {

    public class App {

        public static void M1() {
            int ss = 1;
        }
        
        public static void M2() {
            int instanceof = 1;
        }

        public static void M3() {
            int arguments = 1;
        }
    }
}
