using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("lib")]

namespace Library {

    public class ClassInLib
    {
        public ClassInLib() { }
        public static int Foo() { return 42; }
    }

    public interface InterfaceInLib
    {
        void Foo();
    }

    public enum EnumInLib
    {
        Item1,
        Item2
    }

    public struct StructInLib { int number; }

    public delegate void DelegateInLib();

    public class ConstantsInLib
    {
        public const string TEXT = "text";
        public const int NUMBER = 42;
    }
}
