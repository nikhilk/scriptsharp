using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]


namespace ValidationTests {

    public class Test {

        public void Foo() {
            try {
            }
            catch (Exception e) {
            }
            catch (Object o) {
            }
            finally {
            }
        }

        public void Foo2() {
            try {
            }
            catch (Exception e) {
                throw;
            }
            finally {
            }
        }

        public void Foo3() {
            try {
            }
            catch (Exception) {
            }
            finally {
            }
        }

        public void Foo4() {
            try {
            }
            catch {
            }
            finally {
            }
        }
    }
}
