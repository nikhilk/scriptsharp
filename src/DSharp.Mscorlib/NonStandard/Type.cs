using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NonStandard;

namespace System
{
    public sealed partial class Type
    {
        [ScriptField]
        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern Dictionary<string, object> Prototype { get; }
    }
}
