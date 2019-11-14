using System;
using Library;

[assembly: ScriptAssembly("test")]

namespace BasicTests
{
    public class App : MyInterface<MyClass>
    {
        private const int number = ConstantsInLib.NUMBER;

        private MyClass field = null;
        public Array AutoProperty { get; set; }
        internal string Method(string arg1, params int[] args) { return (string)ConstantsInLib.TEXT; }
        public MyEnum this[MyStruct arg] { get { return MyEnum.Item1; } set { } }
        private Type GenericMethod<TArg>() { return typeof(TArg); }
    }

    public static class Extensions
    {
        static int ExtensionMethod(this MyClass arg) { return number; }
    }

    public class MyClass { }
    public interface MyInterface<TArg> { }
    public enum MyEnum { Item1 = 0, Item2 = 1 }
    public struct MyStruct { int number; }
}
