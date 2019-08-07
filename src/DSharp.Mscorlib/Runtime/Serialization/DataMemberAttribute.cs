using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.Runtime.Serialization
{
    [AttributeUsageAttribute(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ScriptIgnore]
    public sealed class DataMemberAttribute : Attribute
    {
        public extern bool EmitDefaultValue
        {
            get;
            set;
        }

        public extern bool IsReference
        {
            get;
            set;
        }

        public extern string Name
        {
            get;
            set;
        }

        public extern int Order
        {
            get;
            set;
        }
    }
}
