using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests
{
    public class Program : IEnumerable<int>
    {
        public void Main()
        {
            IEnumerator<int> e1 = this.GetEnumerator();
            IEnumerator e2 = ((IEnumerable)this).GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            return null;
        }

        [ScriptIgnore]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return null;
        }
    }
}
