using System;
using System.Diagnostics;
using System.Testing;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace BasicTests {

    public class PublicClass {

        public string Format(int i) { return "0"; }
        public int Parse(string s) { return 0; }
    }

    internal class InternalClass {

        public string Format(int i) { return null; }
        public int Parse(string s) { return 0; }
    }
}

namespace BasicTests.Tests {

    internal sealed class PublicTests : TestClass {

        public void TestFormat() {
            Assert.ExpectAsserts(1);

            PublicClass testee = new PublicClass();
            string s = testee.Format(0);
            Assert.AreEqual(s, "0", "Expected '0' for result.");
        }
    }

    internal sealed class InternalTests : TestClass {

        private Date _startTime;
        private Date _endTime;

        public void TestFormat() {
            Assert.ExpectAsserts(1);

            InternalClass testee = new InternalClass();
            string s = testee.Format(0);
            Assert.AreEqual(s, "0", "Expected '0' for result.");
        }

        public void TestParse() {
            Assert.ExpectAsserts(1);

            InternalClass testee = new InternalClass();
            int i = testee.Parse("0");
            Assert.AreEqual(i, 0, "Expected 0 for result.");
        }

        public override void Setup() {
            _startTime = Date.Now;
        }

        public override void Cleanup() {
            _endTime = Date.Now;
        }
    }
}

namespace BasicTests.Tests.Helpers {

    internal sealed class Foo {
    }
}
