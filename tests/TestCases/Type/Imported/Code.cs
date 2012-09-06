using System;
using System.Html;
using System.Runtime.CompilerServices;
using System.Xml;

[assembly: ScriptAssembly("test")]
[assembly: ScriptNamespace("test")]

namespace TypeTests {

    [IgnoreNamespace]
    [Imported]
    public sealed class MyElement : Element {

        private MyElement() { }

        [IntrinsicProperty]
        public string myString {
            get { return null; }
            set { }
        }

        [IntrinsicProperty]
        public string this[string name] {
            get { return null; }
            set { }
        }
    }

    public class App {

        public App() {
            MyElement elem = (MyElement)Document.GetElementById("foo");
            string s = elem.myString;

            elem["Smith"] = elem["Joe"];

            int n = Math.Truncate(5.5);
            XmlDocumentParser parser = new XmlDocumentParser();
            XmlDocument doc = parser.ParseFromString("<markup></markup>", "text/xml");
            Date d = Date.Parse("1/1/2010");
        }
    }
}
