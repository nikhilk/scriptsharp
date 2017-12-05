using System;
using System.Collections;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class Foo {

        public Foo(int i, int j) {
        }
    }

    public class Bar {

        public Bar(int i, int j, Foo f) {
        }
    }

    [ScriptObject]
    public sealed class Point {
         int x;
         int y;

         public Point(int x, int y) {
             this.x = x;
             this.y = y;
         }
    }

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public class CustomDictionary {
    
        public CustomDictionary() {
        }
        
        public CustomDictionary(params object[] nameValueList) {
        }
    }

    public class Test {

        public static void Main() {
            Foo f = new Foo(0, 1);
            Bar b = new Bar(0, 1, new Foo(0, 1));
            Test t = new Test();
            Date d = new Date("3/9/1976");
            int[] items = new Array();
            int[] items2 = new int[] { 1, 2 };
            int[] items3 = { 4, 5 };
            int[] items4 = new int[5];
            ArrayList list = new ArrayList();
            ArrayList list2 = new ArrayList(5);
            ArrayList list3 = new ArrayList("abc", "def", "ghi");
            ArrayList list4 = new ArrayList(1, 2, 3);
            Date[] dates = new Date[] {
                             new Date("1/1/2006"),
                             new Date("1/1/2005") };

            Point p = new Point(0, 0);

            CustomDictionary cd = new CustomDictionary();
            CustomDictionary cd2 = new CustomDictionary("abc", 123, "def", true);

            object o1 = Script.CreateInstance(typeof(Test));

            Type type1 = typeof(Foo);
            object o2 = Script.CreateInstance(type1, 1, 2);
            object o3 = Script.CreateInstance(typeof(Bar), 1, 2, (Foo)o2);

            Function f1 = new Function("alert('hello');");
            Function f2 = new Function("alert(s);", "s");
            Function f3 = new Function("alert(greeting + ' ' + name + '!');", "greeting", "name");
        }
    }
}
