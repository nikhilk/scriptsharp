using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Testing;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace ListTests
{

    public class PublicClass
    {

        public PublicClass()
        {
            List<string> list = new List<string>();
            list.Add("one");
            list.AddRange("two", "three");
            //Assert.Equals(3, list.Count);

            IReadOnlyList<string> readOnlyList = list.AsReadOnly();

            string[] array = list.ToArray();
            //Assert.Equals(array, list);
        }
    }
}
