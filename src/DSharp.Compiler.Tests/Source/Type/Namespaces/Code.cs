using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace TypeTests.Sub1.Sub2 {

    public class MyClass {

        public MyClass() {
            YourClass yc = new YourClass();
            yc.Run();
        }
    }
}

namespace TypeTests.Sub1 {

    public class YourClass {

        public void Run() {
        }
    }
}

namespace TypeTests {

    public class YourClass1 {
    }
}

namespace MyApp.Foo {

    public class MyClassF {
    }
}

namespace MyApp {

    using TypeTests.Sub1.Sub2;

    public class Test {

        public Test() {
            MyClass c = new MyClass();
        }
    }
}

namespace MyCompany {

    public class Utility {

        public void Run() {
        }
    }
}

namespace MyCompany.MyProduct {

    public class UtilityP {
    }
}

namespace MyCompany.MyProduct.MyComponent {

    using MyCompany;

    public class Component {

        public Component() {
            Utility u = new Utility();
            u.Run();
        }
    }
}