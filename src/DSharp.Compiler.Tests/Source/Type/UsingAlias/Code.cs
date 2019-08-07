using System;
using System.Html;
using HtmlElement = System.Html.Element;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace TypeTests {

    public class MyClass {

        public MyClass() {
            HtmlElement body = Document.Body;
            HtmlElement head = Document.GetElementsByTagName("head")[0];
            head.AppendChild(body);
        }
    }
}
