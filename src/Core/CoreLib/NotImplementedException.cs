using System.Runtime.CompilerServices;

namespace System
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Error")]
    public class NotImplementedException : Exception
    {
        public NotImplementedException() 
            : base(null)
        {
        }
    }
}
