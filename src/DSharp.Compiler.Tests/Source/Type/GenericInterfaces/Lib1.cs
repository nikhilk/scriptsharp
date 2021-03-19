using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("lib1")]

namespace Library1 {

    [ScriptImport]
    public interface IScriptImportedGenericInterface<T>
    {
    }

    public interface IReferencedGenericInterface<T>
    {
    }
}
