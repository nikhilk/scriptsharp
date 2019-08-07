using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.Runtime.Serialization
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, Inherited = false, AllowMultiple = false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ScriptIgnore]
    public sealed class DataContractAttribute : Attribute
    {
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

        public extern string Namespace
        {
            get;
            set;
        }
    }
}
