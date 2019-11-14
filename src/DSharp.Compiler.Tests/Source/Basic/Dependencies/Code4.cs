using System;
using System.Html;
using System.Runtime.CompilerServices;
using Library1;
using Library2;
using Library3;

[assembly: ScriptAssembly("test")]
[assembly: ScriptReference("comp3", Path = "/lib/comp3")]
[assembly: ScriptReference("comp4", DelayLoad = true)]

[assembly: ScriptReference("text!data.html", Identifier = "dataTemplate", IsExplicit = true)]
[assembly: ScriptReference("text!unused.html", Identifier = "nonUsed")]

namespace BasicTests {

    [ScriptImport]
    public static class Templates {

        [ScriptField]
        [ScriptAlias("dataTemplate")]
        public static string DataTemplate {
            get { return null; }
        }
    }

    public class App {

        public App() {
            Component1 c1 = new Component1();
            Component2 c2 = new Component2();
            Component3 c3 = new Component3();

            Window.Require("comp4", delegate() {
                Component4 c4 = new Component4();
            });

            Window.Alert(Templates.DataTemplate);
        }
    }
}
