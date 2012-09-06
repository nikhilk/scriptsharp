using System;
using System.Html;
using System.Runtime.CompilerServices;
using ScriptFX;

[assembly: ScriptAssembly("test")]
[assembly: ScriptNamespace("test")]

namespace BasicTests {

    [GlobalMethods]
    public static class GlobalMethodsClass {

        public static void Run() {
        }
    }

    public class App {

        public App() {
            AppHelper helper = new AppHelper();
            helper.ShowHelp();
        }

        public void Run() {
        }

        private void Initialize() {
        }

        void Dispose() {
        }
    }

    public delegate object MyHandler(int indexValue, string textValue);

    public enum AppFlags {

        AAA = 0,

        BBB = 1
    }

    internal class AppHelper {

        internal void ShowHelp() { }
    }

    internal interface IApp {
    }

    internal class Bar {

        public virtual void DoStuff() { }

        public override string ToString() {
            return null;
        }

        internal void ExecuteHandler(MyHandler handler) {
        }
    }

    internal class Bar2 : Bar {
    }

    internal class BarEx : Bar2 {

        public void Setup() { MyMode mode = MyMode.Numeric; }

        public override void DoStuff() {
            Setup();
            base.DoStuff();

            MyData d = new MyData("a", "b");
            d.string1 = d.string2;
        }

        internal void DoStuffInternal(int blah) {
            blah = blah + 2;
        }

        internal void DoStuffDelayed(int currentValue) {
            int numericValue = currentValue + 1;
            string stringValue = currentValue.ToString();
            int value = 0;

            ExecuteHandler(delegate (int indexValue, string textValue) {
                               ExecuteHandler(delegate (int indexValue, string textValue) {
                                                  int value = 11;
                                                  return indexValue;
                                              });
                               int value = 10;
                               int value2 = 11;
                               return numericValue + indexValue +
                                      stringValue + textValue + value;
                           });
        }

        internal int Stuff { get { return 0; } set { int x = value; } }
        
        internal int StuffProperty {
            get {
                ExecuteHandler(delegate (int indexValue, string textValue) {
                               ExecuteHandler(delegate (int indexValue, string textValue) {
                                                  int value = 11;
                                                  return indexValue;
                                              });
                               int value = 10;
                               int value2 = 11;
                               return indexValue + textValue + value;
                });
                return 0;
            }
            set {
                int numericValue = value + 1;
                string stringValue = value.ToString();

                ExecuteHandler(delegate (int indexValue, string textValue) {
                               ExecuteHandler(delegate (int indexValue, string textValue) {
                                                  int value1 = 11;
                                                  return indexValue;
                                              });
                               int value2 = 10;
                               int value3 = 11;
                               return numericValue + indexValue +
                                      stringValue + textValue + value + value3;
                });
            }
        }
    }

    [PreserveName]
    internal class BarCustom : Bar {
    }

    internal class BarCustom2 : BarCustom {

        public int Foo() { return 0; }

        [PreserveName]
        public int Baz() { return 0; }

        [PreserveName]
        private void Xyz() { }
    }

    internal enum MyMode { Alpha = 0, Numeric = 1 };

    public class FooBehavior : Behavior {

        private int _intVal;
        private int _intVal2;
        int _intVal3;

        static string _strVal;

        event EventHandler ValueChanged;

        public FooBehavior(Element e, int i) : base(e, null) {
            _intVal = i;
            _intVal2 = i * 2;
            _intVal3 = i * 4;
        }

        public override void Dispose() {
            _intVal = 0;
            base.Dispose();
        }

        void OnValueChanged() {
        }

        int this[string name] {
            get { return 0; }
        }

        string Property1 {
            get { return null; }
        }
    }

    internal class MaskTextBox : TextBox {

        public MaskTextBox(Element e) : base(e) {
        }

        private void OnValueChanged() {
        }

        void OnClicked() {
        }
    }

    internal class DerivedClass : BaseClass {

        private void DoStuffDerived() {
        }
    }

    internal class BaseClass : BaseBaseClass {

        private void DoStuffBase() {
        }
    }

    internal class BaseBaseClass {

        private void DoStuffBaseBase() {
        }
    }

    internal sealed class MyData : Record {

        public string string1;
        public string string2;

        public MyData(string a, string b) {
            string1 = a;
            string2 = b;
        }
    }

    internal class ABC {
    }
}
