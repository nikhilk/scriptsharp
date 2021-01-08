using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class Attribute : _Attribute
    {
        extern void _Attribute.GetIDsOfNames(ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

        extern void _Attribute.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

        extern void _Attribute.GetTypeInfoCount(out uint pcTInfo);

        extern void _Attribute.Invoke(uint dispIdMember, ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
    }
}
