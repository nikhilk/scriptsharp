using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace TypeTests {

    public class MyObject : IDisposable {

        public void dispose() {
        }
    }

    public interface IMarker {
    }

    public interface ISerializable {

        object serialize();
    }

    public interface IRunnable : IMarker, IDisposable {

        bool canRun { get; }

        void run();
    }

    public class MyObject2 : MyObject, IRunnable {

        public bool canRun { get { return true; } }

        public void run() { }
    }

    public class Foo : IMarker, ISerializable, IRunnable {

        public bool canRun { get { return true; } }

        public void run() { }

        public object serialize() { return null; }

        public void dispose() { }
    }
}
