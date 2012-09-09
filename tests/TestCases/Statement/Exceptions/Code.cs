using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace StatementTests {

    public class App {

        public void Test(string arg) {
            if (arg == null) {
                throw new Exception("null");
            }
        }

        public void Test2() {
            try {
            }
            catch (Exception e) {
            }

            try {
            }
            catch (Exception e) {
            }
            finally {
            }

            try {
            }
            finally {
            }

            try {
            }
            catch {
            }

            try {
            }
            catch {
            }
        }
    }
}
