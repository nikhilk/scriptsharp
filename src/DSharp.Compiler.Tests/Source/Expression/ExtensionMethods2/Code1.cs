using System;
using System.Runtime.CompilerServices;
using DSharp.Compiler.Tests.Source.Expression.ExtensionMethods2.Test1;

[assembly: ScriptAssembly("ExpressionTests.ExtensionMethods")]

namespace ExpressionTests
{
    public class Test1
    {
        private object value;

        public void Func()
        {
            value.Apa();
        }
    }
}
