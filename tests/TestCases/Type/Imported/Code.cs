using System;
using System.Html;
using System.Runtime.CompilerServices;
using System.Xml;

[assembly: ScriptAssembly("test")]

namespace TypeTests {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class MyElement : Element {

        private MyElement() { }

        [ScriptField]
        public string myString {
            get { return null; }
            set { }
        }

        [ScriptField]
        public string this[string name] {
            get { return null; }
            set { }
        }

        [ScriptMethod("foo")]
        [ScriptName("do")]
        public void DoFoo() {
        }

        [ScriptMethod("bar")]
        [ScriptName("do")]
        public void DoBar(int n) {
        }

        [ScriptEvent("addEventListener", "removeEventListener")]
        public event Action Click {
            add { }
            remove { }
        }
    }

    public class App {

        public App() {
            MyElement elem = (MyElement)Document.GetElementById("foo");
            string s = elem.myString;
            elem.DoFoo();
            elem.DoBar(10);

            elem["Smith"] = elem["Joe"];

            int n = Math.Truncate(5.5);
            XmlDocumentParser parser = new XmlDocumentParser();
            XmlDocument doc = parser.ParseFromString("<markup></markup>", "text/xml");
            Date d = Date.Parse("1/1/2010");

            Action eventHandler = delegate() { };
            elem.Click += eventHandler;
            elem.Click -= eventHandler;
        }
    }
}
