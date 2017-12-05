using System;
using System.Collections;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace TypeTests {

    public class App {
    
        public void Method() {
            int i = 10;
            bool b = true;
            bool? flag;
            int? num;
            Nullable<int> num2;
            Nullable<int> num3 = new Nullable<int>(100);
            Nullable<bool> xyz = false;
            char? ch;            
            
            bool hasValue = xyz.HasValue || num3.HasValue;
            int num3_ = num3.Value;
            bool f = flag.HasValue ? flag.Value : true;
            
            xyz = true;
            num2 = 10;
            num = 1;
            
            bool boolVal = flag.GetValueOrDefault();
            char textVal = ch.GetValueOrDefault();
            int numVal = num3.GetValueOrDefault();
        }
    }
}
