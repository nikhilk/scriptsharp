using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class App {

        public void Test(string arg) {
            Object o;
            bool b;

            Script.InvokeMethod(o, arg);
            Script.InvokeMethod(o, "xyz");
            Script.InvokeMethod(o, "Proxy-Connection");
            Script.InvokeMethod(o, "xyz", 0);
            Script.InvokeMethod(o, "xyz", 0, arg);

            b = Script.HasMethod(o, arg);
            b = Script.HasMethod(o, "xyz");
            b = Script.HasMethod(typeof(Object), "xyz");            

            Script.SetField(o, arg, 0);
            Script.SetField(o, "abc", 0);
            Script.SetField(o, "Proxy-Connection", 0);

            object v = Script.GetField(o, arg);
            v = Script.GetField(o, "abc");
            v = Script.GetField(o, "Proxy-Connection");

            b = Script.HasField(o, arg);
            b = Script.HasField(o, "abc");
            b = Script.HasField(typeof(Object), "abc");

            Script.DeleteField(o, "xyz");
            Script.DeleteField(o, "Proxy-Connection");
            Script.DeleteField(o, arg);
            
            Type t = Script.GetScriptType(o);

            if (Script.GetScriptType(o) == "object") {
            }

            if (Script.HasMethod(o, "execute")) {
            }

            Script.InvokeMethod(null, "globalMethod");
            Script.InvokeMethod(null, "globalMethod", "xyz");
        }
    }
}
