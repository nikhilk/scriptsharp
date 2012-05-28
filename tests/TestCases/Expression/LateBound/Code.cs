using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]
[assembly: ScriptNamespace("test")]

namespace ExpressionTests {

    public class App {

        public void Test(string arg) {
            Object o;
            bool b;

            Type.InvokeMethod(o, arg);
            Type.InvokeMethod(o, "xyz");
            Type.InvokeMethod(o, "Proxy-Connection");
            Type.InvokeMethod(o, "xyz", 0);
            Type.InvokeMethod(o, "xyz", 0, arg);

            b = Type.HasMethod(o, arg);
            b = Type.HasMethod(o, "xyz");
            b = Type.HasMethod(typeof(Object), "xyz");            

            Type.SetField(o, arg, 0);
            Type.SetField(o, "abc", 0);
            Type.SetField(o, "Proxy-Connection", 0);

            object v = Type.GetField(o, arg);
            v = Type.GetField(o, "abc");
            v = Type.GetField(o, "Proxy-Connection");

            b = Type.HasField(o, arg);
            b = Type.HasField(o, "abc");
            b = Type.HasField(typeof(Object), "abc");

            Type.SetProperty(o, arg, 0);
            Type.SetProperty(o, "def", 0);
            Type.SetProperty(o, "Proxy-Connection", 0);

            object v2 = Type.GetProperty(o, arg);
            v2 = Type.GetProperty(o, "def");
            v2 = Type.GetProperty(o, "Proxy-Connection");

            b = Type.HasProperty(o, arg);
            b = Type.HasProperty(o, "def");
            b = Type.HasProperty(typeof(Object), "def");

            Delegate handler;
            Type.AddHandler(o, arg, handler);
            Type.AddHandler(o, "mmm", handler);
            Type.AddHandler(o, "Proxy-Connection", handler);

            Type.RemoveHandler(o, arg, handler);
            Type.RemoveHandler(o, "mmm", handler);
            Type.RemoveHandler(o, "Proxy-Connection", handler);

            Type.DeleteField(o, "xyz");
            Type.DeleteField(o, "Proxy-Connection");
            Type.DeleteField(o, arg);
            
            Type t = Type.GetScriptType(o);

            if (Type.GetScriptType(o) == "object") {
            }

            if (Type.HasMethod(o, "execute")) {
            }

            Type.InvokeMethod(null, "globalMethod");
            Type.InvokeMethod(null, "globalMethod", "xyz");
        }
    }
}
