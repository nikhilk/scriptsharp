using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace TypeTests {

    public class MyObject : IDisposable {

        public void Dispose() {
        }
    }

    public interface IMarker {
        string this[string key] { get; set; }
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
        private Dictionary<string, string> someValues = new Dictionary<string, string>();

        public string this[string key]
        {
            get { return someValues[key]; }
            set { someValues[key] = value; }
        }

        public bool canRun { get { return true; } }

        public void run() { }

        public object serialize() { return null; }

        public void Dispose() { }
    }

    public class Program
    {
        public void useInterfaces(IRunnable runnable)
        {
            runnable.Dispose();

            IEnumerable<string> s = new List<string>();
            s.GetEnumerator();

            string someValue = new Foo()["someValuesKey"];
        }
    }
}
