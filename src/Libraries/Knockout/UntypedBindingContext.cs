using System.Runtime.CompilerServices;

namespace KnockoutApi
{

    [Imported]
    [IgnoreNamespace]
    public class UntypedBindingContext
    {

        [IntrinsicProperty]
        [ScriptName("$data")]
        public object Data
        {
            get;
            set;
        }

        [IntrinsicProperty]
        [ScriptName("$parent")]
        public object Parent
        {
            get;
            set;
        }

        [IntrinsicProperty]
        [ScriptName("$parents")]
        public object[] Parents
        {
            get;
            set;
        }

        [IntrinsicProperty]
        [ScriptName("$root")]
        public object[] Root
        {
            get;
            set;
        }

        [IntrinsicProperty]
        [ScriptName("$index")]
        public Observable<int> Index
        {
            get;
            set;
        }
    }
}
