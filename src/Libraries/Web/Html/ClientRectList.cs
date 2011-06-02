// ClientRectList.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Html {
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
    public sealed class ClientRectList {
        private ClientRectList() {

        }

        [IntrinsicProperty]
        public int Length {
            get { return 0; }
        }

		[IntrinsicProperty]
    	public ClientRect this[ulong index]
    	{
			get
			{
				return null;
			}
    	}

        public IEnumerator<ClientRect> GetEnumerator() {
            return null;
        }
    }
}
