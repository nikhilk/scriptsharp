// TextRectangle.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Html {
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    ///  see http://www.w3.org/TR/cssom-view/#clientrect
    /// </remarks>
    [IgnoreNamespace]
    [Imported]
    [ScriptName("Object")]
    public sealed class ClientRect {
        private ClientRect() {
        }

        [IntrinsicProperty]
        public float Top {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public float Right {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public float Bottom {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public float Left {
            get {
                return 0;
            }
        }
    }
}
