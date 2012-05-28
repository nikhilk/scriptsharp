using System;
using System.Html;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]
[assembly: ScriptNamespace("test")]

namespace BasicTests {

    public class App {

        public App() {
            Element e = Document.Body;
        }
    }
}
