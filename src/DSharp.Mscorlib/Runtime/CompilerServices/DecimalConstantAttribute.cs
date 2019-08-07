using System.ComponentModel;

namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field, Inherited = false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ScriptIgnore]
    public sealed class DecimalConstantAttribute : Attribute
    {
        public DecimalConstantAttribute(byte scale, byte sign, int hi, int mid, int low)
        {
        }

        [CLSCompliant(false)]
        public DecimalConstantAttribute(byte scale, byte sign, uint hi, uint mid, uint low)
        {
        }

        public decimal Value
        {
            get { return 0m; }
        }
    }
}
