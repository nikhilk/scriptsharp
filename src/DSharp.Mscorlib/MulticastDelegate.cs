using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ScriptIgnore]
    public abstract class MulticastDelegate : Delegate
    {

        protected MulticastDelegate(object target, string method)
            : base(target, method)
        {
        }

        protected MulticastDelegate(Type target, string method)
            : base(target, method)
        {
        }
    }
}
