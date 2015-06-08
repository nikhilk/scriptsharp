using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace BasicTests {

    public static class MyDebug {

        [Conditional("DEBUG")]
        public static void ShowInfo() {
        }

        [Conditional("TRACE")]
        public static void TraceInfo() {
        }

        [Conditional("RETAIL")]
        public static void LogInfo() {
        }
    }

    public class App {

        public App(int i) {
            Debug.Assert(false);
            MyDebug.ShowInfo();

            while (true) {
                Debug.Assert(false);
            }

            switch (i) {
                case 0:
                    Debug.Assert(false);
                    break;
            }

            {
                Debug.Assert(i != 0);
            }

            {
                Debug.Assert(i != 0);
                i++;
            }
            
            if (false)
                Debug.WriteLine("Debug spew");
                
            while (false)
                Debug.WriteLine(".");

            for (int i = 0; i < 10; i++)
                Debug.WriteLine(".");

            MyDebug.TraceInfo();

            MyDebug.LogInfo();
        }
    }
}
