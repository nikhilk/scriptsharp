using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public delegate void Foo(int i, string s, bool b);

    public delegate int Bar(int i);

    public delegate void Callback();

    public class SomeClass {

        public SomeClass(Callback cb) {
        }
    }

    public class Test {

        private int _n;

        public static void Main(string[] args) {
            object o = new object();
            string name;

            DoStuffStatic(o, delegate(int i, string s, bool b) {
                                 name = s;
                             });
        }

        public void AAA() {
            object o = new object();
            DoStuff(o, delegate(int i, string s, bool b) {
                   _n = i;
               });

            SomeClass s = new SomeClass(delegate { });

            for (int i = 0; i < 10; i++) {
                object foo;

                DoStuff(o, delegate(int i, string s, bool b) {
                        foo = i + s;
                    });
                DoStuff(o, delegate(int i, string s, bool b) {
                        _n += i;
                    });
                DoStuffStatic(o, delegate { });
                DoStuffStatic(o, delegate { _n++; });
            }

            SomeClass s2 = new SomeClass(delegate {
               int[] numbers = new int[] { _n };
            });

            SomeClass s3 = new SomeClass(delegate {
                SomeClass s4 = new SomeClass(delegate {
                    int[] numbers = new int[] { _n * 2 };
                });
            });

            int j = 0;
            new Callback(delegate {
                this._n++;
            }).Invoke();

            new Callback(delegate {
                j++;
            })();

            new Foo(delegate(int i, string s, bool b) {
                i++;
                b = string.IsNullOrEmpty(s);
            }).Invoke(j, "foo", false);

            new Foo(delegate(int i, string s, bool b) {
                i++;
                b = string.IsNullOrEmpty(s);
            })(j, "foo", false);

            j = new Bar(delegate (int k) { 
                return k + 1; 
            }).Invoke(3);

            j = new Bar(delegate(int k) {
                return k + 1;
            })(3);
        }

        public void BBB(object o) {
            SomeClass s = new SomeClass(delegate {
                object temp = o;
            });
        }

        public void CCC(object o) {
            SomeClass s = new SomeClass(delegate {
                SomeClass s = new SomeClass(delegate {
                    int[] numbers = new int[] { _n * 2 };
                });
            });
        }

        public static void DoStuffStatic(object o, Foo callback) {
            SomeClass s = new SomeClass(delegate {
                object temp = o;
            });
        }

        public void DoStuff(object o, Foo callback) {
        }
    }
}
