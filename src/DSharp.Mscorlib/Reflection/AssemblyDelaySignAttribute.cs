using System.Runtime.CompilerServices;

namespace System.Reflection
{
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
    [ScriptIgnore]
    public sealed class AssemblyDelaySignAttribute : Attribute
    {
        public AssemblyDelaySignAttribute(bool delaySign)
        {
            DelaySign = delaySign;
        }

        public bool DelaySign { get; }
    }
}
