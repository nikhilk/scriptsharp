// ClientRectList.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Html
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// see http://www.w3.org/TR/cssom-view/#clientrectlist
    /// interface ClientRectList {
    ///   readonly attribute unsigned long length;
    ///   getter ClientRect item(unsigned long index);
    /// };
    /// </remarks>
    [IgnoreNamespace]
    [Imported]
    [ScriptName("Object")]
    public class ClientRectList : IEnumerable<ClientRect>
    {
        private ClientRectList()
        {
            
        }

        [IntrinsicProperty]
        public ulong Length
        {
            get { return 0; }
        }
        
        public ClientRect Item(ulong index)
        {
            return null;
        }

        public IEnumerator<ClientRect> GetEnumerator()
        {
            return null;
        }
    }
}
