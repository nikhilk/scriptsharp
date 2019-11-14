using System;
using Library;

[assembly: ScriptAssembly("test")]

namespace BasicTests
{
    public class App : GenericClass<ClassInLib> { }
    public class GenericClass<T> { }
}
