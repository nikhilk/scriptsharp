using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace StatementTests {

    public class App {

        public void TestMethod(bool boolValue, int numValue) {
            if (boolValue) {
            }

            if (boolValue) {
                boolValue = false;
            }

            if (boolValue) {
            }
            else {
            }

            if (numValue == 1) {
            }
            else if (numValue == 2) {
            }

            if (numValue == 1) {
            }
            else if (numValue == 2) {
            }
            else {
            }
        }
    }
}
