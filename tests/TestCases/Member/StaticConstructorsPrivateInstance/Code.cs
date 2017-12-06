using System;
using System.Html;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace MemberTests {

    public class PrivateStaticConstructorPrivateInstanceMember
    {
        private static PrivateStaticConstructorPrivateInstanceMember source;
        private int state;

        static PrivateStaticConstructorPrivateInstanceMember()
        {
            source = new PrivateStaticConstructorPrivateInstanceMember();
            source.state = 1;
        }
    }
}
